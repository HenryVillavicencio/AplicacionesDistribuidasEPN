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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public delegate void ManejoLog(string msg);

namespace Cliente
{

    public partial class frmCliente : Form
    {
        ConexionCliente gestorCliente = null;
        byte[] bufferTx;
        byte[] bufferRx = new byte[2048];

        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        // Pasamos por referencia la instanciamos el obejto usado para la conexión 
        public void EstablecerGestorCliente(ConexionCliente gestor)
        {
            this.gestorCliente = gestor;
        }

        // Concatenamos el mensaje de log 
        public void ManejoLog(string msg)
        {
            txtLog.AppendText(msg);
        }
        //cambia el label estado del formulario de acuerdo al resultado de la prueba de conexión realizada
        private void btnProbar_Click(object sender, EventArgs e)
        {
            lblEstado.Text = gestorCliente.ObtenerResultadoPruebaConexion();
        }

        private void btnActualizarBinario_Click(object sender, EventArgs e)
        {

            bufferTx = null;
            txtBinarioEnviar.Text = "";
            String datosAEnviar = "";
            //int posicion = -1;
            // Verifica si el contenido del textbox a eviar es direferente de nulo y si su formato 
            // de entrada es hexadecimal o texto 
            if (chkTexto.Checked && txtTextoAEnviar.Text.Length != 0)
            {
                // Si los datos de entrada se encuentran con puestos de varias lineas separada por un enter
                // se remplaza por la linea por los caracters \n de tal forma que pueda ser enviada.
                if (txtTextoAEnviar.Text.IndexOf("\\n") != -1)
                {
                    String[] subs = txtTextoAEnviar.Text.Split(new String[] { "\\n" },StringSplitOptions.None);
                    for (int i = 0; i < subs.Length; i++)
                    {
                        if (subs[i].Equals(""))
                            datosAEnviar += "\n";
                        else
                            datosAEnviar += subs[i];
                    }
                }
                else
                    datosAEnviar = txtTextoAEnviar.Text;
                // Se codifican a asci los datos a ser enviados 
                bufferTx = Encoding.ASCII.GetBytes(datosAEnviar);
            }
            else
            {

                // Si los datos se encuentran en hexadecimal estos deben ser mayor a dos digitos de tal forma de 
                // formar almenos un byte para ser enviado
                if (txtTextoAEnviar.Text.Length >= 2)
                {
                    string delimitador = " ";
                    byte resultado = 0x00;
                    char[] numero;
                    string[] cadenaDeDatos = txtTextoAEnviar.Text.Split(delimitador.ToCharArray());
                    bufferTx = new byte[cadenaDeDatos.Length];
                    // Intenta concatenar todos los caracteres separados por un espacio de tal manera que puedan 
                    // ser enviados 
                    for (int i = 0; i < cadenaDeDatos.Length; i++)
                    {
                        try
                        {
                            numero = cadenaDeDatos[i].ToCharArray();
                            if (numero.Length != 2)
                                throw new Exception("");
                            byte.TryParse(numero[0].ToString(), out resultado);
                            bufferTx[i] = (byte)(resultado << 4);
                            byte.TryParse(numero[1].ToString(), out resultado);
                            bufferTx[i] |= (byte)resultado;
                        }
                        catch (Exception ex)
                        {
                            gestorCliente.Traza("Hay un error en el formato, recuerda: si es binario, debes escribir, 12 34 AB, siendo estos numeros hexadecimales");
                        }
                    }
                }
            }

            // Si el buffer a enviar es diferente de nulo conbierte a hexadecimal al Textbox binario enviar 
            // de tal manera que el usuarios pueda apreciar de forma grafica cuantos bytes se han enviado. 
            if (bufferTx != null)
                for (int i = 0; i < bufferTx.Length; i++)
                {
                    txtBinarioEnviar.AppendText(bufferTx[i].ToString("x") + " ");
                }


        }

        // Obtiene la dirección del servidor al que deseamos conectarnos y lo pressenta en la GUI en el textbox ip servidor
        private void btnResolver_Click(object sender, EventArgs e)
        {
            if (txtServidor.Text.Length > 0)
            {
                txtIPServidor.Text = gestorCliente.ObtenerDireccionIP(txtServidor.Text).ToString();
            }
            else
                gestorCliente.Traza("Por favor incluye el nombre del servidor");
        }
        // Recupera la IP y puerto del servidor e intenta conectarse al el 
        // de no lograr la conexi;on se lanza una exepción y se lo guarda en los logs
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIPServidor.Text.Length != 0 && txtServidor.Text.Length != 0 && txtPuerto.Text.Length
                != 0)
                {
                    gestorCliente.EspecificarServidor(txtServidor.Text);
                    gestorCliente.EspecificarPuertoServidor(txtPuerto.Text);
                    gestorCliente.Conectar();
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                gestorCliente.Traza("Por favor comprueba la dirección IP o el nombre de servidor");
            }
        }

        // Envia los datos del texbox  y presenta los datos recibidos del servidor 
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int recibidos = gestorCliente.EnviarRecibir(bufferTx, ref bufferRx);
            gestorCliente.Traza("Recibidos: " + recibidos + " bytes");
            txtRecibidoBinario.Text = "";
            // Convierte a hexadecimal los datos recibidos y los muestra en el  texbox recibido binario 
            for (int i = 0; i < recibidos; i++)
            {
                txtRecibidoBinario.AppendText(bufferRx[i].ToString("X"));
            }
            String respuesta = Encoding.ASCII.GetString(bufferRx, 0, recibidos);
            txtRespuesta.Text = "";
            txtRespuesta.AppendText(respuesta);
        }
    }
}
