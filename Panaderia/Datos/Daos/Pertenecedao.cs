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
    public class Pertenecedao
    {
        private MySqlConnection conexion = new MySqlConnection();

        public bool Insert(Pertenece p)
        {
            try
            {
                conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                conexion.Open();
                string insertQuery = "INSERT INTO Pertenece (Id_Venta,Id_Pan, Nombre, Precio, Cantidad)" +
                            "VALUES (@Id_Venta, @Id_Pan, @Nombre, @Precio,@Cantidad);";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Venta", p.Id_Venta);
                sqlCom.Parameters.AddWithValue("@Id_Pan", p.Id_Pan);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Precio", p.Precio);
                sqlCom.Parameters.AddWithValue("@Cantidad", p.Cantidad);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
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
                conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                conexion.Open();
                string insertQuery = "DELETE FROM Pertenece WHERE Id_Venta=@Id_Venta and Id_Pan =@Id_Pan ;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Venta", Id_Venta);
                sqlCom.Parameters.AddWithValue("@Id_Pan", Id_Pan);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
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
                conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                conexion.Open();
                string insertQuery = "DELETE FROM Pertenece WHERE Id_Venta=@Id_Venta;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Venta", Id_Venta);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
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
                conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                conexion.Open();
                string insertQuery = "UPDATE pertenece SET  Nombre = @Nombre, Precio = @Precio, Cantidad=@Cantidad " +
                    "WHERE Id_Venta = @Id_Venta and Id_Pan =@Id_Pan ;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Venta", p.Id_Venta);
                sqlCom.Parameters.AddWithValue("@Id_Pan", p.Id_Pan);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Precio", p.Precio);
                sqlCom.Parameters.AddWithValue("@Cantidad", p.Cantidad);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
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
                conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM pertenece where Id_Venta="+Id_Venta;
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = conexion;
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
                conexion.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}
