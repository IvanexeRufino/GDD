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
using UberFrba.GD1C2017DataSetTableAdapters;

namespace UberFrba.Abm_Cliente
{
    public partial class ABMCliente : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;

        public ABMCliente()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();

        }

        private void ABMCliente_Load(object sender, EventArgs e)                        //Creacion Datagrid a partir de vista
        {
            DataGridViewButtonColumn modificarCliente = new DataGridViewButtonColumn();
            modificarCliente.Name = "Modificar Cliente";
            modificarCliente.Text = "Modificar Cliente";

            DataGridViewButtonColumn eliminarCliente = new DataGridViewButtonColumn();
            eliminarCliente.Name = "Eliminar Cliente";
            eliminarCliente.Text = "Eliminar Cliente";

            String select = "select * from OVERFANTASY.ClienteCompleto";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.Columns["Modificar Cliente"] == null)
            {
                dataGridView1.Columns.Insert(13, modificarCliente);
            }
            if (dataGridView1.Columns["Eliminar Cliente"] == null)
            {
                dataGridView1.Columns.Insert(14, eliminarCliente);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                if (!textBox2.Text.Equals(""))
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Cliente_Nombre LIKE '" + textBox1.Text + "%' AND Cliente_Apellido LIKE'" + textBox2.Text + "%'");
                }
                else
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Cliente_Nombre LIKE '" + textBox1.Text + "%'");
                }
            }
            else
            {
                ABMCliente_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)  //ALTA Cliente
        {
            //           Agregar_Modificar_Cliente amc = new Agregar_Modificar_Cliente();
            //           amc.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13) //Modificar Cliente
            {
                //               Agregar_Modificar_Cliente amc = new Agregar_Modificar_Cliente(dataGridView1.Rows[e.RowIndex]);
                //                amc.Show();
            }
            if (e.ColumnIndex == 14) //Eliminar Cliente
            {
                clienteTableAdapter.DeleteCliente(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("El Cliente se ha Inhabilitado Correctamente", "Baja Cliente", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.ABMCliente_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(""))
            {
                if (!textBox1.Text.Equals(""))
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Cliente_Nombre LIKE '" + textBox1.Text + "%' AND Cliente_Apellido LIKE'" + textBox2.Text + "%'");
                }
                else
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Cliente_Apellido LIKE '" + textBox2.Text + "%'");
                }
            }
            else
            {
                ABMCliente_Load(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals(""))
            {
                SqlDataAdapter dad = new SqlDataAdapter("SELECT * FROM OVERFANTASY.ClienteCompleto WHERE Cliente_DNI = '" + textBox3.Text + "'", conexion);
                DataSet ds = new DataSet();
                dad.Fill(ds);
                dataGridView1.DataSource = ds;
                dataGridView1.DataSource = ds.Tables[0];

                //Si no se vuelven a crear los botones queda modificar y eliminar como primera y segunda columna.

                dataGridView1.Columns.RemoveAt(0);
                dataGridView1.Columns.Remove("Eliminar Cliente");

                DataGridViewButtonColumn modificarCliente = new DataGridViewButtonColumn();
                modificarCliente.Name = "Modificar Cliente";
                modificarCliente.Text = "Modificar Cliente";

                DataGridViewButtonColumn eliminarCliente = new DataGridViewButtonColumn();
                eliminarCliente.Name = "Eliminar Cliente";
                eliminarCliente.Text = "Eliminar Cliente";

                dataGridView1.Columns.Insert(13, modificarCliente);
                dataGridView1.Columns.Insert(14, eliminarCliente);

                textBox3.Clear();
            }
            else
            {
                ABMCliente_Load(sender, e);
            }
        }
    }
}

