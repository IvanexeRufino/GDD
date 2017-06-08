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

namespace UberFrba.Abm_Chofer
{
    public partial class ABMChofer : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;

        public ABMChofer()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
        }

        public void ABMChofer_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn modificarChofer = new DataGridViewButtonColumn();
            modificarChofer.Name = "Modificar Chofer";
            modificarChofer.Text = "Modificar Chofer";

            DataGridViewButtonColumn inhabilitarChofer = new DataGridViewButtonColumn();
            inhabilitarChofer.Name = "Inhabilitar Chofer";
            inhabilitarChofer.Text = "Inhabilitar Chofer";

            String select = "SELECT Usuario_Username, Chofer_Nombre, Chofer_Apellido, Chofer_DNI, Chofer_FechaNacimiento, Chofer_Direccion, Chofer_Piso, Chofer_Departamento, Chofer_CodigoPostal, Chofer_Mail, Chofer_telefono, Chofer_Localidad, Usuario_Estado FROM OVERFANTASY.ChoferCompleto";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.Columns["Modificar Chofer"] == null)
            {
                dataGridView1.Columns.Insert(13, modificarChofer);
            }
            else
            {
                dataGridView1.Columns.Remove("Modificar Chofer");
                dataGridView1.Columns.Remove("Inhabilitar Chofer");
                dataGridView1.Columns.Insert(13, modificarChofer);
            }
            if (dataGridView1.Columns["Inhabilitar Chofer"] == null)
            {
                dataGridView1.Columns.Insert(14, inhabilitarChofer);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String filtro = "";
            String and = " AND ";
            filtro += "Chofer_Nombre LIKE '%" + textBox1.Text + "%'";
            filtro += and;
            filtro += "Chofer_Apellido LIKE '%" + textBox2.Text + "%'";
            if (!textBox3.Text.Equals(""))
            {
                filtro += and;
                filtro += "Chofer_DNI = '" + textBox3.Text + "'";
            }
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filtro;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar_Modificar_Chofer amc = new Agregar_Modificar_Chofer(this);
            amc.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                Agregar_Modificar_Chofer amc = new Agregar_Modificar_Chofer(dataGridView1.Rows[e.RowIndex], this);
                amc.Show();
            }
            else
            {
                if (e.ColumnIndex == 14)
                {
                    choferTableAdapter1.DeleteChofer(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("El Chofer se ha Inhabilitado Correctamente", "Baja Chofer", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.ABMChofer_Load(sender, e);
                }
            }
        }
    }
}
