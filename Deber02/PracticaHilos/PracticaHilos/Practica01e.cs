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
    class Practica01e
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Empezando el programa");
            //se crea el primer hilo y se le pasa el método Imprimir Números con retardo
            Thread primerHilo = new Thread(ImprimirNumerosConRetardo);
            //se crea el segundo hilo y se le pasa el método no hace nada que lo pone a dormir por dos segundos
            Thread segundoHilo = new Thread(NoHaceNada);
            //se imprime el estado del primer hilo
            Console.WriteLine(primerHilo.ThreadState.ToString());
            //se inicializa el primer hilo
            primerHilo.Start();
            // se inicializa el segundo hilo después de enviarlo a dormir
            segundoHilo.Start();
            // se imprime secuencialmente las iteraciones conjuntamente con el estado del primer hilo 
            for (int i = 1; i < 30; i++)
                Console.WriteLine(primerHilo.ThreadState.ToString());
            //se envía a dormir al hilo principal por seis segundos para poder denotar la acción de aborto del primer hilo
            Thread.Sleep(TimeSpan.FromSeconds(6));
            //se aborta el primer hilo
            primerHilo.Abort();
            Console.WriteLine("El primer hilo ha abortado!");
            //se imprime el estado del primer hilo
            Console.WriteLine(primerHilo.ThreadState.ToString());
            //se imprime el estado del segundo hilo
            Console.WriteLine(segundoHilo.ThreadState.ToString());

        }

        //se crea el método imprimir numeros con retardo que lo ejecutará el primer hilo
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando ….");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }

        // se crea el método no hace nada que envía a dormir al hilo y será ejecutado por el segundo hilo
        static void NoHaceNada()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
