// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// 6. Tiempo de Prestamo
// RESULTADOS
// 1. Comente los resultados obtenidos. ¿El comportamiento es el esperado de acuerdo a lo indicado en
// clase?
// Se crea objetos remotos, los cuales el cliente los usa para hacer invocaciones de metodos. Asi mismo se crea otro
// objeto remoto el cual llama a un metodo. 
// 2. Juegue con el lease time. Pruebe con distintos valores, nota alguna diferencia?
// Cuando el lease time todavia no ha expirado, se utiliza el mismo objeto remoto para realizar la ejecucion de los
// metodos de otro cliente, una vez que haya terminado ese tiempo se crea un nuevo objeto remoto si un nuevo cliente
// asi lo requiera.
// ******************************************************************
// Conclusion
// Cada vez que recibe una llamada remota para el objeto del servidor,
// CurrentLeaseTime de este objeto se establece en el intervalo de tiempo RenewOnCallTime.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente
{
   
    /// Clase Componente que hereda de MarshalByRefObject
    public class Componente : MarshalByRefObject
    {
        //Variable priavada estatica de tipo int inicializadad en 0
        private static int ID = 0;
        //Varaiable privada de tipo int
        private int id;
 
        /// Constructor de clase
        public Componente()
        {
            //Incrementa la variable privada estatica ID utilizada por varios procesos de forma atómica
            id = System.Threading.Interlocked.Increment(ref ID);
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se creo una instancia  del Objeto Remoto Componente.id={0}", id);
        }

        /// Destructor de clase
        ~Componente() {
            Log.Imprimir("Se destruyo una instancia del Objeto Remoto Componente");
        }
   
        /// Metodo LlamadaUno que retorna un objeto de tipo string
        public string LlamadaUno()
        {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a LlamadaUno(), Componente.id={0}",id);
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
