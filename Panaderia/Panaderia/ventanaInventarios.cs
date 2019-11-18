using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Daos;
using Datos.Modelo;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Panaderia
{

    /*
     * Clase para la sección de inventarios
     * creacion de variables y metodos para la manipulación de información relacionada con la parte de inventarios,
     * se implementaron los métodos necesarios para la manipulacion de la ventana
     * funcionalidades básicas para la manipuclación de los componentes de la ventana,
     * métodos para la manipulación de datos y consultas con la base de datos a través de otras clases
     * como los modelos y los DAOS, verificacion de campos vacios a través de consultas en distintos metodos.
     */


    public partial class VentanaInventarios : Form
    {
        private Usuario usuario;
        private List<Ventas> listav;
        private MySqlConnection conexion = new MySqlConnection();
        public VentanaInventarios(Usuario usuario,List<Ventas> listav)
        {
            this.usuario = usuario;
            this.listav = listav;
            InitializeComponent();
            
        }

        Materia obj = new Materia();
        Materiadao obj2 = new Materiadao();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                if (txtDescripcion.Text.Equals("") || txtNombre.Text.Equals("") || txtExistencias.Text.Equals(""))
                {
                    MessageBox.Show("Llene bien el formulario");
                }
                else
                {
                    obj.Nombre = txtNombre.Text;
                    obj.Existencias = int.Parse(txtExistencias.Text);
                    obj.Descripcion = txtDescripcion.Text;
                    bool valor = obj2.Agregar(obj);
                    if (valor)
                    {
                        MessageBox.Show("El Producto se guardo con exito.");
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error: El Producto no se guardo.");
                    }
                    dgvProductos.ReadOnly = true;
                    dgvProductos.DataSource = obj2.Ver();
                    txtNombre.Text = "";
                    txtExistencias.Text = "";
                    txtDescripcion.Text = "";
                    lblIdMostrar.Text = "---";
                }
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para esta acción");
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                if (lblIdMostrar.Text.Equals("---"))
                {
                    MessageBox.Show("Seleccione el producto a actualizar");
                }
                else if (txtDescripcion.Text.Equals("") || txtNombre.Text.Equals("") || txtExistencias.Text.Equals(""))
                {
                    MessageBox.Show("Llene bien el formulario");
                }
                else
                {
                    obj.Nombre = txtNombre.Text;
                    obj.Existencias = int.Parse(txtExistencias.Text);
                    obj.Descripcion = txtDescripcion.Text;
                    obj.Id_Materia = int.Parse(lblIdMostrar.Text);
                    bool valor = obj2.Editar(obj);
                    if (valor)
                    {
                        MessageBox.Show("El Producto se actualizo con exito.");
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error: El Producto no se actualizo.");
                    }
                    dgvProductos.ReadOnly = true;
                    dgvProductos.DataSource = obj2.Ver();
                    txtNombre.Text = "";
                    txtExistencias.Text = "";
                    txtDescripcion.Text = "";
                    lblIdMostrar.Text = "---";
                }
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para esta acción");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuario.Administrador)
            {
                if (lblIdMostrar.Text.Equals("---"))
                {
                    MessageBox.Show("Escoga la materia a eliminar");
                }
                else
                {
                    obj.Nombre = txtNombre.Text;
                    obj.Existencias = int.Parse(txtExistencias.Text);
                    obj.Descripcion = txtDescripcion.Text;
                    obj.Id_Materia = int.Parse(lblIdMostrar.Text);
                    bool valor = obj2.Eliminar(obj);
                    if (valor)
                    {
                        MessageBox.Show("El Producto se elimino con exito.");
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error: El Producto no se elimino.");
                    }
                    dgvProductos.ReadOnly = true;
                    dgvProductos.DataSource = obj2.Ver();
                    txtNombre.Text = "";
                    txtExistencias.Text = "";
                    txtDescripcion.Text = "";
                    lblIdMostrar.Text = "---";
                }
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para esta acción");
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            //No es necesario
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Manda al formulario principal
          
                VentanaMenu ven = new VentanaMenu(usuario, listav);
                ven.Show();
                this.Close();
           
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //No es necesario
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Es mejor el de cellclick :v
            //txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
            //txtExistencias.Text = dgvProductos.CurrentRow.Cells["Existencias"].Value.ToString();
            //txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
            //lblIdMostrar.Text = dgvProductos.CurrentRow.Cells["Id_Materia"].Value.ToString();
            //obj.Nombre = txtNombre.Text;
            //obj.Existencias = int.Parse(txtExistencias.Text);
            //obj.Descripcion = txtDescripcion.Text;
            //obj.Id_Materia = int.Parse(lblIdMostrar.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtExistencias.Text = "";
            txtDescripcion.Text = "";
            lblIdMostrar.Text = "---";
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtExistencias.Text = dgvProductos.CurrentRow.Cells["Existencias"].Value.ToString();
            txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
            lblIdMostrar.Text = dgvProductos.CurrentRow.Cells["Id_Materia"].Value.ToString();
            obj.Nombre = txtNombre.Text;
            obj.Existencias = int.Parse(txtExistencias.Text);
            obj.Descripcion = txtDescripcion.Text;
            obj.Id_Materia = int.Parse(lblIdMostrar.Text);
        }

        private void txtExistencias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
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

        private void ventanaInventarios_Load(object sender, EventArgs e)
        {
            dgvProductos.ReadOnly = true;
            dgvProductos.DataSource = obj2.Ver();
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

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            btnAgregar_Click(sender, e);
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            btnEliminar_Click(sender, e);
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtNombre.ResetText();
            txtDescripcion.ResetText();
            txtExistencias.ResetText();
        }
    }
}
