// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// 4. Singleton
// RESULTADOS
// 1. Comente los resultados obtenidos. ¿El comportamiento es el esperado de acuerdo a lo indicado en
// clase?
// El programa crea un objeto remoto, con el cual se hace los llamados a los metodos del servidor. Se instancia
// otro objeto remoto, el cual es tiene el mismo id que el primero objeto creado. La comunicacion remota es singleton
// la cual conserva el estado del objeto remoto.
// 2. Lance otro ClienteSAO. ¿Cual es el resultado?
// Se conserva el estado del objeto remoto, por lo que no se instancia un nuevo objeto en el servidor, sino que se 
// comparte con los otros clientes.
// 3. Explique claramente cúal es la diferencia entre Singleton y SingleCall
// En SingleCall se tiene un mismo id para todos los objetos remotos mientras que en Singleton se usa un mismo id para
// el objeto remoto, osea que no hace instancia de nuevos objetos remotos.
// ******************************************************************
// Conclusion
// En modo Singleton, todas las aplicaciones de Cliente comparten una sola
// instancia del objeto remoto que se crea en el Servidor. Incluso si crea 
// varios objetos en la aplicación Cliente, aún utilizan el mismo objeto individual 
// de la aplicación Servidor.
// El objeto que se crea es un objeto proxy

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponenteSAOST
{
 
    /// Clase Componente que hereda de MarshalByRefObject

    public class ComponenteSAOST : MarshalByRefObject
    {
        //Variable priavada estatica de tipo int inicializadad en 0
        private static int ID = 0;
        //Varaiable privada de tipo int
        private int id;

        /// Constructor de clase
        public ComponenteSAOST()
        {
            //Incrementa la variable privada estatica ID utilizada por varios procesos de forma atómica
            id = System.Threading.Interlocked.Increment(ref ID);
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se creo una instancia  del Objeto Remoto ComponenteCAO, id={0}", id);
        }
       
        /// Metodo PrimeraLlamada que retorna un objeto de tipo string
        public string PrimeraLlamada()
        {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a PrimeraLlamada()");
            //Retorna un string que tiene el id del componente
            return string.Format("ComponenteCAO.id={0}", id);
        }
 
        /// Metodo SegundaLlamada que retorna un objeto de tipo string
        public string SegundaLlamada()
        {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a SegundaLlamada()");
            //Retorna un string que tiene el id del componente
            return string.Format("ComponenteCAO.id={0}", id);
        }
    }
}
