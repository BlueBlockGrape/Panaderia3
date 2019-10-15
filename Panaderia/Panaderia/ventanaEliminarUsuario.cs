using Datos.Daos;
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

    public partial class VentanaEliminarUsuario : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaEliminarUsuario(Usuario p, List<Ventas> listav)
        {
            this.listav = listav;
            usuario = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo ID_Usuario", "ERROR*");
            }
            else
            {
                int del = int.Parse(txtID.Text);
                Usuario obj = new Usuario();
                Usuariodao vd = new Usuariodao();
                bool g = vd.Delete(del);

                if (g)
                {
                    MessageBox.Show("Usuario eliminado con exito", "MENSAJE");
                }
                else
                {
                    MessageBox.Show("No se a encontrado algun usuario con ese id", "ERROR*");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                VentanaUsuario ven = new VentanaUsuario(usuario,listav);
                ven.Show();
                this.Hide();
            
        }

        private void ventanaEliminarUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
