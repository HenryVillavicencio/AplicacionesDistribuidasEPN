//####################################################################################################
//Deber17
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: /12/2018
//Fecha de entrega: /12/2018
//####################################################################################################

// RESULTADO:
// El formulario web creado con ASP. NET permite  manipular el componente, a través de una interfaz que se
// presenta en el navegador. EL formulario permite obtener, eliminar, actualizar y crear un estudiante en la 
// base de datos 
//
// CONCLUSIONE:
// 
// Se utilizo el componente, para poder utilizar varios metodos y acceder a la base de datos desde un formulario 
// web creado con ASP. net

// 
// RECOMENDACIONES: 
// Verificar que los id de los elelementos creados en la GUI sean los correctos 
// Verificar que si el componente usa la  base de datos, el servicio sql este activo. 
// En caso de tener dudas acudir a la documentación oficial de microsof 
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Componente;
namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClienteBd clienteBdd = new ClienteBd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnObtener_Click(object sender, EventArgs e)
        {
            EstudianteDetalle cliente = clienteBdd.ObtenerCliente(Convert.ToInt32(tbxId.Text));
            // Si se encontro algún alumno con el id indicado se llenan los 
            // textbox de la GUI con la informacion recuperada
            tbxNombre.Text = cliente.Nombre;
            tbxApellido.Text = cliente.Apellido;
            tbxCedula.Text = cliente.Cedula;
            tbxPassword.Text = cliente.Password;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
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
                Response.Write("<script>alert('Cliente Eliminado')</script>");
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
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
                Response.Write("<script>alert('Cliente Actualizado')</script>");
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
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
                Response.Write("<script>alert('Cliente Agregado')</script>");
            }
        }
    }
}