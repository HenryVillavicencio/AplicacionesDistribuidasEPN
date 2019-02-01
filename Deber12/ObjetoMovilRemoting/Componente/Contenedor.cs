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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente
{

    // El atributo [Serializable] se emplea para usar marshal-by-value
    // que nos permitira crear un objeto movil
    [Serializable]
    public class Contenedor
    {
        // Declaramos los atributos de nuestra clase 
        private string cadena;
        private int numero;

        // Definimos el constructor de nuestra clase
        public Contenedor(string cadena, int numero)
        {
            this.cadena = cadena;
            this.numero = numero;
        }

        // getters y setters 
        public string Cadena { get { return cadena; } }
        public int Numero { get { return numero; } }

        // Sobreescribimos el método toString para que retoner una cadena con
        // los atributos cadena y numero de nuestro objeto
        public override string ToString()
        {
            return string.Format("Contenedor[cadena=\"{0}\",numero={1}]", Cadena,Numero);
        }
    }
}