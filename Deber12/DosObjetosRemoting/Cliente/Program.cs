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
  
    /// Clase Program del proyecto Cliente
    class Program
    {
       
        /// Metodo principal

        /// Inidica que es un subproceso COM de una aplicacion
        [STAThread]
        static void Main(string[] args)
        {
            //Configuracion de la comunicacion remota del
            RemotingConfiguration.Configure("Cliente.exe.config");
            //llamada al metodo MostarTodosLosDatos de la clase utilidades
            Utilidades.MostrarTodosLosDatos();
            //instancia de un objeto tipo string
            string resultado;
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("1) Presione ENTER para crear el objeto remoto...");
            //Instancia e inicializacion de un objeto tipo Componente
            Componente.ComponenteA miComponenteA = new Componente.ComponenteA();
            //llamada al metodo Imprimir donde se muestra un mensaje, indica si es un objeto proxy real o transparente
            Log.Imprimir("miComponenteA ha sido creado. Es Proxy? {0}", (RemotingServices.IsTransparentProxy(miComponenteA) ? "SI" : "NO"));
            //invocacion del metodo Llamada() de la clase ComponenteCAO el cual se guarda en la variable resultado tipo string
            resultado = miComponenteA.Llamada();
            Log.Imprimir("miComponenteA.Llamada() retorno: {0}", resultado);
            //Instancia e inicializacion de un objeto tipo Componente
            Componente.ComponenteB miComponenteB = new Componente.ComponenteB();
            //llamada al metodo Imprimir donde se muestra un mensaje, indica si es un objeto proxy real o transparente
            Log.Imprimir("miComponenteB ha sido creado. Es Proxy? {0}", (RemotingServices.IsTransparentProxy(miComponenteB) ? "SI" : "NO"));
            //invocacion del metodo Llamada() de la clase ComponenteCAO el cual se guarda en la variable resultado tipo string
            resultado = miComponenteB.Llamada();
            Log.Imprimir("miComponenteB.Llamada() retorno: {0}", resultado);
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("Presione ENTER para salir...");
            //Evita que se cierre el servidor
            Console.ReadLine();
        }
    }
}
