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

        public void ABMCliente_Load(object sender, EventArgs e)                        //Creacion Datagrid a partir de vista
        {
            //Creacion de los botones Modificacion y Baja
            DataGridViewButtonColumn modificarCliente = new DataGridViewButtonColumn();
            modificarCliente.Name = "Modificar Cliente";
            modificarCliente.Text = "Modificar Cliente";

            DataGridViewButtonColumn inhabilitarCliente = new DataGridViewButtonColumn();
            inhabilitarCliente.Name = "Inhabilitar Cliente";
            inhabilitarCliente.Text = "Inhabilitar Cliente";

            //Creacion del datagrid con la vista ClienteCompleto
            String select = "SELECT Usuario_Username, Cliente_Nombre, Cliente_Apellido, Cliente_DNI, Cliente_FechaNacimiento, Cliente_Direccion, Cliente_Piso, Cliente_Departamento, Cliente_CodigoPostal, Cliente_Mail, Cliente_telefono, Cliente_Localidad, Usuario_Estado FROM OVERFANTASY.ClienteCompleto";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //Insercion de los botones en datagrid
            if (dataGridView1.Columns["Modificar Cliente"] == null)
            {
                dataGridView1.Columns.Insert(13, modificarCliente);
            }
            else
            {
                dataGridView1.Columns.Remove("Modificar Cliente");
                dataGridView1.Columns.Remove("Inhabilitar Cliente");
                dataGridView1.Columns.Insert(13, modificarCliente);
            }
            if (dataGridView1.Columns["Inhabilitar Cliente"] == null)
            {
                dataGridView1.Columns.Insert(14, inhabilitarCliente);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //Boton Limpiar
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button7_Click(object sender, EventArgs e) //boton cancelar
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e) //boton alta cliente
        {
            Agregar_Modificar_Cliente amc = new Agregar_Modificar_Cliente(this);
            amc.Show();
        }

        private void button5_Click(object sender, EventArgs e) //Boton filtrar
        {
            String filtro = "";
            String and = " AND ";
            filtro += "Cliente_Nombre LIKE '%" + textBox1.Text + "%'";
            filtro += and;
            filtro += "Cliente_Apellido LIKE '%" + textBox2.Text + "%'";
            if (!textBox3.Text.Equals(""))
            {
                try
                {
                    Decimal.Parse(textBox3.Text);
                    filtro += and;
                    filtro += "Cliente_DNI = '" + textBox3.Text + "'";
                }
                catch
                {
                    MessageBox.Show("Inserte numero en el campo DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filtro;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //botones datagrid
        {
            if (e.ColumnIndex == 13) //Modificar Cliente
            {
                Agregar_Modificar_Cliente amc = new Agregar_Modificar_Cliente(dataGridView1.Rows[e.RowIndex], this);
                amc.Show();
            }
            if (e.ColumnIndex == 14) //Eliminar Cliente
            {
                clienteTableAdapter.DeleteCliente(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("El Cliente se ha Inhabilitado Correctamente", "Baja Cliente", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.ABMCliente_Load(sender, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

