// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************

// Objetos Móviles y Objetos Remotos// Resultados: 
// En primera intancia el programa no devuelve el resultado esperado, esto es debido a que en la hoja guia se 
// omite la configuración de remoting para el cliente. Al agregar la correcta configuracion podemos observa el 
// correcto funcionamiento del mismo. Donde el programa cliente crea un objeto remoto componente el cual al ejecutar 
// su metodo recibe y envia un objeto móvil del tipo contenedor los cuales se pueden apreciar en el servidor como 
// el cliente.
// Conclusiones:
// Los objetos moviles permiten crean aplicaciones que pueden intercambiar objetos  que seran enviados a través 
// de la red ejecutandose entre diferentes appdomains
// Recomendaciones: 
// Verificar que en los archivos de configuracion se encuentren correctamente definido los parámetros de net remoting
// Usar la documentación de microsoft en caso de existir dudas en la implementación de alguna clase o método

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Componente
{

    // La clase extiende de  MarshalByRefObject para poder usar  la semántica 
    // marshal-by-reference que nos permitira crear un objeto remoto
    public class Componente : MarshalByRefObject
    {
        // Método que devuelve un objeto remoto del tipo contenedor
        public Contenedor RetornaContenedor(Contenedor entrada)
        {
            Log.Imprimir("Se invoco RetornaContenedor(), se obtuvo {0}", entrada);
            return new Contenedor("abc", 123);
        }
    }
}