using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClienteTCPTipoEco
{
    class Program
    {
        static void Main(string[] args)
        { 
            //Se crea un string que contendrá los datos a enviar, y también
            //se crea un punto remoto que representará al servidor que nos vamos a conectar
            //de igual forma se crea el cliente tcp, el buffer de recepcion para recibir el mensaje
            //de eco que enviará el servidor
            string datos = "##--##--##----***----##--##--##";
            IPEndPoint remoto = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            TcpClient cliente = new TcpClient();
            byte[] bufferRx = new byte[512];
            int indicador;
            // Se envía la solicitud de conexión al servidor
            cliente.Connect(remoto);
            //Una vez que el servidor acepta la conexión, se obtiene el flujo mediante el cual se 
            //enviarán los datos contenidos en el buffer de transmisión
            if (cliente.Connected)
            {
                NetworkStream flujo = cliente.GetStream();
                byte[] bufferTx = Encoding.ASCII.GetBytes(datos);
                flujo.Write(bufferTx, 0, bufferTx.Length);
                //Se obtiene la cantidad de datos que se encuentran en el buffer de recepción
                //si existen datos en el buffer, se codifican de forma adecuada de tal forma que 
                //puedan ser mostrados en pantalla, esto se repite hasta que ya no existan datos 
                //en el buffer de recepción.
                do
                {
                    indicador = flujo.Read(bufferRx, 0, bufferRx.Length);
                    if (indicador > 0)
                    {
                        datos = Encoding.ASCII.GetString(bufferRx);
                        Console.WriteLine("Mensaje Recibido");
                        Console.WriteLine("Se recibio: \n{0}", datos);
                    }
                    Console.WriteLine("FIN{0}", indicador);

                } while (indicador > 0);
                Console.WriteLine("FIN{0}", indicador);

                //al finalizar se cierra la conexión
                flujo.Close();
                cliente.Close();


            }
        }
    }
}
