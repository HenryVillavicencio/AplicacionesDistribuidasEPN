using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClienteTCP
{
    class Program
    {
        static void Main(string[] args)
        {

            // variable string que contiene los datos a enviar
            string datos = "##--##--##----***----##--##--##";

            //### Modifique el código para que el cliente pueda especificar la dirección IP 
            //### del servidor y el puerto.
            //### Para ver el funcionamiento del programa original  descomente las
            //### lineas //#  y comente las restantes hasta el delimitador //### 

            //creo un puto remoto el cual especifica el servidor al que nos conectaremos
            //# IPEndPoint remoto = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);

            Console.WriteLine("Ingrese la ip del servidor: ");
            String ipAdd = Console.ReadLine();
            Console.WriteLine("Ingrese el puerto del servidor: ");
            int port = Convert.ToInt32(Console.ReadLine());
            IPEndPoint remoto = new IPEndPoint(IPAddress.Parse(ipAdd),port);

            //###

            //creo cliente tcp y envio la peticion de conexion al servidor remoto
            TcpClient cliente = new TcpClient();
            cliente.Connect(remoto);

            //una vez que se establezca la conexion se obtiene el flujo, y se coifican los datos 
            ////de tal manera que puedan ser enviados. Al finalizar el envio cerramos el socket

            if (cliente.Connected)
            {
                NetworkStream flujo = cliente.GetStream();
                byte[] bufferTx = Encoding.ASCII.GetBytes(datos);
                flujo.Write(bufferTx, 0, bufferTx.Length);
                cliente.Close();
            }
        }
    }
}
