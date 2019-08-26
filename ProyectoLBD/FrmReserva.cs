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
    public partial class FrmReserva : Form
    {
        string conString = "User Id=Administrador;Password=admin;Data Source=localhost:1521/xe;";


        public FrmReserva()
        {
            InitializeComponent();
        }

        private void FrmReserva_Load(object sender, EventArgs e)
        {
            updateDataGridReserva();
        }

        private void updateDataGridReserva()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand comando = new OracleCommand("PKGRESERVA.OBT_RESERVA", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("REGISTROS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvReserva.DataSource = tabla;

            con.Close();
        }

        private void dgvReserva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
