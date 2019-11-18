using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Datos.Modelo;
using System.Data;

namespace Datos.Daos
{

    /*
     * Métodos implementados para realizar las consultas con la base de datos
     * y algunas cuestiones con los modelos de la parte de Proveedores para que se
     * guarden todos los datos referentes a esta clase y puedan ser utilizados por
     * el programa, por lo que el programa utiliza esta clase para conseguir datos
     * de la base de datos según lo requiera.
     */

    public class Proveedordao
    {
        private MySqlConnection Conexion = new MySqlConnection();
        public string Insert(Proveedor p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            try
            {
                Conexion.Open();
                string insertQuery = "INSERT INTO Proveedor (Nombre, Domicilio, Telefono, Productos)" +
                            "VALUES (@Nombre, @Domicilio, @Telefono, @Productos)";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                SqlCom.Parameters.AddWithValue("@Domicilio", p.Domicilio);
                SqlCom.Parameters.AddWithValue("@Telefono", p.Telefono);
                SqlCom.Parameters.AddWithValue("@Productos", p.Productos);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return "si";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public bool Delete(Proveedor p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            try
            {
                Conexion.Open();
                string insertQuery = "DELETE FROM Proveedor WHERE Id_Proveedor=@Id_Proveedor limit 1;";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Proveedor", p.Id_Proveedor);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Proveedor p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            try
            {
                Conexion.Open();
                string insertQuery = "UPDATE Proveedor SET Id_Proveedor=@Id_Proveedor, Nombre=@Nombre, Domicilio=@Domicilio, Telefono=@Telefono, Productos=@Productos WHERE Id_Proveedor = @Id_Proveedor limit 1;";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Proveedor", p.Id_Proveedor);
                SqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                SqlCom.Parameters.AddWithValue("@Domicilio", p.Domicilio);
                SqlCom.Parameters.AddWithValue("@Telefono", p.Telefono);
                SqlCom.Parameters.AddWithValue("@Productos", p.Productos);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<Proveedor> GetAll()
        {
            List<Proveedor> lista = new List<Proveedor>();
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            Conexion.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();


            //cnn.Open();
            cmd.CommandText = "SELECT * FROM Proveedor";
            da.SelectCommand = cmd;
            da.SelectCommand.Connection = Conexion;
            da.Fill(ds);
            DataSet datos = ds;

            DataTable dt = datos.Tables[0];
            Proveedor p;
            foreach (DataRow r in dt.Rows)
            {
                p = new Proveedor();
                p.Id_Proveedor = (int)r.ItemArray[0]; ;
                p.Nombre = (string)r.ItemArray[1];
                p.Domicilio = (string)r.ItemArray[2];
                p.Telefono = (string)r.ItemArray[3];
                p.Productos = (string)r.ItemArray[4];
                lista.Add(p);
            }

            return lista;
        }
    }
}
