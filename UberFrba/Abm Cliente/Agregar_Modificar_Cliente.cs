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

namespace UberFrba.Abm_Cliente
{
    public partial class Agregar_Modificar_Cliente : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        ABMCliente abm;
        String user;

        public Agregar_Modificar_Cliente(ABMCliente abm)
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            label12.Visible = false;
            comboBox1.Visible = false;
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.MaxDate = new DateTime(DateTime.Now.Year - 5, DateTime.Now.Month, DateTime.Now.Day);
            button2.Hide();                                     //BOTON MODIFICAR
            this.abm = abm;
        }

        public Agregar_Modificar_Cliente(DataGridViewRow row, ABMCliente abm)
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button1.Hide();                                     //BOTON ALTA
            this.abm = abm;
            label12.Visible = true;
            comboBox1.Visible = true;
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.MaxDate = new DateTime(DateTime.Now.Year - 5, DateTime.Now.Month, DateTime.Now.Day);

            user = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();      //Nombre
            textBox2.Text = row.Cells[2].Value.ToString();      //Apellido
            textBox3.Text = row.Cells[3].Value.ToString();      //DNI
            textBox4.Text = row.Cells[9].Value.ToString();      //Mail
            textBox5.Text = row.Cells[4].Value.ToString();      //Nacimiento
            textBox6.Text = row.Cells[10].Value.ToString();     //Telefono
            textBox7.Text = row.Cells[5].Value.ToString();      //Direccion
            textBox8.Text = row.Cells[6].Value.ToString();      //Piso
            textBox9.Text = row.Cells[7].Value.ToString();      //Depto
            textBox10.Text = row.Cells[8].Value.ToString();     //Cod Postal
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
            textBox10.Clear();
            textBox11.Clear();
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
                    decimal piso = Decimal.Parse(textBox8.Text);
                    decimal telefono = Decimal.Parse(textBox6.Text);
                    String fecha = textBox5.Text.Substring(6, 4);
                    fecha += textBox5.Text.Substring(2, 3);
                    fecha += "/";
                    fecha += textBox5.Text.Substring(0, 2);
                    try
                    {
                        conexion.Open();
                        String procedure = "exec OVERFANTASY.UnicidadDeTelefonos '" + textBox6.Text + "'";
                        using (SqlCommand cmd = new SqlCommand(procedure, conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conexion.Close();
                        if (!textBox4.Text.Equals(""))
                        {
                            String insert = "INSERT INTO OVERFANTASY.ClienterCompleto (Usuario_Username, Cliente_Nombre, Cliente_Apellido, Cliente_DNI, Cliente_FechaNacimiento, Cliente_Direccion, Cliente_Piso, Cliente_Departamento, Cliente_CodigoPostal, Cliente_Mail, Cliente_telefono, Cliente_Localidad)";
                            insert += " VALUES ( '" + textBox6.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + dni + "', '" + fecha + "', '" + textBox5.Text + "' , '" + piso + "', '" + textBox7.Text + "' , '" + textBox8.Text + "', '" + textBox9.Text + "', '" + telefono + "', '" + textBox11.Text + "')";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(insert, conexion);
                            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                            DataSet ds = new DataSet();
                            dataAdapter.Fill(ds);
                            MessageBox.Show("El Cliente se ha creado exitosamente", "Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.None);
                            button4_Click(sender, e);
                            abm.ABMCliente_Load(sender, e);
                        }
                        else 
                        {
                            String insert = "INSERT INTO OVERFANTASY.ClienterCompleto (Usuario_Username, Cliente_Nombre, Cliente_Apellido, Cliente_DNI, Cliente_FechaNacimiento, Cliente_Direccion, Cliente_Piso, Cliente_Departamento, Cliente_CodigoPostal, Cliente_Mail, Cliente_telefono, Cliente_Localidad)";
                            insert += " VALUES ( '" + textBox6.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + dni + "', '" + fecha + "', '" + textBox7.Text + "' , '" + piso + "', '" + textBox9.Text + "' , '" + textBox10.Text + "', '" + textBox4.Text + "', '" + telefono + "', '" + textBox11.Text + "')"; 
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(insert, conexion);
                            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                            DataSet ds = new DataSet();
                            dataAdapter.Fill(ds);
                            MessageBox.Show("El Cliente se ha creado exitosamente", "Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.None);
                            button4_Click(sender, e);
                            abm.ABMCliente_Load(sender, e);
                            }
                    }
                    catch (SqlException ex)
                    {
                        conexion.Close();
                        MessageBox.Show(ex.Message);
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
                    decimal piso = Decimal.Parse(textBox8.Text);
                    decimal telefono = Decimal.Parse(textBox6.Text);
                    String fecha = textBox5.Text.Substring(6, 4);
                    fecha += textBox5.Text.Substring(2, 3);
                    fecha += "/";
                    fecha += textBox5.Text.Substring(0, 2);
                    try
                    {
                        conexion.Open();
                        String procedure = "exec OVERFANTASY.UnicidadDeTelefonos '" + textBox6.Text + "'";
                        using (SqlCommand cmd = new SqlCommand(procedure, conexion))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conexion.Close();
                        try
                        {
                            if (comboBox1.Text.Equals("Inhabilitado"))
                            {
                                estado = "I";
                                clienteTableAdapter2.UpdateCliente(textBox1.Text, textBox2.Text, dni, DateTime.Parse(fecha), textBox7.Text, piso, textBox9.Text, textBox10.Text, textBox4.Text, telefono, textBox11.Text, user);
                                clienteTableAdapter2.DeleteCliente(user);
                                MessageBox.Show("El Cliente se ha Inhabilitado Correctamente", "Baja Cliente", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                estado = "H";
                                clienteTableAdapter2.UpdateCliente(textBox1.Text, textBox2.Text, dni, DateTime.Parse(fecha), textBox7.Text, piso, textBox9.Text, textBox10.Text, textBox4.Text, telefono, textBox11.Text, user);
                                usuarioTableAdapter1.UpdateUserEstado(estado, user);
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
                    catch (Exception ex)
                    {
                        conexion.Close();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox5.Text = monthCalendar1.SelectionStart.ToString().Substring(0, 10);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
