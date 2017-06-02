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
    public partial class HistorialDeViajes : Form
    {
        int porcentajeACobrar = 30;
        BaseDeDatos bd;
        SqlConnection conexion;
        String chofer_Username;
        String Turno_Descripcion;

        public HistorialDeViajes(DataGridViewRow fila)
        {
            InitializeComponent();
            textBox2.Text = porcentajeACobrar.ToString();
            chofer_Username = fila.Cells[0].Value.ToString();
            Turno_Descripcion = fila.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HistorialDeViajes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gD1C2017DataSet.Viaje' Puede moverla o quitarla según sea necesario.
            this.viajeTableAdapter.FillBy(this.gD1C2017DataSet.Viaje, chofer_Username, Turno_Descripcion);

        }

    }
}
