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
    public partial class VentanaPanesMenu : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaPanesMenu(Usuario usuario,List<Ventas> listav)
        {
            this.usuario = usuario;
            this.listav = listav;
            InitializeComponent();
        }

        private void VentanaPanesMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaPanesAdd vPa = new VentanaPanesAdd(usuario,listav);
            vPa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaPanesUpdate vPm = new VentanaPanesUpdate(usuario,listav);
            vPm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaPanesDelete vPd = new VentanaPanesDelete(usuario,listav);
            vPd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventanaMenu ven = new ventanaMenu(usuario, listav);
            ven.Show();
            this.Hide();
//Application.Exit();
        }
    }
}
