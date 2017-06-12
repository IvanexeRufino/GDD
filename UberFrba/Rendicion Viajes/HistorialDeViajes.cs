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
    public partial class HistorialDeViajes : Form
    {
        int porcentajeACobrar = 30;
        BaseDeDatos bd;
        SqlConnection conexion;
        String chofer_Username;
        String Turno_Descripcion;
        String fecha;
        RendicionViajes rendicion;

        public HistorialDeViajes(DataGridViewRow fila, RendicionViajes rendicion) //Carga variables con los datos traidos del dataGrid en RendicionViajes
        {
            InitializeComponent();
            this.rendicion = rendicion;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            textBox2.Text = porcentajeACobrar.ToString(); //porcentaje base
            chofer_Username = fila.Cells[0].Value.ToString();
            Turno_Descripcion = fila.Cells[1].Value.ToString();
            String aux = fila.Cells[2].Value.ToString().Substring(0,10);
            fecha = aux.Substring(6, 4);
            fecha += aux.Substring(2, 3);
            fecha += "/";
            fecha += aux.Substring(0, 2);
        }

        private void button1_Click(object sender, EventArgs e)  //Boton para cerrar
        {
            this.Close();
        }

        private void HistorialDeViajes_Load(object sender, EventArgs e)  //Carga el dataGrid con los viajes a rendir del Chofer
        {
            String select = "SELECT Viaje_Id, Viaje_Cantidad_Kilometros, Viaje_Hora_Inicio, Viaje_Hora_Fin, Chofer_Username, Cliente_Username, Turno_Descripcion, Viaje_Total FROM OVERFANTASY.Viaje ";
            select += "WHERE Rendicion_Nro IS NULL ";
            select += "AND Chofer_Username = '" + chofer_Username + "' ";
            select += "AND Turno_Descripcion = '"+Turno_Descripcion+"' ";
            select += "AND CONVERT(date,Viaje_Hora_Inicio) = '"+fecha+"'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            Decimal subtotal = 0; 
            for(int i = 0; i < dataGridView1.RowCount; i++) //Calcula los totales
            {
                subtotal += Decimal.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
            }
            textBox1.Text = subtotal.ToString();
            textBox3.Text = (subtotal * porcentajeACobrar / 100).ToString();
        }

        private void button2_Click(object sender, EventArgs e)  //Realiza la rendicion con un insert en la tabla de rendiciones
        {
            String insert;
            conexion.Open();
            insert = "INSERT INTO OVERFANTASY.Rendicion(Rendicion_Fecha, Chofer_Username, Turno_Descripcion, Rendicion_Total)";
            insert += "VALUES ('" + fecha + "', '" + chofer_Username + "', '" + Turno_Descripcion + "', " + textBox3.Text.Replace(',', '.') + ")";
            using (SqlCommand cmd = new SqlCommand(insert, conexion))
            {
                cmd.ExecuteNonQuery();
            }
            conexion.Close();
            MessageBox.Show("La rendicion se ha realizado con exito", "Rendicion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            RendicionViajes rendicionV = new RendicionViajes();
            rendicionV.Show();
            rendicion.Close();
            this.Close();
        }

    }
}
