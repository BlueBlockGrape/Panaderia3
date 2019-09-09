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
    public class Panesdao
    {
        private MySqlConnection conexion = new MySqlConnection();

        public string insert(Panes p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "INSERT INTO Panes (Nombre, Precio, Tamaño)" +
                "VALUES (@Nombre, @Precio, @Tamaño);";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Precio", p.Precio);
                sqlCom.Parameters.AddWithValue("@Tamaño", p.Tamaño);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return "si";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public bool delete(Panes p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "DELETE FROM Panes WHERE Id_Pan=@Id_Pan ;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Pan", p.Id_Pan);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;

            }
            catch (Exception )
            {

                return false;
            }

        }

        public bool update(Panes p)
        {
            conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                conexion.Open();
                string insertQuery = "update Panes set Nombre = @Nombre, Precio = @Precio, Tamaño = @Tamaño where Id_Pan = @Id_Pan";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, conexion);
                sqlCom.Parameters.AddWithValue("@Id_Pan", p.Id_Pan);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Precio", p.Precio);
                sqlCom.Parameters.AddWithValue("@Tamaño", p.Tamaño);
                sqlCom.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<Panes> getAll()
        {
            List<Panes> lista = new List<Panes>();
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
            cmd.CommandText = "SELECT * FROM Panes";
            da.SelectCommand = cmd;
            da.SelectCommand.Connection = conexion;
            da.Fill(ds);
            DataSet datos = ds;

            DataTable dt = datos.Tables[0];
            Panes p;
            foreach (DataRow r in dt.Rows)
            {

                p = new Panes();
                p.Id_Pan = (int)r.ItemArray[0];
                p.Nombre = (string)r.ItemArray[1];
                p.Precio = (double)r.ItemArray[2];
                p.Tamaño = (string)r.ItemArray[3];
                lista.Add(p);
            }
            conexion.Close();

            return lista;
        }


    }
    }

