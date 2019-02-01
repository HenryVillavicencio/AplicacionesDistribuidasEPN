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

namespace ServidorUDPBinario
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creamos un socket desde el cual escuchara nuestro servidor
            // La ip en la que escucha es cualquiera y el puerto 8080

            IPEndPoint miIp = new IPEndPoint(IPAddress.Any, 8080);
            
            UdpClient local = new UdpClient(miIp);
            Console.WriteLine("Esperando datos...");

            // creamos un socket el cual se usara para guardar la ip y puerto
            // del cliente que se ha conectado a nuestro servidor
            IPEndPoint remoto = new IPEndPoint(IPAddress.Any, 0);

            // Recibe 5 datos en formato tipo byte y los parseamos a cada uno de los 
            // formatos definidos en el cliente y los imprimimos en pantalla

            byte[] data1 = local.Receive(ref remoto);
            int p1 = BitConverter.ToInt32(data1, 0);
            Console.WriteLine("1er dato = {0}", p1);

            byte[] data2 = local.Receive(ref remoto);
            double p2 = BitConverter.ToDouble(data2, 0);
            Console.WriteLine("2do dato = {0}", p2);

            byte[] data3 = local.Receive(ref remoto);
            int p3 = BitConverter.ToInt32(data3, 0);
            Console.WriteLine("3er dato = {0}", p3);

            byte[] data4 = local.Receive(ref remoto);
            bool p4 = BitConverter.ToBoolean(data4, 0);
            Console.WriteLine("4to dato = {0}", p4.ToString());

            byte[] data5 = local.Receive(ref remoto);
            string p5 = Encoding.ASCII.GetString(data5);
            Console.WriteLine("5to dato = {0}", p5);

            local.Close();
        }
    }
}
