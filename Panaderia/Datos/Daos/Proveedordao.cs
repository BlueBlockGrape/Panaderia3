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
    public class Proveedordao
    {
        private MySqlConnection conexion = new MySqlConnection();
        public string Insert(Proveedor p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "INSERT INTO Proveedor (Nombre, Domicilio, Telefono, Productos)" +
                            "VALUES (@Nombre, @Domicilio, @Telefono, @Productos)";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Domicilio", p.Domicilio);
                sqlCom.Parameters.AddWithValue("@Telefono", p.Telefono);
                sqlCom.Parameters.AddWithValue("@Productos", p.Productos);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return "si";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public bool Delete(Proveedor p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "DELETE FROM Proveedor WHERE Id_Proveedor=@Id_Proveedor limit 1;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Proveedor", p.Id_Proveedor);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Proveedor p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "UPDATE Proveedor SET Id_Proveedor=@Id_Proveedor, Nombre=@Nombre, Domicilio=@Domicilio, Telefono=@Telefono, Productos=@Productos WHERE Id_Proveedor = @Id_Proveedor limit 1;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Proveedor", p.Id_Proveedor);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Domicilio", p.Domicilio);
                sqlCom.Parameters.AddWithValue("@Telefono", p.Telefono);
                sqlCom.Parameters.AddWithValue("@Productos", p.Productos);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
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
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            conexion.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();


            //cnn.Open();
            cmd.CommandText = "SELECT * FROM Proveedor";
            da.SelectCommand = cmd;
            da.SelectCommand.Connection = conexion;
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
