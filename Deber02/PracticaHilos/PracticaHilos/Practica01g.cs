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
    class Practica01g
    {
        static void Main(string[] args)
        {
            //se instancia la clase HiloEjemplo con el valor de 10 como parámetro de entrada
            var ejemplo = new HiloEjemplo(10);
            //creación hilo del metodo ejemplo.contar
            var hiloUno = new Thread(ejemplo.Contar);
            //asignación nombre hilo creado
            hiloUno.Name = "hilo Primero";
            //iniciación hilo uno
            hiloUno.Start();
            //hilo principal espera que se ejecute el hilo uno antes de continuar con su proceso
            hiloUno.Join(); 
            Console.WriteLine("------");

            // Creación hilo dos con el método contar de manera similar al caso anterior 
            var hiloDos = new Thread(Contar); 
            hiloDos.Name = "hilo Dos"; 
            // Pasamos el parámetro de entrada al hilo dos
            hiloDos.Start(8);  
            hiloDos.Join();
            Console.WriteLine("------");

            // Creación hilo tres con una función anonima contarNumeros de manera similar al caso anterior 
            // pasamos como parámetro el valor de  12
            var hiloTres = new Thread(() => ContarNumeros(12));
            hiloTres.Name = "hilo Tres";
            hiloTres.Start();
            hiloTres.Join();
            Console.WriteLine("------");

            int i = 10;
            
            // Creación hilo cuatro de manera similar al caso anterior 
            // pasamos como parámetro la variable i

            var hiloCuatro = new Thread(() => ImprimirNumeros(i));
            // modificamos el valor de variable i 
            i = 20;
            var hiloCinco = new Thread(() => ImprimirNumeros(i));
            hiloCuatro.Start();
            hiloCinco.Start();

        }

        static void Contar(object iteraciones)
        {
            //llama al método y  le pasa como parámetro el objeto iteraciones  
            ContarNumeros((int)iteraciones);
        }
        // Método que imprime el nombre del hilo actual y la iteración correspondiente
        // espera 1/2 entre cada impresión 
        static void ContarNumeros(int iteraciones)
        {
            for (int i = 1; i <= iteraciones; i++)
            {
                //Faltaba un paréntesis
                Thread.Sleep(TimeSpan.FromSeconds(0.5));  
                Console.WriteLine("{0} imprime {1}", Thread.CurrentThread.Name, i);
            }
        }
        static void ImprimirNumeros(int numero)
        {
            Console.WriteLine(numero);
        }
        class HiloEjemplo
        {
            private readonly int numIteraciones;

            // El constructor estaba mal definido, el nombre debe ser el mismo de la clase.
            public HiloEjemplo(int iteraciones) 
            {
                numIteraciones = iteraciones;
            }
            // Método que imprime el nombre del hilo actual y la iteración correspondiente
            public void Contar()
            {
                for (int i = 0; i < numIteraciones; i++)
                {
                    // Correción faltaba un parentesis
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));  
                    Console.WriteLine("{0} imprime {1}",Thread.CurrentThread.Name, i);
                }
            }

        }

    }
}
