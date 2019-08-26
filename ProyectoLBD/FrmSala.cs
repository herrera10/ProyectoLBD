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
    public partial class FrmSala : Form
    {
        string conString = "User Id=Administrador;Password=admin;Data Source=localhost:1521/xe;";


        public FrmSala()
        {
            InitializeComponent();
        }

        private void FrmSala_Load(object sender, EventArgs e)
        {
            updateDataGridSala();
        }

        private void updateDataGridSala()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand comando = new OracleCommand("PKGSALA.OBT_SALA", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("REGISTROS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvSala.DataSource = tabla;

            con.Close();
        }
        private void dgvSala_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
