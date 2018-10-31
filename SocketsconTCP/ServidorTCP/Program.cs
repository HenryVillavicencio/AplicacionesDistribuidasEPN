


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServidorTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos un conjunto de objetos y variables que nos permitiran 
            // almacenar y majenar las conexiones del cliente, servidor, asi como los buffer
            // y datos a enviar.

            TcpClient manejoCliente;
            TcpListener servidor;

            //### Cambie el tamaño del buffer de recepción a 1. Realice pruebas
            //### Para ver el funcionamiento del programa original  descomente las
            //### lineas //#  y comente las restantes hasta el delimitador //### 
        
            //# byte[] bufferRx = new byte[512];
   
            byte[] bufferRx = new byte[1];
            
            // ###

            int datosLeidos;
            string datos;


            //creo el socket local mediante el cuál escuchará el servidor en el 
            //puerto 11000 y cualquier ip. Iniciamos con el método start la escucha
            
            IPEndPoint puntoLocal = new IPEndPoint(IPAddress.Any, 11000);
            servidor = new TcpListener(puntoLocal);
            Console.WriteLine("El servidor está escuchado...");
            servidor.Start();
            //mediante esta condición hacemos que el servidor permanezca escuchando 
            //las solicitudes de conexión permanentemente. En este caso no se puede
            //tener conexiones simultáneas.
            
            while (true)
            {
                //Aceptamos la conexión por parte del cliente, y obtenemos el flujo
                //del cual recuperaremos la información.
                manejoCliente = servidor.AcceptTcpClient();
                Console.WriteLine("El servidor ha aceptado a un cliente...");
                NetworkStream flujo = manejoCliente.GetStream();

                //Si es que existen datos,leemos el flujo de datos y los mostramos en consolo, y repetimos el proceso
                //hasta que no hayamos terminado de leer todos los datos.
                do
                {
                    datosLeidos = flujo.Read(bufferRx, 0, bufferRx.Length);
                    if (datosLeidos > 0)
                    {
                        datos = Encoding.ASCII.GetString(bufferRx);
                        Console.WriteLine("Mensaje Recibido");
                        Console.WriteLine("Se recibio: \n{0}", datos);
                    }
                } while (datosLeidos > 0);
            }
        }

    }
}
