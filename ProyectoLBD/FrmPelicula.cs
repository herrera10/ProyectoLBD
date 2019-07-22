using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLBD
{
    public partial class FrmPelicula : Form


    {

        string conString = "User Id=Administrador;Password=admin;Data Source=localhost:1521/xe;";

        public FrmPelicula()
        {
            InitializeComponent();
        }

        

        private void updateDataGridPeliculas()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            string sql = "SELECT PEL_IDPEL,PEL_NOMBRE,PEL_CLASIFICACION,PEL_IDIOMA FROM PELICULA";
            OracleCommand cmd = new OracleCommand(sql, con);
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvPeliculas.DataSource = dataTable;
            }
        }

        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            updateDataGridPeliculas();
        }

        private void dgvPeliculas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvPeliculas.Rows[e.RowIndex];
                    txtPelicula.Text = row.Cells["PEL_IDPEL"].Value.ToString();
                    txtNombre.Text = row.Cells["PEL_NOMBRE"].Value.ToString();
                    txtClasificacion.Text = row.Cells["PEL_CLASIFICACION"].Value.ToString();
                    txtIdioma.Text = row.Cells["PEL_IDIOMA"].Value.ToString();
                    

                    btnAgregar.Enabled = false;
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }
    }
}
