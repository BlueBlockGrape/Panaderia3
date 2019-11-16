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

    /*
     * Clase para la eliminación de un usuario
     * creacion de variables y metodos para la manipulación de información relacionada con la eliminación de usuarios,
     * se implementaron los métodos necesarios para la manipulacion de la ventana
     * funcionalidades básicas para la manipuclación de los componentes de la ventana,
     * métodos para la manipulación de datos y consultas con la base de datos a través de otras clases
     * como los modelos y los DAOS, verificacion de campos vacios a través de consultas en distintos metodos.
     */


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

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender,e);
        }
    }
}
