//####################################################################################################
//Deber17
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: /12/2018
//Fecha de entrega: /12/2018
//####################################################################################################

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente
{
    public class ClienteBd : MarshalByRefObject
    {
        SqlConnection miConexion ;

        // Creamos un constructor el cual permite definir la cadena de conexion 
        // de la base a la cual queremos conectarnos
        public ClienteBd(String cadenaConexion)
        {
            this.miConexion = new SqlConnection(cadenaConexion);
        }

        public ClienteBd()
        {
            this.miConexion = new SqlConnection("Data Source=GNIRUTNALA\\SQLEXPRESS;Initial Catalog=DbMatriculas;Integrated Security=True");
        }


        // El medotodo nos permite actualizar los datos de un estudiante en la base de datos
        public bool Modificar(EstudianteDetalle cliente)
        {

            string consulta = "UPDATE Estudiantes SET Nombre= '"+cliente.Nombre+"',Apellido='"+cliente.Apellido+"', Cedula ='"+ cliente.Cedula
                +"', password='"+cliente.Password+ "' WHERE IdEstudiante=" + cliente.Id + ";";
            return Consulta(consulta);
        }

        // El metodo nos pemite actualizar el campo Activo en la base de tal forma 
        // que se lo tome encuenta como eliminado 
        public bool Eliminar(EstudianteDetalle cliente)
        {
            string consulta = "UPDATE Estudiantes SET Activo = 0  WHERE IdEstudiante=" + cliente.Id +";" ;
            return Consulta(consulta);
        }


        // Nos permite realizar una consulta a la base de datos y obtener informacion de un estudiante 
        // Si el estudiante existe en la base de datos retorna un objeto estudiante con la informacion 
        // devuelta por la base
        public EstudianteDetalle ObtenerCliente(int id)
        {

            EstudianteDetalle cliente = new EstudianteDetalle();
            string consulta = "SELECT * FROM Estudiantes WHERE IdEstudiante=" + id + " and Activo = 1;";
            SqlCommand comando = new SqlCommand(consulta, miConexion);
            miConexion.Open();
            // using define el scope del obejto y lo destruye de forma forzada
            // alfinalizar este
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                // Si la consulta contiene columnas con datos
                if (lector.HasRows)
                {
                    // Modificamos los atributos del objeto con la informacion devuelta por la
                    // base de datos
                    while (lector.Read())
                    {
                        cliente.Nombre = lector.GetString(1);
                        cliente.Apellido = lector.GetString(2);
                        cliente.Cedula = lector.GetString(3);
                        cliente.Password= lector.GetString(4);
                    }
                }
                miConexion.Close();
            }

            return cliente;
        }


        // Ejecutamos un query a la base de datos y retornamos si se pudo realizar o no  

        private bool Consulta(string consulta)
        {
            int numfilas = 0;
            SqlCommand comando = new SqlCommand(consulta, miConexion);
            miConexion.Open();
            comando.ExecuteNonQuery();
            miConexion.Close();
            if (numfilas != 1)
                return false;
            return true;
        }

        // metodo que nos permite inserta un nuevo estudiante en la tabla 
        public bool AgregarEstudiante(EstudianteDetalle nuevo)
        {
            string consulta = "INSERT INTO Estudiantes (Nombre,Apellido,Cedula,Activo,Password) VALUES('" + nuevo.Nombre + "','" + nuevo.Apellido 
                + "',"+ nuevo.Cedula +", 1 ,'" + nuevo.Password+ "');";
            return Consulta(consulta);
        }

        // 
        public string ObtenerDominioActual()
        {
            //Para saber en que dominio se esta trabajando
            return AppDomain.CurrentDomain.FriendlyName;
        }


    }
}
