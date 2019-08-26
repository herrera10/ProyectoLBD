namespace ProyectoLBD
{
    partial class FrmSala
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSala = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSala)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 73);
            this.label1.TabIndex = 23;
            this.label1.Text = "SALAS";
            // 
            // dgvSala
            // 
            this.dgvSala.AllowUserToAddRows = false;
            this.dgvSala.AllowUserToDeleteRows = false;
            this.dgvSala.AllowUserToOrderColumns = true;
            this.dgvSala.AllowUserToResizeColumns = false;
            this.dgvSala.AllowUserToResizeRows = false;
            this.dgvSala.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSala.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSala.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSala.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSala.Location = new System.Drawing.Point(110, 87);
            this.dgvSala.Name = "dgvSala";
            this.dgvSala.RowHeadersVisible = false;
            this.dgvSala.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSala.Size = new System.Drawing.Size(497, 353);
            this.dgvSala.TabIndex = 22;
            this.dgvSala.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSala_CellContentClick);
            // 
            // FrmSala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSala);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSala";
            this.Text = "FrmSala";
            this.Load += new System.EventHandler(this.FrmSala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSala)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSala;
    }
}