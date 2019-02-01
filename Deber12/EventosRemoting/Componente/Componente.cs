// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************

// Eventos
// RESULTADOS:
//El programa cliente servidor permite lanzar un par de eventos generados desde el servidor,
//los cuales son manejados y ejecutados por un manejador de eventos en el lado del cliente.
//El cliente muestra en pantalla el callback ejecutado
// CONCLUSIONES:
// Se pudo generar un programa cliente servidor, donde el objeto remoto lanza un evento el cual sera escuchado 
// por el cliente y ejecutado en su lado 
// RECOMENDACIONES:
// Verificar los archivos de configuración de remoting en el lado del cliente y servidor 
// Apoyarse en la ayuda de visual studio, microsoft  por si se desconoce la información de como implementar un clase
// o sus métodos


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Componente
{
    // Declaramos el delegado que nos permitira amnejar el evento
    public delegate void OnEventHandler(string mensaje);

    // La clase extiende de  MarshalByRefObject para poder usar  la semántica 
    // marshal-by-reference que nos permitira crear un objeto remoto
    public class Componente : MarshalByRefObject
    {
        //Declaramos el manipulador del evento 
        public event OnEventHandler ManipuladorEvento;
        
        // En el constructor al generar una nueva instancia de un objeto 
        // imprimimos un mensaje por pantalla
        public Componente()
        {
            Log.Imprimir("Se creo una instancia de Componente");
        }

        public string LlamadaUno()
        {
            PublicarEvento_PlanificarOtro("Evento desde Servidor: se invoco a LlamadaUno()");
            return "Componente.LlamadaUno()";
        }
        // Método que permite publicar un evento
        private void PublicarEvento(string mensaje)
        {
            Log.Imprimir("Publicando \"{0}\"...", mensaje);
            // Si el evento no ha sido publicado, lo publicamos 
            if (ManipuladorEvento != null)
            {
                ManipuladorEvento(mensaje);
            }
            else
            {
                Log.Imprimir("Hora de publicar un evento, pero no hay suscriptores");
            }
        }
        // Método que publicación un evento con el texto ingresado y espera 5 segundos 
        //para la publicacion de  otro 
        private void PublicarEvento_PlanificarOtro(string texto)
        {
            PublicarEvento(texto);
            Thread hilo = new Thread(new ThreadStart(PublicarEventoEnCincoSeg));
            hilo.Start();
        }
        // Este método espera  5 segundos antes de  publicar un evento
        private void PublicarEventoEnCincoSeg()
        {
            Thread.Sleep(5000);
            PublicarEvento("Han pasado 5 segundos desde una llamada a un método");
        }
    }
}