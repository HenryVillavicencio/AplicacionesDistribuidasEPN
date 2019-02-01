// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ObjetoRemoto;

namespace Servidor
{
    class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            // Definimos y registramos el canal que usara remoting para la comunicación 
            // http en el puerto 30000
            HttpChannel canal = new HttpChannel(30000);
            ChannelServices.RegisterChannel(canal, false);
            // Imprimimos por pantalla el mensaje de inicio del servidor 
            Console.WriteLine("Iniciando el servidor");
            // Configuramos un objeto singleton del tipo GestorDatos para remoting 
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Cerebro),
            "Cerebro",
            WellKnownObjectMode.Singleton);
            // Imprimimos un mensaje y esperamos un Enter para finalizar
            Console.WriteLine("Presione ENTER para concluir...");
            Console.ReadLine();
        }

    }
}
