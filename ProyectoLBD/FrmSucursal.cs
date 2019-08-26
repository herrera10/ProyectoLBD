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
    public partial class FrmSucursal : Form
    {
        string conString = "User Id=Administrador;Password=admin;Data Source=localhost:1521/xe;";

        public FrmSucursal()
        {
            InitializeComponent();
        }

    
        private void updateDataGridSucursal()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand comando = new OracleCommand("PKGSUCURSAL.OBT_SUCURSALES", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("REGISTROS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvSucursal.DataSource = tabla;

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
                    DataGridViewRow row = this.dgvSucursal.Rows[e.RowIndex];
                    txtIdSucursal.Text = row.Cells["ID"].Value.ToString();
                    txtNombre.Text = row.Cells["SUCURSAL"].Value.ToString();
                    txtTelefono.Text = row.Cells["TELEFONO"].Value.ToString();
                    txtProvincia.Text = row.Cells["PROVINCIA"].Value.ToString();
                    txtDireccion.Text = row.Cells["DIRECCION"].Value.ToString();
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

        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            updateDataGridSucursal();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;


            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("PKGSUCURSAL.agregar_sucursal", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idSuc", OracleDbType.Int16).Value = txtIdSucursal.Text;
                comando.Parameters.Add("nom", OracleDbType.Varchar2).Value = txtNombre.Text;
                comando.Parameters.Add("pro", OracleDbType.Varchar2).Value = txtProvincia.Text;
                comando.Parameters.Add("tel", OracleDbType.Varchar2).Value = txtTelefono.Text;
                comando.Parameters.Add("dir", OracleDbType.Varchar2).Value = txtDireccion.Text;


                comando.ExecuteNonQuery();
                MessageBox.Show("Sucursal agregada exitosamente", "Agregar");
                updateDataGridSucursal();
            }
            catch (Exception)
            {

                MessageBox.Show("Algo fallo", "Error");
            }
            con.Close();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtIdSucursal.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtProvincia.Text = "";
            txtDireccion.Text = "";

            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;

            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("PKGSUCURSAL.borrar_sucursal", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idSucursal", OracleDbType.Int16).Value = txtIdSucursal.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Sucursal eliminada", "Eliminar");
                updateDataGridSucursal();
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;


            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("PKGSUCURSAL.actualizar_sucursal", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idSuc", OracleDbType.Int32).Value = txtIdSucursal.Text;
                comando.Parameters.Add("nom", OracleDbType.Varchar2).Value = txtNombre.Text;
                comando.Parameters.Add("pro", OracleDbType.Varchar2).Value = txtProvincia.Text;
                comando.Parameters.Add("tel", OracleDbType.Int32).Value = txtTelefono.Text;
                comando.Parameters.Add("dir", OracleDbType.Varchar2).Value = txtDireccion.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Sucursal actualizada", "Actualizar");
                updateDataGridSucursal();
            }
            catch (Exception )
            {
                            
                MessageBox.Show("Algo fallo", "Error");
            }
            con.Close();
        }
    }
}
