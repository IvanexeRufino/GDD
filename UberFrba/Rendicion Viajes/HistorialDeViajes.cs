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
            fecha = fila.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)  //Boton para cerrar
        {
            rendicion.RendicionViajes_Load(sender, e);
            rendicion.Show();
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
            rendicionTableAdapter1.InsertRendicion(chofer_Username, Turno_Descripcion, Configuracion.fechaCompleta(), Decimal.Parse(textBox3.Text), fecha);
            MessageBox.Show("La rendicion se ha realizado con exito", "Rendicion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            rendicion.RendicionViajes_Load(sender, e);
            rendicion.Show();
            this.Close();
        }

    }
}
