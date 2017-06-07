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
using System.Globalization;
using UberFrba.GD1C2017DataSetTableAdapters;

namespace UberFrba.Abm_Cliente
{
    public partial class Agregar_Modificar_Cliente : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        ABMCliente abm;
        decimal dni;
        decimal piso;
        DateTime dt;
        String user;

        public Agregar_Modificar_Cliente(ABMCliente abm)
        {
            this.abm = abm;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            label12.Visible = false;
            comboBox1.Visible = false;
            button2.Hide();                                     //BOTON MODIFICAR

        }

        public Agregar_Modificar_Cliente(DataGridViewRow row, ABMCliente abm)
        {
            this.abm = abm;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button1.Hide();                                     //BOTON ALTA
            label12.Visible = true;
            comboBox1.Visible = true;

            user = row.Cells[1].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();      //Nombre
            textBox2.Text = row.Cells[2].Value.ToString();      //Apellido
            decimal dni = Decimal.Parse(row.Cells[3].Value.ToString()); 
            textBox3.Text = row.Cells[3].Value.ToString();      //DNI
            textBox9.Text = row.Cells[4].Value.ToString();      //Nacimiento
            textBox6.Text = row.Cells[5].Value.ToString();      //Direccion
            decimal piso = Decimal.Parse(row.Cells[6].Value.ToString());
            textBox7.Text = row.Cells[6].Value.ToString();      //Piso
            textBox8.Text = row.Cells[7].Value.ToString();      //Dpto
            textBox10.Text = row.Cells[8].Value.ToString();     //Codigo Postal
            textBox4.Text = row.Cells[9].Value.ToString();      //Mail
            textBox5.Text = row.Cells[10].Value.ToString();     //Telefono
            textBox11.Text = row.Cells[11].Value.ToString();    //Localidad

            if (row.Cells[12].Value.ToString().Equals("I"))
            {
                comboBox1.Text = "Inhabilitado";
            }
            else
            {
                comboBox1.Text = "Habilitado";
            }


        }

        private void Agregar_Cliente_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //Boton limpiar
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

        private void button3_Click(object sender, EventArgs e)  //Boton cerrar
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Boton alta
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox5.Text.Equals("") && !textBox6.Text.Equals("") && !textBox7.Text.Equals("") && !textBox8.Text.Equals("") && !textBox9.Text.Equals("") && !textBox10.Text.Equals("") && !textBox11.Text.Equals(""))
            {
                try
                {
                    decimal dni = Decimal.Parse(textBox3.Text);
                    decimal piso = Decimal.Parse(textBox7.Text);

                    if (DateTime.TryParseExact(textBox9.Text, "d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    { 
                            try
                            {
                               clienteTableAdapter1.InsertCliente(textBox1.Text, textBox2.Text, dni, dt, textBox6.Text, piso, textBox8.Text, textBox10.Text, textBox4.Text, textBox5.Text, textBox11.Text);
                               MessageBox.Show("El Cliente se ha creado exitosamente", "Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.None);
                               button4_Click(sender, e);
                               abm.ABMCliente_Load(sender, e);
                            }
                            catch
                            {
                               MessageBox.Show("El cliente ya existe", "Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                    }
                    
                    else
                    {
                        MessageBox.Show("Inserte fecha valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Por favor ingrese datos de tipo valido, coloque numeros donde hay que ponerlos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Boton Modificar
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox5.Text.Equals("") && !textBox6.Text.Equals("") && !textBox7.Text.Equals("") && !textBox8.Text.Equals("") && !textBox9.Text.Equals("") && !textBox10.Text.Equals("") && !textBox11.Text.Equals(""))
            {
                try
                {
                    String estado;
                    decimal dni = Decimal.Parse(textBox3.Text);
                    decimal piso = Decimal.Parse(textBox7.Text);

                    if (DateTime.TryParseExact(textBox9.Text, "d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {

                        try
                        {
                            if (comboBox1.Text.Equals("Inhabilitado"))
                            {
                                estado = "I";
                                clienteTableAdapter1.UpdateCliente(textBox1.Text, textBox2.Text, dni, dt, textBox6.Text, piso, textBox8.Text, textBox10.Text, textBox4.Text, textBox5.Text, textBox11.Text);
                                clienteTableAdapter1.DeleteClienteDni(dni);
                                MessageBox.Show("El Turno se ha Inhabilitado Correctamente", "Baja Turno", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                estado = "H";
                                clienteTableAdapter1.UpdateCliente(textBox1.Text, textBox2.Text, dni, dt, textBox6.Text, piso, textBox8.Text, textBox10.Text, textBox4.Text, textBox5.Text, textBox11.Text);
                                userTableAdapter1.UpdateUserEstado(estado, user);

                            }
                            MessageBox.Show("El Cliente se ha modificado exitosamente", "Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.None);
                            abm.ABMCliente_Load(sender, e);
                            this.Close();
                        }

                        catch (ArgumentException arg)
                        {
                            MessageBox.Show(arg.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Inserte fecha valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch
                {
                    MessageBox.Show("Por favor ingrese datos de tipo valido, coloque numeros donde hay que ponerlos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
