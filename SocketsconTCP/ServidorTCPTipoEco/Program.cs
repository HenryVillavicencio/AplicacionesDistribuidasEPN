using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServidorTCPTipoEco
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se crea un conjunto de objetos  y variables que nos permitiran 
            // almacenar y majenar las conexiones del cliente, servidor, asi como los buffer
            // y datos a enviar.
            TcpClient manejoCliente;
            TcpListener servidor;
            byte[] bufferRx = new byte[512];
            byte[] bufferTx;
            int datosLeidos;
            string datos;
            //Se crea el socket local mediante el cual el servidor escuchará por el puerto
            //11000 y de cualquier ip. Mediante el método start el servidor empieza la escucha, 
            //que en este caso 
            //
            IPEndPoint puntoLocal = new IPEndPoint(IPAddress.Any, 11000);
            servidor = new TcpListener(puntoLocal);
            Console.WriteLine("El servidor está escuchado...");
            servidor.Start(5);
            while (true)
            {
                manejoCliente = servidor.AcceptTcpClient();
                Console.WriteLine("El servidor ha aceptado a un cliente...");
                NetworkStream flujo = manejoCliente.GetStream();
                do
                {
                    datosLeidos = flujo.Read(bufferRx, 0, bufferRx.Length);
                    if (datosLeidos > 0)
                    {
                        datos = Encoding.ASCII.GetString(bufferRx);
                        Console.WriteLine("Mensaje Recibido");
                        Console.WriteLine("Se recibio: \n{0}", datos);
                        Console.WriteLine("Mensaje Enviado");
                        bufferTx = Encoding.ASCII.GetBytes(datos);
                        flujo.Write(bufferTx, 0, bufferTx.Length);
                    }
                } while (datosLeidos > 0);
            }
        }
    }
}
