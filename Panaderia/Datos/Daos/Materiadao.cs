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

    /*
     * Métodos implementados para realizar las consultas con la base de datos
     * y algunas cuestiones con los modelos de la parte de Materia para que se
     * guarden todos los datos referentes a esta clase y puedan ser utilizados por
     * el programa, por lo que el programa utiliza esta clase para conseguir datos
     * de la base de datos según lo requiera.
     */

    public class Materiadao
    {
        private MySqlConnection Conexion = new MySqlConnection();

        public bool Agregar(Materia p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            try
            {
                Conexion.Open();
                string insertQuery = "INSERT INTO Materia (Id_Materia, Nombre, Existencias, Descripcion, Ultima_Mod)" +
                            "VALUES (null, @Nombre, @Existencias, @Descripcion, '2019-11-19 13:11:02')";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                SqlCom.Parameters.AddWithValue("@Existencias", p.Existencias);
                SqlCom.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Materia p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            try
            {
                Conexion.Open();
                string insertQuery = "Update Materia Set Nombre = @Nombre, Existencias = @Existencias, Descripcion = @Descripcion " +
                            "Where Id_Materia = @Id_Materia";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                SqlCom.Parameters.AddWithValue("@Existencias", p.Existencias);
                SqlCom.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                SqlCom.Parameters.AddWithValue("@Id_Materia", p.Id_Materia);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Eliminar(Materia p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            try
            {
                Conexion.Open();
                string insertQuery = "DELETE FROM Materia WHERE Id_Materia = @Id_Materia";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Materia", p.Id_Materia);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Materia> Ver()
        {
            List<Materia> Lista = new List<Materia>();
            
           Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";

            Conexion.Open();

            DataSet Ds = new DataSet();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT * FROM Materia";
            Da.SelectCommand = cmd;
            Da.SelectCommand.Connection = Conexion;
            Da.Fill(Ds);
            DataSet Datos = Ds;

            DataTable Dt = Datos.Tables[0];
            Materia P;
            foreach (DataRow r in Dt.Rows)
            {
                P = new Materia();
                P.Id_Materia = (int)r.ItemArray[0];
                P.Nombre = (string)r.ItemArray[1];
                P.Descripcion = (string)r.ItemArray[2];
                P.Existencias = (int)r.ItemArray[3];
                P.Ultima_Mod = (DateTime)r.ItemArray[4];
                Lista.Add(P);
            }
            Conexion.Close();
            return Lista;
        }
    }
}
