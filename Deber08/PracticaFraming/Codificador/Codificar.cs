﻿//####################################################################################################
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
using System.Net;

namespace Codificador
{
    public class ConstantesCodificadorTexto
    {
        public static readonly String CODIFICACION_POR_DEFECTO = "ascii";
        public static readonly int LONG_MAX_FLUJO = 1024;
    }
    public class ConstantesCodificadorBinario
    {
        public static readonly String CODIFICACION_POR_DEFECTO = "ascii";
        public static readonly byte BANDERA_DESCUENTO = 1 << 7;
        public static readonly byte BANDERA_EN_STOCK = 1 << 0;
        public static readonly int LONG_MAX_DESCRIPCION = 255;
        public static readonly int LONG_MAX_FLUJO = 1024;
    }
    public class CodificadorTexto : CodificadorElemento
    {
        public Encoding codificador;

        //constructor por defecto
        public CodificadorTexto() : this(ConstantesCodificadorTexto.CODIFICACION_POR_DEFECTO)
        {
        }
    
        //Codifica los datos de entrada
        public CodificadorTexto(string datos)
        {
            codificador = Encoding.GetEncoding(datos);
        }
        //Se convierte en bytes a los datos antes codificados
        public byte[] Codificar(Elemento elemento)
        {
            // Metodología de codificación
            String cadenaCodificada = elemento.numeroElemento + " ";
            if (elemento.descripcion.IndexOf('\n') != -1)
                throw new IOException("Descripcion no valida (contiene un salto de linea)");

            cadenaCodificada = cadenaCodificada + elemento.descripcion + "\n";
            cadenaCodificada = cadenaCodificada + elemento.cantidad + " ";
            cadenaCodificada = cadenaCodificada + elemento.precio + " ";

            if (elemento.tieneDescuento)
                cadenaCodificada = cadenaCodificada + "d";

            if (elemento.enStock)
                cadenaCodificada = cadenaCodificada + "s";

            cadenaCodificada = cadenaCodificada + "\n";

            if (cadenaCodificada.Length > ConstantesCodificadorTexto.LONG_MAX_FLUJO)
                throw new IOException("Longitud codificada demasiado grande");

            byte[] bufer = codificador.GetBytes(cadenaCodificada);
            // se retorna el buffer con bytes
            return bufer;
        }
    }

