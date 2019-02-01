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
            Log.EsperarParaTerminar("1) Presione ENTER para crear un nuevo objeto remoto...");
            //Instancia e inicializacion de un objeto tipo ComponenteCAO
            Componente.Componente miComponente = new Componente.Componente();
            //llamada al metodo Imprimir donde se muestra un mensaje, indica si es un objeto proxy real o transparente
            Log.Imprimir("miComponente ha sido creado. Es Proxy? {0}", (RemotingServices.IsTransparentProxy(miComponente) ? "SI" : "NO"));
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("2) Presione ENTER para usar el primer metodo...");
            //invocacion del metodo PrimeraLlamada() de la clase ComponenteCAO el cual se guarda en la variable resultado tipo string
            resultado = miComponente.LlamadaUno();
            Log.Imprimir("miComponente.LlamadaUno() retorno: {0}", resultado);
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("3) Presione ENTER para usar el segundo metodo...");
            //invocacion del metodo SegundaLlamada() de la clase ComponenteCAO el cual se guarda en la variable resultado tipo string
            resultado = miComponente.LlamadaDos();
            Log.Imprimir("miComponente.LlamadaDos() retorno: {0}", resultado);
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("4) Presione ENTER para crear un nuevo objeto remoto...");
            //Instancia e inicializacion de un objeto tipo ComponenteCAO
            Componente.Componente otroComponente = new Componente.Componente();
            //llamada al metodo Imprimir donde se muestra un mensaje, indica si es un objeto proxy real o transparente
            Log.Imprimir("otroComponente ha sido creado. Es Proxy? {0}", (RemotingServices.IsTransparentProxy(otroComponente) ? "SI" : "NO"));
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("5) Presione ENTER para usar el primer metodo...");
            //invocacion del metodo PrimeraLlamada() de la clase ComponenteCAO el cual se guarda en la variable resultado tipo string
            resultado = otroComponente.LlamadaUno();
            Log.Imprimir("otroComponente.LlamadaUno() retorno: {0}", resultado);
            //llamada al metodo EsperarParaTerminar de la clase Log
            Log.EsperarParaTerminar("Presione ENTER para salir...");
            //Evita el cierre de la consola
            Console.ReadLine();
        }
    }
}
