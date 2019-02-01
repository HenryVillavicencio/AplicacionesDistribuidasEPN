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
    class Practica01b
    {
        static void Main(string[] args)
        {
            //se crea el hiloTrabajador y se llama al método Imprimir numeros con retardo, se inicializa el hilo
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);
            hiloTrabajador.Start();
            //se llama al método para visualizar los números en la pantalla 
            ImprimirNumeros();
        }

        //se crea el método para imprimir numeros secuencialmente sin retardo
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando ….");
            for (int i = 1; i < 10; i++)
                Console.WriteLine(i);
        }

        //se crea el método para imprimir números secuencialmente con retardos de 2s
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezand0 ….");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
    }
}
