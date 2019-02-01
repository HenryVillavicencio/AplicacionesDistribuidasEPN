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

namespace Cliente
{
    public partial class frmLogin : Form
    {
        // Declaramos un atributo para el nombre de usuario
        private string nombreUsuario;
        public frmLogin()
        {
            InitializeComponent();
        }

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }

        // Asignamos el nombre ingresado en el textbox
        // a la cadena nombreUsuario
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text != null)
            {
                this.NombreUsuario = txtNombreUsuario.Text;
            }
        }
    }
}
