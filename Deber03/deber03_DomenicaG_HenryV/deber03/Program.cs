//####################################################################################################
//Practica01
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 5/10/2018
//Fecha de entrega: 12/10/2018
//Resultados 
//•	Los hilos creados imprimen los múltiplos de 5 y 7 que se encuentran en el intervalo de -10 y 50 
//
//Conclusiones
//•	Gracias a los conocimientos sobre hilos adquiridos en clase y en la práctica realizada hemos 
//    podido implementar un ejercicio sencillo de creación de hilos
//•	Los hilos nos permiten ejecutar varios procesos a la par y ejecutarlos al mismo de forma simultanea
//
//Recomendación
//•	Revisar la documentación oficial de Microsoft en casos que exista dudas acerca de cómo se debe 
//    realizar alguna operación con hilos.
//
//####################################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace deber03
{
    class Program
    {
        static void Main(string[] args)
        {
            //creación hilo uno y paso del método imprimir multiplos de cinco
            Thread hiloUno = new Thread(imprimirMultiplosCinco);
            //asignación de nombre al hilo uno
            hiloUno.Name = "Hilo uno";
            //inicialización del hilo uno
            hiloUno.Start();
            //creación del hilo dos y paso del método imprimir multiplos de siete
            Thread hiloDos = new Thread(imprimirMultiplosSiete);
            //asignación de nombre al hilo dos
            hiloDos.Name = "Hilo dos";
            //inicialización  del hilo dos
            hiloDos.Start();

        }

        // Metodo que cuenta desde -10 a 50 e imprimi los multiplos de 5
        static void imprimirMultiplosCinco()
        {
            for (int i = -10; i <= 50; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine("{0} {1}", Thread.CurrentThread.Name, i);
                }
            }
        }

        // Metodo que cuenta desde -10 a 50 e imprimi los multiplos de 7

        static void imprimirMultiplosSiete()
        {
            for (int i = -10; i <= 50; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine("{0} {1}", Thread.CurrentThread.Name, i);
                }
            }
        }


    }
}
