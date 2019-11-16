﻿using System;
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
     * Clase para la edición de ventas
     * creacion de variables y metodos para la manipulación de información relacionada con las ventas,
     * se implementaron los métodos necesarios para la manipulacion de la ventana
     * funcionalidades básicas para la manipuclación de los componentes de la ventana,
     * métodos para la manipulación de datos y consultas con la base de datos a través de otras clases
     * como los modelos y los DAOS, verificacion de campos vacios a través de consultas en distintos metodos.
     */ 


    public partial class VentanaEditarVenta : Form
    {
        Usuario usuario;
        List<Ventas> listav;
        List<Pertenece> lista;
        Ventas venta;
        Pertenecedao pd;
        
        public VentanaEditarVenta(Usuario usuario, List<Ventas> listav, Ventas venta)
        {
            
            this.usuario = usuario;
            this.listav = listav;
            this.venta = venta;
            this.pd = new Pertenecedao();
            InitializeComponent();
        }

        private void VentanaEditarVenta_Load(object sender, EventArgs e)
        {
            Panesdao pn = new Panesdao();
            lista = pd.GetAll(venta.Id_Venta);
            dtgPanes.DataSource = pn.GetAll();
           // MessageBox.Show(venta.Id_Venta + "");
            lblFecha.Text = venta.Fecha.Year+"/"+venta.Fecha.Month+"/"+venta.Fecha.Day;
            lblVenta.Text = venta.Id_Venta+"";
            lblTotal.Text = venta.Total + "";
            txtDescuento.Text = venta.Descuento + "";
            dtgPertenece.DataSource = lista;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

            
            this.Hide();
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
            carrito(dtgPanes.CurrentRow.Index, cantidad);
            dtgPertenece.DataSource = null;
            dtgPertenece.DataSource = lista;
            lblTotal.Text = "$ " + total() + "";
            txtCantidad.Text = "";
        
        }


        private void carrito(int Indice, int cantidad)
        {
            bool co = true;
            Pertenece pan = new Pertenece();
            pan.Id_Venta = venta.Id_Venta;
            pan.Id_Pan = int.Parse(dtgPanes.Rows[Indice].Cells[0].Value.ToString());
            pan.Nombre = dtgPanes.Rows[Indice].Cells[1].Value.ToString();
            pan.Precio = double.Parse(dtgPanes.Rows[Indice].Cells[2].Value.ToString());
            pan.Cantidad = cantidad;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista.ElementAt(i).Id_Pan == pan.Id_Pan)
                {
                    lista.ElementAt(i).Cantidad += cantidad;
                    co = false;
                    break;
                }

            }
            if (co)
            {
                lista.Add(pan);
            }

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
        public  void actualizarcorte(int id,double descuento)
        {
            for (int i = 0; i < listav.Count; i++)
            {
                if (listav.ElementAt(i).Id_Venta == id)
                {
                    listav.ElementAt(i).Total = total();
                    listav.ElementAt(i).Descuento = descuento;
                    break;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            double des;
            if (txtDescuento.Text.Equals(""))
            {
                des = 0;
            }
            else
            {
                des = double.Parse(txtDescuento.Text);
            }
            if (lista.Count == 0)
            {
                MessageBox.Show("Compra vacía");
            }
            else if (total() < des)
            {
                MessageBox.Show("Descuento eccede el total");
            }
            else
            {
                pd.Delete(venta.Id_Venta);

                for (int i = 0; i < lista.Count(); i++)
                {
                    pd.Insert(lista.ElementAt(i));
                }

                Ventasdao vd = new Ventasdao();
                venta.Total = total();
                venta.Descuento = des;
                vd.Update(venta);
                actualizarcorte(venta.Id_Venta, des);
                VentanaVentas v = new VentanaVentas(usuario, listav);

                v.Show();
                this.Hide();
            }



            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lista.Count > 0)
            {
                lista.RemoveAt(dtgPertenece.CurrentRow.Index);

                dtgPertenece.DataSource = null;
                dtgPertenece.DataSource = lista;
                lblTotal.Text = "$ " + total() + "";
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtgPanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            btnEliminar_Click(sender, e);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
