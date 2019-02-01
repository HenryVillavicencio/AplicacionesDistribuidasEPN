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
using System.Threading;

namespace Componente
{
    
    /// Clase publica Log
    public class Log
    {
     
        /// Constructor privado de Log
        private Log() { }
      
        /// Metodo Imprimir 
        public static void Imprimir(string texto, params object[] args)
        {
            //Llamada a metodo estatico RealizarLog
            RealizarLog("", texto, args);
        }
      
        /// Metodo Informacion
        public static void Informacion(string texto, params object[] args)
        {
            //Llamada a metodo estatico RealizarLog
            RealizarLog("INFO: ", texto, args);
        }
        
        /// Metodo Advertencia
        public static void Advertencia(string texto, params object[] args)
        {
            //Llamada a metodo estatico RealizarLog
            RealizarLog("ADVERTENCIA: ", texto, args);
        }
        
        /// Metodo Error
        public static void Error(string texto, params object[] args)
        {
            //Llamada a metodo estatico RealizarLog
            RealizarLog("!!!ERROR!!! ", texto, args);
        }
     
        /// Metodo EsperarParaTerminar
        public static void EsperarParaTerminar()
        {
            //Llamada a metodo estatico EsperarParaTerminar
            EsperarParaTerminar("Presione ENTER para terminar...");
        }
        
        /// Metodo EsperarParaTerminar
        public static void EsperarParaTerminar(string mensaje)
        {
            //Espacio en consola
            Console.WriteLine();
            Console.WriteLine();
            //Llamada a metodo estatico RealizarLog
            RealizarLog("", mensaje);
            //Espacio en consola
            Console.WriteLine();
        }
       
        /// Metodo RealizarLog
        private static void RealizarLog(string prefijo, string texto, params object[] args)
        {
            //Obtiene el identificador del hilo que se esta ejecutando
            int idHilo = Thread.CurrentThread.ManagedThreadId;
            //Muestra el identificador del hilo actual en ejecucion, y la fecha actual obtenida del sistema
            Console.Write("[{0:D4}] [{1}]", idHilo, DateTime.Now.ToString("yyy/MM/dd HH:mm:ss.fff"));
            //Muestra los argumentos del metodo
            Console.Write(prefijo);
            Console.WriteLine(texto, args);
        }
    }
}
