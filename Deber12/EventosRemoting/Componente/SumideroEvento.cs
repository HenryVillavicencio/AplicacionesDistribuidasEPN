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

namespace Componente
{

    // La clase extiende de  MarshalByRefObject para poder usar  la semántica 
    // marshal-by-reference que nos permitira crear un objeto remoto

    public class SumideroEvento : MarshalByRefObject
    {
        //Declaramos el manipulador del evento 
        private OnEventHandler manipulador;
        // Definimos el constructor de nuestra clase, la cual recibe como parametro de entrada el 
        // manipulador del evento 
        public SumideroEvento(OnEventHandler manipulador)
        {
            this.manipulador = manipulador;
        }

        // Se marcan los métodos como unidireccionales, indicando que  no se 
        // espera ningún mensaje de respuesta, estado o información. En este caso 
        // ya que los metodos son del tipo void
        [System.Runtime.Remoting.Messaging.OneWay]


        // Método que invoca el manipulador del evento
        public void ManipuladorEventoCallback(string texto)
        {
            if (manipulador != null)
            {
                manipulador(texto);
            }
        }

        //  Método que realiza la sucripcion del evento 
        public void Registrar(Componente miComponente)
        {
           miComponente.ManipuladorEvento += new
           OnEventHandler(ManipuladorEventoCallback);
        }
        // Método que realiza la desuscripcion del evento 
        public void Deregistrar(Componente miComponente)
        {
            miComponente.ManipuladorEvento -= new
           OnEventHandler(ManipuladorEventoCallback);
        }
    }
}
