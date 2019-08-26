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
    public partial class FrmProyeccion : Form
    {
        string conString = "User Id=Administrador;Password=admin;Data Source=localhost:1521/xe;";

        public FrmProyeccion()
        {
            InitializeComponent();
        }

        private void FrmProyeccion_Load(object sender, EventArgs e)
        {
            updateDataGridProyecion();
        }

        private void updateDataGridProyecion()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand comando = new OracleCommand("PKGPROYECCION.OBT_PROYECCION", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("REGISTROS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvProyeccion.DataSource = tabla;

            con.Close();
        }

        private void dgvProyeccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProyeccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
