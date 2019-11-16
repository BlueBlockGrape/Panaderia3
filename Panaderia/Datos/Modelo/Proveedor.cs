using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Esta clase genera un objeto de la clase Proveedor con todos
    los atributos necesarios de dicho objeto segun las
    especificaciones que se tienen en la base de datos.
*/


namespace Datos.Modelo
{
    public class Proveedor
    {
        public int Id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Productos { get; set; }
    }
}
