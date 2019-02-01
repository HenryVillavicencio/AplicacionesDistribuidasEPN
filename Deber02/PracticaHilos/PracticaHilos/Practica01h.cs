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
    class Practica01h
    {
        static void Main(string[] args)
        {
            // Creamos una nueva instacia del objeto Contador
            var c = new Contador();
            // Creamos tres hilos con el método Prueba
            // y le pasamos como parámetro el objeto c como referencia
            var t1 = new Thread(() => Prueba(c));
            var t2 = new Thread(() => Prueba(c));
            var t3 = new Thread(() => Prueba(c));

            // Iniciamos los 3 hilos
            // con join se ejecutan los tres hilos antes de que continue el hilo principal  

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Cuenta Total: {0}", c.Contar);
            Console.WriteLine("------");
            Console.WriteLine("Contador correcto");

            // Creamos y ejecutamos los hilos de forma similiar al codigo anterior 
            // pero en este caso le pasamos como parámetro el objeto con el bloqueo 
            
            var c1 = new ContadorConBloqueo();
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
            public int Contar { get; private set; }

            // Implementamos los métodos definidos en la clase base 
            // Método que incrementa el contador
            public override void Incrementar()
            {
                Contar++;
            }
            // Método que decrementa el contador
            public override void Decrementar()
            {
                Contar--;
            }
        }

        // Definimos la clase ContadorConBloqueo, la misma que extiende de ContadorBase
        class ContadorConBloqueo : ContadorBase
        {
            private readonly object objetoSincronizador = new Object();
            public int Contar { get; private set; }

            // Implementamos los métodos definidos en la clase base 
            // Método que incrementa el contador 
            // utilizamos block para  evitar que varios hilos accedan al contador
            public override void Incrementar()
            {
                lock (objetoSincronizador)
                {
                    Contar++;
                }
            }
            // Método que decrementa el contador

            public override void Decrementar()
            {
                lock (objetoSincronizador)
                {
                    Contar--;
                }
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
