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
    public partial class VentanaProveedorMenu : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaProveedorMenu(Usuario usuario,List<Ventas> listav)
        {
            this.usuario = usuario;
            this.listav = listav;
            InitializeComponent();
        }

        private void VentanaProveedorMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventanaMenu ven = new ventanaMenu(usuario, listav);
            ven.Show();
            this.Hide();
            //Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaProveedorAdd vPa = new VentanaProveedorAdd(usuario,listav);
            vPa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaProveedorUpdate vPu = new VentanaProveedorUpdate(usuario,listav);
            vPu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaProveedorDelete vPd = new VentanaProveedorDelete(usuario,listav);
            vPd.Show();
        }
    }
}
