//####################################################################################################
//Practica01
//Nombre: Henry Villavicencio
//Fecha de realización: 5/10/2018
//Fecha de entrega: 12/10/2018
//####################################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PracticaHilos
{
    class Practica01f
    {

        static void Main(string[] args)
        {
            //se instancia la clase EjemploHilo
            var hiloForeground = new EjemploHilo(10);
            var hiloBackground = new EjemploHilo(20);
            //se crea un hilo con el método Contar del objeto Foreground y se le asigna un nombre para hacerlo más amigable
            var hiloUno = new Thread(hiloForeground.Contar);
            hiloUno.Name = "hilo Foreground";
            //se crea un hilo con el método Contar del objeto Background y se le asigna un nombre para hacerlo más amigable
            var hiloDos = new Thread(hiloBackground.Contar);
            hiloDos.Name = "hilo Background";
            //le mando al hilo dos a background para que cuando hilo uno termine su ejecución hilo dos también lo haga
            hiloDos.IsBackground = true;
            //se inicializan los hilos uno y dos
            hiloUno.Start();
            hiloDos.Start();
        }

        //se crea la clase EjemploHilo
        // Cambio la clase estaba mal definida, una clase no lleva () acontinuación del nombre.

        class EjemploHilo
        {
            private readonly int numIteraciones;

            //se crea el constructor de la clase
            public EjemploHilo(int iteraciones)
            {
                numIteraciones = iteraciones;
            }

            //se crea el método contar que será usado por los dos hilos.
            public void Contar()
            {
                for (int i = 0; i < numIteraciones; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    Console.WriteLine("{0}imprime {1}", Thread.CurrentThread.Name, i);
                }
            }

        }
    }
}

