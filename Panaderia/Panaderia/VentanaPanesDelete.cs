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
    public partial class VentanaPanesDelete : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaPanesDelete(Usuario usuario,List<Ventas> listav)
        {
            this.usuario = usuario;
            this.listav = listav;
            InitializeComponent();
        }

        Panes p = new Panes();
        Panesdao pd = new Panesdao();

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDel.Text.Equals(""))
            {
                MessageBox.Show("Por favor, introduzca un ID válido", "ERROR*");
            }
            else
            {               
                p.Id_Pan = int.Parse(txtDel.Text);                
               if(pd.Delete(p)) {

                }
                MessageBox.Show("Registro Eliminado", "Éxito");
                txtDel.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaPanesMenu vPm = new VentanaPanesMenu(usuario,listav);
            vPm.Show();
        }

        private void VentanaPanesDelete_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Panesdao().GetAll();
        }

        private void txtDel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            
            else
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDel.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
