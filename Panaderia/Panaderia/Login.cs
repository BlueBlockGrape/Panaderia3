using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Daos;
using Datos.Modelo;
namespace Panaderia
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /*
         * Métodos de verificación y funcionalidad de los botones de la pantalla de login
         * además de la funcionalidad con la consulta de bases de datos y
         * algunos elementos relacionados al manejo de la interfaz
        */
        private void button1_Click(object sender, EventArgs e)
        {

            Usuario obj = new Usuario();
            Usuariodao vd = new Usuariodao();
            //String z = Tipotxt.SelectedValue.ToString();
            String z = Tipotxt.SelectedItem.ToString();
            if (Usertxt.Text.Equals("") || Passtxt.Text.Equals("") || z.Equals(""))
            {
                MessageBox.Show("Por favor, introduzca un ID válido", "ERROR*");
            }
            else
            {
                bool x = false;
                if (z.Equals("ADMINISTRADOR"))
                {
                    x = true;
                }

                obj.Id_Usuario = int.Parse(Usertxt.Text);
                obj.Contraseña = Passtxt.Text;
                obj.Administrador = x;
                Usuario g = vd.Entrar(obj);
               

               // string c = "";
                bool val = g.Administrador;
              /*  if (val)
                {
                   c = "ADMINISTRADOR";
                }
                else
                {
                    c = "EMPLEADO";
                }*/


              //  MessageBox.Show();
                if (g.Contraseña== obj.Contraseña && x==val)
               {
                    MessageBox.Show("Permiso concedido ", "Éxito");
                    List<Ventas> listav = new List<Ventas>();
                    VentanaMenu ven = new VentanaMenu(g,listav);
                   
                    this.Hide();
                    ven.Show();
                }
                else
                {
                    MessageBox.Show("Usuario, Contraseña o Tipo de Usuario incorrectos ", "*Error");
                }
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Desea salir del programa?", "Salir",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void Tipotxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Usertxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
           
            else
            {
                e.Handled = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Tipotxt.Text = "ADMINISTRADOR";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }


        /*
         * Método del botón para saber si se conceen permisos para entrar a la aplicación
         * utiliza llamadas a los DAOS y Modelos necesarios para verificar en la base de datos
         * para que se pueda obtener una respuesta y en base a eso otorgar o denegar los permisos a la aplicación
        */
        private void button1_Click_1(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            Usuariodao vd = new Usuariodao();
            //String z = Tipotxt.SelectedValue.ToString();
            String z = Tipotxt.SelectedItem.ToString();
            if (Usertxt.Text.Equals("") || Passtxt.Text.Equals("") || z.Equals(""))
            {
                MessageBox.Show("Por favor, introduzca un ID válido", "ERROR*");
            }
            else
            {
                bool x = false;
                if (z.Equals("ADMINISTRADOR"))
                {
                    x = true;
                }

                obj.Id_Usuario = int.Parse(Usertxt.Text);
                obj.Contraseña = Passtxt.Text;
                obj.Administrador = x;
                Usuario g = vd.Entrar(obj);


                // string c = "";
                bool val = g.Administrador;
                /*  if (val)
                  {
                     c = "ADMINISTRADOR";
                  }
                  else
                  {
                      c = "EMPLEADO";
                  }*/


                //  MessageBox.Show();
                if (g.Contraseña == obj.Contraseña && x == val)
                {
                    MessageBox.Show("Permiso concedido ", "Éxito");
                    List<Ventas> listav = new List<Ventas>();
                    VentanaMenu ven = new VentanaMenu(g, listav);

                    this.Hide();
                    ven.Show();
                }
                else
                {
                    MessageBox.Show("Usuario, Contraseña o Tipo de Usuario incorrectos ", "*Error");
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
