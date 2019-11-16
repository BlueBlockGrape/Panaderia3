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
     * Clase para la sección de Ventas
     * creacion de variables y metodos para la manipulación de información relacionada con la parte 
     * del registro de ventas de cada uno de los empleados que han utilizado el programa,
     * se implementaron los métodos necesarios para la manipulacion de la ventana
     * funcionalidades básicas para la manipuclación de los componentes de la ventana,
     * métodos para la manipulación de datos y consultas con la base de datos a través de otras clases
     * como los modelos y los DAOS, verificacion de campos vacios a través de consultas en distintos metodos.
     */

    public partial class VentanaRegistros : Form
    {
        List<Ventas> listav;
        Usuario usuario;
        Ventasdao vd;
        Pertenecedao pd;
        public VentanaRegistros(List<Ventas> listav,Usuario usuario)
        {
            this.listav = listav;
            this.usuario = usuario;
            vd = new Ventasdao();
            pd = new Pertenecedao();
            InitializeComponent();
        }

        private void VentanaRegistros_Load(object sender, EventArgs e)
        {
            dtgVentas.DataSource = vd.GetAll();
            Usuariodao z = new Usuariodao();
            List<Usuario> us = z.GetAll();
            for (int i = 0; i < us.Count; i++)
            {
                cmcUsuario.Items.Add(us.ElementAt(i).Id_Usuario);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = dtgVentas.CurrentRow.Index;
            int id = int.Parse(dtgVentas.Rows[indice].Cells[0].Value.ToString());
            pd.Delete(id);
            vd.Delete(id);
            for (int i = 0; i < listav.Count(); i++)
            {
                if (listav.ElementAt(i).Id_Venta == id)
                {
                    listav.RemoveAt(i);
                    break;
                }
            }
            dtgVentas.DataSource = null;
            dtgVentas.DataSource = vd.GetAll();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            VentanaVentas v = new VentanaVentas(usuario, listav);
            v.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            int indice = dtgVentas.CurrentRow.Index;
            venta.Id_Venta = int.Parse(dtgVentas.Rows[indice].Cells[0].Value.ToString());
            venta.Id_Usuario = int.Parse(dtgVentas.Rows[indice].Cells[1].Value.ToString());
            venta.Fecha = Convert.ToDateTime((dtgVentas.Rows[indice].Cells[2].Value.ToString()));
            venta.Total= double.Parse(dtgVentas.Rows[indice].Cells[3].Value.ToString());
            venta.Descuento= double.Parse(dtgVentas.Rows[indice].Cells[4].Value.ToString());


            VentanaEditarVenta v = new VentanaEditarVenta(usuario, listav, venta);
            v.Show();
            
        }

        private void btnBuscaraño_Click(object sender, EventArgs e)
        {
            string fecha = dttFecha.Value.Year + "/" + dttFecha.Value.Month + "/" + dttFecha.Value.Day;
            List<Ventas> v= vd.GetFecha(fecha);
            
            if (v.Count == 0)
            {
                MessageBox.Show("No se encontraron registros");
            }
            else
            {
                dtgVentas.DataSource = null;
                dtgVentas.DataSource = v;
            }


        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            if (cmcUsuario.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el Id");
            }
            else
            {
                int id = int.Parse(cmcUsuario.Text);
                List<Ventas> v = vd.GetIdUsuario(id);

                if (v.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros");
                }
                else
                {
                    dtgVentas.DataSource = null;
                    dtgVentas.DataSource = v;
                }
            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (txtVenta.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Id");
            }
            else
            {
                int id = int.Parse(txtVenta.Text);
                List<Ventas> v = vd.GetVenta(id);

                if (v.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros");
                }
                else
                {
                    dtgVentas.DataSource = null;
                    dtgVentas.DataSource = v;
                }
            }
        }

        private void txtIdUsuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
