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
     * y algunas cuestiones con los modelos de la parte de Pertenencia que es
     * una tabla relacional de la base de datos para que se
     * guarden todos los datos referentes a esta clase y puedan ser utilizados por
     * el programa, por lo que el programa utiliza esta clase para conseguir datos
     * de la base de datos según lo requiera.
     */

    public class Pertenecedao
    {
        private MySqlConnection Conexion = new MySqlConnection();

        public bool Insert(Pertenece p)
        {
            try
            {
                Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                Conexion.Open();
                string insertQuery = "INSERT INTO Pertenece (Id_Venta,Id_Pan, Nombre, Precio, Cantidad)" +
                            "VALUES (@Id_Venta, @Id_Pan, @Nombre, @Precio,@Cantidad);";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Venta", p.Id_Venta);
                SqlCom.Parameters.AddWithValue("@Id_Pan", p.Id_Pan);
                SqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                SqlCom.Parameters.AddWithValue("@Precio", p.Precio);
                SqlCom.Parameters.AddWithValue("@Cantidad", p.Cantidad);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }


        public bool Delete(int Id_Venta,int Id_Pan)
        {
            try
            {
                Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                Conexion.Open();
                string insertQuery = "DELETE FROM Pertenece WHERE Id_Venta=@Id_Venta and Id_Pan =@Id_Pan ;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, Conexion);
                sqlCom.Parameters.AddWithValue("@Id_Venta", Id_Venta);
                sqlCom.Parameters.AddWithValue("@Id_Pan", Id_Pan);
                sqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool Delete(int Id_Venta)
        {
            try
            {
                Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                Conexion.Open();
                string insertQuery = "DELETE FROM Pertenece WHERE Id_Venta=@Id_Venta;";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Venta", Id_Venta);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Update(Pertenece p)
        {
            try
            {
                Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                Conexion.Open();
                string insertQuery = "UPDATE pertenece SET  Nombre = @Nombre, Precio = @Precio, Cantidad=@Cantidad " +
                    "WHERE Id_Venta = @Id_Venta and Id_Pan =@Id_Pan ;";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Venta", p.Id_Venta);
                SqlCom.Parameters.AddWithValue("@Id_Pan", p.Id_Pan);
                SqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                SqlCom.Parameters.AddWithValue("@Precio", p.Precio);
                SqlCom.Parameters.AddWithValue("@Cantidad", p.Cantidad);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<Pertenece> GetAll(int Id_Venta)
        {
            List<Pertenece> lista = new List<Pertenece>();
            try
            {
                Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=Root123;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                Conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM pertenece where Id_Venta="+Id_Venta;
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                Pertenece p;
                foreach (DataRow r in dt.Rows)
                {

                    p = new Pertenece();
                    p.Id_Venta = (int)r.ItemArray[0];
                    p.Id_Pan = (int)r.ItemArray[1];
                    p.Nombre = (string)r.ItemArray[2];
                    p.Precio = (double)r.ItemArray[3];
                    p.Cantidad = (int)r.ItemArray[4];
                    lista.Add(p);
                }
                Conexion.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}
