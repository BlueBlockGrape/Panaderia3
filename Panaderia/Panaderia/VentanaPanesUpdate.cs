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
    public partial class VentanaPanesUpdate : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaPanesUpdate(Usuario usuario, List<Ventas> listav)
        {
            this.usuario = usuario;
            this.listav = listav;
            InitializeComponent();
        }

        Panes p = new Panes();
        Panesdao pd = new Panesdao();

        private void button1_Click(object sender, EventArgs e)
        {
            LlenarTextBox(dataGridView1.CurrentRow.Index);
        }

        private void LlenarTextBox(int Indice)
        {
            
        }

        private void VentanaPanesUpdate_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Panesdao().GetAll();
            cmbTam.Text = "CHICO";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaPanesMenu vPm = new VentanaPanesMenu(usuario,listav);
            vPm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Seleccione producto a modificar");
            }else if (txtNombre.Text.Equals("") | txtPrecio.Text.Equals(""))
            {
                MessageBox.Show("Llene el formulario");
            }
            else{
                p.Id_Pan = int.Parse(txtID.Text);
                p.Nombre = txtNombre.Text;
                p.Precio = double.Parse(txtPrecio.Text);
                p.Tamaño = cmbTam.Text;
                pd.Update(p);
                MessageBox.Show("Registro Modificado", "Éxito");
                txtID.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
                cmbTam.Text = "-Selecciona una opción-";
                dataGridView1.DataSource = new Panesdao().GetAll();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {

                if (txtPrecio.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }


            }
            else
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbTam.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
