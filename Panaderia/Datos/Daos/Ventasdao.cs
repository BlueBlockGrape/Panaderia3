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
        private MySqlConnection Conexion = new MySqlConnection();

        public bool Insert(Ventas p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string insertQuery = "INSERT INTO ventas (Id_Venta,Id_Usuario, Fecha, Total, Descuento)" +
                            "VALUES (@Id_Venta,@Id_Usuario, @Fecha, @Total, @Descuento)";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Venta", p.Id_Venta);
                SqlCom.Parameters.AddWithValue("@Id_Usuario", p.Id_Usuario);
                SqlCom.Parameters.AddWithValue("@Fecha", p.Fecha);
                SqlCom.Parameters.AddWithValue("@Total", p.Total);
                SqlCom.Parameters.AddWithValue("@Descuento", p.Descuento);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception )
            {

                return false;
            }

            
        }


        public bool Delete(int id)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string insertQuery = "DELETE FROM Ventas WHERE Id_Venta=@id ;";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@id", id);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool Update(Ventas p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string insertQuery = "UPDATE Ventas SET   Total = @Total, Descuento = @Descuento WHERE Id_Venta = @Id_Venta;";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Venta", p.Id_Venta);
                SqlCom.Parameters.AddWithValue("@Total", p.Total);
                SqlCom.Parameters.AddWithValue("@Descuento", p.Descuento);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false ;
            }
            
        }

        public List<Ventas> GetAll()
        {
            List<Ventas> lista = new List<Ventas>();
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas";
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Conexion;
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
                Conexion.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }

            
        }
        public int GetLast()
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas";
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Conexion;
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
                Conexion.Close();
                return id;
            }
            catch (Exception)
            {

                return 0;
            }


        }
        public List<Ventas> GetFecha(string fecha)
        {
            List<Ventas> lista = new List<Ventas>();
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas where fecha=@fecha";
                cmd.Parameters.AddWithValue("@fecha", fecha);
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Conexion;
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
                Conexion.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }


        }
        public List<Ventas> GetIdUsuario(int Id_Usuario)
        {
            List<Ventas> lista = new List<Ventas>();
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas where Id_Usuario="+Id_Usuario;
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Conexion;
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
                Conexion.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }

            
        }
        public List<Ventas> GetVenta(int Id_Venta)
        {
            List<Ventas> lista = new List<Ventas>();
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Ventas where Id_Venta="+Id_Venta;
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Conexion;
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
