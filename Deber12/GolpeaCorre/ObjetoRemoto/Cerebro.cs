// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// Golpea y Corre / Hit and Run// RESULTADOS:
// El programa ejecuta un juego que consiste en acertar golpes a un cuadrado que se mueve 
// de manera aleatoria en la pantalla si se acierta la posición del cuadro marca como golpes caso 
// contrarios estos seran marcados como fallidos. 
// CONCLUSIONES:
// Los objetos remotos de netremoting sindleton nos permiten intercambiar el estado de un objeto remoto 
// entre varios clientes, que suelen ser muy utiles para programas como este juego 
// RECOMENDACIONES:
// Verificar que la configuracion de remoting sehaya realizado correctamente en el lado del cliente como el servidor
// Revisar la documentaci;on oficial de microsoft en caso de ener dudas

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Threading;



namespace ObjetoRemoto
{
    // La clase extiende de  MarshalByRefObject para poder usar  la semántica 
    // marshal-by-reference que nos permitira crear un objeto remoto
    public class Cerebro : MarshalByRefObject
    {
        // Declaramos los atributos de clase que seran usados para la lógica del juego
        private int xPos, yPos;
        private int x, y;
        private Thread hilo;
        private Random aleatorio;
        private int dimensionCuadrado = 50;

        // Definimos el constructor de la clase 
        public Cerebro()
        {
            // Generamso números aleatorios 
            aleatorio = new Random();
            for (int i = 0; i < 500000; i++)
            {
                aleatorio.Next(100000);
            }
            // Instaciamso el hilo que ejecutara el método moveposicion
            hilo = new Thread(new ThreadStart(MoverPosicion));
            hilo.Start();
        }


        // Getters y Setters
        public int POSX
        {
            get
            {
                return xPos;
            }
        }
        public int POSY
        {
            get
            {
                return yPos;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }
        public int Dimensiones
        {
            get
            {
                return dimensionCuadrado;
            }
        }

        // Este método nos permite almacenar la posición 

        public void AlmacenarPosicion(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Este método devuelve un dato booleano  que indica si se realizo o no el golpe  
        public bool GolpeoAlCuadro(int x, int y)
        {
            return (x >= POSX && x <= POSX + dimensionCuadrado)
           && (y >= POSY && y <= POSY + dimensionCuadrado);
        }

        // Este método mueve la posición de forma aleatoria del cuadrado 
        // cada 2 segundos
        public void MoverPosicion()
        {
            while (true)
            {
                Thread.Sleep(2000);
                xPos = aleatorio.Next(225);
                yPos = aleatorio.Next(150);
            }
        }
    }
}