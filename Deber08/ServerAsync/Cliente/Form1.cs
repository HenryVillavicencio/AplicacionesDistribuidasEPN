//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocolo;

namespace Cliente
{
    public partial class Form1 : Form
    {
        private Socket socketCliente;
        private string nombre;
        private EndPoint epServidor;
        private byte[] buferRx = new byte[1024];
        private delegate void DelegadoMensajeActualizacion(string mensaje);
        private DelegadoMensajeActualizacion delegadoActualizacion = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            delegadoActualizacion = new DelegadoMensajeActualizacion(DesplegarMensaje);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creación del paquete a enviarse al servidor, obtención de los bytes del paquete
                Paquete paqueteParaEnviar = new Paquete();
                paqueteParaEnviar.NombreChat = nombre;
                paqueteParaEnviar.MensajeChat = txtEnviar.Text.Trim();
                paqueteParaEnviar.IdentificadorChat = IdentificadorDato.Mensaje;
                byte[] arregloBytes = paqueteParaEnviar.ObtenerArregloBytes();
                //socket para envío
                socketCliente.BeginSendTo(arregloBytes, 0, arregloBytes.Length, SocketFlags.None, epServidor,
                new AsyncCallback(ProcesarEnviar), null);
                txtEnviar.Text = string.Empty;
            }
            catch (Exception ex)
            {
                //en caso de error muestra el mensaje
                MessageBox.Show("Error al enviar: " + ex.Message,  "Cliente UDP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                //seteo en la variable el nombre ingresado
                nombre = txtNombre.Text.Trim();
                //se crean los paquetes iniciales 
                Paquete paqueteInicio = new Paquete();
                paqueteInicio.NombreChat = nombre;
                paqueteInicio.MensajeChat = null;
                paqueteInicio.IdentificadorChat = IdentificadorDato.Conectado;
                //se instancia socket, con el constructor que acepta como parámetros de entrada el esquema de
                //direccionamiento, el tipo de socket, y el tipo de protocolo que en este caso es udp
                socketCliente = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
                //se setea la dirección ip del servidor
                IPAddress servidorIP = IPAddress.Parse(txtServidor.Text.Trim());
                //se crea un punto remoto con la dirección ip del servidor y el puerto de escucha
                IPEndPoint puntoRemoto = new IPEndPoint(servidorIP, 30000);
                epServidor = (EndPoint)puntoRemoto;
                //se obtiene el arreglo de bytes de paquete inicial 
                byte[] buferTx = paqueteInicio.ObtenerArregloBytes();
                //socket para envío de datos
                socketCliente.BeginSendTo(buferTx, 0, buferTx.Length, SocketFlags.None, epServidor, new
                //delegado al método ProcesarEnviar cuando se intenta la conexión
                AsyncCallback(ProcesarEnviar), null);
                //se setea el tamaño del buffer de recepción
                buferRx = new byte[1024];
                //se recibe asincrónicamente los datos
                socketCliente.BeginReceiveFrom(buferRx, 0, buferRx.Length, SocketFlags.None, ref epServidor, new
                //se hace referencia al método ProcesarRecibir cuando finalice la entrega asincrónica 
                    AsyncCallback(this.ProcesarRecibir), null);
            }
            catch (Exception ex)
            {
                //si se presenta un error se muestra por consola
                MessageBox.Show("Error al conectarse: " + ex.Message, "Cliente UDP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void ProcesarEnviar(IAsyncResult res)
        {
            try
            {
                socketCliente.EndSend(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enviar Datos: " + ex.Message,
                 "Cliente UDP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }        private void ProcesarRecibir(IAsyncResult res)
        {
            try
            {
                socketCliente.EndReceive(res);
                Paquete paqueteRecibido = new Paquete(buferRx);
                if (paqueteRecibido.MensajeChat != null)
                    Invoke(delegadoActualizacion, new object[] { paqueteRecibido.MensajeChat });
                buferRx = new byte[1024];
                socketCliente.BeginReceiveFrom(buferRx, 0, buferRx.Length, SocketFlags.None, ref
                 epServidor, new AsyncCallback(ProcesarRecibir), null);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show("Datos Recibidos: " + ex.Message,
                 "Cliente UDP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }        private void DesplegarMensaje(string mensaje)
        {
            rxtMensajes.Text += mensaje + Environment.NewLine;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.socketCliente != null)
                {
                    //se crea el paquete de salida 
                    Paquete paqueteSalida = new Paquete();
                    paqueteSalida.IdentificadorChat = IdentificadorDato.Desconectado;
                    paqueteSalida.NombreChat = nombre;
                    paqueteSalida.MensajeChat = null;
                    //se obtiene el arreglo de bytes de dicho paquete 
                    byte[] buferTx = paqueteSalida.ObtenerArregloBytes();
                    socketCliente.SendTo(buferTx, 0, buferTx.Length, SocketFlags.None,
                     epServidor);
                    socketCliente.Close();
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error al desconectar: " + ex.Message, "Cliente UDP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
