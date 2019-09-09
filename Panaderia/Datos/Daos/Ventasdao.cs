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
    public class Ventasdao
    {
        private MySqlConnection conexion = new MySqlConnection();

        public bool insert(Ventas p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "INSERT INTO ventas (Id_Venta,Id_Usuario, Fecha, Total, Descuento)" +
                            "VALUES (@Id_Venta,@Id_Usuario, @Fecha, @Total, @Descuento)";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Venta", p.Id_Venta);
                sqlCom.Parameters.AddWithValue("@Id_Usuario", p.Id_Usuario);
                sqlCom.Parameters.AddWithValue("@Fecha", p.Fecha);
                sqlCom.Parameters.AddWithValue("@Total", p.Total);
                sqlCom.Parameters.AddWithValue("@Descuento", p.Descuento);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception )
            {

                return false;
            }

            
        }


        public bool delete(int id)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "DELETE FROM Ventas WHERE Id_Venta=@id ;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@id", id);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool update(Ventas p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "UPDATE Ventas SET   Total = @Total, Descuento = @Descuento WHERE Id_Venta = @Id_Venta;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Venta", p.Id_Venta);
                sqlCom.Parameters.AddWithValue("@Total", p.Total);
                sqlCom.Parameters.AddWithValue("@Descuento", p.Descuento);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false ;
            }
            
        }

        public List<Ventas> getAll()
        {
            List<Ventas> lista = new List<Ventas>();
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas";
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                Ventas p;
                foreach (DataRow r in dt.Rows)
                {

                    p = new Ventas();
                    p.Id_Venta = (int)r.ItemArray[0];
                    p.Id_Usuario = (int)r.ItemArray[1];
                    p.Fecha = (DateTime)r.ItemArray[2];
                    p.Total = (double)r.ItemArray[3];
                    p.Descuento = (double)r.ItemArray[4];
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
        public int getLast()
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas";
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = conexion;
                da.Fill(ds);
                DataSet datos = ds;
                int id=0;
                DataTable dt = datos.Tables[0];
                Ventas p;
                foreach (DataRow r in dt.Rows)
                {

                    p = new Ventas();
                    id = (int)r.ItemArray[0];
                    p.Id_Usuario = (int)r.ItemArray[1];
                    p.Fecha = (DateTime)r.ItemArray[2];
                    p.Total = (double)r.ItemArray[3];
                    p.Descuento = (double)r.ItemArray[4];

                }
                conexion.Close();
                return id;
            }
            catch (Exception)
            {

                return 0;
            }


        }
        public List<Ventas> getFecha(string fecha)
        {
            List<Ventas> lista = new List<Ventas>();
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas where fecha=@fecha";
                cmd.Parameters.AddWithValue("@fecha", fecha);
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                Ventas p;
                foreach (DataRow r in dt.Rows)
                {

                    p = new Ventas();
                    p.Id_Venta = (int)r.ItemArray[0];
                    p.Id_Usuario = (int)r.ItemArray[1];
                    p.Fecha = (DateTime)r.ItemArray[2];
                    p.Total = (double)r.ItemArray[3];
                    p.Descuento = (double)r.ItemArray[4];
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
        public List<Ventas> getIdUsuario(int Id_Usuario)
        {
            List<Ventas> lista = new List<Ventas>();
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas where Id_Usuario="+Id_Usuario;
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                Ventas p;
                foreach (DataRow r in dt.Rows)
                {

                    p = new Ventas();
                    p.Id_Venta = (int)r.ItemArray[0];
                    p.Id_Usuario = (int)r.ItemArray[1];
                    p.Fecha = (DateTime)r.ItemArray[2];
                    p.Total = (double)r.ItemArray[3];
                    p.Descuento = (double)r.ItemArray[4];
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
        public List<Ventas> getVenta(int Id_Venta)
        {
            List<Ventas> lista = new List<Ventas>();
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas where Id_Venta="+Id_Venta;
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                Ventas p;
                foreach (DataRow r in dt.Rows)
                {

                    p = new Ventas();
                    p.Id_Venta = (int)r.ItemArray[0];
                    p.Id_Usuario = (int)r.ItemArray[1];
                    p.Fecha = (DateTime)r.ItemArray[2];
                    p.Total = (double)r.ItemArray[3];
                    p.Descuento = (double)r.ItemArray[4];
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
