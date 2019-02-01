//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################
// ¿El servidor es capaz de manejar a estos tres clientes?// si, el servidor está en la capacidad de manejar 3 clientes, puesto que para cada conexión con cada // cliente se crea un hilo específico, lo cual permite evitar un bloqueo, permitiendo que se pueda // extablecer conexión con múltiples clientes.//Resultados:// El programa crea una clase que permita el manejo de múltiples clientes, mediante hilos,
// a cada cliente se le asignará un hilo diferente, por lo que el servidor podrá recibir multiples 
// solicitudes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerHilosIPv4
{

    class Program
    {
        //se instancia el socket para escuchar, usando el constructor que tiene como 
        //parámetros de entrada esquema de direccionamiento IPv4, tipo de socket de flujo de bytes bidireccional confiable , y tipo de protocolo,
        Socket socketEscucha = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //Socket cliente
        Socket socketCliente;


        static void Main(string[] args)
        { //consola se muestra permanentemente
            new Program();
            Console.Read();
        }

        public Program() {
            //se busca recuperar el nombre del dominio del cliente
            IPAddress[] direccionesIP = Dns.GetHostAddresses(Dns.GetHostName());
            //Se almacena las direcciones ip servidor
            IPAddress direccionServidor = direccionesIP[0];
            Console.WriteLine("Direcciones IP: ");
            //Se recorre el array de direcciones ip
            foreach (IPAddress ip in direccionesIP)
            { //se imprimen la direcciones ip en el array
                Console.WriteLine(" * {0}", ip);
                //se condiciona si las direcciones ip se encuentran en esquema de direccionamiento
                //IPv4
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    //se condiciona si la dirección es diferente de 127.0.0.1
                    if (!ip.Equals("127.0.0.1"))
                    {
                        //se setea la dirección ip del servidor y se imprime por consola junto con el puerto.
                        direccionServidor = ip;
                        Console.WriteLine("El servidor está escuchando en la dirección: {0} puerto: 8080", ip);
                    }
                }
            }

            //se almacena en un punto remoto la dirección ip del servidor y el puerto de escucha
            IPEndPoint ipServidor = new IPEndPoint(direccionServidor, 8080);
            //se enlaza el socket al punto remoto
            socketEscucha.Bind(ipServidor);
            //se notifica por consola
            Console.WriteLine("El servidor enlazó el socket...");
            // se crea un hiloEscucha para las conexiones disponibles
            Thread hiloEscucha = new Thread(new ThreadStart(Escuchar));
            //hiloEscucha ennsegundo plano
            hiloEscucha.IsBackground = true;
            //Se inicia la acción del hilo
            hiloEscucha.Start();

        }
        private void Escuchar() {
            //lazo para que se escuche permanente
            while (true)
            {
                //se escucha en función de recursos del sistema
                socketEscucha.Listen(-1);
                Console.WriteLine("El servidor entrá en espera de conexiones...");
                //se acepta la conexión 
                socketCliente = socketEscucha.Accept();
                Console.WriteLine("El servidor ha recibido a un cliente...");
                //se condiciona si existe un cliente conectado
                if (socketCliente.Connected)
                {
                    //se crea un nuevo hilo encargado de ejecutar el método recibir 
                    Thread hiloCliente = new Thread(new ThreadStart(Recibir));
                    hiloCliente.IsBackground = true;
                    //Empieza a ejecutarse el hiloCliente
                    hiloCliente.Start();
                }


            }
        }
        private void Recibir()
        {
            // Se crea un socket con esquema de direccionamiento IPv6, tipo de socket de flujo bidireccional 
            //  y protocolo TCP 
            Socket socketC = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            // se bloqueo el recurso, según requerimientos
            lock (this)
            {
                //asociamos el socket al socket del cliente
                socketC = socketCliente;
            }
            Console.WriteLine("Recibiendo datos...");
            //lazo permanente para cuando el socket está conectado
            while (true)
            {
                //variable para llevar control de bytes recibidos
                int cantidadBytesRecibidos = 0;
                //se define un tamaño de 2 bytes
                byte[] bytesRecibidos = new byte[2];
                try
                {
                    //se setea la cantidad de bytes recibidos, si es diferente de cero
                    //se muestra los datos decodificados en consola
                    cantidadBytesRecibidos = socketC.Receive(bytesRecibidos);
                    if (cantidadBytesRecibidos != 0)
                    {

                        Console.WriteLine(Encoding.ASCII.GetString(bytesRecibidos));
                    }
                }
                //Control de excepciones
                catch (Exception ex)
                {
                    // se muestra por consola el mensaje de error
                    Console.WriteLine("Error: " + ex);
                }
                //se condiciona si el socket no está conectado se rompe el lazo
                if (!socketC.Connected)
                    break;
            }


        }


    }
}
