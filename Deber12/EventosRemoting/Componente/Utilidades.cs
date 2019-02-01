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
    public class Utilidades
    {
        // Método que imprime en los logs de pantalla el nombre del tipo de dato de cada uno de los 
        // elementos contenidos en un array de datos 
        private static void MostrarTipoDeDatos(Array arregloDatos)
        {
            foreach (object obj in arregloDatos)
            {
                Log.Imprimir(" {0}: {1}", obj.GetType().Name, obj);
            }
        }

        // Método que recupera la información acerca del tipo de los objetos definidos, configurados  
        // para el programa que usa net remoting 
        public static void MostrarTodosLosDatos()
        {
            Log.Imprimir("TIPOS DE DATOS REGISTRADOS EN REMOTING -(INICIO)- ---------");
            // Recupera los tipos de objetos registrados en el cliente como tipos que se activarán 
            // de forma remota
            MostrarTipoDeDatos(RemotingConfiguration.GetRegisteredActivatedClientTypes());
            // Recupera los tipos de objetos registrados en el servicio que se pueden activar 
            // cuando lo solicita un cliente.
            MostrarTipoDeDatos(RemotingConfiguration.GetRegisteredActivatedServiceTypes());
            // Recupera los tipos de objetos registrados en el cliente como tipos conocidos (WellKnown)
            MostrarTipoDeDatos(RemotingConfiguration.GetRegisteredWellKnownClientTypes());
            // Recupera los  tipos de objetos registrados en el servicio como tipos conocidos (WellKnown) 
            MostrarTipoDeDatos(RemotingConfiguration.GetRegisteredWellKnownServiceTypes());
            Log.Imprimir("TIPOS DE DATOS REGISTRADOS EN REMOTING -(FIN)- ---------");
        }
    }
}
