using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Modelo;
using Datos.Daos;
using System.Runtime.InteropServices;

namespace Panaderia
{

    /**
     * Creacion de componentes de la pantalla y elementos para
     * el manejo de datos
     */ 
    public partial class VentanaControl : Form
    {
        private int ind;
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaControl(Usuario usuario,List<Ventas> listav, int ind )
        {
            this.usuario = usuario;
            this.listav = listav;
            this.ind = ind;
            InitializeComponent();
        }

        /*
         * MEtodo de verificacion de usuario
         * 
         */ 

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            Usuariodao vd = new Usuariodao();
            //String z = Tipotxt.SelectedValue.ToString();
            //String z = Tipotxt.SelectedItem.ToString();
            if (Usertxt.Text.Equals("") || Passtxt.Text.Equals("") )
            {
                MessageBox.Show("Por favor, introduzca un ID válido", "ERROR*");
            }
            else
            {
                //bool x = false;
                //if (z.Equals("ADMINISTRADOR"))
                //{
                //    x = true;
                //}

                obj.Id_Usuario = int.Parse(Usertxt.Text);
                obj.Contraseña = Passtxt.Text;
                //obj.Administrador = x;
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
                if (g.Contraseña == obj.Contraseña &&  val)
                {
                    MessageBox.Show("Permiso concedido ", "Éxito");
                    //List<Ventas> listav = new List<Ventas>();
                    switch (ind)
                    {
                        case 1:
                            VentanaRegistros v = new VentanaRegistros(listav, usuario);
                            v.Show();
                            this.Hide();
                            break;
                        case 2:
                            VentanaUsuario ven = new VentanaUsuario(usuario, listav);
                            ven.Show();
                            this.Hide();
                            break;
                        case 3:
                             VentanaPanesMenu ve=new VentanaPanesMenu(usuario, listav);
                            ve.Show();
                            this.Hide();
                            break;
                        case 4:
                            VentanaProveedorMenu p = new VentanaProveedorMenu(usuario, listav);
                            p.Show();
                            this.Hide();
                            break;
                        case 5:
                            VentanaInventarios inv= new VentanaInventarios(usuario, listav);
                            inv.Show();
                            this.Hide();
                            break;

                    }
                    
                   
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña ", "*Error");
                }
            }
        }


        /*
        * Métodos para los botones en la parte superior derecha y
        * para poder cambiar de ventana.
        */

        private void ventanaControl_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (ind)
            {
                case 1:
                    VentanaVentas v = new VentanaVentas(usuario,listav);
                    v.Show();
                    this.Hide();
                    break;
                default:
                    VentanaMenu ven = new VentanaMenu(usuario, listav);
                    ven.Show();
                    this.Hide();
                    break;


            }
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int vParam, int iParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



    }
}
