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
        private void updateDataGridPelicula()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand comando = new OracleCommand("OBT_PELICULAS", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("REGISTROS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvPeliculas.DataSource = tabla;

            con.Close();
        }


        private void dgvPeliculas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPeliculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvPeliculas.Rows[e.RowIndex];
                    txtIdPelicula.Text = row.Cells["ID"].Value.ToString();
                    txtNombre.Text = row.Cells["TITULO"].Value.ToString();
                    txtClasificacion.Text = row.Cells["CLASIFICACION"].Value.ToString();
                    txtIdioma.Text = row.Cells["IDIOMA"].Value.ToString();
                   
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

        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            updateDataGridPelicula();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;


            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("agregar_pelicula", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idPeli", OracleDbType.Int16).Value = txtIdPelicula.Text;
                comando.Parameters.Add("nom", OracleDbType.Varchar2).Value = txtNombre.Text;
                comando.Parameters.Add("cla", OracleDbType.Varchar2).Value = txtClasificacion.Text;
                comando.Parameters.Add("idi", OracleDbType.Varchar2).Value = txtIdioma.Text;
               
                comando.ExecuteNonQuery();
                MessageBox.Show("Pelicula agregada exitosamente", "Agregar");
                updateDataGridPelicula();
            }
            catch (Exception)
            {

                MessageBox.Show("Algo fallo", "Error");
            }
            con.Close();

        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtIdPelicula.Text = "";
            txtNombre.Text = "";
            txtIdioma.Text = "";
            txtClasificacion.Text = "";
            
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;


            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("actualizar_peli", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idPeli", OracleDbType.Int16).Value = txtIdPelicula.Text;
                comando.Parameters.Add("nom", OracleDbType.Varchar2).Value = txtNombre.Text;
                comando.Parameters.Add("cla", OracleDbType.Varchar2).Value = txtClasificacion.Text;
                comando.Parameters.Add("idi", OracleDbType.Varchar2).Value = txtIdioma.Text;
                
                comando.ExecuteNonQuery();
                MessageBox.Show("Pelicula actualizada", "Actualizar");
                updateDataGridPelicula();
            }
            catch (Exception)
            {

                MessageBox.Show("Algo fallo", "Error");
            }
            con.Close();
        }
    }
}
