//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Codificador;

namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Puerto de escucha del servidor
            int puerto = 8082;
            //se crea el objeto con el cual el servidor iniciará  la escucha.
            TcpListener socketEscucha = new TcpListener(IPAddress.Any, puerto);
            //Se inicializa la escucha
            socketEscucha.Start();
            //Se acepta el intento de conexión del cliente
            TcpClient cliente = socketEscucha.AcceptTcpClient();
            //se llama a decodificar texto, para decodificarlo y mostrarlo en consola
            DecodificadorTexto decodificador = new DecodificadorTexto();
            Elemento elemento = decodificador.Decodificar(cliente.GetStream());
            Console.WriteLine("Se recibio un elemento codificado en texto:");
            Console.WriteLine(elemento);

            //se procede a codificar en binario y a enviarlo.
            CodificadorBinario codificador = new CodificadorBinario();
            elemento.precio += 10;
            Console.Write("Enviando elemento en binario...");
            byte[] bytesParaEnviar = codificador.Codificar(elemento);
            Console.WriteLine("(" + bytesParaEnviar.Length + " bytes): ");
            cliente.GetStream().Write(bytesParaEnviar, 0, bytesParaEnviar.Length);

            // ### Modifica el programa para enviar dos elementos y recibir dos elementos.
            // ### Si  se requiere ver el funcionamiento original del programa comente las siguientes 
            // ### lineas hasta encontrar la linea //### 

            elemento = decodificador.Decodificar(cliente.GetStream());
            Console.WriteLine("Se recibio un elemento codificado en texto:");
            Console.WriteLine(elemento);
            //se procede a codificar en binario y a enviarlo.
            codificador = new CodificadorBinario();
            elemento.precio += 10;
            Console.Write("Enviando elemento en binario...");
            bytesParaEnviar = codificador.Codificar(elemento);
            Console.WriteLine("(" + bytesParaEnviar.Length + " bytes): ");
            cliente.GetStream().Write(bytesParaEnviar, 0, bytesParaEnviar.Length);

            //### 

            //se cierra la conexión del cliente
            cliente.Close();
            //se termina la escucha
            socketEscucha.Stop();
        }
    }
}
