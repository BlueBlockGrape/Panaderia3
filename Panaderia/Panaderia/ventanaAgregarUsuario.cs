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
     * Declaración de componentes y elementos
     * de la pantalla para el manejo de datos
     */ 


    public partial class VentanaAgregarUsuario : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaAgregarUsuario(Usuario p, List<Ventas> listav)
        {
            this.listav = listav;
            usuario = p;
            InitializeComponent();
        }


        /*
         * Métodos de llamada a la otros componentes como los modelos y los DAOS
         * para realizar consultas
         */ 

        private void button1_Click(object sender, EventArgs e)
        {

            if (usuario.Administrador)
            {

                if (txtNombre.Text.Equals(""))
                {
                    MessageBox.Show("Falta llenar el campo nombre", "ERROR*");
                }
                else if (txtApellidos.Text.Equals(""))
                {
                    MessageBox.Show("Falta llenar el campo Apellidos", "ERROR*");
                }
                else if (txtDireccion.Text.Equals(""))
                {
                    MessageBox.Show("Falta llenar el campo Dirección", "ERROR*");
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
                    MessageBox.Show("Usuario agregado con exito" + ".\n" + "ID_USUARIO: " + d.Id_Usuario + ".\n" + "Conraseña: " + txtPassword.Text);
                }
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para esta acción");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                VentanaUsuario ven = new VentanaUsuario(usuario,listav);
                ven.Show();
                this.Hide();
            
        }

        /*
         * Métodos para los botones en la parte superior derecha y
         * para poder cambiar de ventana.
         */ 

        private void ventanaAgregarUsuario_Load(object sender, EventArgs e)
        {
            cmbTipo.Text = "ADMINISTRADOR";
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        /*
         * método para llamar a agregar a un nuevo usuario y
         * para limpiar los campos de texto de la aplicación.
         */

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtPassword.Text = "";
        }
    }
}
