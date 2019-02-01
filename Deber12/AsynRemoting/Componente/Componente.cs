// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// Llamadas Asíncronas// RESULTADOS: 
//El programa cliente servidor ejecuta la respuesta asincrona del llamado al método de nuestro objeto remoto 5 veces,
// como se puede notar la repuesta ejecutada en el cliente pued ocurrir en desorden y en tiempos diferente al llamado
// del método tal y como se lo esperartia en una repsuesta asincrona
// CONCLUSIONES:
// Las llamadas asincronas nos permiten ejecutar las respuestas remotas de forma que estos sean ejecutadas por un hilo independiente
//  y no se bloqueen 
// RECOMENDACIONES:
// Verificar que las objetos remotos y los serializables tengan etiquetados los atributos correctos o extiendan de las clases adecuadas 
// Verificar que la configuracion de netremoting sea realizada  de manera correcta en el lado del servidor como del cliente 
//

using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

using System.Threading;
namespace Componente
{
    // La clase extiende de  MarshalByRefObject para poder usar  la semántica 
    // marshal-by-reference que nos permitira crear un objeto remoto
    public class Componente : MarshalByRefObject
    {
        // Método que imprime en la pantalal su llamada y retorna una 
        // cadena y el tiempo actual 
        public string Llamada(string texto)
        {
            Log.Imprimir("Se invoco a Componente.Llamada(\"{0}\")", texto);
            return texto + DateTime.Now.ToString("HH:mm:ss.fff");
        }
    }
}
