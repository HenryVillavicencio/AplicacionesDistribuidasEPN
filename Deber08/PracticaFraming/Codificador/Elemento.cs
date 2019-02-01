//####################################################################################################
//Practica03
//Nombre:  Doménica Gómez, Henry Villavicencio
//Fecha de realización: 29/10/2018
//Fecha de entrega: 05/11/2018
//####################################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Codificador
{
    //Clase en la que se crean distintos tipos de datos que serán utilizados
    //como datos para envío.
    public class Elemento
    {
        public long numeroElemento;
        public String descripcion;
        public int cantidad;
        public int precio;
        public Boolean tieneDescuento;
        public Boolean enStock;
        public Elemento(long id, string descripcion, int cant, int precio, bool
        tieneDescuento, bool enStock)
        {
            numeroElemento = id;
            this.descripcion = descripcion;
            cantidad = cant;
            this.precio = precio;
            this.tieneDescuento = tieneDescuento;
            this.enStock = enStock;
        }
        //Método para poder presentar el contenido del objeto por consola
        public override string ToString()
        {
            String separador = "\n";
            String valor = "ID#=" + numeroElemento + separador
            + "Descripcion=" + descripcion + separador
            + "Cantidad=" + cantidad + separador
            + "Precio=" + precio + separador
            + "Precio Total=" + (cantidad * precio);
            if (tieneDescuento)
                valor += " (descuento)";
            if (enStock)
                valor += separador + "En Stock" + separador;
            else
                valor += separador + "No en Stock" + separador;
            return valor;
        }
    }

    //interfaz para la codificación de datos
    public interface CodificadorElemento
    {
        byte[] Codificar(Elemento elemento);
    }
    //interfaz para la decdificación de datos
    public interface DecodificadorElemento
    {
        Elemento Decodificar(Stream dato);
        Elemento Decodificar(byte[] paquete);
    }
}