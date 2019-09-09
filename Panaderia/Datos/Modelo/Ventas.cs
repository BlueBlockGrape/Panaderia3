using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelo
{
    public class Ventas
    {
        public int Id_Venta { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public double Descuento { get; set; }
    }
}
