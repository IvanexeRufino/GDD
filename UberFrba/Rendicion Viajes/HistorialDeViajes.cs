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

        public HistorialDeViajes(DataGridViewRow fila)
        {
            InitializeComponent();
            textBox2.Text = porcentajeACobrar.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
