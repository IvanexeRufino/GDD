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

namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        String filtro;
        String año = "2015";

        public ListadoEstadistico()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            textBox1.Text = "2015";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.Text) {
                case "Chóferes con mayor recaudación":
                    {
                        String select = "SELECT TOP 5 Chofer_Username, total = (SELECT  SUM(Rendicion_Total) FROM OVERFANTASY.Rendicion r1 WHERE r1.Chofer_Username = r2.Chofer_Username AND r1.Rendicion_Fecha " + filtro + ") FROM OVERFANTASY.Rendicion r2 WHERE r2.Rendicion_Fecha " + filtro + " GROUP BY Chofer_Username order by total desc";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.ReadOnly = true;
                        break;
                    }
                case "Choferes con el viaje más largo realizado":
                    {
                        String select = "SELECT TOP 5 Chofer_Username, Automovil_Patente, Cliente_Username, Viaje_Cantidad_Kilometros, Viaje_Hora_Inicio, Viaje_Hora_Fin, Viaje_Total FROM OVERFANTASY.Viaje WHERE Viaje_Hora_Inicio " + filtro + " order by Viaje_Cantidad_Kilometros desc ";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.ReadOnly = true;
                        break;
                    }
                case "Clientes con mayor consumo":
                    {
                        String select = "SELECT TOP 5 Cliente_Username, total = SUM(Factura_Total) FROM OVERFANTASY.Factura WHERE Factura_Fecha_Inicio "+ filtro +" GROUP BY Cliente_Username order by total desc";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.ReadOnly = true;
                        break;
                    }
                case "Cliente que utilizo más veces el mismo automóvil":
                    {
                        String select = "SELECT DISTINCT TOP 5 Cliente_Username, Automovil_Patente,Usados = (SELECT COUNT(*) FROM OVERFANTASY.Viaje v1 WHERE v1.Cliente_Username = v2.Cliente_Username AND v1.Automovil_Patente = v2.Automovil_Patente AND v1.Viaje_hora_Inicio " + filtro + ") FROM OVERFANTASY.Viaje v2 order by Usados desc";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.ReadOnly = true;
                        break;
                    }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Enero-Marzo":
                    filtro = "BETWEEN '" + año + "-01-01 00:00:00' AND '" + año + "-03-31 23:59:59'";
                    this.comboBox1_SelectedIndexChanged(sender, e);
                    break;
                case "Abril-Junio":
                    filtro = "BETWEEN '" + año + "-04-01 00:00:00' AND '" + año + "-06-30 23:59:59'";
                    this.comboBox1_SelectedIndexChanged(sender, e);
                    break;
                case "Julio-Septiembre":
                    filtro = "BETWEEN '" + año + "-07-01 00:00:00' AND '" + año + "-09-30 23:59:59'";
                    this.comboBox1_SelectedIndexChanged(sender, e);
                    break;
                case "Octubre-Diciembre":
                    filtro = "BETWEEN '" + año + "-10-01 00:00:00' AND '" + año + "-12-31 23:59:59'";
                    this.comboBox1_SelectedIndexChanged(sender, e);
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int16.Parse(textBox1.Text);
                año = textBox1.Text;
                this.comboBox2_SelectedIndexChanged(sender, e);
            }
            catch
            {
            }
        }
    }
}
