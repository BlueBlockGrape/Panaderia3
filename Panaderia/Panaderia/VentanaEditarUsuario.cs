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
    public partial class VentanaEditarUsuario : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaEditarUsuario(Usuario p, List<Ventas> listav)
        {
            this.listav = listav;
            usuario = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo Nombre", "ERROR*");
            }
            else if (txtApellidos.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo Apellidos", "ERROR*");
            }
            else if (txtFecha.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo Fecha Nac.", "ERROR*");
            }
            else if (txtDireccion.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo Direccion", "ERROR*");
            }
            else if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo Contraseña", "ERROR*");
            }
            else
            {
                Usuario obj = new Usuario();
                Usuariodao vd = new Usuariodao();
                String z = cmbTipo.SelectedItem.ToString();
                DateTime dat = Convert.ToDateTime(txtFecha.Text); //"1/1/2010"

                bool x = false;
                if (z.Equals("ADMINISTRADOR"))
                {
                    x = true;
                }

                obj.Contraseña = txtPassword.Text;
                obj.Nombre = txtNombre.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.Fecha_Nac = dat;
                obj.Direccion = txtDireccion.Text;
                obj.Administrador = x;
                obj.Id_Usuario = int.Parse(cmbUsuario.Text);
                bool g = vd.Update(obj);
                if (g)
                {
                    MessageBox.Show("Se modifico el registro correctamente", "Correcto");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al querer actualizar", "ERROR*");
                }



                txtNombre.Text = "";
                txtApellidos.Text = "";
                txtFecha.Text = "";
                txtDireccion.Text = "";
                cmbTipo.Text = "ADMINISTRADOR";
                txtPassword.Text = "";
                cmbUsuario.Text = "";
                txtNombre.Enabled = false;
                txtApellidos.Enabled = false;
                txtFecha.Enabled = false;
                txtDireccion.Enabled = false;
                txtPassword.Enabled = false;
                cmbTipo.Enabled = false;
            }
        

       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                ventanaUsuario ven = new ventanaUsuario(usuario,listav);
                ven.Show();
                this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.Text.Equals(""))
            {
                MessageBox.Show("Falta llenar el campo ID", "ERROR*");
            }
            else
            {
                string f = "";
                Usuario obj = new Usuario();
                Usuariodao vd = new Usuariodao();
                Usuario d = vd.Especifico(int.Parse(cmbUsuario.Text));
                txtNombre.Text = d.Nombre;
                txtApellidos.Text = d.Apellidos;
                txtFecha.Text = d.Fecha_Nac+"";
                txtDireccion.Text = d.Direccion;
                if (d.Administrador)
                {
                    f = "ADMINISTRADOR";
                }
                else
                {
                    f = "EMPLEADO";
                }
                cmbTipo.Text = f;
                txtPassword.Text = d.Contraseña;

                txtNombre.Enabled = true;
                txtApellidos.Enabled = true;
                txtFecha.Enabled = true;
                txtDireccion.Enabled = true;
                txtPassword.Enabled = true;
                cmbTipo.Enabled = true;
            }
        }

        private void VentanaEditarUsuario_Load(object sender, EventArgs e)
        {
            cmbUsuario.Enabled = true;
            Usuariodao z = new Usuariodao();
            List<Usuario> us = z.GetAll();
            for(int i = 0; i < us.Count; i++)
            {
                cmbUsuario.Items.Add(us.ElementAt(i).Id_Usuario);

            }
        }
    }
}
