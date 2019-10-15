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
    public partial class VentanaProveedorUpdate : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaProveedorUpdate(Usuario usuario,List<Ventas> listav)
        {
            this.usuario = usuario;
            this.listav = listav;
            InitializeComponent();
        }

        Proveedor p = new Proveedor();
        Proveedordao pd = new Proveedordao();


        private void LlenarTextBox(int Indice)
        {
            txtID.Text = dataGridView1.Rows[Indice].Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.Rows[Indice].Cells[1].Value.ToString();
            txtDomicilio.Text = dataGridView1.Rows[Indice].Cells[2].Value.ToString();
            txtTel.Text = dataGridView1.Rows[Indice].Cells[3].Value.ToString();
            txtProducto.Text = dataGridView1.Rows[Indice].Cells[4].Value.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LlenarTextBox(dataGridView1.CurrentRow.Index);
        }

        private void VentanaProveedorUpdate_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Proveedordao().GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaProveedorMenu vPm = new VentanaProveedorMenu(usuario,listav);
            vPm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Escoga el proveedor a modificar");
            }
           else if ( txtNombre.Text.Equals("") || txtProducto.Text.Equals("") || txtDomicilio.Text.Equals("") || txtTel.Text.Equals(""))
            {
                MessageBox.Show("Llene bien el formulario");
            }
            else
            {
                p.Id_Proveedor = int.Parse(txtID.Text);
                p.Nombre = txtNombre.Text;
                p.Domicilio = txtDomicilio.Text;
                p.Telefono = txtTel.Text;
                p.Productos = txtProducto.Text;
                pd.Update(p);
                MessageBox.Show("Registro Modificado", "Éxito");
                txtID.Text = "";
                txtNombre.Text = "";
                txtDomicilio.Text = "";
                txtTel.Text = "";
                txtProducto.Text = "";
                dataGridView1.DataSource = new Proveedordao().GetAll();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDomicilio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtProducto.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
