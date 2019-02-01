//####################################################################################################
//Practica01
//Nombre: Henry Villavicencio
//Fecha de realización: 5/10/2018
//Fecha de entrega: 12/10/2018

//Resultados:
// 1.Practica01a-Creación de hilos
//    a.¿Qué encontró al ejecutar dos veces el programa?
//
//    El hilo creado se ejecuta la primera vez hasta intervalos diferentes, a partir  de esto el hilo 
//    principal ejecuta el método ImprimirNúmeros() imprimiendo su serie de números hasta otro  punto 
//    de ejecución. No en todas las ejecuciones del programa este método imprimirNumeros() llamado por 
//    el hilo principal se ejecuta por completo.
//
//    b.¿Es el resultado el mismo? Explique el por qué? 
//   
//    No, el resultado es diferente en cada caso debido a que el sistema operativo es quien asigna de 
//    forma dinámica de acuerdo a su planificador el slot de ejecución de cada hilo.
//
//    c.Qué sucede si cambia la línea ImprimirNúmeros(); antes de la creación del hilo?
//    La ejecución del  método ImprimirNúmeros() realizada por completo, ya que el hilo es creado e 
//    inicializado una vez que este se complete.
//
// 2.Practica01b-Pausa de un Hilo
//    a.¿Qué encontró al ejecutar dos veces el programa? 
//    
//    En ambos casos no se pueden notar diferencia debido a que el hilo creado al inicio no alcanza a 
//    imprimir nada en consola.El Método llamado en el hilo principal termina su ejecución antes que 
//    el hilo creado imprima su primer mensaje en la consola.
//
//    b.¿Es el resultado el mismo? Explique el por qué?
//    
//    Si, el resultado es el mismo debido a que en ambos casos el método llamado por el hilo principal 
//    termina su proceso antes que el hilo hijo creado pueda imprimir algo en pantalla.
//
//
//    c.¿Qué diferencia hay con el caso anterior?
//    
//    El hilo solo alcanza a crearse, pero no a empezar su ejecución imprimiendo algún mensaje.
//
// 3.Practica01c-Consiguiendo que un hilo espere
//    
//    a.¿Qué encontró al ejecutar dos veces el programa?
//    
//    No existe una diferencia muy clara en ambas ejecuciones.
//    
//    b.¿Es el resultado el mismo al del código anterior Practica01b?
//    
//    No, ya que el hilo principal se ejecuta sin esperar a que un hilo creado termine con su proceso.
//
//    c.¿Qué sucede si comenta la línea hiloTrabajador.Join()? ¿Explique claramente qué sucede en este caso?
//
//    El hilo principal termina de imprimir todos sus mensajes, ya que al comentar join este no debe esperar
//    a que el hilo hijo termine con su ejecución para continuar con la suya.
//
// 4.Practica01d-Abortando un hilo
//    a.Explique claramente qué sucede en este caso
//
//    En este caso detiene y cancela la ejecución del hilo creado, terminado con el proceso que se encontraba
//    realizando.  Para que se pueda visualizar esto el hilo principal espera 6 segundos para que este se pueda 
//    ejecutar antes de abortarlo. Seguido de esto el hilo principal crea un nuevo hilo y ejecuta el método
//    impimirNumeros().
//
// 5.Practica01e-Estado de un hilo
//
//    a.Explique claramente qué sucede en este caso.
//
//    En este caso el hilo principal recupera el estado en los que se encuentra un hilo hijo y los muestra por 
//    pantalla. Durante el programa se manejan los hilos de tal manera que se pueden ver los estados de: unstarted, 
//    running, waitSleepJoin, aborted y stopped.
//
// 6.Practica01f-Hilos en el Foreground y en el Background
//
//    a.Explique claramente qué sucede en este caso.
//
//    Al finalizar la ejecución del hilo que se encuentra en foreground, el hilo en background finaliza también 
//    su ejecución a pesar de no completar su proceso.
//
// 7.Practica01g-Paso de Parámetros a un Hilo
//   
//    a.Explique claramente qué sucede en este caso.
//    
//    En cada uno de los casos analizamos las formas en las que se puede pasar parámetros a los threats, ya sea 
//    en la instancia de un objeto, en el inicio de un hilo o directamente cuando pasamos el método al hilo. Durante 
//    la ejecución de los hilos 4 y 5 podemos notar que se realiza paso por referencia ya que al modificarse el valor 
//    de la variable i el hilo numero 4 imprime el valor de 20.
//
// 8.Practica01h-Bloqueo con lock
//
//    a.Explique claramente qué sucede en este caso.
//    
//    En el código se implementan 3 hilos para dos casos de prueba, en el primer caso no se utiliza el bloqueo de tal 
//    forma que cada hilo puede acceder al recurso tal que la cuenta final sea errónea, en el segundo caso al implementar 
//    el bloqueo el recurso es accedido por un único hilo hasta terminar su proceso de tal forma que al finalizar obtenemos
//    la cuenta correcta.
//
// 9.Practica01i-Bloqueo con Monitor
//   
//    a.Explique claramente qué sucede en este caso.
//
//    En este ejemplo se puede visualizar dos casos, en el primero se causa una muerte por bloqueo debido a que dos 
//    hilos están intentando acceder a un recurso bloqueado por el otro. En el segundo caso se observa el uso de 
//    Monitor para evitar quedarse atascado brindando un temporizador para desbloquear el recurso.
//
// 10.Practica01j-Bloqueo con interlock
//    
//    a.Explique claramente qué sucede en este caso.
//
//    En el código se implementan 3 hilos para dos casos de prueba, en el primer caso no se utiliza el bloqueo de 
//    tal forma que cada hilo puede acceder al recurso tal que la cuenta final sea errónea, en el segundo caso se 
//    utiliza el método increment y decrement de la clase interlock para poder acceder al recurso compartido mediante 
//    un único hilo hasta terminar su proceso de tal forma que al finalizar obtenemos la cuenta correcta.
//Conclusiones
//
// *  Los hilos nos permiten ejecutar varios procesos de manera aparente simultánea. Aparentemente simultanea ya 
//    que en realidad el sistema operativo es quien se encarga de la asignar slots de tiempo a cada hilo durante 
//    el cual ejecutara su código
//
// *  Los hilos generados en un mismo proceso comparten recursos de memoria y procesador, por eso se debe tener 
//    cuidado al acceder y modificar un recurso compartido ya que puede generar inconsistencias en la funcionalidad 
//    del programa.Para solventar este problema se puede usar el bloqueo del recurso.
//
// *  Los hilos pueden encontrase en background y foreground.Una vez que el hilo que se encuentre en foreground 
//    termine su ejecución, automáticamente también terminara los que se encuentren en background a pesar no haber
//    completado su ejecución.
//
//Recomendaciones
//
//    * Revisar la documentación oficial de Microsoft en casos que exista dudas acerca de cómo funciona un método 
//    o cuáles son sus parámetros de entrada
//    
//    * Se debe tener cuidado al realizar varios los bloqueos, ya que si no se manejan los objetos de manera 
//    adecuada podemos causar una muerte por bloqueo.
//
//####################################################################################################


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PracticaHilos
{
    class Practica01a
    {
        static void Main(string[] args)
        {
            //se modificó el programa para usar delegados llamando al método imprimir números
            ThreadStart imprimir = new ThreadStart(ImprimirNumeros);
            //se crea el hiloTrabajador y se le pasa la instancia del delegado
            Thread hiloTrabajador = new Thread(imprimir);
            //Se inicializa el hilo 
            hiloTrabajador.Start();
            //se llama al método 
            ImprimirNumeros();
        }

        //Método que será usado para que el hilo imprima números hasta el 50 secuencialmente
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando ….");
            for (int i = 1; i < 50; i++)
                Console.WriteLine(i);
        }

    }
}
