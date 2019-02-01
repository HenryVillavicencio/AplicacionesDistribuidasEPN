//####################################################################################################
//Deber13
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 03/12/2018
//Fecha de entrega: 03/12/2018
//####################################################################################################

// RESULTADOS:
// El cliente haciendo uso de netremoting puede manipular el componente, a través del protocolo TCP
//usando un objeto CAO.
//
// CONCLUSIONES:
// 
// Se modificó el componente de tal forma que el cliente se crea de forma remota como se puede observar
// al recuperar el dominio
// 
// RECOMENDACIONES: 
// Verificar el Assembly de nuestro componente de tal forma que no exista errores en la configuración de netremoting
// Verificar que la sintaxis de las consultas SQL sea correcta
// En caso de tener dudas acudir a la documentación oficial de microsof 
// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Componente;
using System.Runtime.Remoting;

namespace Cliente
{
    public partial class Form1 : Form
    {
        // Objeto que sera usado para realizar las consultas a la base de datos
        
        Componente.ClienteBd clienteBdd;
            

        public Form1()
        {
            InitializeComponent();

            //  Intanciamos el Objeto Cliente BD con la cadena de conexion de la base de datos
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Se carga la configuración e instancio un objeto remoto
            RemotingConfiguration.Configure("Cliente.exe.config", false);
            clienteBdd = new ClienteBd("Data Source=GNIRUTNALA\\SQLEXPRESS;Initial Catalog=DbMatriculas;Integrated Security=True");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Recupera el id ingresado por la GUI  y realiza una consulta a la base
            EstudianteDetalle cliente = clienteBdd.ObtenerCliente(Convert.ToInt32(tbxId.Text));
            // Si se encontro algún alumno con el id indicado se llenan los 
            // textbox de la GUI con la informacion recuperada
            tbxNombre.Text = cliente.Nombre;
            tbxApellido.Text = cliente.Apellido;
            tbxCedula.Text = cliente.Cedula;
            tbxPassword.Text = cliente.Password;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Instanciamos un nuevo objeto Estudiante con la informacion repuerada 
            // de los textbox de la GUI
            EstudianteDetalle cliente = new EstudianteDetalle(
                Convert.ToInt32(tbxId.Text),
                tbxNombre.Text,
                tbxApellido.Text,
                tbxCedula.Text,
                true,
                tbxPassword.Text
                );

            // Borramos el contenido en la GUI
            tbxId.Text = "";
            tbxNombre.Text = "";
            tbxApellido.Text = "";
            tbxCedula.Text = "";
            tbxPassword.Text = "";
            // Actualiza el actributo Activo de un estudiante en  la base de datos 

            if (!clienteBdd.Eliminar(cliente))
            {
                MessageBox.Show("Cliente Eliminado ;)");
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Instanciamos un nuevo objeto Estudiante con la informacion repuerada 
            // de los textbox de la GUI
            EstudianteDetalle cliente = new EstudianteDetalle(
               Convert.ToInt32(tbxId.Text),
               tbxNombre.Text,
               tbxApellido.Text,
               tbxCedula.Text,
               true,
               tbxPassword.Text
               );
            // Actualizamos la informacion del estudiante en la base de datos
            if (!clienteBdd.Modificar(cliente))
            {
                MessageBox.Show("Cliente Actualizado ;)");
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Instanciamos un nuevo objeto Estudiante con la informacion repuerada 
            // de los textbox de la GUI
            EstudianteDetalle cliente = new EstudianteDetalle(
               Convert.ToInt32(tbxId.Text),
               tbxNombre.Text,
               tbxApellido.Text,
               tbxCedula.Text,
               true,
               tbxPassword.Text
               );
            // Insertamos un nuevo estudiante en la base de datos

            if (!clienteBdd.AgregarEstudiante(cliente))
            {
                MessageBox.Show("Cliente Agregado ;)");
            }
        }

        private void btndominio_Click(object sender, EventArgs e)
        {
            //obtiene el dominio en el cual se está realizando el proceso
            MessageBox.Show(clienteBdd.ObtenerDominioActual());
        }
    }
}
