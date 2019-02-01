
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


using System.Runtime.Remoting;
using Componente;

namespace Servidor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Lee el archivo de configuración y lo aplica en el programa 
            RemotingConfiguration.Configure("Servidor.exe.config",false);
            // Muestra los tipos de datos de net remoting  configurados para el programa 
            Utilidades.MostrarTodosLosDatos();
            // Imprime un mensaje y espera un Enter para termininar el programa 
            Log.EsperarParaTerminar("Presione ENTER para detener al servidor...");
        }
    }
}
