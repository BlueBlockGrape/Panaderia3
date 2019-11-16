using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Modelo;
using Datos.Daos;

namespace Panaderia
{

    /*
         * Métodos de llamada a la otros componentes como los modelos y los DAOS
         * para realizar consultas
   */
    public partial class VentanaComprar : Form
    {
        private Ventas venta;
        private Usuario usuario;
        private List<Pertenece> lista;
        private Ventasdao vd;
        private Pertenecedao pd;
        private List<Ventas> listav;
        public VentanaComprar(Ventas venta,Usuario usuario,List<Pertenece> lista,List<Ventas> listav)
        {
            this.listav = listav;
            this.usuario = usuario;
            this.venta = venta;
            InitializeComponent();
            lblUsuario.Text = usuario.Nombre + " " + usuario.Apellidos;
            lblTotal.Text = "$ "+venta.Total+"";
            lblDes.Text = "$ " + venta.Descuento + "";
            lblTotalPagar.Text = "$ " + (venta.Total - venta.Descuento) + "";
            lblIdVenta.Text = venta.Id_Venta+"";
            lblFecha.Text = venta.Fecha.Day+"/"+venta.Fecha.Month+"/"+venta.Fecha.Year;
            this.lista = lista;
            vd = new Ventasdao();
            pd = new Pertenecedao();
        }


        /*
         * Métodos para los botones en la parte superior derecha y
         * para poder cambiar de ventana.
         */
        private void VentanaComprar_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        /*
         * método para llamar al método para pagar y
         * para limpiar los campos de texto de la aplicación.
         */

        private void btnPagar_Click(object sender, EventArgs e)
        {
            double pagar=0.0;
            if (txtPago.Text.Equals("")){
                pagar = 0;
            }
            else
            {
                pagar = double.Parse(txtPago.Text);
            }
            if ((venta.Total-venta.Descuento) <= pagar) {
                vd.Insert(venta);
                for (int i = 0; i < lista.Count(); i++)
                {
                    pd.Insert(lista.ElementAt(i));
                }
                MessageBox.Show("Cambio= "+(pagar - venta.Total+venta.Descuento));
                listav.Add(venta);
                VentanaVentas v = new VentanaVentas(usuario,listav);
                
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("Faltan "+(venta.Total-pagar));
            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
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

                if (txtPago.Text.Contains("."))
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


        /*
        * Métodos para los botones en la parte superior derecha y
        * para poder cambiar de ventana.
        */

        private void txtPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            btnRegresar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            
            btnRegresar.Visible = false;
        }
    }
}
