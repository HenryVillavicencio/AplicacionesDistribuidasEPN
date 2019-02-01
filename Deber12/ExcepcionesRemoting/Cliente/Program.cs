
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
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Lee el archivo de configuración y lo aplica en el programa 
            RemotingConfiguration.Configure("Cliente.exe.config",false);
            // Muestra los tipos de datos de net remoting  configurados para el programa 
            Utilidades.MostrarTodosLosDatos();
            
            Componente.Componente miComponente = new Componente.Componente();
            Log.Imprimir("Se creo miComponenete. Es un proxy? {0}",
            (RemotingServices.IsTransparentProxy(miComponente) ? "SI" : "NO"));

            try
            {
                miComponente.LlamadaUno();
            }
            catch (ExcepcionRemota ex)
            {
                Log.Imprimir("Se capturo una ExcepcionRemota: mensaje=\"{0}\", msg.extra =\"{1}\"", ex.Message, ex.MensajeAdicional);
            }
            try
            {
                miComponente.LlamadaDos();
            }
            catch (Exception ex)
            {
                Log.Imprimir("Se capture una Exception: mensaje=\"{0}\"",ex.Message);
            }

            Log.EsperarParaTerminar("Presiona ENTER para terminar...");
        }

    }
}
