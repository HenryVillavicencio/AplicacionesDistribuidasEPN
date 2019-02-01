// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************

// Gestor de Datos// RESULTADOS:
//El programa cliente agrega nombres que se dan como parametro de entrada a un objeto
//remoto creado en el servidor, este dato es de tipo sigleton y por lo tanto el mismo
//objeto es compartido por todos los clientes permitiendoles saber los nombres de todos los
// lientes que han realizado la llamada al objeto remoto
// CONCLUSIONES:
// Los objetos sigleton nos permiten generar programas de manera sencilla en la cual se requieren que 
// el estado y el obejo sea comportado por todos los clienetes.
// RECOMENDACIONES:
// Si la configuración de remoting se realiza directamente en cédigo y no a través del archivo de configuración 
// se debe verificar que los comandas se hayan implementados correctamente
// Si se tiene dudas de como realizar la configuración de remoting revisar la documentación oficial de microsoft


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace GestorDatos
{
    // La clase extiende de  MarshalByRefObject para poder usar  la semántica 
    // marshal-by-reference que nos permitira crear un objeto remoto
    public class GestorDatos : MarshalByRefObject
    {
        // Declaramos un atributo del tipo almacen de datos que nos ayudara a almacenar 
        // una lista de nombres 
        private AlmacenDatos almacen;

        // Definimos el constructor por defecto de la clase
        public GestorDatos()
        {
            almacen = new AlmacenDatos();
        }
        // Método que agrega un nombre al almacen de datos  
        public void AgregarDato(string nombre)
        {
            almacen.AgregarNombre(nombre);
        }
        // Método que permite obtener el almacen de datos 
        public ArrayList ObtenerDatos()
        {
            return almacen.ObtenerNombres();
        }
    }
}