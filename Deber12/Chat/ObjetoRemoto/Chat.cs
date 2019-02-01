// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// Chat
// RESULTADOS:
// El programa permite el intercambio de mensajes entre varios de usuarios de una sala de chat y 
// presentarlos a través de la interfaz gráfica. Este programa hace uso de objetos singleton ya que estos
// mantienen su estado y son compartidos por todos los usuarios 
// CONCLUSIONES:
// Se debe realizar el bloqueo de atributos que a los que se accedan de forma simultanea para evitar errores 
// durante la ejecución del programa 
// Net remoting nos permite implementar de forma facil y sencilla programas de comunicación como un chat 
// donde se comparte el estado e informacion de un objeto remoto, mediante el uso de objetos singleton
// RECOMENDACIONES:
// Verificar que la configuracion de net remoting se haya realizado correctamente tanto en el lado del cliente como 
// en el  lado del servidor 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
namespace ObjetoRemoto
{
    // La clase extiende de  MarshalByRefObject para poder usar  la semántica 
    // marshal-by-reference que nos permitira crear un objeto remoto
    public class Chat : MarshalByRefObject
    {
        // Definimos un arraylist que almacenara los clientes 
        private ArrayList clientes = new ArrayList();
        private string sesion = "";

        // Método que nos permite agregar el nombre de un cliente al arrayList
        public void AgregarCliente(string nombre)
        {
            // El nombre debe ser no nulo para poder ser agregado
            if (nombre != null)
            {
                // bloqueamos esta sección de código para evitar errores 
                // durante el acceso simultáneo 
                lock (clientes)
                {
                    clientes.Add(nombre);
                }
            }
        }
        // Método que retira el cliente del arrayList
        public void RemoverCliente(string nombre)
        {
            // bloqueamos esta sección de código para evitar errores 
            // durante el acceso simultáneo
            lock (clientes)
            {
                clientes.Remove(nombre);
            }
        }

        // Este método nos permite agregar un texto a la seción 
        public void AgregarTexto(string texto)
        {
            if (texto != null)
            {
                // bloqueamos esta sección de código para evitar errores 
                // durante el acceso simultáneo 

                lock (sesion)
                {
                    sesion += texto;
                }

            }
        }

        // Este método permite obtener el array de clientes 
        public ArrayList Clientes()
        {
            return clientes;
        }

        // Este método permite obtener el string de sesion
        public string Sesion()
        {
            return sesion;
        }
    }
}