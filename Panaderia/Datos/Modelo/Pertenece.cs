using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Esta clase genera un objeto de la clase pertenece con todos
    los atributos necesarios de dicho objeto segun las
    especificaciones que se tienen en la base de datos.
    (Esta clase relaciona dos objetos segun la base de datos).
*/


namespace Datos.Modelo
{
   public class Pertenece
    {
        public int Id_Venta { get; set; }
        public int Id_Pan { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
