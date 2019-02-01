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
    class Practica01c
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Empezando");
            //se crea el hiloTrabajador y se le pasa el método imprimir números con retardo, se inicializa el hilo
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);
            hiloTrabajador.Start();
            //El hilo trabajador terminará su proceso antes de devolver el control al hilo principal
            hiloTrabajador.Join();
            //Mensaje que denota la finalización del hilo principal
            Console.WriteLine("Ejecución de hilo principal finalizada");
        }

        //Método que muestra números en pantalla secuencialmente y con retardos, que será llamado por el hilo trabajador
        //y será ejecutado hasta que el hilo termine 
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando ….");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }
    }
}
