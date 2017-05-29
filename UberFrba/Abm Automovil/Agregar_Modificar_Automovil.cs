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

namespace UberFrba.Abm_Automovil
{
    public partial class Agregar_Modificar_Automovil : Form
    {

        BaseDeDatos bd;
        SqlConnection conexion;

        public Agregar_Modificar_Automovil()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button2.Hide();
            label4.Visible = false;
            comboBox1.Visible = false;
            textBox1.ReadOnly = false;
        }

        public Agregar_Modificar_Automovil(DataGridViewRow row)
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button1.Hide();
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox1.ReadOnly = true;
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            label6.Visible = true;
            comboBox1.Visible = true;

            if (row.Cells[3].Value.ToString().Equals("I"))
            {
                comboBox1.Text = "Inhabilitado";
            }
            else {
                comboBox1.Text = "Habilitado";
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }



    }
}
