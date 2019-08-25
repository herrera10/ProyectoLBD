
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Windows;


namespace ProyectoLBD
{
    public partial class FrmEmpleado : Form
    {
        string conString = "User Id=Administrador;Password=admin;Data Source=localhost:1521/xe;";


        public FrmEmpleado()
        {
            InitializeComponent();

        }

        private void updateDataGridEmpleados()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand comando = new OracleCommand("OBT_EMPLEADOS", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("REGISTROS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvEmpleados.DataSource = tabla;

            con.Close();
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateDataGridEmpleados();
        }



       
                


       

        private void dgvEmpleados_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvEmpleados.Rows[e.RowIndex];
                    txtEmpleadoId.Text = row.Cells["IDE"].Value.ToString();
                    txtNombre.Text = row.Cells["NOMBRE"].Value.ToString();
                    txtApellido1.Text = row.Cells["APELLIDO1"].Value.ToString();
                    txtApellido2.Text = row.Cells["APELLIDO2"].Value.ToString();
                    txtTelefono.Text = row.Cells["TELEFONO"].Value.ToString();
                    txtSalario.Text = row.Cells["SALARIO"].Value.ToString();
                    txtDireccion.Text = row.Cells["DIRECCION"].Value.ToString();
                    txtSucursal.Text = row.Cells["SUCURSAL"].Value.ToString();

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

        private void btnResetear_Click_1(object sender, EventArgs e)
        {
            txtEmpleadoId.Text = "";
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtSalario.Text = "";
            txtSucursal.Text = "";

            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;

            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("borrar_empleado", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idEmpleado", OracleDbType.Int16).Value = txtEmpleadoId.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Empleado eliminado", "Eliminar");
                updateDataGridEmpleados();
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;


            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("agregar_empleado", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idEmp", OracleDbType.Int16).Value = txtEmpleadoId.Text;
                comando.Parameters.Add("nombre", OracleDbType.Varchar2).Value = txtNombre.Text;
                comando.Parameters.Add("ap1", OracleDbType.Varchar2).Value = txtApellido1.Text;
                comando.Parameters.Add("ap2", OracleDbType.Varchar2).Value = txtApellido2.Text;
                comando.Parameters.Add("tel", OracleDbType.Int16).Value = txtTelefono.Text;
                comando.Parameters.Add("dir", OracleDbType.Varchar2).Value = txtDireccion.Text;
                comando.Parameters.Add("sal", OracleDbType.Varchar2).Value = txtSalario.Text;
                comando.Parameters.Add("suc", OracleDbType.Int16).Value = txtSucursal.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Empleado agregado exitosamente", "Agregar");
                updateDataGridEmpleados();
            }
            catch (Exception)
            {

                MessageBox.Show("Algo fallo", "Error");
            }
            con.Close();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("actualizar_empleado", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idEmp", OracleDbType.Int16).Value = txtEmpleadoId.Text;
                comando.Parameters.Add("nombre", OracleDbType.Varchar2).Value = txtNombre.Text;
                comando.Parameters.Add("ap1", OracleDbType.Varchar2).Value = txtApellido1.Text;
                comando.Parameters.Add("ap2", OracleDbType.Varchar2).Value = txtApellido2.Text;
                comando.Parameters.Add("tel", OracleDbType.Int16).Value = txtTelefono.Text;
                comando.Parameters.Add("dir", OracleDbType.Varchar2).Value = txtDireccion.Text;
                comando.Parameters.Add("sal", OracleDbType.Int16).Value = txtSalario.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Empleado actualizado", "Actualizar");
                updateDataGridEmpleados();
            }
            catch (Exception)
            {

                MessageBox.Show("Algo fallo", "Error");
            }
            con.Close();
        }
    }
    }

