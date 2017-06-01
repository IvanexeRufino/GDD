using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace UberFrba.Rendicion_Viajes
{
    public partial class RendicionViajes : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;

        public RendicionViajes()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
        }

        private void RendicionViajes_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn rendirViajes = new DataGridViewButtonColumn();
            rendirViajes.Name = "Rendir Viajes";
            rendirViajes.Text = "Rendir Viajes";
            String select = "SELECT DISTINCT(Chofer_Username), Turno_Descripcion FROM OVERFANTASY.Viaje WHERE Rendicion_Nro IS NULL";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.Columns["Rendir Viajes"] == null)
            {
                dataGridView1.Columns.Insert(2, rendirViajes);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                MessageBox.Show("hola wachin", "ok");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Chofer_Username LIKE '" + textBox1.Text + "%'");
            }
            else
            {
                RendicionViajes_Load(sender, e);
            }
        }
    }
}
