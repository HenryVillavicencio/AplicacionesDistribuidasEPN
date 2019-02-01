//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################

// * Ejecuta el programa, ¿qué puedes decir sobre las dos codificaciones? 
//   Para poder enviar un objeto y que este pueda ser manejado de tal manera que el mensaje sea entendible y recuperable del lado de recepción. 
//   El método CodificadorTexto concatena los datos de elemento y utiliza caracteres como delimitadores para identificar sus elementos 
//   formando  así una cadena, la cuál puede ser enviada. El método CodificadorBinario toma la cadena de caracteres convirtiendola en  bytes para su posterior transmisión.
// Resultados:
// El cliente envia un objeto al servidor, el cuál es manejado en el lado del servidor y puede realizar otras tareas
// como por ejemplo en este caso alterar su precio. Para enviar datos de este tipo, es necesario primero aplanarlos o 
// codificarlos de tal manera que estos puedan ser manejados de manera correcta para su envio. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Codificador;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            //tiempo para dormir el proceso
            Thread.Sleep(500);
            // se define la ip del servidor a conectarse
            IPAddress servidor = IPAddress.Parse("127.0.0.1");
            //se especifica el puerto por el cual debe conectarse
            int puerto = 8082;
            //se crea un pnto remoto que será el servidor al que nos conectaremos
            IPEndPoint extremo = new IPEndPoint(servidor, puerto);
            //se crea un cliente tcp para proceder a la solicitud de conexión conexión
            TcpClient cliente = new TcpClient();
            cliente.Connect(extremo);


            //Se llama al método get stream usando network stream para envío y 
            //recepción de bytes
            NetworkStream flujoRed = cliente.GetStream();
            // Se crean los elementos que serán enviados
            Elemento elemento = new Elemento(1234567890987654L, "Cadena de Bicicleta", 18,1000, true, false);
            //se procede a la codificación del elemento, y se los transforma en bytes para su envío
            CodificadorTexto codificador = new CodificadorTexto();
            byte[] datosCodificados = codificador.Codificar(elemento);
            Console.WriteLine("Enviando elemento codificado en texto (" + datosCodificados.Length + " bytes): ");
            Console.WriteLine(elemento);
            // se procede a recuperar los datos enviados.
            flujoRed.Write(datosCodificados, 0, datosCodificados.Length);



            DecodificadorBinario decodificador = new DecodificadorBinario();
            Elemento elementoRecibido = decodificador.Decodificar(cliente.GetStream());
            Console.WriteLine("Se recibio un elemento codificado en formato binario:");
            Console.WriteLine(elementoRecibido);

            // ### Modifica el programa para enviar dos elementos y recibir dos elementos.
            // ### Si  se requiere ver el funcionamiento original del programa comente las siguientes 
            // ### lineas hasta encontrar la linea //### 

             elemento = new Elemento(1234567890123456L, "Bicicleta", 18, 50000, true, true);
            //se procede a la codificación del elemento, y se los transforma en bytes para su envío
            codificador = new CodificadorTexto();
            datosCodificados = codificador.Codificar(elemento);
            Console.WriteLine("Enviando elemento codificado en texto (" + datosCodificados.Length + " bytes): ");
            Console.WriteLine(elemento);
            // se procede a recuperar los datos enviados.
            flujoRed.Write(datosCodificados, 0, datosCodificados.Length);
            decodificador = new DecodificadorBinario();
            elementoRecibido = decodificador.Decodificar(cliente.GetStream());
            Console.WriteLine("Se recibio un elemento codificado en formato binario:");
            Console.WriteLine(elementoRecibido);

            //###





            //se Cierra el network stream para finalizar la conexión adecuadamente
            flujoRed.Close();
            //se cierra la conexión con el cliente
            cliente.Close();
        }
    }
}