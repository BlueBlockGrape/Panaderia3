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
    public partial class ventanaAgregarUsuario : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public ventanaAgregarUsuario(Usuario p, List<Ventas> listav)
        {
            this.listav = listav;
            usuario = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo nombre", "ERROR*");
            }else if (txtApellidos.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo Apellidos", "ERROR*");
            }else if (txtDireccion.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo Dirección", "ERROR*");
            }else if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo Contraseña", "ERROR*");
            }
            else
            {
                Usuario obj = new Usuario();
                Usuariodao vd = new Usuariodao();
                String z = cmbTipo.SelectedItem.ToString();
                DateTime dat = dtpFecha.Value; //"1/1/2010"

                bool x = false;
                if (z.Equals("ADMINISTRADOR"))
                {
                    x = true;
                }

                obj.Nombre = txtNombre.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.Fecha_Nac = dat;
                obj.Direccion = txtDireccion.Text;
                obj.Administrador = x;
                obj.Contraseña = txtPassword.Text;
                string g = vd.Registrar(obj);
                Usuario d = vd.Ultimo();
                MessageBox.Show("Usuario agregado con exito"+ ".\n"+"ID_USUARIO: "+ d.Id_Usuario + ".\n" +"Conraseña: "+ txtPassword.Text);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                ventanaUsuario ven = new ventanaUsuario(usuario,listav);
                ven.Show();
                this.Hide();
            
        }

        private void ventanaAgregarUsuario_Load(object sender, EventArgs e)
        {
            cmbTipo.Text = "ADMINISTRADOR";
        }
    }
}
