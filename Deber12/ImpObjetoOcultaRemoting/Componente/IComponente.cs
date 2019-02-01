// ******************************************************************
// Deber No: 12
// Integrantes: Domenica Gomez
//              Henry Villavicencio
// Grupo: Gr1
// Materia: Aplicaciones distribuidas
// Fecha de realización: 21/12/2018
// Fecha de entrega: 04/01/2019
// ******************************************************************
// 7. Ocultando la implementacion del Objeto Remoto a traves de una interfaz
// RESULTADOS
// 1.Comente los resultados obtenidos. ¿El comportamiento es el esperado deacuerdo a lo indicado en
// clase?
// Hay una excepcion debido a que no encuentra al metodo implementado en la clase Componente.IComponente
// ******************************************************************
// Conclusion
// Se puede generar varios objetos remotos que atenderan las peticiones de los
// clientes mediante una interfaz y ofertando servicios a los mismos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente
{
   
    /// Interfaz del Componente que generará los objetos remotos
    public interface IComponente
    {
        //Interfaz del metodo LlamadaUno()
        string LlamadaUno();
        //Interfaz del metodo LlamadaDos()
        string LlamadaDos();
    }
}
