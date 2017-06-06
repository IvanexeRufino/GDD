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

namespace UberFrba.Abm_Chofer
{
    public partial class Agregar_Modificar_Chofer : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;

        public Agregar_Modificar_Chofer()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button2.Hide();                                     //BOTON MODIFICAR

        }

        public Agregar_Modificar_Chofer(DataGridViewRow row)
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button1.Hide();                                     //BOTON ALTA

            textBox1.Text = row.Cells[1].Value.ToString();      //Nombre
            textBox2.Text = row.Cells[2].Value.ToString();      //Apellido
            textBox3.Text = row.Cells[3].Value.ToString();      //DNI
            textBox9.Text = row.Cells[4].Value.ToString();      //Nacimiento
            textBox6.Text = row.Cells[5].Value.ToString();      //Direccion
            textBox7.Text = row.Cells[6].Value.ToString();      //Piso
            textBox8.Text = row.Cells[7].Value.ToString();      //Dpto
            textBox10.Text = row.Cells[8].Value.ToString();     //Codigo Postal
            textBox4.Text = row.Cells[9].Value.ToString();      //Mail
            textBox5.Text = row.Cells[10].Value.ToString();     //Telefono
            textBox11.Text = row.Cells[11].Value.ToString();    //Localidad

            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox5.Text.Equals("") && !textBox6.Text.Equals("") && !textBox7.Text.Equals("") && !textBox8.Text.Equals("") && !textBox9.Text.Equals("") && !textBox10.Text.Equals("") && !textBox11.Text.Equals(""))
            {

            }
           
            else
            {
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void Agregar_Cliente_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
