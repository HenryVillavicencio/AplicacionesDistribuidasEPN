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
    class Practica01j
    {
        static void Main(string[] args)
        {

            // Creamos una nueva instacia del objeto Contador
            // Iniciamos los 3 hilos
            // con join se ejecutan los tres hilos antes de que continue el hilo principal  

            Console.WriteLine("Contador Incorrecto");
            var c = new Contador();
            var t1 = new Thread(() => Prueba(c));
            var t2 = new Thread(() => Prueba(c));
            var t3 = new Thread(() => Prueba(c));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Cuenta Total: {0}", c.Contar);

            Console.WriteLine("------");


            // Creamos y ejecutamos los hilos de forma similiar al codigo anterior 
            // pero en este caso la claseSinBloqueo implementa los métodos de increment 
            // y decrement de Interlock para poder acceder al recurso.

            Console.WriteLine("Contador correcto");

            var c1 = new ContadorSinBloqueo();
            t1 = new Thread(() => Prueba(c1));
            t2 = new Thread(() => Prueba(c1));
            t3 = new Thread(() => Prueba(c1));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Cuenta Total: {0}", c1.Contar);
            Console.WriteLine("------");
        }

        // Método que llama 100000 al metodo incrementar y decrementar 
        // del objeto c pasado como parámetro
        static void Prueba(ContadorBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Incrementar();
                c.Decrementar();
            }
        }


        // Definimos la clase Contador, la misma que extiende de ContadorBase

        class Contador : ContadorBase
        {
            private int contar;
            public int Contar { get { return contar; } }
            // Implementamos los métodos definidos en la clase base 
            // Método que incrementa el contador
            public override void Incrementar()
            {
                contar++;
            }
            // Método que decrementa el contador
            public override void Decrementar()
            {
                contar--;
            }
        }

        // Definimos la clase ContadorSinBloqueo, la misma que extiende de ContadorBase

        class ContadorSinBloqueo : ContadorBase
        {
            private int contar;
            public int Contar { get { return contar; } }
            // Implementamos los métodos definidos en la clase base 
            // con interlockep para poder aceder al recurso compartido
            public override void Incrementar()
            {
                Interlocked.Increment(ref contar);
            }
            public override void Decrementar()
            {
                Interlocked.Decrement(ref contar);
            }
        }

        // Creamos la clase abstracta ContadorBase e 
        // indicamos la firma de sus métodos
        abstract class ContadorBase
        {
            public abstract void Incrementar();
            public abstract void Decrementar();
        }
    }
}
