// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// 3. SingleCall
// RESULTADOS
// 1. Comente los resultados obtenidos. ¿El comportamiento es el esperado de acuerdo a lo indicado en
// clase?
// El programa instancia un objeto remoto, el cual cuando realiza la llamada a un metodo de la clase Componente
// usa un id diferente para cada llamada a un metodo distinto. El comportamiento es el indicado.
// 2. Lance otro ClienteCAO. ¿Cual es el resultado?
// Se tiene diferentes objetos remotos para cada uno de las invocaciones de los metodos para cada nuevo cliente necesite
// ******************************************************************
// Conclusion
// Se puede generar varios objetos remotos que atenderan las peticiones de los
// clientes y ofertando servicios a los mismos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponenteSAOSC
{

    /// Clase Componente que hereda de MarshalByRefObject

    public class ComponenteSAOSC : MarshalByRefObject
    {
        //Variable priavada estatica de tipo int inicializadad en 0
        private static int ID = 0;
        //Varaiable privada de tipo int
        private int id;

        /// Constructor de clase
        public ComponenteSAOSC()
        {
            //Incrementa la variable privada estatica ID utilizada por varios procesos de forma atómica
            id = System.Threading.Interlocked.Increment(ref ID);
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se creo una instancia  del Objeto Remoto ComponenteSAO, id={0}", id);
        }
    
        /// Metodo PrimeraLlamada que retorna un objeto de tipo string
        public string PrimeraLlamada()
        {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a PrimeraLlamada()");
            //Retorna un string que tiene el id del componente
            return string.Format("ComponenteSAO.id={0}", id);
        }
  
        /// Metodo SegundaLlamada que retorna un objeto de tipo string
        public string SegundaLlamada()
        {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a SegundaLlamada()");
            //Retorna un string que tiene el id del componente
            return string.Format("ComponenteSAO.id={0}", id);
        }
    }
}
