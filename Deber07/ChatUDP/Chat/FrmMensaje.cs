//####################################################################################################
//Practica02
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 19/10/2018
//Fecha de entrega: 26/10/2018
//####################################################################################################


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    public partial class FrmMensaje : Form
    {

        public string nombre;
        // Inicializamos una nueva instancia de la clase UdpClient y la enlazamos 
        // con el número de puerto 1800 local especificado.

        UdpClient cliente = new UdpClient(1800);
        // Creamos un Endpoint en el cual almacenaremos posteriormente la ip
        // y puerto del sitio remoto
        IPEndPoint sitioRemoto = new IPEndPoint(IPAddress.Any, 0);

        public FrmMensaje()
        {
            InitializeComponent();
        }

        private void FrmMensaje_Load(object sender, EventArgs e)
        {

            // imprimos por pantalla por el nombre de la persona que se ha unido a 
            // la sala, y creamos un hilo el cual nos ayudara a manejar la recepción de 
            // mensajes de cada uno  de los clientes unidos a la sala

            txtMensaje.Text = nombre + " se ha unido a la sala...";
            Thread hiloTrabajador = new Thread(RecepcionMensajes);
            hiloTrabajador.Start();
            txtMensajeParaEnviar.Focus();

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Al presionar clic sobre el boton enviar 
            // Si existen datos en el textbox, concatemamos los
            // datos al nombre del cliente que los genero, luego de 
            // esto, son enviados.

            if (!string.IsNullOrEmpty(txtMensajeParaEnviar.Text))
            {
                string datos = nombre + " dice >> " + txtMensajeParaEnviar.Text;
                EnviarMensaje(datos);
            }
        }

        private void txtMensaje_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        
        private void txtMensajeParaEnviar_KeyDown(object sender, KeyEventArgs e)
        {
            // Al presionar la tecla Enter sobre el texbox Mensajeparaenviar 
            // Si existen datos en el textbox, concatemamos los
            // datos al nombre del cliente que los genero, luego de 
            // esto son enviados.

            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtMensajeParaEnviar.Text))
                {
                    string datos = nombre + " dice >> " + txtMensajeParaEnviar.Text;
                    EnviarMensaje(datos);
                }
            }
        }

        // Cuando cerramos el formulario, cerramos el socket creado para la comunicación 
        private void FrmMensaje_FormClosing(object sender, FormClosingEventArgs e)
        {
            string datos = nombre + " ha salido...";
            EnviarMensaje(datos);
        }

        

        private void RecepcionMensajes()
        {
             
            try
            {
                // En caso de que  se ejecute este método sin ningun error
                // este se repite hasta que el usuario remoto se desconecte de la sala
                // Una vez enviado el nombre se aborta el hilo

                
                while (true)
                {
                    Byte[] buferRx = cliente.Receive(ref sitioRemoto);
                    string mensaje = Encoding.ASCII.GetString(buferRx);
                    if (mensaje == nombre + " ha salido...")
                    {
                        break;
                    }
                    else
                    {
                        // Si el mensaje es enviado por el nombre de usuario con el cual 
                        // se ingreso al chat se remplaza la palabra "dice" por "yo":
                        // ya que se supone que fué el usuario quien generó ese mensaje 

                        if (mensaje.Contains(nombre + " dice >> "))
                        {
                            mensaje = mensaje.Replace(nombre + " dice >> ", "Yo: >> ");
                        }

                        // Llamamos el método que nos permite presentar el contenido en pantalla
                        PresentarMensaje(mensaje);
                    }
                }
                Thread.CurrentThread.Abort();
                Application.Exit();
            }
            catch (ThreadAbortException ex)
            {
                Application.Exit();
            }
        }

        private void EnviarMensaje(string datos)
        {
            // creamos una instancia de udp client con la cuál enviaremos los datos en 
            // broadcast al puerto 1800

            UdpClient envio = new UdpClient();
            Byte[] mensaje = Encoding.ASCII.GetBytes(datos);
            IPEndPoint remoto = new IPEndPoint(IPAddress.Broadcast, 1800);
            envio.Send(mensaje, mensaje.Length, remoto);
            envio.Close();
            // Limpiamos el textbox una vez enviado el mensaje
            txtMensajeParaEnviar.Clear();
            txtMensajeParaEnviar.Focus();
        }
        private void PresentarMensaje(string mensaje)
        {
            // Invoke nos permite realizar el control para la actualización del UI
            // ejecuta un delegado en el subproceso de la ventana 

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate () { PresentarMensaje(mensaje); }));
            else
            {
                // Concatemaos los mensajes para que se presenten todos en pantalla
                // como un chat 
                txtMensaje.Text = txtMensaje.Text + Environment.NewLine + mensaje;
                txtMensaje.SelectionStart = txtMensaje.TextLength;
                txtMensaje.ScrollToCaret();
                txtMensaje.Refresh();
            }
        }

    }
}
