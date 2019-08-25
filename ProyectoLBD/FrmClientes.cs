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
    public partial class FrmClientes : Form
    {

        string conString = "User Id=Administrador;Password=admin;Data Source=localhost:1521/xe;";

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void updateDataGridClientes()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand comando = new OracleCommand("OBT_PERSONAS", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("REGISTROS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvClientes.DataSource = tabla;

            con.Close();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            updateDataGridClientes();
        }


        


        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvClientes.Rows[e.RowIndex];
                    txtEmpleadoId.Text = row.Cells["CL_IDCLIENTE"].Value.ToString();
                    txtNombre.Text = row.Cells["CL_NOMBRE"].Value.ToString();
                    txtApellido1.Text = row.Cells["CL_APELLIDO1"].Value.ToString();
                    txtApellido2.Text = row.Cells["CL_APELLIDO2"].Value.ToString();
                    txtTelefono.Text = row.Cells["CL_TELEFONO"].Value.ToString();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
           

            OracleCommand comando = new OracleCommand("borrar_cliente", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idCliente", OracleDbType.Int16).Value = txtEmpleadoId.Text;

            try
            {                
                con.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente eliminado");
                updateDataGridClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }


        }

       

    }
}
