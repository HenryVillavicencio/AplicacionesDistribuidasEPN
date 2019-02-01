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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using Componente;
namespace Cliente
{
    // Declaramos el delegado que manejara la respuesta asincrona
    delegate string ObtenerCadena(string arg);
    class Cliente
    {
        // Declaramos la constante de numero de invocaciones a realizar
        private const int NUMERO_DE_INVOCACIONES = 5;

        // Método que se ejecuta al terminar la llamada asincrona
        private static void OnLlamadaTermina(IAsyncResult res)
        {
            // Declaramos un manipulador del tipo asincronico
            ObtenerCadena manipulador = ((AsyncResult)res).AsyncDelegate as ObtenerCadena;
            // Guardamos el estado del indice de la llamada asincrona
            int indice = (int)res.AsyncState;
            // Guardamos el resultado obtenido por el manipulador
            string resultado = manipulador.EndInvoke(res);

            Log.Imprimir("miContenido.Llamada() #{0} concluyo. El resultado es\"{1}\"", indice, resultado);
        }


        [STAThread]
        static void Main(string[] args)
        {
            // Lee el archivo de configuración y lo aplica en el programa 
            RemotingConfiguration.Configure("Cliente.exe.config",false);
            // Instanciamos un componente remoto
            Componente.Componente miComponente = new Componente.Componente();
            Log.Imprimir("Se creo un objeto remoto. Es Proxy? {0}",
            (RemotingServices.IsTransparentProxy(miComponente) ? "SI" : "NO"));

            // Realizamos la invocacion de 5 veces de la llamada a nuestro cliente como una llamada asincrona
            for (int i = 1; i <= NUMERO_DE_INVOCACIONES; ++i)
            {
                Log.Imprimir("Invocando a miComponente.Llamada() #{0}...", i);
                ObtenerCadena manipulador = new ObtenerCadena(miComponente.Llamada);
                manipulador.BeginInvoke("Desde Cliente", new AsyncCallback(OnLlamadaTermina), i);
            }
            Log.EsperarParaTerminar("Presione ENTER para salir...");
        }
    }
}