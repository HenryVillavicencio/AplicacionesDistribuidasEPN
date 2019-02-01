//####################################################################################################
//Practica02
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 19/10/2018
//Fecha de entrega: 26/10/2018
//####################################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServidorUDP
{
    class Program
    {
        private const int puertoEscucha = 11000;
        static void Main(string[] args)
        {

            bool terminado = false;
            // Crea un socket UDP en un puerto especifico en el cuál el servidor estara escuchara 
            UdpClient servidor = new UdpClient(puertoEscucha);
            // Crea un socket en el cual se almacenara la IP y puerto del cliente que quiera 
            // conectarse
            IPEndPoint sitioRemoto = new IPEndPoint(IPAddress.Any, puertoEscucha);
            // Definimos un buffer y variable que almacenaran los datos recividos 
            string datosRx;
            byte[] bufferRx;
            Console.WriteLine("Empezando ….");

            // Este ciclo se repite indefinidamente, para imprimir los mensajes enviados por los 
            // clientes 

            while (!terminado)
            {
                Console.WriteLine("Esperando por mensajes ….");
                bufferRx = servidor.Receive(ref sitioRemoto);
                Console.WriteLine("Se recibió un mensaje de {0} ….", sitioRemoto);
                datosRx = Encoding.ASCII.GetString(bufferRx, 0, bufferRx.Length);
                Console.WriteLine("El contenido del mensaje es: \n{0}\n", datosRx);
            }

        }
    }
}
