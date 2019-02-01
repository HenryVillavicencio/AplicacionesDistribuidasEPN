// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// ******************************************************************
// 2. CAO
// RESULTADOS
// 1. Comente los resultados obtenidos. ¿El comportamiento es el esperado de acuerdo a lo indicado en
// clase?
// El servidor registra que el cliente a instanciado dos objetos remotos, lo cuales son individuales para cada uno.
// El cliente con sus objetos remotos propios hacen el llamado de los metodos.
// 2. Lance otro ClienteCAO. ¿Cual es el resultado?
// Se crea nuevos objetos remotos para el cliente nuevo. Estos objetos tienen diferentes id que de los anteriores clientes.
// *****************************************************************
// Conclusion:
// Si crea 2 o más objetos remotos en su aplicación Cliente, sí, se creará la 
// cantidad exacta de objetos remotos en la aplicación del Servidor.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponenteCAO
{
   
    /// Clase Componente que hereda de MarshalByRefObject
    public class ComponenteCAO : MarshalByRefObject
    {
        //Variable priavada estatica de tipo int inicializadad en 0
        private static int ID = 0;
        //Varaiable privada de tipo int
        private int id;
 
        /// Constructor de clase
        public ComponenteCAO() {
            //Incrementa la variable privada estatica ID utilizada por varios procesos de forma atómica
            id = System.Threading.Interlocked.Increment(ref ID);
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se creo una instancia  del Objeto Remoto ComponenteCAO, id={0}",id);
        }

        /// Metodo PrimeraLlamada que retorna un objeto de tipo string
        public string PrimeraLlamada() {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a PrimeraLlamada()");
            //Retorna un string que tiene el id del componente
            return string.Format("ComponenteCAO.id={0}",id);
        }
       
        /// Metodo SegundaLlamada que retorna un objeto de tipo string
        public string SegundaLlamada() {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a SegundaLlamada()");
            //Retorna un string que tiene el id del componente
            return string.Format("ComponenteCAO.id={0}", id);
        }
    }
}
