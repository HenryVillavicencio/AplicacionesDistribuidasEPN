//####################################################################################################
//Deber13
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 03/12/2018
//Fecha de entrega: 03/12/2018
//####################################################################################################

// RESULTADOS:
// El cliente haciendo uso de netremoting puede manipular el componente, a través del protocolo TCP
//usando un objeto CAO.
//
// CONCLUSIONES:
// 
// Se modificó el componente de tal forma que el cliente se crea de forma remota como se puede observar
// al recuperar el dominio
// 
// RECOMENDACIONES: 
// Verificar el Assembly de nuestro componente de tal forma que no exista errores en la configuración de netremoting
// Verificar que la sintaxis de las consultas SQL sea correcta
// En caso de tener dudas acudir a la documentación oficial de microsof

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Componente;
using System.Runtime.Remoting;

namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //  Configuración de Netremoting
            RemotingConfiguration.Configure("Servidor.exe.config", false);
            
            Console.WriteLine("Pulse para cerrar el servidor ");
            Console.Read();

        }
    }
}
