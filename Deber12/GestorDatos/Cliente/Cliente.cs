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


using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using GestorDatos;

namespace Cliente
{
    public class Cliente
    {
        // Definimos el constructor de la clase que recibe por  
        // parametro un nombre
        public Cliente(string nombre)
        {
            // Definimos y registramos un canal para la comunicación 
            HttpChannel canal = new HttpChannel();
            ChannelServices.RegisterChannel(canal, false);
            // Realizamos la configuración del objeto remoto 
            InicializarObjetoRemoto();
            // Agregamos el nombre del cliente al objeto remoto del Gestor de datos
            this.AgregarNombre(new GestorDatos.GestorDatos(), nombre);
        }
        // Metodo Factory
        private void InicializarObjetoRemoto()
        {

            RemotingConfiguration.RegisterWellKnownClientType(typeof(GestorDatos.GestorDatos), "http://localhost:30000/GestorDatos");
        }


        // Método que permite agregar un nombre al gestor de Datos remoto  e imprimir los 
        // nombre registrados añadidos hasta el momento 
        private void AgregarNombre(GestorDatos.GestorDatos objetoRemoto, String nombre)
        {
            objetoRemoto.AgregarDato(nombre);
            ArrayList nombres = objetoRemoto.ObtenerDatos();
            foreach (string elemento in nombres)
            {
                Console.WriteLine(elemento);
            }
            Console.WriteLine();
        }

        // Método principal del programa 
        static void Main(string[] args)
        {
            // Agrega el nombre ingresado por parámetro al objeto remoto 

            Console.WriteLine("Agregando el nombre: " + args[0] + " a la lista...");
            new Cliente(args[0]);
            Console.WriteLine("Presione ENTER para concluir...");
            Console.ReadLine();
        }
    }
}