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

    /*
     * Clase para la sección de agregar panes
     * creacion de variables y metodos para la manipulación de información relacionada con la parte 
     * de añadir panes a la lista de seleccion en la parte de ventas introduciendolos en la base de datos,
     * se implementaron los métodos necesarios para la manipulacion de la ventana
     * funcionalidades básicas para la manipuclación de los componentes de la ventana,
     * métodos para la manipulación de datos y consultas con la base de datos a través de otras clases
     * como los modelos y los DAOS, verificacion de campos vacios a través de consultas en distintos metodos.
     */

    public partial class VentanaPanesAdd : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        public VentanaPanesAdd(Usuario usuario,List<Ventas> listav)
        {
            this.usuario = usuario;
            this.listav = listav;
            InitializeComponent();
        }

        Panes p = new Panes();
        Panesdao pd = new Panesdao();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaPanesMenu vPm = new VentanaPanesMenu(usuario,listav);
            vPm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Equals("") | txtPrecio.Text.Equals("") | cmbTam.Text.Equals("-Selecciona tamaño del pan-"))
            {
                MessageBox.Show("Campos obligatorios vacíos", "ERROR*");
            }
            else
            {
                p.Nombre = txtNombre.Text;
                p.Precio = double.Parse(txtPrecio.Text);
                p.Tamaño = cmbTam.Text;
                pd.Insert(p);                
                MessageBox.Show("Registro Guardado", "Éxito");
                txtNombre.Text = "";
                txtPrecio.Text = "";
                cmbTam.Text = "Chico" ;
            }
        }

        private void VentanaPanesAdd_Load(object sender, EventArgs e)
        {
            cmbTam.Text = "CHICO";
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
    }
}
