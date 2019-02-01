//####################################################################################################
//Practica02
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 19/10/2018
//Fecha de entrega: 26/10/2018
//Resultados 
//•	
//
//Conclusiones
//•	
//
//Recomendación
//•	
//####################################################################################################




// Prueba la aplicación. Lanza el programa desde otro PC, puedes ver los mensajes en los dos PC?

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace Chat
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            txtNombreUsuario.Focus();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Focus();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            // Si el nombre de usuario no esta vacío 
            // creamos un nuevo cliente y enviamos en broadcast al puerto 1800 el nombre de usuario
            // y creamos un nuevo formulario con la sala de chat 

            if (!string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                UdpClient cliente = new UdpClient();
                Byte[] buferTx = Encoding.ASCII.GetBytes(txtNombreUsuario.Text + " ha entrado a la sala...");
               
                IPEndPoint sitioRemoto = new IPEndPoint(IPAddress.Broadcast, 1800);
                cliente.Send(buferTx, buferTx.Length, sitioRemoto);
                cliente.Close();
                this.Hide();
                FrmMensaje formMensaje = new FrmMensaje();
                formMensaje.nombre = txtNombreUsuario.Text;
                formMensaje.Show();
            }



        }

        private void txtNombreUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConectar_Click(sender, e);
                //btnConectar_Click();
                //Conectar();
            }
        }
    }
}
