using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void RendicionViajes_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn rendirViajes = new DataGridViewButtonColumn();
            rendirViajes.Name = "Rendir Viajes";
            rendirViajes.Text = "Rendir Viajes";
            String select = "SELECT DISTINCT(Chofer_Username), Turno_Descripcion, Fecha = CONVERT(date,Viaje_Hora_Inicio) FROM OVERFANTASY.Viaje v JOIN OVERFANTASY.Usuario u ON (v.Chofer_Username = u.Usuario_Username) WHERE Rendicion_Nro IS NULL AND Usuario_Estado = 'H'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.Columns["Rendir Viajes"] == null)
            {
                dataGridView1.Columns.Insert(3, rendirViajes);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                String query = "SELECT Rendicion_Nro FROM OVERFANTASY.Rendicion WHERE Chofer_Username = '"+dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()+"' AND Rendicion_Fecha = CONVERT(date, getdate())";
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            HistorialDeViajes hdv = new HistorialDeViajes(dataGridView1.Rows[e.RowIndex], this);
                            hdv.Show();
                        }
                        else
                        {
                            MessageBox.Show("Este Choffer ya tiene una rendicion hecha en este dia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                conexion.Close();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
