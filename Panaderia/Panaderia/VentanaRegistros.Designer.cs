namespace Panaderia
{
    partial class VentanaRegistros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaRegistros));
            this.dtgVentas = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.dttFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscaraño = new System.Windows.Forms.Button();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.cmcUsuario = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgVentas
            // 
            this.dtgVentas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVentas.Location = new System.Drawing.Point(1, 1);
            this.dtgVentas.Name = "dtgVentas";
            this.dtgVentas.ReadOnly = true;
            this.dtgVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVentas.Size = new System.Drawing.Size(391, 369);
            this.dtgVentas.TabIndex = 10;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(1, 376);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(88, 33);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(286, 376);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(106, 33);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(671, 405);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(117, 33);
            this.btnRegresar.TabIndex = 9;
            this.btnRegresar.Text = "regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // dttFecha
            // 
            this.dttFecha.Location = new System.Drawing.Point(588, 35);
            this.dttFecha.Name = "dttFecha";
            this.dttFecha.Size = new System.Drawing.Size(200, 20);
            this.dttFecha.TabIndex = 1;
            // 
            // btnBuscaraño
            // 
            this.btnBuscaraño.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBuscaraño.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaraño.Location = new System.Drawing.Point(401, 22);
            this.btnBuscaraño.Name = "btnBuscaraño";
            this.btnBuscaraño.Size = new System.Drawing.Size(184, 33);
            this.btnBuscaraño.TabIndex = 2;
            this.btnBuscaraño.Text = "Buscar Fecha";
            this.btnBuscaraño.UseVisualStyleBackColor = true;
            this.btnBuscaraño.Click += new System.EventHandler(this.btnBuscaraño_Click);
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarUsuario.Location = new System.Drawing.Point(401, 76);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(184, 33);
            this.btnBuscarUsuario.TabIndex = 4;
            this.btnBuscarUsuario.Text = "Buscar Usuario";
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.Location = new System.Drawing.Point(401, 136);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(184, 33);
            this.btnVenta.TabIndex = 6;
            this.btnVenta.Text = "Buscar Venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // txtVenta
            // 
            this.txtVenta.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenta.Location = new System.Drawing.Point(588, 136);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(100, 33);
            this.txtVenta.TabIndex = 5;
            this.txtVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVenta_KeyPress);
            // 
            // cmcUsuario
            // 
            this.cmcUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmcUsuario.FormattingEnabled = true;
            this.cmcUsuario.Location = new System.Drawing.Point(591, 88);
            this.cmcUsuario.Name = "cmcUsuario";
            this.cmcUsuario.Size = new System.Drawing.Size(197, 21);
            this.cmcUsuario.TabIndex = 11;
            // 
            // VentanaRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Panaderia.Properties.Resources.pan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.cmcUsuario);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.txtVenta);
            this.Controls.Add(this.btnBuscarUsuario);
            this.Controls.Add(this.btnBuscaraño);
            this.Controls.Add(this.dttFecha);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgVentas);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VentanaRegistros";
            this.Text = "Registros";
            this.Load += new System.EventHandler(this.VentanaRegistros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgVentas;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.DateTimePicker dttFecha;
        private System.Windows.Forms.Button btnBuscaraño;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.ComboBox cmcUsuario;
    }
}