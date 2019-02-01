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
    public class Log
    {

        private Log()
        {
        }

        // Método que imprime un log genérico
        public static void Imprimir(string texto, params object[] args)
        {
            RealizarLog("", texto, args);
        }

        // Método que imprime un log de información 
        public static void Informacion(string texto, params object[] args)
        {
            RealizarLog("INFO: ", texto, args);
        }
        // Método que imprime un log de warning o advertencia 
        public static void Advertencia(string texto, params object[] args)
        {
            RealizarLog("ADVERTENCIA: ", texto, args);
        }
        // Método que imprime un log de error
        public static void Error(string texto, params object[] args)
        {
            RealizarLog("!!!ERROR!!! ", texto, args);
        }

        // Sobrecarga de métodos que imprime un mensaje en pantalla y espera un  enter para ejecutar 
        // la siguiente acción  

        public static void EsperarParaTerminar()
        {
            EsperarParaTerminar("Presione ENTER para terminar...");
        }

        public static void EsperarParaTerminar(string mensaje)
        {
            Console.WriteLine();
            Console.WriteLine();
            RealizarLog("", mensaje);
            Console.ReadLine();
        }

        // Método que imprime por pantalla información acerca de la tarea que se esta ejecutando 
        private static void RealizarLog(string prefijo, string texto, params object[] args)
        {
            // Obtnenemos el id único del hilo gestionado 
            int idHilo = Thread.CurrentThread.ManagedThreadId;
            // Imprimimos por pantalla la información obtenida
            Console.Write("[{0:D4}] [{1}] ", idHilo, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"));
            Console.Write(prefijo);
            Console.WriteLine(texto, args);
        }


    }
}
