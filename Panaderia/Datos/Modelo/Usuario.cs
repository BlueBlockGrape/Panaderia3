using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelo
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Direccion { get; set; }
        public bool Administrador { get; set; }
    }
}
