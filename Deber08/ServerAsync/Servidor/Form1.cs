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
using Protocolo;using System.Net;using System.Net.Sockets;using System.Collections;

namespace Servidor
{
    public partial class Form1 : Form
    {
        private ArrayList listaClientes;
        private Socket socketServidor;
        private byte[] buferRx = new byte[1024];
        private delegate void DelegadoActualizarEstado(string estado);
        private DelegadoActualizarEstado delegadoActualizarEstado = null;
        public Form1()
        {
            InitializeComponent();
        }

        private struct Cliente
        {
            public EndPoint puntoExtremo;
            public string nombre;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                //se obtiene un arraylist que contiene todos los clientes
                listaClientes = new ArrayList();
                //se crea delegado para ver el estado actual del cliente 
                delegadoActualizarEstado = new DelegadoActualizarEstado(ActualizarEstado);
                // Se crea un socket para el servidor con el constructor que establece como parámetros de entrada
                //el esquema de direccionamiento IPv6, tipo de socket 
                socketServidor = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,  ProtocolType.Udp);
                //se crea un punto remoto con cualquier dirección ip, y el puerto 30000
                IPEndPoint servidorExtremo = new IPEndPoint(IPAddress.Any, 30000);
                //se en laza el socket al punto remoto
                socketServidor.Bind(servidorExtremo);
                //se crea un nuevo punto remoto para el cliente 
                IPEndPoint clienteExtremo = new IPEndPoint(IPAddress.Any, 0);
                EndPoint extremoEP = (EndPoint)clienteExtremo;
                //se comienza a recibir los datos asincrónicamente
                socketServidor.BeginReceiveFrom(buferRx, 0,  buferRx.Length, SocketFlags.None, ref extremoEP, new AsyncCallback(ProcesarRecibir), extremoEP);
                //se setea el label con el estado "escuchando"
                lblEstado.Text = "Escuchando";
            }
            catch (Exception ex)
            {
                //si existe un error se muestra en el label de estado
                lblEstado.Text = "Error";
                //se envia el mensaje del error
                MessageBox.Show("Cargando Error: " + ex.Message,
                 "Servidor UDP",
                 MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ProcesarRecibir(IAsyncResult resultadoAsync)
        {
            try
            {
                byte[] data;
                Paquete datoRecibido = new Paquete(buferRx);
                Paquete datoParaEnviar = new Paquete();
                //se crea una conexión endpoint con cualquier ip 
                IPEndPoint puntoExtremoCliente = new IPEndPoint(IPAddress.Any, 0);
                EndPoint extremoEP = (EndPoint)puntoExtremoCliente;
                //se define el socket para finalizar la lectura asincrónica desde el extremo especificado
                socketServidor.EndReceiveFrom(resultadoAsync, ref extremoEP);
                datoParaEnviar.IdentificadorChat = datoRecibido.IdentificadorChat;
                datoParaEnviar.NombreChat = datoRecibido.NombreChat;
                switch (datoRecibido.IdentificadorChat)
                {
                    case IdentificadorDato.Mensaje:
                        datoParaEnviar.MensajeChat = string.Format("{0}: {1}",
                        datoRecibido.NombreChat, datoRecibido.MensajeChat);
                        break;
                    case IdentificadorDato.Conectado:
                        Cliente nuevoCliente = new Cliente();
                        nuevoCliente.puntoExtremo = extremoEP;
                        nuevoCliente.nombre = datoRecibido.NombreChat;
                        listaClientes.Add(nuevoCliente);
                        datoParaEnviar.MensajeChat = string.Format("-- {0} está conectado --",
                       datoRecibido.NombreChat);
                        break;
                    case IdentificadorDato.Desconectado:
                        foreach (Cliente c in listaClientes)
                        {
                            if (c.puntoExtremo.Equals(extremoEP))
                            {
                                listaClientes.Remove(c);
                                break;
                            }
                        }
                        datoParaEnviar.MensajeChat = string.Format("-- {0} se ha desconectado --", datoRecibido.NombreChat);
                 break;
                }
                //se setea el arreglo de bytes obtenido para enviar
                data = datoParaEnviar.ObtenerArregloBytes();
                foreach (Cliente clienteEnLista in listaClientes)
                {
                    if (clienteEnLista.puntoExtremo != extremoEP ||
                    datoParaEnviar.IdentificadorChat != IdentificadorDato.Conectado)
                    {
                        socketServidor.BeginSendTo(data, 0, data.Length, SocketFlags.None,
                        clienteEnLista.puntoExtremo, new
                        AsyncCallback(ProcesarEnviar),
                        clienteEnLista.puntoExtremo);
                    }
                }
                //comienza a recibir los datos asincrónicamente
                socketServidor.BeginReceiveFrom(buferRx, 0, buferRx.Length, SocketFlags.None,
                 ref extremoEP, new AsyncCallback(ProcesarRecibir), extremoEP);
                Invoke(delegadoActualizarEstado, new object[] { datoParaEnviar.MensajeChat });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la recepción: " + ex.Message,
                 "Servidor UDP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        public void ProcesarEnviar(IAsyncResult resultadoAsync)
        {
            try
            {
                socketServidor.EndSend(resultadoAsync);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar datos: " + ex.Message,
                 "Servidor UDP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            //se cierra la conexión, se cierra la ventana
            socketServidor.Close();
            Close();
        }

        private void ActualizarEstado(string estado)
        {
            rxtInformacion.Text += estado + Environment.NewLine;
        }
    }
}
