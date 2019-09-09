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
    public partial class ventanaMenu : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public ventanaMenu(Usuario p,List<Ventas> listav)
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
                ventanaUsuario ven = new ventanaUsuario(usuario,listav);
                
                this.Hide();
                ven.Show();
            }
            else
            {
                ventanaControl v = new ventanaControl(usuario, listav, 2);
               
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
                ventanaControl v = new ventanaControl(usuario, listav, 3);
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
                ventanaControl v = new ventanaControl(usuario, listav, 3);
                v.Show();
                this.Hide();
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                ventanaInventarios ven = new ventanaInventarios(usuario, listav);
                ven.Show();
                this.Hide();
            }
            else
            {
                ventanaControl v = new ventanaControl(usuario, listav, 5);
                v.Show();
                this.Hide();
            }
        }

        private void lblname_Click(object sender, EventArgs e)
        {

        }
    }
}
