using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Esta clase genera un objeto de la clase provee con todos
    los atributos necesarios de dicho objeto segun las
    especificaciones que se tienen en la base de datos.
    (Esta clase relaciona dos objetos segun la base de datos).
*/


namespace Datos.Modelo
{
    class Provee
    {
        public int Id_Materia { get; set; }
        public int Id_Proveedor { get; set; }
    }
}
