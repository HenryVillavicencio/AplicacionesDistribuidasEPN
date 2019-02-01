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
using System.Runtime.Remoting;

namespace Componente
{
  
    /// Clase publica Utilidades
    public class Utilidades
    {
       
        /// Metodo MostrarTipoDeDatos que muestra los tipos de datos que esta en un arreglo
        private static void MostrarTipoDeDatos(Array arregloDatos)
        {
            foreach (object obj in arregloDatos)
            {
                //Llamada al metodo Imprimir de la clase Log
                Log.Imprimir("{0}: {1}", obj.GetType().Name, obj);
            }
        }
 
        /// Metodo MostrarTodosLosDatos
        public static void MostrarTodosLosDatos()
        {
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("TIPOS DE DATOS REGISTRADOS EN REMOTING -(INICIO)- ----------");
            //llamada al metodo MostrarTipoDeDatos que obtiene los tipos de datos de la comunicacion remota
            MostrarTipoDeDatos(RemotingConfiguration.GetRegisteredActivatedClientTypes());
            //llamada al metodo MostrarTipoDeDatos que obtiene los tipos de datos de la comunicacion remota
            MostrarTipoDeDatos(RemotingConfiguration.GetRegisteredActivatedServiceTypes());
            //llamada al metodo MostrarTipoDeDatos que obtiene los tipos de datos de la comunicacion remota
            MostrarTipoDeDatos(RemotingConfiguration.GetRegisteredWellKnownClientTypes());
            //llamada al metodo MostrarTipoDeDatos que obtiene los tipos de datos de la comunicacion remota
            MostrarTipoDeDatos(RemotingConfiguration.GetRegisteredWellKnownServiceTypes());
            //Llamada al metodo Imprimir de la clase Log
            Log.Imprimir("TIPOS DE DATOS REGISTRADOS EN REMOTIN -(FIN)- ----------");
        }
    }
}

