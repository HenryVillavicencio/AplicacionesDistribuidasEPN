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


namespace ClienteUDPBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializamos una nueva instacia de cliente Udp y establecemos
            // por defecto el host remoto al cual nos conectaremos, en este caso
            // es el mismo punto local

            UdpClient local = new UdpClient("127.0.0.1", 8080);

            // Creamos varios tipos de datos que seran enviados 
            int p1 = 45;
            double p2 = 3.14159;
            int p3 = -1234567890;
            bool p4 = false;
            string p5 = "This is a test.";

            // Enviamos cada uno de datos creados anteriormente 
            // en formato bytes  

           

            byte[] data1 = BitConverter.GetBytes(p1);
            local.Send(data1, data1.Length);

            byte[] data2 = BitConverter.GetBytes(p2);
            local.Send(data2, data2.Length);

            byte[] data3 = BitConverter.GetBytes(p3);
            local.Send(data3, data3.Length);

            byte[] data4 = BitConverter.GetBytes(p4);
            local.Send(data4, data4.Length);

            byte[] data5 = Encoding.ASCII.GetBytes(p5);
            local.Send(data5, data5.Length);

            // cerramos el socket del cliente 
            local.Close();

        }
    }
}
