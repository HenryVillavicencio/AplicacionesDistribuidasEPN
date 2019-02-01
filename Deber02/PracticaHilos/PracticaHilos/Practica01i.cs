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
    class Practica01i
    {
        static void Main(string[] args)
        {
            // creamos e iniciamos un hilo del método DemasiadosBloqueos el cual recibe
            // como parámetro los objetos bloqueo1 y 2
            object bloqueo1 = new object();
            object bloqueo2 = new object();
            new Thread(() => DemasiadosBloqueos(bloqueo1, bloqueo2)).Start();

            // bloqueamos esta sección de codigo usando como 
            // objeto sincronizador el objeto bloqueo2
            // con la ayuda de monitor esperamos un tiempo para ver si podemos acceder al 
            // objeto bloqueado 

            lock (bloqueo2)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Monitor.TryEnter permite no quedarse atascado, retornado falso depuesta de que el timeout ha expirado");
                if (Monitor.TryEnter(bloqueo1,TimeSpan.FromSeconds(5)))
                {
                    Console.WriteLine("Desbloqueo del recurso exitoso");
                }
                else
                {
                    Console.WriteLine("Temporizador no se cumple!");
                }
            }


            Console.WriteLine("----");

            

            new Thread(() => DemasiadosBloqueos(bloqueo1, bloqueo2)).Start();

            // En este caso se causa una muerte del programa debido a que cada hilo 
            // intenta acceder a un recurso bloqueado por el otro 
            lock (bloqueo2)
            {
                Console.WriteLine("Aquí viene una muerte por bloqueo DEADLOCK");
                Thread.Sleep(1000);

                lock (bloqueo1)
                {
                    Console.WriteLine("Desbloqueo del recurso exitoso");
                }
            }
            var c = new Contador();
            var t1 = new Thread(() => Prueba(c));
            var t2 = new Thread(() => Prueba(c));
        }

        // Método raliza varios bloqueos anidados 
        // Espera 1 segundo para que el objeto bloqueo1
        // usado para la sincronización sea desbloqueado 
        static void DemasiadosBloqueos(object bloqueo1, object bloqueo2)
        {

            lock (bloqueo1)
            {
                Thread.Sleep(1000);
                lock (bloqueo2);
            }

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

        // Creamos la clase abstracta ContadorBase e 
        // indicamos la firma de sus métodos
        abstract class ContadorBase
        {
            public abstract void Incrementar();
            public abstract void Decrementar();
        }
    }
}
