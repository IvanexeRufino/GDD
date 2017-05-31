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

namespace UberFrba.Registro_Viajes
{
    public partial class RegistroViajes : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        String username;

        public RegistroViajes(String username)
        {
            InitializeComponent();
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            this.username = username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistroViajes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gD1C2017DataSet1.Turno' Puede moverla o quitarla según sea necesario.
            this.turnoTableAdapter.Fill(this.gD1C2017DataSet1.Turno);
            // TODO: esta línea de código carga datos en la tabla 'gD1C2017DataSet1.Chofer' Puede moverla o quitarla según sea necesario.
            this.choferTableAdapter.Fill(this.gD1C2017DataSet1.Chofer);
            relacionComboYText();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            relacionComboYText();
        }

        private void relacionComboYText()
        {
            conexion.Open();
            String query = "SELECT Automovil_Patente FROM OVERFANTASY.Automovil WHERE Chofer_Username = '" + comboBox1.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader.GetString(0);
                    }
                }
            }
            query = "SELECT Turno_Descripcion FROM OVERFANTASY.Automovil WHERE Chofer_Username = '" + comboBox1.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox2.Text = reader.GetString(0);
                    }
                }
            }
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals(""))
            {
                try
                {
                    decimal cantidadDeKilometros = Decimal.Parse(textBox3.Text.Replace('.', ','));
                    if (cantidadDeKilometros > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Ingrese una cantidad de kilometros validos (Mayor a 0)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Por favor ingrese numeros donde tiene qe haberlos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor llene todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
