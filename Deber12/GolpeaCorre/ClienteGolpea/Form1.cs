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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ObjetoRemoto;

namespace ClienteGolpea
{
    public partial class frmClienteGolpea : Form
    {

        // Declaramos el objeto remoto que tendra la lógica del juegp y las variables 
        //  de golpes y fallos 
        private Cerebro cerebroJuego;
        private int golpes, fallos;

        public frmClienteGolpea()
        {
            InitializeComponent();

            // Establece los límites del control en la ubicación y en el tamaño especificados.

            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),(Screen.GetBounds(this).Height / 2) - (this.Height / 2),
            this.Width,this.Height, BoundsSpecified.Location);
            // Definimos y registramos un canal para la comunicación 
            // Realizamos la configuración del objeto remoto 
            HttpChannel canal = new HttpChannel();
            ChannelServices.RegisterChannel(canal, false);
            InicializarObjetoRemoto();
            // Instanciamos un objeto remoto
            cerebroJuego = new Cerebro();

        }

        private void InicializarObjetoRemoto()
        {
            RemotingConfiguration.RegisterWellKnownClientType(typeof(Cerebro),"http://localhost:30000/Cerebro");
        }

        private void frmClienteGolpea_Load(object sender, EventArgs e)
        {

        }

        private void pnlPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        // Este evento se lanza cuando  el puntero del mouse está sobre 
        // el control y se presiona un botón del mouse.
        private void pnlPanel_MouseDown(object sender, MouseEventArgs e)
        {

            // Se grafica una x sobre la superficie en una posición especifica

            Graphics g = pnlPanel.CreateGraphics();
            g.DrawString("X", Font, new SolidBrush(Color.Blue), e.X, e.Y);

            cerebroJuego.AlmacenarPosicion(e.X, e.Y);
            // Si el golpe es acertado sobre el cuadrado la x se colorea el cuadrado de azul
            if (cerebroJuego.GolpeoAlCuadro(e.X, e.Y))
            {
                g.DrawString("H", Font, new SolidBrush(Color.Red), e.X, e.Y);
                golpes++;
            }
            else
            {
                fallos++;
            }
            lblGolpes.Text = "Golpes: " + golpes.ToString();
            lblFallos.Text = "Fallos: " + fallos.ToString();

        }
    }
}
