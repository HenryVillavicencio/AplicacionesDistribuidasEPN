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


using System.Collections;
namespace GestorDatos
{
    // El atributo [Serializable] se emplea para usar marshal-by-value
    // que nos permitira que este se transmita por la red 
    [Serializable]
    public class AlmacenDatos
    {
        // Declaramos un atributo que almacera una lisata de nombres
        private ArrayList nombres = new ArrayList();
        // Método que agrega un nombre a la lista 
        public void AgregarNombre(string nombre)
        {
            nombres.Add(nombre);
        }
        // Método que permite obtener la lista de nombres
        public ArrayList ObtenerNombres()
        {
            return nombres;
        }
    }
}