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
   public class Usuariodao
    {
        private MySqlConnection Conexion = new MySqlConnection();

        public Usuario Entrar(Usuario p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                //  bool si = false;
                Conexion.Open();
                string insertQuery = "select * from Usuario where Id_Usuario=@Id_Usuario ";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, Conexion);
                sqlCom.Parameters.AddWithValue("@Id_Usuario", p.Id_Usuario);
                // sqlCom.Parameters.AddWithValue("@Contraseña", p.Contraseña);
                sqlCom.ExecuteNonQuery();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sqlCom;
                da.SelectCommand.Connection = Conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                Usuario user = new Usuario();
                foreach (DataRow r in dt.Rows)
                {

                    user.Id_Usuario = (int)r.ItemArray[0];
                    user.Contraseña = (string)r.ItemArray[1];
                    user.Nombre = (string)r.ItemArray[2];
                    user.Apellidos = (string)r.ItemArray[3];
                    user.Fecha_Nac = (DateTime)r.ItemArray[4];
                    user.Direccion = (string)r.ItemArray[5];
                    user.Administrador = (bool)r.ItemArray[6];


                }
                Conexion.Close();
                return user;

            }
            catch (Exception )
            {
                return null;

            }


        }

        public string Registrar(Usuario p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string insertQuery = "INSERT INTO Usuario (Id_Usuario, Contraseña, Nombre, Apellidos, " +
                    "Fecha_Nac, Direccion, Administrador)" + "values(null, @Contraseña, @Nombre, @Apellido, @fech, @Direccion, @Tipo); ";
                MySqlCommand sqlCom = new MySqlCommand(insertQuery, Conexion);
                sqlCom.Parameters.AddWithValue("@Contraseña", p.Contraseña);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Apellido", p.Apellidos);
                sqlCom.Parameters.AddWithValue("@fech", p.Fecha_Nac);
                sqlCom.Parameters.AddWithValue("@Direccion", p.Direccion);
                sqlCom.Parameters.AddWithValue("@Tipo", p.Administrador);
                sqlCom.ExecuteNonQuery();

                Conexion.Close();
                return "si";
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }



        public bool Delete(int id)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string insertQuery = "DELETE FROM Usuario WHERE Id_usuario=@id limit 1;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, Conexion);
                sqlCom.Parameters.AddWithValue("@id", id);
                sqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }





        public bool Update(Usuario p)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();
                string insertQuery = "UPDATE Usuario SET  Contraseña = @Contraseña, Nombre = @Nombre, Apellidos = @Apellidos, Fecha_Nac = @Fecha_Nac, Direccion = @Direccion, Administrador = @Administrador WHERE Id_Usuario = @Id_Usuari limit 1;";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, Conexion);
                sqlCom.Parameters.AddWithValue("@Contraseña", p.Contraseña);
                sqlCom.Parameters.AddWithValue("@Nombre", p.Nombre);
                sqlCom.Parameters.AddWithValue("@Apellidos", p.Apellidos);
                sqlCom.Parameters.AddWithValue("@Fecha_Nac", p.Fecha_Nac);
                sqlCom.Parameters.AddWithValue("@Direccion", p.Direccion);
                sqlCom.Parameters.AddWithValue("@Administrador", p.Administrador);
                sqlCom.Parameters.AddWithValue("@Id_Usuari", p.Id_Usuario);
                sqlCom.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        //"SELECT * FROM Usuario ORDER by Id_Usuario DESC LIMIT 1; ";

        public Usuario Ultimo()
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                //  bool si = false;
                Conexion.Open();
                string insertQuery = "SELECT* FROM Usuario ORDER by Id_Usuario DESC LIMIT 1; ";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, Conexion);
                //  sqlCom.Parameters.AddWithValue("@Id_Usuario", g);
                // sqlCom.Parameters.AddWithValue("@Contraseña", p.Contraseña);
                sqlCom.ExecuteNonQuery();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sqlCom;
                da.SelectCommand.Connection = Conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                Usuario user = new Usuario();
                foreach (DataRow r in dt.Rows)
                {

                    user.Id_Usuario = (int)r.ItemArray[0];
                    user.Contraseña = (string)r.ItemArray[1];
                    user.Nombre = (string)r.ItemArray[2];
                    user.Apellidos = (string)r.ItemArray[3];
                    user.Fecha_Nac = (DateTime)r.ItemArray[4];
                    user.Direccion = (string)r.ItemArray[5];
                    user.Administrador = (bool)r.ItemArray[6];


                }
                Conexion.Close();
                return user;

            }
            catch (Exception )
            {
                return null;

            }


        }
        public List<Usuario> GetAll()
        {
            List<Usuario> lista = new List<Usuario>();
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                Conexion.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();


                //cnn.Open();
                cmd.CommandText = "SELECT * FROM Usuario";
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                
                foreach (DataRow r in dt.Rows)
                {
                    Usuario user=new Usuario();
                    user.Id_Usuario = (int)r.ItemArray[0];
                    user.Contraseña = (string)r.ItemArray[1];
                    user.Nombre = (string)r.ItemArray[2];
                    user.Apellidos = (string)r.ItemArray[3];
                    user.Fecha_Nac = (DateTime)r.ItemArray[4];
                    user.Direccion = (string)r.ItemArray[5];
                    user.Administrador = (bool)r.ItemArray[6];
                    lista.Add(user);
                }
                Conexion.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }


        }



        public Usuario Especifico(int g)
        {
            Conexion.ConnectionString = "server=localhost; database=panaderia; uid=root; pwd=root;";
            try
            {
                //  bool si = false;
                Conexion.Open();
                string insertQuery = "select * from Usuario where Id_Usuario=@Id_Usuario ";

                MySqlCommand sqlCom = new MySqlCommand(insertQuery, Conexion);
                sqlCom.Parameters.AddWithValue("@Id_Usuario", g);
                // sqlCom.Parameters.AddWithValue("@Contraseña", p.Contraseña);
                sqlCom.ExecuteNonQuery();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sqlCom;
                da.SelectCommand.Connection = Conexion;
                da.Fill(ds);
                DataSet datos = ds;

                DataTable dt = datos.Tables[0];
                Usuario user = new Usuario();
                foreach (DataRow r in dt.Rows)
                {

                    user.Id_Usuario = (int)r.ItemArray[0];
                    user.Contraseña = (string)r.ItemArray[1];
                    user.Nombre = (string)r.ItemArray[2];
                    user.Apellidos = (string)r.ItemArray[3];
                    user.Fecha_Nac = (DateTime)r.ItemArray[4];
                    user.Direccion = (string)r.ItemArray[5];
                    user.Administrador = (bool)r.ItemArray[6];


                }
                Conexion.Close();
                return user;

            }
            catch (Exception )
            {
                return null;

            }


        }
    }
}
