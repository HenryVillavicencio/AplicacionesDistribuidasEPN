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
    public class Entramar
    {
        public static byte[] SiguienteToken(Stream datosEntrada, byte[] delimitador)
        {
            //Se crean tramas para el envío de datos, con delimitadores
            int siguienteByte;
            if ((siguienteByte = datosEntrada.ReadByte()) == -1)
                return null;
            MemoryStream bufer = new MemoryStream();
            do
            {
                bufer.WriteByte((byte)siguienteByte);
                byte[] tokenActual = bufer.ToArray();
                if (TerminaCon(tokenActual, delimitador))
                {
                    int longitudToken = tokenActual.Length - delimitador.Length;
                    byte[] token = new byte[longitudToken];
                    Array.Copy(tokenActual, 0, token, 0, longitudToken);
                    return token;
                }
            } while ((siguienteByte = datosEntrada.ReadByte()) != -1);
            return bufer.ToArray();
        }

        //Aplico Entramado en la aplicación
        private static Boolean TerminaCon(byte[] valor, byte[] sufijo)
        {
            if (valor.Length < sufijo.Length)
                return false;
            for (int offset = 1; offset <= sufijo.Length; offset++)
                if (valor[valor.Length - offset] != sufijo[sufijo.Length - offset])
                    return false;
            return true;
        }
    }
}

