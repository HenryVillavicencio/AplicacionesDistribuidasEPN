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

using System.Runtime.Serialization;
namespace Componente
{
    // El atributo [Serializable] se emplea para usar marshal-by-value
    // que nos permitira transferir el objeto sobre la red
    [Serializable]
    // La clase extiende de ApplicationException para poder definir las excepciones para nuestro
    // programa
    public class ExcepcionRemota : ApplicationException
    {
        // Atributo qu epermitira incluir algún mensaje extra a anuesta exepción 
        private string mensajeAdicional;


        //  Sobrecarga de constructores de clase, se llama al constructor de la clase 
        //  padre el cual recibira el mensaje, información o contexto de  la exepción 
        //  que se mostrara.
        
        public ExcepcionRemota(string mensaje, string mensajeExtra)
        : base(mensaje)
        {
            mensajeAdicional = mensajeExtra;
        }
        public ExcepcionRemota(SerializationInfo info, StreamingContext contexto)
        : base(info, contexto)
        {
            mensajeAdicional = info.GetString("mensajeAdicional");
        }

        // Agregamos el mensaje adicional a la información de Serialización 
        // Este método es llamado en la serialización
        public override void GetObjectData(SerializationInfo info, StreamingContext contexto)
        {
            base.GetObjectData(info, contexto);
            info.AddValue("mensajeAdicional", mensajeAdicional);
        }
        // Getters y setters
        public string MensajeAdicional { get { return mensajeAdicional; } }
    }
}
