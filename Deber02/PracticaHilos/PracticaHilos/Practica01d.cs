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
    class Practica01d
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Empezando el programa");
            //se crea el hiloTrabajador y se le pasa el método Imprimir Numeros con retardo
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);
            //se inicializa el hilo
            hiloTrabajador.Start();
            //se envía a dormir al hilo principal por 6 segundos para que se pueda visualizar el aborto del hilo
            Thread.Sleep(TimeSpan.FromSeconds(6));
            //se aborta el hilo
            hiloTrabajador.Abort();
            Console.WriteLine("El hilo trabajador ha abortado!");

            //se crea un segundo hilo y se le pasa el método imprimir números
            Thread hiloTrabajador2 = new Thread(ImprimirNumeros);
            //se inicializa el hilo
            hiloTrabajador2.Start();
            // se llama al método
            ImprimirNumeros();
        }


        //método para imprimir Números con Retardo que será llamado por el hiloTrabajador
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezand0 ….");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }

        //método para imprimir Números sin retardo que será llamado por el hiloTrabajador2 y el hilo principal
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando ….");
            for (int i = 1; i < 10; i++)
                Console.WriteLine(i);
        }

    }
}
