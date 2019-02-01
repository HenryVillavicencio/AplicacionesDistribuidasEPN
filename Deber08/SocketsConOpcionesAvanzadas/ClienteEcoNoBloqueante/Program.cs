//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################
// Resultados:
// El servidor realiza un eco de los mensajes enviados por el cliente, el cliente presenta por consola el eco recibido desde el cliente. 
// Al realizar las primeras pruebas con los valores por defecto del programa no se llega a sobrepasar el timer de tal forma que se rompa 
// la conexión. Al variar el timer podemos conseguir  que se cierre la conexión sin embargo si la cadena es corta aun podremos obtener el 
// eco completo desde el servidor. Al incrementar la cadena podemos observar que esta ahora si la coexion se cierra prematuramente antes 
// de recibir todos los datos 
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClienteEcoNoBloqueante
{
    class Program
    {
        static void Main(string[] args)
        {
            // se crean las variables a utilizar, incluyendo el nombre del servidor, puerto de conexión 
            // y sus respectivos buffers
            String servidor = "localhost";
            byte[] buferTx = new byte[512];
            byte[] buferRx = new byte[512];
            int puerto = 8082;
            //se crea el socket del cliente
            Socket socketCliente = null;
            try
            {
                //creamos el socket para el cliente empleando el constructor en el que se especifica
                // el esquema de dirección, el tipo del socket, y el tipo de protocolo.
                socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
                // procedemos a realizar la solicitud de conexión en la cual el cliente
                //busca conectarse al servidor mediante el nombre del dominio y el puerto.
                socketCliente.Connect(new IPEndPoint(Dns.Resolve(servidor).AddressList[0], puerto));
            }
            catch (Exception e)
            {   //se muestra el mensaje de la excepción y termina el proceso
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }

            // se crean las variables con el propósito de llevar el control de bytes enviados
            //y recibidos.
            int totalBytesEnviados = 0;
            int totalBytesRecibidos = 0;


            // ### Ejecuta las aplicaciones y comprueba su funcionamiento.Cambia la cadena que se 
            // ### envía, de igual manera cambia el tiempo que el cliente se va a dormir y observa 
            // ### si el servidor rompe la conexión.
            // ### Si  se requiere ver el funcionamiento original del programa comente las siguientes 
            // ### lineas hasta encontrar la linea //### y descomente las lineas //#



            //se codifica en bytes una cadena para poder ser enviada, y se guarda en el buffer de tx
            //# buferTx = Encoding.ASCII.GetBytes("ESTOY ENVIANDO TODO ESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!");

            buferTx = Encoding.ASCII.GetBytes("AHOOOOOOOOOORA ESTOY ENVIANDO  TODO ESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO Y MAAAAAAAASSSSSSSSSS!!! XD XD XD XD hasta coooooooommmmmmmmleeeetar 600 Caracteres AHOOOOOOOOOORA ESTOY ENVIANDO  TODO ESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO Y MAAAAAAAASSSSSSSSSS!!! XD XD XD XD hasta coooooooommmmmmmmleeeetar 600 Caracteres AHOOOOOOOOOORA ESTOY ENVIANDO  TODO ESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO Y MAAAAAAAASSSSSSSSSS!!! XD XD XD XD hasta coooooooommmmmmmmleeeetar 600 Caracteres 1111111111111111111111 1 1 1 1 1 1 1XD .......................11111112222222222222222222222222222222222222222222222222222222222222222...........");

            //###


            // se establece en false la propiedad bloquing del socket para que no sea bloqueante
            socketCliente.Blocking = false;
            //Condición que establece que cuando los bytes recibidos sean siempre menores al tamaño del buffer de tx
            // se realice la condición interna
            
            while (totalBytesRecibidos < buferTx.Length)
            {
                // si los bytes enviados son menores al tamaño del buffer de transmisión entonces 
                if (totalBytesEnviados < buferTx.Length)
                {
                    
                    try
                    { // se incrementa la cantidad de bytes totales enviados, al enviar los datos se 
                      // se setean los parámetros del buffer
                        totalBytesEnviados += socketCliente.Send(buferTx, totalBytesEnviados,  buferTx.Length - totalBytesEnviados, SocketFlags.None);
                        // se muestra por consola la cantidad de bytes enviados
                        Console.WriteLine("Se han enviado un total de {0} bytes al servidor...",totalBytesEnviados);
                    }
                    catch (SocketException se)
                    {
                        //se controla la excepción "operation would block", 
                        //mediante la condicion de identificador de excepción
                        if (se.ErrorCode == 10035)
                        {
                            //WSAEWOULDBLOCK: Recurso temporalmente no disponible
                            Console.WriteLine("Temporalmente no es posible enviar, se reintentará despues...");
                        }
                        else
                        {
                            //si no se muestra el mensaje de error, se cierra la conexión y se termina el proceso
                            Console.WriteLine(se.ErrorCode + ": " + se.Message);
                            socketCliente.Close();
                            Environment.Exit(se.ErrorCode);
                        }
                    }
                }
                try
                {   //se crea la variable bytes recibidos y se la setea en cero
                    int bytesRecibidos = 0;
                    //se condiciona si el buffer tx esta vacío
                    if ((bytesRecibidos = socketCliente.Receive(buferRx, totalBytesRecibidos,  buferRx.Length - totalBytesRecibidos, SocketFlags.None)) == 0)
                    {   //se notifica
                        Console.WriteLine("La conexion se cerro prematuramente...");
                        break;
                    }

                    // adición de los bytes recibidos al total de bytes recibidos
                    totalBytesRecibidos += bytesRecibidos;
                }
                catch (SocketException se)
                { // se condiciona para identificar una excepción, y continuar con el procedimiento
                    if (se.ErrorCode == 10035)
                        continue;
                    else
                    {   //si no se muestra el mensaje con el error
                        Console.WriteLine(se.ErrorCode + ": " + se.Message);
                        break;
                    }
                }
                //se llama al método realizar Procesamiento
                RealizarProcesamiento();
            }
            //se muestra en pantalla el total de bytes recibidos por el servidor
            Console.WriteLine("Se han recibido {0} bytes desde el servidor: {1}", totalBytesRecibidos, Encoding.ASCII.GetString(buferRx, 0, totalBytesRecibidos));
            //se cierra la conexión
            socketCliente.Close();
        }
        static void RealizarProcesamiento()
        {
            // ### Ejecuta las aplicaciones y comprueba su funcionamiento.Cambia la cadena que se 
            // ### envía, de igual manera cambia el tiempo que el cliente se va a dormir y observa 
            // ### si el servidor rompe la conexión.
            // ### Si  se requiere ver el funcionamiento original del programa comente las siguientes 
            // ### lineas hasta encontrar la linea //### y descomente las lineas //#

            //se manda a dormir al cliente
            Console.WriteLine(".");
            Thread.Sleep(10005);
            
            //# Console.WriteLine(".");
            //# Thread.Sleep(2000);

            //##
        }
    }
}
