namespace ProyectoLBD
{
    partial class FrmSucursal
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
            this.dgvSucursal = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdSucursal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSucursal
            // 
            this.dgvSucursal.AllowUserToAddRows = false;
            this.dgvSucursal.AllowUserToDeleteRows = false;
            this.dgvSucursal.AllowUserToOrderColumns = true;
            this.dgvSucursal.AllowUserToResizeColumns = false;
            this.dgvSucursal.AllowUserToResizeRows = false;
            this.dgvSucursal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSucursal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSucursal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSucursal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursal.Location = new System.Drawing.Point(65, 199);
            this.dgvSucursal.Name = "dgvSucursal";
            this.dgvSucursal.RowHeadersVisible = false;
            this.dgvSucursal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSucursal.Size = new System.Drawing.Size(522, 283);
            this.dgvSucursal.TabIndex = 0;
            this.dgvSucursal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeliculas_CellClick);
            this.dgvSucursal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeliculas_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnResetear);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.txtProvincia);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIdSucursal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(66, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 181);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion de Sucursales";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(114, 161);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(234, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "DIRECCION";
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(481, 125);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 8;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new System.Drawing.Point(481, 89);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(114, 128);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(234, 20);
            this.txtProvincia.TabIndex = 3;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(481, 54);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(481, 15);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "PROVINCIA";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(114, 92);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(234, 20);
            this.txtTelefono.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "TELEFONO";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(114, 57);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(234, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID SUCURSAL";
            // 
            // txtIdSucursal
            // 
            this.txtIdSucursal.Location = new System.Drawing.Point(114, 25);
            this.txtIdSucursal.Name = "txtIdSucursal";
            this.txtIdSucursal.Size = new System.Drawing.Size(234, 20);
            this.txtIdSucursal.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "NOMBRE";
            // 
            // FrmSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 513);
            this.Controls.Add(this.dgvSucursal);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSucursal";
            this.Text = "FrmSucursal";
            this.Load += new System.EventHandler(this.FrmSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSucursal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label3;
    }
}