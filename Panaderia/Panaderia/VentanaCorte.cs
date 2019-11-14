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

namespace Panaderia
{
    public partial class VentanaCorte : Form
    {
        Usuario usuario;
        List<Ventas> lista;
        public VentanaCorte(Usuario usuario,List<Ventas> lista)
        {
            this.usuario = usuario;
            this.lista = lista;
            
            InitializeComponent();
        }

        private void VentanaCorte_Load(object sender, EventArgs e)
        {
            double total = 0;
            lblUsuario.Text = usuario.Nombre + " " + usuario.Apellidos;
            for (int i = 0; i < lista.Count(); i++)
            {
                total += lista.ElementAt(i).Total;
            }
            lblVentas.Text = (total) + "";

            double des = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                des += lista.ElementAt(i).Descuento;
            }
            lblDescuentos.Text = (des) + "";
            lblTotal.Text = (total - des) + "";
        }
        

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            VentanaVentas v = new VentanaVentas(usuario, lista);
            v.Show();
            this.Hide();
        }

        private void btnCorte_Click(object sender, EventArgs e)
        {
            /*  Login l = new Login();
                l.Show();
              this.Close();
               this.Hide();*/
            Application.Exit();

            //  VentanaCorte_Load(sender, e);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
