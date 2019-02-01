//####################################################################################################
//Deber11
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 26/11/2018
//Fecha de entrega: 27/11/2018
//####################################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
