// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Collections;

using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ObjetoRemoto;

namespace ClienteCorre
{
    public partial class frmClienteCorre : Form
    {
        // Declaramos el objeto remoto que tendra la lógica del juego 

        private Cerebro cerebroJuego;
        private Thread hilo;

        public frmClienteCorre()
        {
            InitializeComponent();

            // Establece los límites del control en la ubicación y en el tamaño especificados.
            this.SetBounds(0, 0, this.Width, this.Height);
            // Definimos y registramos un canal para la comunicación 
            // Realizamos la configuración del objeto remoto 
            HttpChannel canal = new HttpChannel();
            ChannelServices.RegisterChannel(canal, false);
            InicializarObjetoRemoto();
            // Instanciamos un objeto remoto
            cerebroJuego = new Cerebro();
            // Instanciamos el hilo que nos permitira manejar el pulso realizado por el jugador
            hilo = new Thread(new ThreadStart(Pulso));
            hilo.Start();

        }

        private void InicializarObjetoRemoto()
        {
            RemotingConfiguration.RegisterWellKnownClientType(typeof(Cerebro),"http://localhost:30000/Cerebro");
        }

        // Invalida todo el contenido del panel y hace que se vuelva a dibujar su contenido
        private void Pulso()
        {
            while (true)
            {
                Thread.Sleep(500);
                pnlPanel.Invalidate();
            }
        }


        // Este método ocurre cuando el panel debe redibujarse
        private void pnlPanel_Paint(object sender, PaintEventArgs e)
        {

            // Dibujamos un cuadrado en la posicion especificada 
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(new SolidBrush(Color.Blue)),
           cerebroJuego.POSX, cerebroJuego.POSY, cerebroJuego.Dimensiones,
           cerebroJuego.Dimensiones);
            // Dibujamos una x que representa el golpe anterior
            if (cerebroJuego.X != 0 && cerebroJuego.Y != 0)
            {
                g.DrawString(
                "X",
                Font,
                new SolidBrush(Color.Red),
                cerebroJuego.X,
                cerebroJuego.Y);
            }

        }

        private void frmClienteCorre_Load(object sender, EventArgs e)
        {

        }
    }
}
