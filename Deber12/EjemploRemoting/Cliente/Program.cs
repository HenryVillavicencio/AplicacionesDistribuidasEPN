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
using Componente;

namespace Cliente
{
    
    /// clase Program del Cliente
    class Program
    {
        /// Metodo principal
        /// Inidica que es un subproceso COM de una aplicacion
        [STAThread]
        static void Main(string[] args)
        {
            //Configuracion de la comunicacion remota del cliente
            RemotingConfiguration.Configure("Cliente.exe.config",false);
            //llamada al metodo MostarTodosLosDatos de la clase utilidades
            Utilidades.MostrarTodosLosDatos();
            //Instancia e inicializacion de un objeto de la clase Componente
            Componente.Componente miComponente = new Componente.Componente();
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("miComponente.LlamadaDePrueba() retorno {0}",miComponente.LlamadaDePrueba());
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("Presione ENTER para salir...");
            //Evita que se cierre el servidor
            Console.ReadLine();
        }
    }
}