    //Clase para decodificar los datos.
    public class DecodificadorTexto : DecodificadorElemento
    {
        public Encoding decodificador;
        public DecodificadorTexto() : this
        (ConstantesCodificadorTexto.CODIFICACION_POR_DEFECTO)
        { }
        public DecodificadorTexto(String datoCodificado)
        {
            decodificador = Encoding.GetEncoding(datoCodificado);
        }
        //se decodifica ingresando como parámetro de entrada el stream con bytes
        public Elemento Decodificar(Stream flujo)
        {
            String noElemento, descripcion, cant, precio, banderas;
            byte[] espacios = decodificador.GetBytes(" ");
            byte[] saltoLinea = decodificador.GetBytes("\n");
            noElemento = decodificador.GetString(Entramar.SiguienteToken(flujo, espacios));
            descripcion = decodificador.GetString(Entramar.SiguienteToken(flujo,
            saltoLinea));
            cant = decodificador.GetString(Entramar.SiguienteToken(flujo, espacios));
            precio = decodificador.GetString(Entramar.SiguienteToken(flujo, espacios));
            banderas = decodificador.GetString(Entramar.SiguienteToken(flujo, saltoLinea));
            return new Elemento(Int64.Parse(noElemento),
            descripcion,
            Int32.Parse(cant),
            Int32.Parse(precio),
            (banderas.IndexOf('d') != -1),
            (banderas.IndexOf('s') != -1));
        }
        public Elemento Decodificar(byte[] paquete)
        {
            // Inicializa una nueva instancia no redimensionable de la clase MemoryStream 
            //basada en la región especificada de una matriz de bytes, con la propiedad 
            //CanWrite establecida como se especifica
            Stream cargaUtil = new MemoryStream(paquete, 0, paquete.Length, false);
            return Decodificar(cargaUtil);
        }
    }
    //Clase utilizada para codificar en binario
    public class CodificadorBinario : CodificadorElemento
    {
        public Encoding codificador;
        public CodificadorBinario() :
        this(ConstantesCodificadorBinario.CODIFICACION_POR_DEFECTO)
        { }
        public CodificadorBinario(String datos)
        {
            codificador = Encoding.GetEncoding(datos);
        }
        public byte[] Codificar(Elemento elemento)
        {
            MemoryStream flujoMemoria = new MemoryStream();
            //Inicializa una nueva instancia de la clase BinaryWriter basada en la secuencia 
            //especificada y utilizando la codificación UTF-8.
            BinaryWriter escritorBinario = new BinaryWriter(new BufferedStream(flujoMemoria));
            //Convierte un valor largo de orden de bytes de host a orden de bytes de red, evitando problemas
            escritorBinario.Write(IPAddress.HostToNetworkOrder(elemento.numeroElemento));
            escritorBinario.Write(IPAddress.HostToNetworkOrder(elemento.cantidad));
            escritorBinario.Write(IPAddress.HostToNetworkOrder(elemento.precio));

            //Definición banderas
            byte banderas = 0;
            if (elemento.tieneDescuento)
                banderas |= ConstantesCodificadorBinario.BANDERA_DESCUENTO;
            if (elemento.enStock)
                banderas |= ConstantesCodificadorBinario.BANDERA_EN_STOCK;
            escritorBinario.Write(banderas);
            byte[] bytesDescripcion = codificador.GetBytes(elemento.descripcion);
            if (bytesDescripcion.Length > ConstantesCodificadorBinario.LONG_MAX_DESCRIPCION)
                throw new IOException("La descripcion del elemento excede el límite establecido");
                escritorBinario.Write((byte)bytesDescripcion.Length);
            escritorBinario.Write(bytesDescripcion);
            escritorBinario.Flush();
            return flujoMemoria.ToArray();
        }
    }

    //Clase para decodificar Binario
    public class DecodificadorBinario : DecodificadorElemento
    {
        public Encoding decodificador;
        public DecodificadorBinario() :
        this(ConstantesCodificadorBinario.CODIFICACION_POR_DEFECTO)
        { }
        public DecodificadorBinario(String datos)
        {
            decodificador = Encoding.GetEncoding(datos);
        }
        public Elemento Decodificar(Stream flujo)
        {
            //Inicializa una nueva instancia de la clase BinaryReader basada en la secuencia 
            //especificada y usando codificación UTF-8.
            BinaryReader lectorBinario = new BinaryReader(new BufferedStream(flujo));
            long noElemento = IPAddress.NetworkToHostOrder(lectorBinario.ReadInt64());
            int cant = IPAddress.NetworkToHostOrder(lectorBinario.ReadInt32());
            int precio = IPAddress.NetworkToHostOrder(lectorBinario.ReadInt32());
            byte banderas = lectorBinario.ReadByte();
            int longCadena = lectorBinario.Read();
            if (longCadena == -1)
                throw new EndOfStreamException();
            byte[] buferDescripcion = new byte[longCadena];
            lectorBinario.Read(buferDescripcion, 0, longCadena);
            String descripcion = decodificador.GetString(buferDescripcion);
            return new Elemento(noElemento, descripcion, cant, precio,
            ((banderas & ConstantesCodificadorBinario.BANDERA_DESCUENTO) ==
            ConstantesCodificadorBinario.BANDERA_DESCUENTO),
            ((banderas & ConstantesCodificadorBinario.BANDERA_EN_STOCK) ==
            ConstantesCodificadorBinario.BANDERA_EN_STOCK));
        }
        public Elemento Decodificar(byte[] paquete)
        {
            //Memoria ocupada en el decodificador
            Stream cargaUtil = new MemoryStream(paquete, 0, paquete.Length, false);
            return Decodificar(cargaUtil);
        }
    }
}

