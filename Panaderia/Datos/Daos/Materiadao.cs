using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelo;
using MySql.Data.MySqlClient;
namespace Datos.Daos
{
    public class Materiadao
    {
        private MySqlConnection conexion = new MySqlConnection();

        public bool Agregar(Materia p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "INSERT INTO Materia (Id_Materia, Nombre, Existencias, Descripcion, Ultima_Mod)" +
                            "VALUES (null, @Nombre, @Existencias, @Descripcion, null)";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Existencias", p.Existencias);
                sqlCom.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Materia p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "Update Materia Set Nombre = @Nombre, Existencias = @Existencias, Descripcion = @Descripcion " +
                            "Where Id_Materia = @Id_Materia";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Existencias", p.Existencias);
                sqlCom.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                sqlCom.Parameters.AddWithValue("@Id_Materia", p.Id_Materia);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Eliminar(Materia p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "DELETE FROM Materia WHERE Id_Materia = @Id_Materia";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Materia", p.Id_Materia);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Materia> Ver()
        {
            List<Materia> lista = new List<Materia>();
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";

            conexion.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT * FROM Materia";
            da.SelectCommand = cmd;
            da.SelectCommand.Connection = conexion;
            da.Fill(ds);
            DataSet datos = ds;

            DataTable dt = datos.Tables[0];
            Materia p;
            foreach (DataRow r in dt.Rows)
            {
                p = new Materia();
                p.Id_Materia = (int)r.ItemArray[0];
                p.Nombre = (string)r.ItemArray[1];
                p.Descripcion = (string)r.ItemArray[2];
                p.Existencias = (int)r.ItemArray[3];
                p.Ultima_Mod = (DateTime)r.ItemArray[4];
                lista.Add(p);
            }
            conexion.Close();
            return lista;
        }
    }
}
