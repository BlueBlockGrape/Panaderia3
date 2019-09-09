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
                    ventanaMenu ven = new ventanaMenu(g,listav);
                   
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
    }
}
