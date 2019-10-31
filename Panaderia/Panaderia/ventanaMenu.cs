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
            usuariossubmenu.Visible = true;
            /*if (usuario.Administrador)
            {
                VentanaUsuario ven = new VentanaUsuario(usuario,listav);


                AbrirForm(ven);
            }
            else
            {
                VentanaControl v = new VentanaControl(usuario, listav, 2);
               
                this.Hide();
                v.Show();
            }*/
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login ven = new Login();
            ven.Show();
            this.Hide();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = true;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
        }

        private void btnPanes_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = true;
            proveedoressubmenu.Visible = false;
           /* if (usuario.Administrador)
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
            }*/
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = true;
            /*if (usuario.Administrador)
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
            }*/
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            VentanaInventarios ven = new VentanaInventarios(usuario, listav);
            AbrirForm(ven);
            usuariossubmenu.Visible= false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            /* if (usuario.Administrador)
             {

                 ven.Show();
                 this.Hide();
             }
             else
             {
                 VentanaControl v = new VentanaControl(usuario, listav, 5);
                 v.Show();
                 this.Hide();
             }*/
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
            btnRestaurar.Visible = true;
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

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AbrirForm(object formhija)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
                Form fh = formhija as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.PanelContenedor.Controls.Add(fh);
                this.PanelContenedor.Tag = fh;
                fh.Show();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirForm(new VentanaAgregarUsuario(usuario, listav));
            usuariossubmenu.Visible = false;
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            AbrirForm(new VentanaEditarUsuario(usuario, listav));
            usuariossubmenu.Visible = false;
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            AbrirForm(new VentanaEliminarUsuario(usuario, listav));
            usuariossubmenu.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            VentanaVentas v = new VentanaVentas(usuario, listav);
            AbrirForm(v);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = true;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = true;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            AbrirForm(new VentanaProveedorDelete(usuario, listav));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ventassubmenu.Visible = false;
            VentanaRegistros vr = new VentanaRegistros(listav,usuario);
            AbrirForm(vr);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            AbrirForm(new VentanaCorte(usuario, listav));
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            AbrirForm(new VentanaProveedorAdd(usuario, listav));
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            AbrirForm(new VentanaProveedorUpdate(usuario, listav));
      
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            AbrirForm(new VentanaProveedorDelete(usuario, listav));
        }

        private void btnAgregarPan_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            AbrirForm(new VentanaPanesAdd(usuario, listav));
        }

        private void btnEditarPan_Click(object sender, EventArgs e)
        {
            usuariossubmenu.Visible = false;
            ventassubmenu.Visible = false;
            panessubmenu.Visible = false;
            proveedoressubmenu.Visible = false;
            AbrirForm(new VentanaPanesUpdate(usuario, listav));
        }
    }
}
