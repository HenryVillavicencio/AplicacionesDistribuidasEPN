//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################
// ¿El servidor es capaz de manejar a estos tres clientes?// Si, se puede manejar 3 clientes, puesto que para cada conexión con cada cliente  se crea un // hilo específico, lo cual permite evitar un bloqueo, permitiendo que se pueda extablecer // conexión con múltiples clientes.//Resultados:// El programa crea una clase que permita el manejo de múltiples clientes, mediante hilos,
// a cada cliente se le asignará un hilo diferente, por lo que el servidor podrá recibir multiples 
// solicitudes, en este caso se maneja esquema de direccionamiento IPv6


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHilosv6
{

    class Program
    {
        // Se crea un socket para escucha con el constructor que acepta como parámetros de entrada el esquema de direccionamiento IPv6, tipo flujo bidireccional 
        // de datos y protocolo TCP 
        Socket socketEscucha = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
        //socket cliente
        Socket socketCliente;

        public Program()
        {
            //Se busca conectar mediante nombre de dominio y puerto
            IPAddress[] direccionesIP = Dns.GetHostAddresses(Dns.GetHostName());
            //Se almacena las direcciones ip del servidor
            IPAddress direccionServidor = direccionesIP[0];
            Console.WriteLine("Direcciones IP: ");
            //se recorre el array de direcciones, imprimiendo cada una por consola
            foreach (IPAddress ip in direccionesIP)
            {
                Console.WriteLine(" * {0}", ip);
                //se condiciona si las direcciones están en esquema de direccionamiento IPv6
                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    //se condiciona si la dirección no coincide con la dirección local
                    if (ip.IsIPv6LinkLocal == false)
                    {
                        //se setea la dirección ip del servidor y se la imprime por pantalla junto con el puerto
                        direccionServidor = ip;
                        Console.WriteLine("El servidor está escuchando en la dirección: {0} puerto: 8080", ip);
                    }
                }
            }
            // se instancia un punto remoto con la dirección ip del servidor y el puerto
            IPEndPoint ipServidor = new IPEndPoint(direccionServidor, 8080);
            //se enlaza el punto remoto al socketEscucha
            socketEscucha.Bind(ipServidor);
            Console.WriteLine("El servidor enlazó el socket...");
            //se crea hiloEscucha para cuando se acepta una conexión, se lo pone en segundo plano y se inicializa el hilo
            Thread hiloEscucha = new Thread(new ThreadStart(Escuchar));
            hiloEscucha.IsBackground = true;
            hiloEscucha.Start();
        }

        static void Main(string[] args)
        {
            //la consola se muestra permanentemente
            new Program();
            Console.Read();
        }

        private void Escuchar() {
            //lazo para escucha permanente 
            while (true)
            {
                //escucha solicitudes de clientes 
                socketEscucha.Listen(-1);
                Console.WriteLine("El servidor entra en espera de conexiones...");
                //se acepta una conexión y se notifica por consola
                socketCliente = socketEscucha.Accept();
                Console.WriteLine("El servidor ha recibido a un cliente...");
                //se condiciona si el cliente está conectado
                if (socketCliente.Connected)
                {
                    //se crea un nuevo hilo que ejecutará las tareas del método recibir,
                    //se inicializa el hilo.
                    Thread hiloCliente = new Thread(new ThreadStart(Recibir));
                    hiloCliente.IsBackground = true;
                    hiloCliente.Start();
                }
            }



        }

        private void Recibir (){
            // Se crea un socket con el constructor que acepta como parámetros de entrada  el esquema de direccionamiento IPv6, tipo de socket de flujo bidireccional 
            // y tipo de protocolo
            Socket socketC = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            //bloqueo el recurso según requerimientos
            lock (this)
        {
                //asocio el nuevo socket al socket del cliente
            socketC = socketCliente;
        }
        Console.WriteLine("Recibiendo datos...");
            //lazo permanente que se ejecuta cuando el socket este conectado
        while (true)
        {
        //variable que lleva el control de la cantidad de bytes recibidos
        int cantidadBytesRecibidos = 0;
        // se setea un buffer de dos bytes
        byte[] bytesRecibidos = new byte[2];
        try
        {
        //se almacena la cantidad de bytes recibidos
        cantidadBytesRecibidos = socketC.Receive(bytesRecibidos);
        // se condiciona si la cantidad de bytes recbidos es diferente de cero
         if (cantidadBytesRecibidos != 0)
         {
         //entonces se decodifica y se muestra por consola lo recibido
        Console.WriteLine(Encoding.ASCII.GetString(bytesRecibidos));
         }
         }
        //control de excepciones
        catch (Exception ex)
        {

        //se muestra por consola la excepción
        Console.WriteLine("Error: " + ex);
        }
        //se condiciona si el socket no está conectado se rompe el lazo
         if (!socketC.Connected)
        break;
        }

        
        }

}
}
