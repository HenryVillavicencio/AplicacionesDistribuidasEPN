// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Threading;
using ObjetoRemoto;


namespace Cliente
{
    public partial class frmChat : Form
    {

        // Declaramos los atributos que se usaran para la comunicacion remota

        private Chat objetoRemoto;
        private string nombre;
        private Thread hilo;

        public frmChat()
        {
            InitializeComponent();
        }

        // Realizamos la configuración del objeto remoto de netremoting

        private void InicializarObjetoRemoto()
        {
            RemotingConfiguration.RegisterWellKnownClientType(typeof(Chat),"http://localhost:30000/Chat");
        }


        // Este método nos permiti registarnos como clientes en el chat 
        // y establecer la conexión con  la servidor de chat 
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Instaciamos un formulario de login
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                // Obetnemos el nombre de usuario ingresado en el formulario de login 
               
                this.nombre = login.NombreUsuario;

                // Definimos y registramos un canal para la comunicación 
                // Realizamos la configuración del objeto remoto 

                HttpChannel canal = new HttpChannel();
                ChannelServices.RegisterChannel(canal, false);
                InicializarObjetoRemoto();

                // Instanciamos un objeto remoto
                objetoRemoto = new Chat();
                // Agremamos nuestro usuario a la lista de clientes 
                objetoRemoto.AgregarCliente(this.nombre);

                // Creamos un hilo que se encargara de realizar el método de Poleo

                hilo = new Thread(new ThreadStart(Poleo));
                hilo.Start();
            }
            else
                MessageBox.Show("Si no proporciona un nombre de usuario no puede continuar");

        }

        // Método usado para finalizar la seción 
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // removemos el usuario de la lista de clientes conectados  
            if (objetoRemoto != null)
            {
                objetoRemoto.RemoverCliente(this.nombre);
                lstMiembros.Items.Clear();
                lstMiembros.Items.Add("No se encuentra conectado...");
                hilo.Abort();
                rtxHistorial.Clear();
            }
        }

        // Este método permite la actualizacion de la GUI  que muesta los clientes conectados 
        // Asi como los mesajes intercambiados. Este método se refresca cada segundo 

        private void Poleo()
        {
            while (true)
            {
                Thread.Sleep(1000);
                ArrayList clientes = objetoRemoto.Clientes();
                lstMiembros.Invoke(new Action(() => lstMiembros.Items.Clear()));
                foreach (string nombreCliente in clientes)
                {
                   lstMiembros.Invoke(new Action(() =>
                   lstMiembros.Items.Add(nombreCliente)));
                }
                String texto = objetoRemoto.Sesion();
                rtxHistorial.Invoke(new Action(() => rtxHistorial.Clear()));
                rtxHistorial.Invoke(new Action(() => rtxHistorial.Text = texto));
            }
        }
        // Limpia el texbox del mensjae a enviar
       
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtEnviar.Clear();

        }

        // Envia un mensaje al chat

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Agrega una cadena de texto al objeto remoto usado la sala de chat 
            
            if (objetoRemoto != null)
            {
                string texto = nombre + ": \n";
                objetoRemoto.AgregarTexto(texto + txtEnviar.Text + "\n\n");
            }
        }
    }
}
