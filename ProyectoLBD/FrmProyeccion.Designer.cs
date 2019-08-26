namespace ProyectoLBD
{
    partial class FrmProyeccion
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
            this.dgvProyeccion = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyeccion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProyeccion
            // 
            this.dgvProyeccion.AllowUserToAddRows = false;
            this.dgvProyeccion.AllowUserToDeleteRows = false;
            this.dgvProyeccion.AllowUserToOrderColumns = true;
            this.dgvProyeccion.AllowUserToResizeColumns = false;
            this.dgvProyeccion.AllowUserToResizeRows = false;
            this.dgvProyeccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProyeccion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProyeccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProyeccion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvProyeccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProyeccion.Location = new System.Drawing.Point(28, 85);
            this.dgvProyeccion.Name = "dgvProyeccion";
            this.dgvProyeccion.RowHeadersVisible = false;
            this.dgvProyeccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProyeccion.Size = new System.Drawing.Size(497, 353);
            this.dgvProyeccion.TabIndex = 16;
            this.dgvProyeccion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProyeccion_CellClick);
            this.dgvProyeccion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProyeccion_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 73);
            this.label1.TabIndex = 21;
            this.label1.Text = "Proyecciones";
            // 
            // FrmProyeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProyeccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProyeccion";
            this.Text = "FrmProyeccion";
            this.Load += new System.EventHandler(this.FrmProyeccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyeccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProyeccion;
        private System.Windows.Forms.Label label1;
    }
}