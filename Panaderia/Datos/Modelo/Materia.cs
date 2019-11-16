using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Esta clase genera un objeto de la clase Materia con todos
    los atributos necesarios de dicho objeto segun las
    especificaciones que se tienen en la base de datos.
*/

namespace Datos.Modelo
{
    public class Materia
    {
        public int Id_Materia { get; set; }
        public string Nombre { get; set; }
        public int Existencias { get; set; }
        public string Descripcion { get; set; }
        public DateTime Ultima_Mod { get; set; }
    }
}
