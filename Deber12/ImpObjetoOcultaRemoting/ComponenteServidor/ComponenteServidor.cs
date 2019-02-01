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
using Componente;

namespace ComponenteServidor
{

    /// Clase de Componente del Servidor el cual creará lo objetos remotos
    /// esta hereda de las clases MarshalByRefObject y IComponente
    public class ComponenteServidor : MarshalByRefObject, IComponente
    {
        //Variable priavada estatica de tipo int inicializadad en 0
        private static int ID = 0;
        //Varaiable privada de tipo int
        private int id;
 
        /// Constructor de clase
        public ComponenteServidor()
        {
            //Incrementa la variable privada estatica ID utilizada por varios procesos de forma atómica
            id = System.Threading.Interlocked.Increment(ref ID);
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se creo una instancia  del Objeto Remoto Componente.id={0}", id);
        }
        
        /// Metodo LlamadaUno que retorna un objeto de tipo string
        public string LlamadaUno()
        {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a LlamadaUno(), Componente.id={0}", id);
            //Retorna un string que tiene el id del componente
            return string.Format("Componente.id={0}", id);
        }
      
        /// Metodo LlamadaDos que retorna un objeto de tipo string
        public string LlamadaDos()
        {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a LlamadaDos(), Componente.id={0}", id);
            //Retorna un string que tiene el id del componente
            return string.Format("Componente.id={0}", id);
        }
    }
}
