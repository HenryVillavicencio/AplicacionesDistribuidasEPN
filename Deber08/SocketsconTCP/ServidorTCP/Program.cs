//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################

// RESULTADOS:
// * TCP//   El cliente ingresa la ip y puerto del servidor al cuál dese enviarle una cadena de caracteres, la cuál //   sera leida y mostrada en pantalla deacuerdo al buffer especificado. // * Servidor TIPO Eco//   EL cliente una vez que establesca la conexión con el servidor puede enviar varios mensajes, hasta que ya solo //   se de un Enter y se cierre la conexión. El servidor reenvia todos los datos recibidos hacia el cliente, el cleinte muestra en //   consola los datos recibidos.// * Uso de Timeouts y llamadas no bloqueantes//   El servidor realiza un eco de los mensajes enviados por el cliente, el cliente presenta por consola el eco 
//   recibido desde el cliente. Al realizar las primeras pruebas con los valores por defecto del programa no se 
//   llega a sobrepasar el timer de tal forma que se rompa la conexión. Al variar el timer podemos conseguir  
//   que se cierre la conexión sin embargo si la cadena es corta aun podremos obtener el eco completo desde 
//   el servidor. Al incrementar la cadena podemos observar que esta ahora si la coexion se cierra prematuramente antes 
//   de recibir todos los datos 
// * Framing y Codificación Binaria y Textual
// -Ejecuta el programa, ¿qué puedes decir sobre las dos codificaciones? 
//   Para poder enviar un objeto y que este pueda ser manejado de tal manera que el mensaje sea entendible y recuperable 
//   del lado de recepción. El método CodificadorTexto concatena los datos de elemento y utiliza caracteres como delimitadores
//   para identificar sus elementos formando  así una cadena, la cuál puede ser enviada. El método CodificadorBinario toma 
//   la cadena de caracteres convirtiendola en  bytes para su posterior transmisión.
// -Resultados:
//   El cliente envia un objeto al servidor, el cuál es manejado en el lado del servidor y puede realizar otras tareas
//   como por ejemplo en este caso alterar su precio. Para enviar datos de este tipo, es necesario primero aplanarlos o 
//  codificarlos de tal manera que estos puedan ser manejados de manera correcta para su envio. // * Uso de Hilos// -¿El servidor es capaz de manejar a estos tres clientes?//   si, el servidor está en la capacidad de manejar 3 clientes, puesto que para cada conexión con cada //   cliente se crea un hilo específico, lo cual permite evitar un bloqueo, permitiendo que se pueda //   extablecer conexión con múltiples clientes.// -Resultados://   El programa crea una clase que permita el manejo de múltiples clientes, mediante hilos,
//   a cada cliente se le asignará un hilo diferente, por lo que el servidor podrá recibir multiples 
//   solicitudes// * Llamadas Asíncronas// * IPv6//  -¿El servidor es capaz de manejar a estos tres clientes?//   Si, se puede manejar 3 clientes, puesto que para cada conexión con cada cliente  se crea un //   hilo específico, lo cual permite evitar un bloqueo, permitiendo que se pueda extablecer //   conexión con múltiples clientes.//  -Resultados://   El programa crea una clase que permita el manejo de múltiples clientes, mediante hilos,
//   a cada cliente se le asignará un hilo diferente, por lo que el servidor podrá recibir multiples 
//   solicitudes, en este caso se maneja esquema de direccionamiento IPv6// * Cliente TCP capaz de manejar HTTP//   www.google.com  la primera ip que devuelve nuestro programa al resolver el nombre esta en formato IPV6 
//   que no es un formato adecudo para las sigueintes pruebas que realiza nuestro nuestro programa. Para poder
//   realizar las pruebas con este servidor realizamos la peticion con con la ayuda del comando nslookup 
//   realizamos la resolucion de nombres, escogemos una que se encuentre en el formato de IPv4 
//   remplazamos en lugar del nombre volvemos a ejecutar, obtiendose los resultados esperados de la petición get.
//   www.epn.edu.ec Se realiza con exito la resolución de nombres y la conexión, sib embargo  no se obtien 
//   resultados de la petición get, debido a que el host remoto bloquea la conexión 
//   Los resultados  conexión y petición get fueron exitos en los siguientes sitios de prueba:
//   1. www.facebok.com,(157.240.14.35) ingresando la ip devuelta por el comando nslookup y obviando la resolución de nombres de nuestro programa
//   2. www.github.com 
//   3. www.youtube.com,(216.58.219.78) ingresando la ip devuelta por el comando nslookup y obviando la resolución de nombres de nuestro programa
//   4. docs.microsoft.com
//   5. educacionvirtual.epn.edu.ec
// CONCLUCIONES:
// * TCP resulta ser más compleja de codificar que UDP, debido a que se debe manejar y controlar las exepciones que surgen durante la conexión
//   y el intercambio de datos. Además,  de manejar los timers de manera adecuada para evitar que nuestro proceso se encuentre bloqueado, 
//   pero sin que este pierda datos.
// * Protocolos usados en la web como HTTP usan TCP para el intercambio de datos através de internet. En este caso de estudio se puedo codificar 
//   y entender con exito la forma en que se realiza las peticiones como get a su servidor web asi como recuperar su respuesta.
// * La utilización de sockets asincronicos nos permiten tener llamadas no bloqueantes, y por lo tanto no es necesario crear un hilo que maneje cada
//   conexión con el cliente, sin embargo las funciones asincronicas por detras en realidad utilizan hilos para la ejecucuón de sus operaciones. 

// RECOMENDACIONES:
// * Tomar como guia y buscar la definicion de los comando de los que se tenga dudas en la documentación oficial de microsof
// * Desactivar o configurar de manera adecuada los firewwal y antirirus que pueden bloquear la ejecución de los programas



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
