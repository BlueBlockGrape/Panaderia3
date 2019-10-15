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
        private MySqlConnection Conexion = new MySqlConnection();

        public string Insert(Panes p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string InsertQuery = "INSERT INTO Panes (Nombre, Precio, Tamaño)" +
                "VALUES (@Nombre, @Precio, @Tamaño);";

                MySqlCommand SqlCom = new MySqlCommand(InsertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                SqlCom.Parameters.AddWithValue("@Precio", p.Precio);
                SqlCom.Parameters.AddWithValue("@Tamaño", p.Tamaño);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return "si";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public bool Delete(Panes p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string insertQuery = "DELETE FROM Panes WHERE Id_Pan=@Id_Pan ;";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Pan", p.Id_Pan);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;

            }
            catch (Exception )
            {

                return false;
            }

        }

        public bool Update(Panes p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string insertQuery = "update Panes set Nombre = @Nombre, Precio = @Precio, Tamaño = @Tamaño where Id_Pan = @Id_Pan";

                MySqlCommand SqlCom = new MySqlCommand(insertQuery, Conexion);
                SqlCom.Parameters.AddWithValue("@Id_Pan", p.Id_Pan);
                SqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                SqlCom.Parameters.AddWithValue("@Precio", p.Precio);
                SqlCom.Parameters.AddWithValue("@Tamaño", p.Tamaño);
                SqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<Panes> GetAll()
        {
            List<Panes> Lista = new List<Panes>();
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
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
            cmd.CommandText = "SELECT * FROM Panes";
            da.SelectCommand = cmd;
            da.SelectCommand.Connection = Conexion;
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
                Lista.Add(p);
            }
            Conexion.Close();

            return Lista;
        }


    }
    }

