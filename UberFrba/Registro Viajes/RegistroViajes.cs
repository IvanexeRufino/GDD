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

        private void RegistroViajes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gD1C2017DataSet.Viaje' Puede moverla o quitarla según sea necesario.
            this.viajeTableAdapter.FillBy(this.gD1C2017DataSet.Viaje);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            conexion.Open();
            if (e.ColumnIndex == 1)
            {
                String query = "SELECT Automovil_Marca, Automovil_Modelo, Automovil_Patente FROM OVERFANTASY.Automovil WHERE Chofer_Username = '"+ dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() +"' AND Automovil_Estado = 'H'";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("El Auto que utiliza el chofer tiene los siguientes datos:\n Patente:" + reader.GetString(2) + "\n Marca: " + reader.GetString(0) + "\n Modelo: " + reader.GetString(1), "Informacion De Auto Habilitado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("El chofer no cuenta con ningun automovil habilitado", "Error de implementacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
            conexion.Close();
        }
    }
}
