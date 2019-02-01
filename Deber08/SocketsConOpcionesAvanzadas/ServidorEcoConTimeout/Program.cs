//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace ServidorEcoConTimeout
{
    class Program
    {
        // definimos el tamaño del buffer, la cantidad de clientes a la cola para ser
        //atendidos por el servidor.
        private const int TAM_BUFFER = 32;
        private const int TAM_COLA = 5;
        

         private const int LIMITE_ESPERA = 10000;

        
        static void Main(string[] args)
        {
            // se define el puerto en el que el servidor escuchará, y se crea el socket
            // que será utilizado por el servidor.
    
            int puerto = 8082;
            Socket servidor = null;
            // se empieza el control de excepciones
            try
            {
                 // Instanciamos el socket para el servidor empleando el constructor en el que se especifica
                 // el esquema de dirección, el tipo del socket, y el tipo de protocolo.
                 servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
                //Procedemos a enlazar el socket con puntos remotos que contengan cualquier dirección ip y el
                //y el puerto especificado
                servidor.Bind(new IPEndPoint(IPAddress.Any, puerto));
                // empieza el proceso de escucha, enviando como parámetro de entrada el tamaño de clientes que 
                //podrán estar en cola.
                servidor.Listen(TAM_COLA);
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                Environment.Exit(se.ErrorCode);
            }
            // se define el tamaño del buffer, la cantidad de bytes recibidos y enviados
            byte[] buferRx = new byte[TAM_BUFFER];
            int cantBytesRecibidos;
            int totalBytesEnviados = 0;
            // se realiza un lazo para que el servidor se encuentre escuchando constantemente 
            //las peticiones de conexión de clientes para ponerlas en cola.
            for (;;)
            {
                // se crea un socket para cliente
                Socket cliente = null;
                try
                {
                    // se acepta la conexión por parte del servidor, devolviedo el socket con el cuál se
                    // esta comunicando el clientess
                    cliente = servidor.Accept();
                    // se crea una variable para registrar cuando se estableció la conexión
                    DateTime tiempoInicio = DateTime.Now;
                    // se define el tiempo de espera del socket, y se define un límite para el mismo
                    cliente.SetSocketOption(SocketOptionLevel.Socket,  SocketOptionName.ReceiveTimeout, LIMITE_ESPERA);
                    // se muestra en pantalla el cliente que está siendo gestionado.
                    Console.Write("Gestionando al cliente: " + cliente.RemoteEndPoint + " - ");
                    //Se define la cantidad total de bytes enviados
                    totalBytesEnviados = 0;
                    // Se condiciona si el buffer de recepción no esta vacío,
                    // entonces se reenvía desde el cliente los datos recibidos.
                    while ((cantBytesRecibidos = cliente.Receive(buferRx, 0,buferRx.Length, SocketFlags.None)) > 0)
                    {
                        cliente.Send(buferRx, 0, cantBytesRecibidos,SocketFlags.None);
                        //sumatoria al total de bytes enviados la cantidad de bytes recibidos.
                        totalBytesEnviados += cantBytesRecibidos;
                        //cálculo del tiempo que ha transcurrido desde que se estableció la conexión
                        TimeSpan tiempoTranscurrido = DateTime.Now - tiempoInicio;
                        //se condiciona que el tiempo transcurrido sea menor al tiempo limite de espera, 
                        //caso contrario se cierra la conexión, mostrando un mensaje que informa sobre la 
                        //cantidad de bytes enviados, posteriormente se lanza una excepción.
                        if (LIMITE_ESPERA - tiempoTranscurrido.TotalMilliseconds < 0)
                        {
                            Console.WriteLine("Terminando la conexión con el cliente debido al temporizador.Se han superado los " + LIMITE_ESPERA + "ms; se han enviado " + totalBytesEnviados + " bytes");
                            cliente.Close();
                            throw new SocketException(10060);
                        }
                        // Se actualiza el time out de recepción haciendolo cada vez mas corto
                        cliente.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (int)(LIMITE_ESPERA -tiempoTranscurrido.TotalMilliseconds));
                    }
                    
                    // se notifica el total de datos enviados y se cierra la conexión
                    Console.WriteLine("Se han enviado {0} bytes.", totalBytesEnviados);
                    cliente.Close();
                }
                catch (SocketException se)
                {   //se condiciona mediante el identificador de excepción
                    if (se.ErrorCode == 10060)
                    { // notificación de cierre de conexión debido a que se supero el tiempo limite de espera
                        Console.WriteLine("Terminado la conexion debido al temporizador.Han transcurrido " + LIMITE_ESPERA + "ms; se han transmitido " + totalBytesEnviados + " bytes");
                    }
                    else
                    {   
                        Console.WriteLine(se.ErrorCode + ": " + se.Message);
                    }
                    //se cierra la conexión tcp
                    cliente.Close();
                }
            }
        }
    }
}
