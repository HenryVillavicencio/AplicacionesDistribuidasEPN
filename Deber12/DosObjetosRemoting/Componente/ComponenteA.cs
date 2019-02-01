// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// 5. Dos Objetos Remotos en un Servidor
// RESULTADOS
// 1. Comente los resultados obtenidos. ¿El comportamiento es el esperado deacuerdo a lo indicado en
// clase?
// El programa realiza la instancia de dos objetos remotos, los cual son creados y verificados que haya comunicacion
// entre el servidor y el cliente a quien pertenece los dos objetos, luego se llamada a un metodo para cada uno de los
// objetos. Se recibe resultado para las dos llamadas.
// 2. Lance otro Cliente. ¿Cual es el resultado?
// Se crea los objetos con una demora, estos objetos tienen el mismo nombre para los dos cliente y se ejecutan de la misma forma.
// ******************************************************************
// Conclusion
// Se puede generar varios objetos remotos pero ahora en el servidor los
// podemos tratar de diferente manera y usar mas puertos para responder a
// las peticiones.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente
{
  
    /// Clase ComponenteA que hereda de MarshalByRefObject
    public class ComponenteA : MarshalByRefObject
    {
    
        /// Constructor de clase
        public ComponenteA() {
            Log.Imprimir("Se creo una instancia del Objeto Remoto ComponenteA");
        }

        /// Metodo Llamada que retorna un objeto tipo string
        public string Llamada() {
            Log.Imprimir("Se invoco a Llamada()");
            return "ComponenteA.Llamada()";
        }
    }

    /// Clase ComponenteB que hereda de MarshalByRefObject
    public class ComponenteB : MarshalByRefObject
    {

        /// Constructor de clase
        public ComponenteB()
        {
            Log.Imprimir("Se creo una instancia del Objeto Remoto ComponenteB");
        }

        /// Metodo Llamada que retorna un objeto tipo string
        public string Llamada()
        {
            Log.Imprimir("Se invoco a Llamada()");
            return "ComponenteB.Llamada()";
        }
    }
}
