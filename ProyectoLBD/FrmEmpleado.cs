
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

            string sql = "SELECT EM_IDEMPLEADO,EM_NOMBRE,EM_APELLIDO1,EM_APELLIDO2,EM_TELEFONO,EM_DIRECCION,EM_SALARIO FROM EMPLEADO ";
            OracleCommand cmd = new OracleCommand(sql, con);
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvEmpleados.DataSource = dataTable;
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvEmpleados.Rows[e.RowIndex];
                    txtEmpleadoId.Text = row.Cells["EM_IDEMPLEADO"].Value.ToString();
                    txtNombre.Text = row.Cells["EM_NOMBRE"].Value.ToString();
                    txtApellido1.Text = row.Cells["EM_APELLIDO1"].Value.ToString();
                    txtApellido2.Text = row.Cells["EM_APELLIDO2"].Value.ToString();
                    txtTelefono.Text = row.Cells["EM_TELEFONO"].Value.ToString();
                    txtSalario.Text = row.Cells["EM_SALARIO"].Value.ToString();
                    txtDireccion.Text = row.Cells["EM_DIRECCION"].Value.ToString();
                    //dTPFecha.Value = DateTime.Parse(row.Cells["HIRE_DATE"].Value.ToString());

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

        private void Form1_Load(object sender, EventArgs e)
        {
            updateDataGridEmpleados();
        }



        private void AUD(String sql_stmt, int state)
        {
            String msg = "";
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    msg = "Fila insertada exitosamente";
                    cmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Int32, 6).Value = txtEmpleadoId.Text;
                    cmd.Parameters.Add("FIRST_NAME", OracleDbType.Varchar2, 25).Value = txtNombre.Text;
                    cmd.Parameters.Add("LAST_NAME", OracleDbType.Varchar2, 25).Value = txtApellido1.Text;
                    cmd.Parameters.Add("JOB_ID", OracleDbType.Varchar2, 25).Value = txtApellido2.Text;
                    cmd.Parameters.Add("SALARY", OracleDbType.Int32, 25).Value = txtTelefono.Text;
                   // cmd.Parameters.Add("HIRE_DATE", OracleDbType.Date, 7).Value = dTPFecha.Value;
                    break;

                case 1:
                    msg = "Fila actualizada exitosamente";

                    cmd.Parameters.Add("FIRST_NAME", OracleDbType.Varchar2, 25).Value = txtNombre.Text;
                    cmd.Parameters.Add("LAST_NAME", OracleDbType.Varchar2, 25).Value = txtApellido1.Text;
                    cmd.Parameters.Add("SALARY", OracleDbType.Int32, 25).Value = txtTelefono.Text;
                    //cmd.Parameters.Add("HIRE_DATE", OracleDbType.Date, 7).Value = dTPFecha.Value;
                    cmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Int32, 6).Value = txtEmpleadoId.Text;



                    break;

                case 2:
                    msg = "Fila borrada exitosamente";

                    cmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Int32, 6).Value = txtEmpleadoId.Text;
                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.updateDataGridEmpleados();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
                //}
                con.Close();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO EMPLOYEES(EMPLOYEE_ID,FIRST_NAME,LAST_NAME,JOB_ID,SALARY,HIRE_DATE)" +
                "VALUES(:EMPLOYEE_ID,:FIRST_NAME,:LAST_NAME,:JOB_ID,:HIRE_DATE)";
            this.AUD(sql, 0);
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

       
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvEmpleados.Rows[e.RowIndex];
                    txtEmpleadoId.Text = row.Cells["EM_IDEMPLEADO"].Value.ToString();
                    txtNombre.Text = row.Cells["EM_NOMBRE"].Value.ToString();
                    txtApellido1.Text = row.Cells["EM_APELLIDO1"].Value.ToString();
                    txtApellido2.Text = row.Cells["EM_APELLIDO2"].Value.ToString();
                    txtTelefono.Text = row.Cells["EM_TELEFONO"].Value.ToString();
                    //dTPFecha.Value = DateTime.Parse(row.Cells["HIRE_DATE"].Value.ToString());

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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            String sql = "Update HR.EMPLOYEES SET FIRST_NAME = :FIRST_NAME," +
                "LAST_NAME = :LAST_NAME,SALARY=:SALARY" +
                "WHERE EMPLOYEE_ID = :EMPLOYEE_ID";
            this.AUD(sql, 1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM EMPLOYEES "+
                "WHERE EMPLOYEE_ID = :EMPLOYEE_ID";
            this.AUD(sql, 2);
            this.resetALL();
        }

        private void resetALL()
        {
            txtEmpleadoId.Text = "";
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtTelefono.Text = "";
           // dTPFecha = null;

            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            this.resetALL();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmpleados_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
