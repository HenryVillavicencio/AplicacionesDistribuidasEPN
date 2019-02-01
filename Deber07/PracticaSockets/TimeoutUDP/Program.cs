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

namespace TimeoutUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instaciamos un nuevo objeto UDP, en el cuál definimos el puerto y la ip 
            // local de nuestro servidor

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            UdpClient servidor = new UdpClient(ip);

            //Obteneos el objeto socket del servidor
            Socket socketUdp = servidor.Client;

            // Obtenemos e imprimimos en pantalla en Tiemout de recepcion por defecto del socket
            // si el valor es cero, se espera hque halla conexiones
            int to = (int)socketUdp.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            Console.WriteLine("Timeout por defecto: {0}", to);

            // Modificamos el Timeout de recepción del socket a 3000 e imprimimos su valor por pantalla
            // para verificarlo
            socketUdp.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
            to = (int)socketUdp.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            Console.WriteLine("Timeout modificado: {0}", to);

            //Cerramos el socket
            servidor.Close();
            Console.ReadLine();
        }
    }
}
 