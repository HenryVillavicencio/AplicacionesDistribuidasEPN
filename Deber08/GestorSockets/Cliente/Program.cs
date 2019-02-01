//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################
// Resultados:
// www.google.com  la primera ip que devuelve nuestro programa al resolver el nombre esta en formato IPV6 que no es un formato adecudo para
// las sigueintes pruebas que realiza nuestro nuestro programa. Para poder realizar las pruebas con este servidor realizamos la peticion con 
// con la ayuda del comando nslookup realizamos la resolucion de nombres, escogemos una que se encuentre en el formato de IPv4 
// remplazamos en lugar del nombre volvemos a ejecutar, obtiendose los resultados esperados de la petición get.
// www.epn.edu.ec Se realiza con exito la resolución de nombres y la conexión, sib embargo  no se obtien resultados de la petición get, debido 
// a que el host remoto bloquea la conexión 
// Los resultados  conexión y petición get fueron exitos en los siguientes sitios de prueba:
// 1. www.facebok.com,(157.240.14.35) ingresando la ip devuelta por el comando nslookup y obviando la resolución de nombres de nuestro programa
// 2. www.github.com 
// 3. www.youtube.com,(216.58.219.78) ingresando la ip devuelta por el comando nslookup y obviando la resolución de nombres de nuestro programa
// 4. docs.microsoft.com
// 5. educacionvirtual.epn.edu.ec


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

namespace Cliente
{
    static class Program
    {



        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // modificamos el metodo main de tal manera que al instaciar 
            // el nuevo objeto gestor, obtenemos la referencia a su formulario
            // y guardamos esta información en los logs antes de lanzar el formulario.

