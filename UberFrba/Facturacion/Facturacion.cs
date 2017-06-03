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
            DataGridViewButtonColumn rendirViajes = new DataGridViewButtonColumn();
            rendirViajes.Name = "Facturar Cliente";
            rendirViajes.Text = "Facturar Cliente";
            String select = "SELECT DISTINCT(Chofer_Username), Turno_Descripcion, Fecha = CONVERT(date,Viaje_Hora_Inicio) FROM OVERFANTASY.Viaje v JOIN OVERFANTASY.Usuario u ON (v.Chofer_Username = u.Usuario_Username) WHERE Rendicion_Nro IS NULL AND Usuario_Estado = 'H'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.Columns["Facturar Cliente"] == null)
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

        }
    }
}
