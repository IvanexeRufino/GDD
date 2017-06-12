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

namespace UberFrba.Abm_Turno
{
    public partial class Agregar_Modificar_Turno : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        decimal horarioInicioAnterior;
        decimal horarioFinAnterior;
        ABMTurno abm;

        public Agregar_Modificar_Turno(ABMTurno abm) //constructor alta turno
        {
            this.abm = abm;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button2.Hide(); //boton modificar
            label6.Visible = false;
            comboBox1.Visible = false; //estado
            textBox1.ReadOnly = false; //descripcion
            horarioInicioAnterior = 45680;
            horarioFinAnterior = 45680;
        }

        public Agregar_Modificar_Turno(DataGridViewRow row, ABMTurno abm) //constructor modificar turno
        {
            this.abm = abm;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button1.Hide(); //boton alta
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox1.ReadOnly = true; //no poder modificar la descripcion del turno
            textBox2.Text = row.Cells[1].Value.ToString(); //hora inicio
            horarioInicioAnterior = Decimal.Parse(row.Cells[1].Value.ToString());
            horarioFinAnterior = Decimal.Parse(row.Cells[2].Value.ToString());
            textBox3.Text = row.Cells[2].Value.ToString(); //hora fin
            textBox4.Text = row.Cells[3].Value.ToString(); //precio base
            textBox5.Text = row.Cells[4].Value.ToString(); //valor por km
            label6.Visible = true;
            comboBox1.Visible = true; //estado turno

            if (row.Cells[5].Value.ToString().Equals("I"))
            {
                comboBox1.Text = "Inhabilitado";
            }
            else {
                comboBox1.Text = "Habilitado";
            }
        }

        private void button3_Click(object sender, EventArgs e) //boton cerrar
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) //boton limpiar
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e) //boton alta
        {
            if(!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox4.Text.Equals("") && !textBox5.Text.Equals("")) {
            try {
                //verificar que los numeros sean el tipo correcto
                decimal horarioInicio = Decimal.Parse(textBox2.Text);
                decimal horarioFin = Decimal.Parse(textBox3.Text);
                decimal precioBase = Decimal.Parse(textBox4.Text.Replace('.', ','));
                decimal valorKilometro = Decimal.Parse(textBox5.Text.Replace('.', ','));
                try {
                    String error = verificarHorarioInicioYFin(horarioInicio, horarioFin);
                    if (error.Equals("ok"))
                    {
                        try
                        {
                            if (precioBase > 0 && valorKilometro > 0) //los precios deben ser mayores a 
                            {
                                //inserto el nuevo turno
                                turnoTableAdapter1.InsertTurno(textBox1.Text, horarioInicio, horarioFin, precioBase, valorKilometro);
                                MessageBox.Show("El Turno se ha creado exitosamente", "Alta Turno", MessageBoxButtons.OK, MessageBoxIcon.None);
                                button4_Click(sender, e);
                                abm.ABMTurno_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Los precios deben ser mayores a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("El nombre del turno ya existe", "Alta Turno", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                    }
                    else
                    {
                        MessageBox.Show(error, "Alta Turno", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                catch (ArgumentException arg){
                    MessageBox.Show(arg.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch {
                MessageBox.Show("Por favor ingrese datos de tipo valido, coloque numeros donde hay que ponerlos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            } else {
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) //boton modificar
        {
            if (!textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox4.Text.Equals("") && !textBox5.Text.Equals(""))
            {
                try
                {
                    //verifico que los numeros sean el tipo correcto
                    String estado;
                    decimal horarioInicio = Decimal.Parse(textBox2.Text);
                    decimal horarioFin = Decimal.Parse(textBox3.Text);
                    decimal precioBase = Decimal.Parse(textBox4.Text.Replace('.', ','));
                    decimal valorKilometro = Decimal.Parse(textBox5.Text.Replace('.', ','));
                    try
                    {
                        if (precioBase > 0 && valorKilometro > 0) //el precio base y el valor por km no pueden ser negativos
                        {
                            if (comboBox1.Text.Equals("Inhabilitado"))
                            {
                                //se modifica el estado a inhabilitado y se hace el delete que activara al trigger
                                estado = "I";
                                verificarHorarioInicioYFin(horarioInicio, horarioFin);
                                turnoTableAdapter1.UpdateTurno(horarioInicio, horarioFin, precioBase, valorKilometro, estado, textBox1.Text);
                                turnoTableAdapter1.DeleteTurno(textBox1.Text);
                                MessageBox.Show("El Turno se ha Inhabilitado Correctamente", "Baja Turno", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                //se modifica el estado a habilitado y se actualiza el turno
                                estado = "H";
                                verificarHorarioInicioYFin(horarioInicio, horarioFin);
                                turnoTableAdapter1.UpdateTurno(horarioInicio, horarioFin, precioBase, valorKilometro, estado, textBox1.Text);
                            }
                            MessageBox.Show("El Turno se ha modificado exitosamente", "Alta Turno", MessageBoxButtons.OK, MessageBoxIcon.None);
                            abm.ABMTurno_Load(sender, e);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Los precios deben ser mayores a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                    }
                    catch (ArgumentException arg)
                    {
                        MessageBox.Show(arg.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private String verificarHorarioInicioYFin(decimal inicio, decimal fin) //verificamos que los horarios no se superpongan ni excedan las 24 horas
        {
            conexion.Open();
            string query = "SELECT Turno_Horario_Inicio, Turno_Horario_Fin FROM OVERFANTASY.Turno";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetDecimal(0) != horarioInicioAnterior && reader.GetDecimal(1) != horarioFinAnterior)
                        {
                            if (reader.GetDecimal(0) < inicio && inicio < reader.GetDecimal(1))
                            {
                                conexion.Close();
                                throw new ArgumentException("Inicio de horario del turno Superpuesto");
                            }
                            else
                            {
                                if (reader.GetDecimal(0) < fin && fin < reader.GetDecimal(1))
                                {
                                    conexion.Close();
                                    throw new ArgumentException("Fin de horario del turno Superpuesto");
                                }
                                else
                                {
                                    if (reader.GetDecimal(0) == inicio && reader.GetDecimal(1) == fin)
                                    {
                                        conexion.Close();
                                        return "Ya existe un turno con este Horario";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (inicio > fin)
            {
                conexion.Close();
                throw new ArgumentException("Los horarios deben ser dentro de las 24 horas");
            }
            if (inicio == fin)
            {
                conexion.Close();
                throw new ArgumentException("El horario no puede empezar y terminar a la misma hora");
            }
            if ((inicio >= 24 || fin >= 24) || (inicio < 0 || fin <= 0))
            {
                conexion.Close();
                throw new ArgumentException("No existen horarios mayores a las 23 horas ni menores a las 0");
            }
            conexion.Close();
            return "ok";
        }

    }
}
