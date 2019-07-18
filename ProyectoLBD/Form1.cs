
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

namespace ProyectoLBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string conString = "User Id=hr;Password=hr;Data Source=localhost:1521/xe;";

        private void btnCargarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = conString;
                con.Open();
                
                                string sql = "select * from employees where department_id=90";
                                OracleCommand cmd = new OracleCommand(sql, con);
                // dgvEmpleados.DataSource = cmd.ExecuteReader();
                // con.Close();*/


                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dgvEmpleados.DataSource = dataTable;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            


        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
