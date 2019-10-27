using Datos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panaderia
{
    public partial class VentanaMenu : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaMenu(Usuario p,List<Ventas> listav)
        {
            this.listav = listav;
            usuario = p;
            InitializeComponent();
        }

        private void ventanaMenu_Load(object sender, EventArgs e)
        {
            lblname.Text = usuario.Nombre;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                VentanaUsuario ven = new VentanaUsuario(usuario,listav);
                
                this.Hide();
                ven.Show();
            }
            else
            {
                VentanaControl v = new VentanaControl(usuario, listav, 2);
               
                this.Hide();
                v.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login ven = new Login();
            ven.Show();
            this.Hide();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            VentanaVentas v = new VentanaVentas(usuario, listav);
            v.Show();
            this.Hide();
        }

        private void btnPanes_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                VentanaPanesMenu ven = new VentanaPanesMenu(usuario, listav);
                ven.Show();
                this.Hide();
            }
            else
            {
                VentanaControl v = new VentanaControl(usuario, listav, 3);
                v.Show();
                this.Hide();
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                VentanaProveedorMenu ven = new VentanaProveedorMenu(usuario, listav);
                ven.Show();
                this.Hide();
            }
            else
            {
                VentanaControl v = new VentanaControl(usuario, listav, 3);
                v.Show();
                this.Hide();
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                VentanaInventarios ven = new VentanaInventarios(usuario, listav);
                ven.Show();
                this.Hide();
            }
            else
            {
                VentanaControl v = new VentanaControl(usuario, listav, 5);
                v.Show();
                this.Hide();
            }
        }

        private void lblname_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnMinimizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }
    }
}
