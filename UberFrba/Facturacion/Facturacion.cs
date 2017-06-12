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


namespace UberFrba.Facturacion
{
    public partial class Facturacion : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;

        public Facturacion()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //boton cerrar
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //filtro
        {
            if (!textBox1.Text.Equals(""))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Cliente_Username LIKE '" + textBox1.Text + "%'");
            }
            else
            {
                Facturacion_Load(sender, e);
            }
        }

        public void Facturacion_Load(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToString("MMMM"); //ponemos el mes en el textbox
            //creamos el datagrid a partir del select
            DataGridViewButtonColumn facturarViajes = new DataGridViewButtonColumn();
            facturarViajes.Name = "Facturar Cliente";
            facturarViajes.Text = "Facturar Cliente";
            String select = "SELECT DISTINCT(Cliente_Username) FROM OVERFANTASY.Viaje v JOIN OVERFANTASY.Usuario u ON (v.Cliente_Username = u.Usuario_Username) WHERE Factura_Nro IS NULL AND Usuario_Estado = 'H'";
            select += " AND Viaje_Hora_Inicio BETWEEN '" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01' AND '" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + " 23:59:59'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.Columns["Facturar Cliente"] == null)
            {
                dataGridView1.Columns.Insert(1, facturarViajes); //boton facturar
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) //click en boton facturar
            {
                HistorialFacturado hf = new HistorialFacturado(dataGridView1.Rows[e.RowIndex], this);
                hf.Show();
            }
        }
    }
}
