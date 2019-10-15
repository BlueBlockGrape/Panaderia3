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
    public partial class VentanaProveedorAdd : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaProveedorAdd(Usuario usuario, List<Ventas> listav)
        {
            this.usuario = usuario;
            this.listav = listav;
            InitializeComponent();
        }

        Proveedor p = new Proveedor();
        Proveedordao pd = new Proveedordao();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaProveedorMenu vPm = new VentanaProveedorMenu(usuario,listav);
            vPm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals("") | txtDomicilio.Text.Equals("") | txtTel.Text.Equals("") | txtProducto.Text.Equals(""))
            {
                MessageBox.Show("Campos obligatorios vacíos", "ERROR*");
            }
            else
            {
                p.Nombre = txtNombre.Text;
                p.Domicilio = txtDomicilio.Text;
                p.Telefono = txtTel.Text;
                p.Productos = txtProducto.Text;
                pd.Insert(p);                
                MessageBox.Show("Registro Guardado", "Éxito");
                txtNombre.Text = "";
                txtDomicilio.Text = "";
                txtTel.Text = "";
                txtProducto.Text = "";
            }
        }

        private void VentanaProveedorAdd_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtNombre.Text.Count() == 49)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtNombre.Text.Count() == 49)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
