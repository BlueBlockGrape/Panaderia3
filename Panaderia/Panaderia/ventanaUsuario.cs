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
    public partial class ventanaUsuario : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public ventanaUsuario(Usuario p, List<Ventas> listav)
        {
            this.listav = listav;
            usuario = p;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
                ventanaAgregarUsuario ven = new ventanaAgregarUsuario(usuario,listav);
                ven.Show();
                this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                ventanaMenu ven = new ventanaMenu(usuario,listav);
                
                this.Hide();
            ven.Show();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
                VentanaEditarUsuario ven = new VentanaEditarUsuario(usuario,listav);
                ven.Show();
                this.Hide();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
                ventanaEliminarUsuario ven = new ventanaEliminarUsuario(usuario,listav);
                ven.Show();
                this.Hide();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
