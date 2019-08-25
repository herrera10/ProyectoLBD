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
                    txtClienteId.Text = row.Cells["CL_IDCLIENTE"].Value.ToString();
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

            try
            {                
                con.Open();
                OracleCommand comando = new OracleCommand("borrar_cliente", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idCliente", OracleDbType.Int16).Value = txtClienteId.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente eliminado","Eliminar");
                updateDataGridClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            

            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("agregar_cliente", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idCliente", OracleDbType.Int16).Value = txtClienteId.Text;
                comando.Parameters.Add("nombre", OracleDbType.Varchar2).Value = txtNombre.Text;
                comando.Parameters.Add("ap1", OracleDbType.Varchar2).Value = txtApellido1.Text;
                comando.Parameters.Add("ap2", OracleDbType.Varchar2).Value = txtApellido2.Text;
                comando.Parameters.Add("tel", OracleDbType.Int16).Value = txtTelefono.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente agregado exitosamente", "Agregar");
                updateDataGridClientes();
            }
            catch (Exception)
            {

                MessageBox.Show("Algo fallo","Error");
            }
            con.Close();


        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtClienteId.Text = "";
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtTelefono.Text = "";
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
                OracleCommand comando = new OracleCommand("actualizar_cliente", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idCliente", OracleDbType.Int16).Value = txtClienteId.Text;
                comando.Parameters.Add("nombre", OracleDbType.Varchar2).Value = txtNombre.Text;
                comando.Parameters.Add("ap1", OracleDbType.Varchar2).Value = txtApellido1.Text;
                comando.Parameters.Add("ap2", OracleDbType.Varchar2).Value = txtApellido2.Text;
                comando.Parameters.Add("tel", OracleDbType.Int16).Value = txtTelefono.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente actualizado", "Actualizar");
                updateDataGridClientes();
            }
            catch (Exception)
            {

                MessageBox.Show("Algo fallo", "Error");
            }
            con.Close();
        }
    }
}
