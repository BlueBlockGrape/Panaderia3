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
    public partial class VentanaVentas : Form
    {
        private Usuario usuario;
        private List<Pertenece> lista ;
        private int id;
        private Ventasdao vd;
        private List<Ventas> listav;
        public VentanaVentas(Usuario p,List<Ventas> listav)
        {
            vd = new Ventasdao();
            id = vd.GetLast()+1;
            usuario = p;
            lista = new List<Pertenece>();
            this.listav = listav;
            InitializeComponent();
        }

        private void VentanaVentas_Load(object sender, EventArgs e)
        {
            lblNombre.Text = usuario.Nombre;
            Panesdao pd = new Panesdao();
            dtgPanes.DataSource = pd.GetAll();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int cantidad;
            if (txtCantidad.Text.Equals(""))
            {
                cantidad = 1;
            }
            else
            {
                cantidad = int.Parse(txtCantidad.Text);
            }
            carrito(dtgPanes.CurrentRow.Index,cantidad);
            dtgCarrito.DataSource = null;
            dtgCarrito.DataSource = lista;
            lblTotal.Text = "$ "+total()+"";
            txtCantidad.Text = "";
        }
        private void carrito(int Indice, int cantidad)
        {
            bool co = true;
            Pertenece pan = new Pertenece();
            pan.Id_Venta =id ;
            pan.Id_Pan =int.Parse(dtgPanes.Rows[Indice].Cells[0].Value.ToString());
            pan.Nombre = dtgPanes.Rows[Indice].Cells[1].Value.ToString();
            pan.Precio = double.Parse(dtgPanes.Rows[Indice].Cells[2].Value.ToString());
            pan.Cantidad = cantidad;
            for(int i = 0; i < lista.Count; i++)
            {
                if (lista.ElementAt(i).Id_Pan == pan.Id_Pan)
                {
                    lista.ElementAt(i).Cantidad+=cantidad;
                    co = false;
                    break;
                }

            }
            if (co) {
                lista.Add(pan);
            }

        }
        private void Eliminarcarrito(int Indice)
        {

            lista.RemoveAt(Indice);

        }

        public double total()
        {
            double total = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                total = total + (lista.ElementAt(i).Precio * lista.ElementAt(i).Cantidad);
            }
            return total;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lista.Count != 0)
            {
                Eliminarcarrito(dtgCarrito.CurrentRow.Index);
                dtgCarrito.DataSource = null;
                dtgCarrito.DataSource = lista;
                lblTotal.Text = "$ " + total() + "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            venta.Id_Venta = id;
            venta.Id_Usuario = usuario.Id_Usuario;
            venta.Fecha = DateTime.Today;
            venta.Total = total();
            if (txtDescuento.Text.Equals(""))
            {
                venta.Descuento = 0;
            }
            else
            {
                venta.Descuento = double.Parse(txtDescuento.Text);
            }
            if (lista.Count == 0)
            {
                MessageBox.Show("Compra vacía");
            }else if (venta.Total<venta.Descuento)
            {
                MessageBox.Show("Descuento eccede el total");
            }
            else
            {
                
                VentanaComprar v = new VentanaComprar(venta, usuario, lista, listav);
                v.Show();
                this.Hide();
            }
        }

        private void btnCorte_Click(object sender, EventArgs e)
        {
            VentanaCorte c = new VentanaCorte(usuario,listav);
            c.Show();
            this.Hide();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                VentanaRegistros r = new VentanaRegistros(listav, usuario);
                r.Show();
                this.Hide();
            }
            else
            {
                ventanaControl v = new ventanaControl(usuario, listav, 1);
                v.Show();
                this.Hide();

            }
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }else if (e.KeyChar == '.')
            {
               
                    if (txtDescuento.Text.Contains("."))
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            ventanaMenu v = new ventanaMenu(usuario, listav);
            v.Show();
            this.Hide();
        }
    }
}
