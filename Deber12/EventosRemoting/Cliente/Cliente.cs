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
    // La clase implementa la interfaz IDisposable, que proporciona un mecanismo 
    // para liberar recursos no administrados.
    class Cliente : IDisposable
    {

        // Declaramos los atributos  de clase que permitiran la comunicación bidireccional 
        // mediante el uso de eventos 
        private Componente.Componente miComponente;
        private SumideroEvento sumidero;

        // Definición del constructor de la clase
        public Cliente()
        {
            Log.Imprimir("Cliente()");
            // Creo el proxy para el objeto remoto
            miComponente = new Componente.Componente();
            // creo el sumidero de eventos
            sumidero = new SumideroEvento(new
           OnEventHandler(ManipuladorEventoCallback));
            // registro el manipulador de evento con el sumidero
            sumidero.Registrar(miComponente);
        }
        // Definición del desconstructor de la clase
        // librera los recursos  no administrados 
        ~Cliente()
        {
            (this as IDisposable).Dispose();
        }
        // Método que se ejecuta al realizar el callback
        public void ManipuladorEventoCallback(string texto)
        {
            Log.Imprimir("Obtuve texto mediante un callback! {0}", texto);
        }
        // Método prueba la llamada uno de nuestro objeto remoto
        public void Prueba()
        {
            Log.Imprimir("miComponente.LlamadaUno() retorno {0}",
           miComponente.LlamadaUno());
        }
        void IDisposable.Dispose()
        {
            // se deregistra el manipulador del objeto remoto
            sumidero.Deregistrar(miComponente);
            GC.SuppressFinalize(this);
            Log.Imprimir("Cliente.Dispose()");
        }


        [STAThread]

        // Método principal de ejecución
        static void Main(string[] args)
        {
            // Lee el archivo de configuración y lo aplica en el programa 
            RemotingConfiguration.Configure("Cliente.exe.config",false);
            // Muestra los tipos de datos de net remoting  configurados para el programa 
            Utilidades.MostrarTodosLosDatos();
            // Los recursos de cliente generados solo seran válidos dentro del using  
            using (Cliente c = new Cliente())
            {
                // ejecutamos el método prueba de nuestro cliente
                c.Prueba();
                Log.EsperarParaTerminar("Presiona ENTER para terminar...");
                GC.KeepAlive(c);
            }
        }
    }
}