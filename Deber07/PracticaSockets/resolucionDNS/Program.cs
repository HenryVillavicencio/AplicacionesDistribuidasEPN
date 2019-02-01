//####################################################################################################
//Practica02
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 19/10/2018
//Fecha de entrega: 26/10/2018
//####################################################################################################// 4. Ejecute el programa.Compruebe que el resultado es el mismo que // el obtenido con nslookup.//
//
//λ nslookup www.epn.edu.ec
//Servidor:  UnKnown
//Address:  fe80::1
//Respuesta no autoritativa:
//Nombre:  www.epn.edu.ec
//Address:  190.96.111.144
//
//Bienvenido!Estas trabajando en: gnirutnala
//190.96.111.144
//
// La dirección IP obtenida por el comando nslookup y el programa 
// es la misma


// 2. Ejemplo de uso de UDP//
// Conecte dos clientes a la misma dirección IP del servidor. ¿Puede recibir de ambos clientes?
// Si, el servidor puede recibir información de ambos clientes debido a que el protocolo que se 
// utiliza es UDP y por lo tanto los clientes no establece una conexión que bloquearia la recepcion
// de informacion de otros cliente como en TCP.

// 3. Envío de datos binarios con UDP
// 4. Timeout en Receive
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace resolucionDNS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Con la ayuda del método GetHostName() el progrma obtiene las direcciones
            // IP asociadas al nombre www.epn.edu.ec

            Console.WriteLine("Bienvenido!Estas trabajando en: "+Dns.GetHostName());
            IPAddress[] direccionesIP = Dns.GetHostAddresses("www.epn.edu.ec");
            foreach (IPAddress ip in direccionesIP)
                Console.WriteLine(ip.ToString());

            //### 5. Modifica el programa para que permita que el usuario ingrese a través de la 
            //### consola(Console.ReadLine) el nombre del host y lo resuelva.También una vez 
            //### que resuelva el nombre de host, agrega el código necesario para que permita 
            //### ingresar una dirección IP y tu programa devuelva el registro DNS del nombre.

            Console.WriteLine("Ingrese el nombre del host: ");
            String hostName =  Console.ReadLine();
            direccionesIP = Dns.GetHostAddresses(hostName);
            foreach (IPAddress ip in direccionesIP)
                Console.WriteLine("Address: "+ip.ToString());

            Console.WriteLine("Ingrese una dirección IP: ");
            String ipAdd = Console.ReadLine();
            IPHostEntry hostEntry = Dns.GetHostEntry(ipAdd);
            Console.WriteLine("Name: " + hostEntry.HostName);


        }
    }
}
