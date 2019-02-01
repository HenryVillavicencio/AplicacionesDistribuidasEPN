// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// 1. Primer ejemplo de .NET Remoting
// RESULTADOS
// En los archivos App.config, modifique el protocolo de transporte, en lugar de TCP use HTTP. Tome tiempos
// y compare con los resultados obtenidos con TCP. Indique el tiempo que tarda TCP y en HTTP. ¿Que puede concluir
// al respecto?
// * TCP: 3.71 segundos aproximandamente a partir de dar clic en el boton de Depuracion
// * HTTP:2.30 segundos aproximandamente a partir de dar clic en el boton de Depuracion
// CONCLUSION
// El uso de HTTP hace la conexion mas rapida, aunque no es una gran diferencia de tiempo.
// CONCLUSIONES DE LA PRACTICA:
// Se pudo comprobar que si se utiliza .NET REMOTING hay que tener en cuenta que se puede usar Singleton, SingleCall u Objetos remotos creados por el
// cliente, donde hay que tener en cuenta que todo cumplen el fin de servir a la comunicacion remota, pero de formas un poco distintas.
// RECOMENDACIONES DE LA PRACTICA:
// Si se va a realizar cambios de nombre a los archivos de configuracion (App.conf) es necesario y bajo nuestra responsabilidad cambiar los archivos de
// configuracion de la solucion para que pueda acceder al arhcivo y usarlo.
// Apoyarse en la ayuda de visual studio por si se desconoce la información o el propósito de cada hilo.
// Usar las herramientas que provee visual studio como lo es la depuración de los programas asi se puede encontrar posibles errores en el código

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente
{

    /// Clase Componente que hereda de MarshalByRefObject
    public class Componente:MarshalByRefObject
    {
        
        /// Constructor que llama a un metodo de la clase publica Log
        public Componente() {
            Log.Imprimir("Se creo una instancia del Objeto Remoto Componente");
        }
     
        /// Metodo LlamadaDePrueba que retorna un string, que hace una llamada a un metodo de la clase publica Log
        public string LlamadaDePrueba() {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("Se invoco a LlamadaDePrueba()");
            return "Componente.LlamadaDePrueba()";
        }
    }
}
