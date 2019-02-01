// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************

// Excepciones 
// RESULTADOS:
//El programa cliente genera dos exepcione generada remotamente y que deberián 
//ser controladas en el lado del servidor, su respuesta por el contrario se 
//transmite y muestra en el lado del cliente
// CONCLUSIONES: 
// Las exepciones remotas nos permiten capturar y tratar en el lado del servidor posible errores generados 
// RECOMENDACIONES:
// Verificar que la configuración de net remoting se encuentra correctamente realizada tanto en el lado del 
// servidor como el cliente 


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
        // Método que lanza una exepción remota
        public void LlamadaUno()
        {
            throw new ExcepcionRemota("Texto para excepción generica","Texto Extra");
        }
        // Método que lanza una exepción estándar
        public void LlamadaDos()
        {
            throw new Exception("Texto para excepción estandar");
        }
    }
}