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
using ComponenteCAO;

namespace ServidorCAO
{

    /// Clase Program del proyecto ServidorCAO
    class Program
    {
  
        /// Metodo principal
       
        /// Inidica que es un subproceso COM de una aplicacion
        [STAThread]
        static void Main(string[] args)
        {
            //Configuracion de la comunicacion remota del servidor
            RemotingConfiguration.Configure("ServidorCAO.exe.config");
            //llamada al metodo MostarTodosLosDatos de la clase utilidades
            Utilidades.MostrarTodosLosDatos();
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("Presione ENTER para detener al servidor...");
            //Evita que se cierre el servidor
            Console.ReadLine();
        }
    }
}