            ConexionCliente gestor = new ConexionCliente(new frmCliente());
            ((frmCliente)gestor.ObtenerVista()).EstablecerGestorCliente(gestor);
            gestor.EspecificarLog(((frmCliente)gestor.ObtenerVista()).ManejoLog);
            Application.Run(gestor.ObtenerVista());

            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frmCliente());
        }
    }

    // Definimos un conjunto de constantes que nos ayudaran a llevar  e identificar el estado de la 
    //conexión. Los distintos valores  hacen referencia a si la conexión se realizo corretamente, 
    // o trata de indentificar. Ejemplo 4 la red a la que se quiere tener conexión no es  alcanzable.
    public enum estadoConexion
    {
        ok = 0,
        problemaDns = 1,
        problemaConSocket = 2,
        problemaConDns_y_Socket = 3,
        errorDeRedOInalcanzable = 4
    }    // Definimos una clase que nos ayudara a manejar las conexiones. Esta almacenará la ip y puerto del    // servidor al que deseemos conectanos, a si como la ip y puerto locales del cliento. Además, contiente     // el formulario que contiene la GUI con la que iteractuara el usuario.    public class ConexionCliente
    {
        IPAddress direccionServidor;
        int puerto = 0;
        IPEndPoint sitioRemoto;
        TcpClient cliente;
        Form formularioCliente = null;
        ManejoLog log;

        // Costructor de la clase. Usado para instanciar el formulario con el que iteractuara el usuario
        // esto permite tener una referencia hacia este obejo, de tal forma que podamos manejar sus datos.  
        public ConexionCliente(Form formularioCliente)
        {
            this.formularioCliente = formularioCliente;
        }
        // Destructor que cierra  la connexión del cliente, si esque existe un cliente instanciado.
        ~ConexionCliente()
        {
            if (cliente != null)
            {
                if (cliente.Connected)
                    cliente.Close();
            }
        }

        public void EspecificarLog(ManejoLog log)
        {
            this.log = log;
        }
        // Obtiene un stack frame que contiene  la información de estado de la subrutina activa 
        // en este caso obtiene el nombre del método y lo guarda en los logs
        public void Traza(string msg)
        {
            StackTrace traza = new StackTrace(false);
            string metodoUsado = traza.GetFrame(1).GetMethod().Name;
            log(metodoUsado + " : " + msg + "\r\n");
        }

        // Devuelve la referencia al formulario 
        public Form ObtenerVista()
        {
            return formularioCliente;
        }
        // recupera el estado de la conexión de acuero a su estatus
        private estadoConexion ObtenerError(estadoConexion actual, estadoConexion siguiente)
        {
            Traza("Error Detectado");
            if (actual == estadoConexion.ok)
                return siguiente;
            if (actual == estadoConexion.problemaDns)
            {
                if (siguiente == estadoConexion.problemaConSocket)
                {
                    return estadoConexion.problemaConDns_y_Socket;
                }
                else
                {
                    return siguiente;
                }
            }
            return siguiente;
        }

        
        // Retorna el estado de conexión
        public String ObtenerResultadoPruebaConexion()
        {
            return PruebaConexion().ToString();
        }
        // Prueba la conexión
        private estadoConexion PruebaConexion()
        {
            // Guarda en los logs la prueba de conexión
            Traza("Prueba de Conexión de Cliente");

            // Define variables en la se almacenaran el nombre y puerto de los servidores 
            //con los que se probara la conexión haciendo una petición del index.html al servidor 
            estadoConexion resultado = estadoConexion.ok;
            String testHttp = "GET /index.html HTTP/1.0\n\n";
            String httpDoc = null;
            int cantRecibida = 0;
            Byte[] bytesParaEnviar = Encoding.ASCII.GetBytes(testHttp);
            Byte[] bytesParaRecibir = new Byte[1024];
            string nombre = "";
            IPAddress IPPrueba = null;
            IPEndPoint extremoPrueba = null;
            TcpClient clientePrueba = null;

            // Intenta resolver el nombre  www.epn.edu.ec y hace la conexion a su servidor.
            // de página web
            try
            {
                IPPrueba = Dns.GetHostEntry("www.epn.edu.ec").AddressList[0];
                extremoPrueba = new IPEndPoint(IPPrueba, 80);
            }
            catch (Exception ex)
            {
                Traza("Parece que el DNS no funciona...");
                resultado = ObtenerError(resultado, estadoConexion.problemaDns);
            }

            // Intenta obtener el nombre asociado a la IP: 163.117.139.128 
            try
            {
                nombre = ((IPHostEntry)Dns.GetHostEntry("163.117.139.128")).HostName;
                clientePrueba = new TcpClient();
            }
            catch (Exception ex)
            {
                Traza("Problemas con los sockets...");
                return ObtenerError(resultado, estadoConexion.problemaConSocket);
            }

            //Intenta contectarse al servidor de la EPN y solicitar su pagina web.

            try
            {
                clientePrueba.Connect(extremoPrueba);
                NetworkStream flujo = clientePrueba.GetStream();
                flujo.Write(bytesParaEnviar, 0, bytesParaEnviar.Length);
                cantRecibida = flujo.Read(bytesParaRecibir, 0, bytesParaRecibir.Length);
            }
            catch (Exception ex)
            {
                Traza("Error en la conexión...");
                return ObtenerError(resultado, estadoConexion.errorDeRedOInalcanzable);
            }
            // Decodifica los datos recibidos desde el resivor
            httpDoc = Encoding.ASCII.GetString(bytesParaRecibir, 0, cantRecibida);
            Traza("Prueba finalizada");
            // Retorna el estado con el que se realizó la prueba
            return resultado;
        }
        // Resuleve el nombre del servidor al que se desea conectar e instancia la dirrección IP
        public void EspecificarServidor(String direccionIP)
        {
            direccionServidor = Dns.GetHostEntry(direccionIP).AddressList[0];
        }
        // Instacia el puerto al que se desea conectar y lo pasa a un dato de tipo entero 
        public void EspecificarPuertoServidor(String puerto)
        {
            int resultado = 0;
            try
            {
                int.TryParse(puerto, out resultado);
                this.puerto = resultado;
            }
            catch (Exception ex)
            {
                Traza("Está correcto el puerto?");
            }
        }
        // Resuleve el nombre del servidor al que se desea conectar y devuelve su  dirrección IP

        public IPAddress ObtenerDireccionIP(String nombreEquipo)
        {
            return Dns.GetHostEntry(nombreEquipo).AddressList[0];
        }

        // Método utilizado para conectarse con el servidor

        public void Conectar()
        {
            try
            {
                // Si el socket tiene una conexion activa la cierra
                if (cliente != null)
                {
                    if (cliente.Connected)
                    {
                        Traza("Cerrando conexiones...");
                        cliente.Client.Disconnect(true);
                    }
                }


                // Definimos el punto remoto e intemamos hacer la peticion connect con este 
                Traza("Creando un endpoint...");
                sitioRemoto = new IPEndPoint(direccionServidor, puerto);
                Traza("Creando el socket...");
                cliente = new TcpClient();
                Traza("Conectando...");
                cliente.Connect(sitioRemoto);

            }
            catch (Exception ex)
            {
                Traza("Error en la conexión" + ex.Message);
            }
        }
        // Método usado para intentar enviar y recibir datos del flujo de la conexión
        public int EnviarRecibir(byte[] buferTx, ref byte[] buferRx)
        {
            try
            {
                int bytes_obtenidos = 0;
                // Obtine el flujo de la conexión 
                NetworkStream flujo = cliente.GetStream();
                // escribe la peticion en el flujo y recupera la respuesta desde el servidor
                flujo.Write(buferTx, 0, buferTx.Length);
                bytes_obtenidos = flujo.Read(buferRx, 0, buferRx.Length);
                // retorna los datos recuperados 
                return bytes_obtenidos;
            }
            catch (SocketException sExec)
            {
                Traza("Error: " + sExec.Message);
            }
            return 0;
        }

    }
}
