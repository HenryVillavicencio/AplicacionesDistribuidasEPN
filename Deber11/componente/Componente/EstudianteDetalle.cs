//####################################################################################################
//Deber13
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 03/12/2018
//Fecha de entrega: 03/12/2018
//####################################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente
{
    [Serializable]
    // Definimos la clase estudiante y extendemos de MarshalByRefObject
    // de tal forma que pueda ser un obeto serializable que se pueda enviar por la red
    public class EstudianteDetalle : MarshalByRefObject
    {
        // Definimos loa atributos del Estudiante 
        private int id;
        private string nombre;
        private string apellido;
        private string cedula;
        // Marcamos este atributo como no serializable de tal forma que no se enviee por la red 
        [NonSerialized] private string password;
        private bool activo;

        // Creamos los diferentes constructores que utilizaremos para instaciar nuestaras clases
        // de acuerdo a nuestras necesidades 
        public EstudianteDetalle()
        {

        }
        public EstudianteDetalle(string nombre,string apellido, string cedula,bool activo, string password)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.Cedula = cedula;
            this.activo = activo;
            this.password = password;
        }
        public EstudianteDetalle(int id,string nombre, string apellido, string cedula, bool activo, string password) : 
            this(nombre,apellido,cedula,activo, password)
        {
            this.id = id;
        }

        // Getter y setters de los atributos de la clase

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public bool Activo { get => activo; set => activo = value; }
        public string Password { get => password; set => password = value; }
        public string Cedula { get => cedula; set => cedula = value; }

        // Sobreescribimos el metodo tostring para ponder obtener informacion resumina de nuestra objeto 
        //  en forma de cadena de texto 
        public override string ToString()
        {
            string cadena = "";
            cadena += "Nombre: " + Nombre + "\n";
            cadena += "Apellido: " + Apellido + "\n";
            cadena += "Cedula: " + cedula;
            return cadena; 
        }
    }
}
