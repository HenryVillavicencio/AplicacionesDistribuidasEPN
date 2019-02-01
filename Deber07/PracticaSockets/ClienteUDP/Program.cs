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


namespace ClienteUDP
{
    class Program
    {
        static void Main(string[] args)
        {

            bool terminado = false;

            // Crea un socket UDP, el cuál sera usado por el cliente para enviar información 
            UdpClient cliente = new UdpClient();

            // Crea un socket, que contiene la IP y puerto del servidor al cuál nos conectaremos

            //# IPAddress servidorIP = IPAddress.Parse("127.0.0.1");
            //# IPEndPoint puntoExtremo = new IPEndPoint(servidorIP, 11000);

            // ### Modifique el programa para que el usuario pueda especificar la dirección IP 
            // ### y el puerto del servidor en Cliente UDP
            // ### Si  se requiere ver el funcionamiento original del programa comente las siguientes 
            // ### lineas hasta encontrar la linea //### y descomente las lineas //#

            Console.WriteLine("Ingrese la dirección IP del servidor al que desea conectarse: ");
            String serverIpAdd = Console.ReadLine();
            Console.WriteLine("Ingrese el puerto del servidor al que desea conectarse: ");
            String serverPort = Console.ReadLine();
            IPAddress servidorIP = IPAddress.Parse(serverIpAdd);
            IPEndPoint puntoExtremo = new IPEndPoint(servidorIP,Convert.ToInt32(serverPort));

            //###

            Console.WriteLine("Ingrese el texto que a transmitir a{0}", servidorIP);
            Console.WriteLine("Para finalizar solo tiene que presionar ENTER");

            // Envia datos al servidor, hasta que no se ingrese ningun texto y se presione
            // solamente un ENTER

            while (!terminado)
            {
                Console.WriteLine("Ingrese texto y presione ENTER para enviar");
                Console.WriteLine("O solamente presione ENTER para finalizar");
                string textoParaEnvio = Console.ReadLine();

                if (textoParaEnvio.Length == 0)
                    terminado = true;
                else
                {
                    Console.WriteLine("Se están enviando datos a la dirección IP: {0} puerto {1}", puntoExtremo.Address, puntoExtremo.Port);
                    byte[] bufferTx = Encoding.ASCII.GetBytes(textoParaEnvio);
                    cliente.Send(bufferTx, textoParaEnvio.Length,puntoExtremo);
                }
            }

        }
    }
}
