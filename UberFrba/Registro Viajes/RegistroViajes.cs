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
        int horarioInicioTurno;
        int horarioFinTurno;

        public RegistroViajes() //Creacion de la comboBox de Choferes y Usuarios
        {
            InitializeComponent();
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            //Select de Choferes habilitados
            String select = "SELECT Usuario_Username FROM OVERFANTASY.Usuario JOIN OVERFANTASY.Automovil a ON  (Usuario_Username = Chofer_Username) JOIN OVERFANTASY.Turno t ON (a.Turno_Descripcion = t.Turno_Descripcion)";
            select += " WHERE Automovil_Estado = 'H' AND Usuario_Estado = 'H' AND Turno_Estado = 'H' order by Usuario_Username";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            //Select de Clientes habilitados
            String select1 = "SELECT c.Usuario_Username FROM OVERFANTASY.Cliente c JOIN OVERFANTASY.Usuario u ON (c.Usuario_Username = u.Usuario_Username)";
            select1 += " WHERE Usuario_Estado = 'H' AND c.Usuario_Username NOT IN (SELECT Cliente_Username FROM OVERFANTASY.Factura WHERE '" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "' BETWEEN Factura_Fecha_Inicio AND Factura_Fecha_Fin)  order by Usuario_Username";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(select1, conexion);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            DataSet ds1 = new DataSet();
            dataAdapter1.Fill(ds1);
            comboBox2.DataSource = ds1.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)  //Boton para cerrar
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

        private void button1_Click(object sender, EventArgs e)  //Registra el viaje
        {
            int error = 0;
            decimal cantidadDeKilometros = 0;
            if (!textBox3.Text.Equals("") && !textBox4.Text.Equals("") && !textBox5.Text.Equals("")) //Verfica que los campos esten completos
            {
                try
                {
                    cantidadDeKilometros = Decimal.Parse(textBox3.Text.Replace('.', ',')); 
                }
                catch
                {
                    error += 1;
                    MessageBox.Show("Por favor ingrese numeros donde tiene que haberlos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (cantidadDeKilometros < 0)
                {
                    error += 1;
                    MessageBox.Show("Ingrese una cantidad de kilometros valida (Mayor a 0)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conexion.Open();
                //Select para verificar que el cliente no tenga ya un viaje realizado en la fecha ingresada
                String query = "SELECT Viaje_Hora_Inicio, Viaje_Hora_Fin FROM OVERFANTASY.Viaje WHERE Cliente_Username = '"+comboBox2.Text+"' AND ('"+textBox4.Text+"' BETWEEN Viaje_Hora_Inicio AND Viaje_Hora_Fin OR '"+textBox5.Text+"' BETWEEN Viaje_Hora_Inicio AND Viaje_Hora_Fin)";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            error += 1;
                            MessageBox.Show("Ya hay un viaje realizado por usted en esa fecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (error == 0) // si no hay errores
                {
                    try
                    {
                        viajeTableAdapter1.InsertViaje(cantidadDeKilometros, textBox4.Text, textBox5.Text, textBox1.Text, comboBox1.Text, comboBox2.Text, textBox2.Text);
                        MessageBox.Show("El viaje se ha registrado con exito", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch
                    {
                        MessageBox.Show("Lo siento, usted no es un cliente registrado, debe ser dado de alta como cliente para realizar viajes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                conexion.Close();
            }
            else
            {
                MessageBox.Show("Por favor llene todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) //Escribe la fecha completa en el textbox
        {
            textBox4.Text = datepickerAString(fechaInicio);
            fechaFin.MinDate = fechaInicio.Value;
            fechaFin.Visible = true;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e) //Escribe la fecha completa en el textbox
        {
            textBox5.Text = datepickerAString(fechaFin);
        }

        private String datepickerAString(DateTimePicker dtp)  //Crea el formato de fecha y hora
        {
            String date = dtp.Value.Year.ToString();
            date += "/";
            date += dtp.Value.Month.ToString();
            date += "/";
            date += dtp.Value.Day.ToString();
            date += " ";
            date += dtp.Value.Hour.ToString();
            date += ":";
            date += dtp.Value.Minute.ToString();
            date += ":";
            date += dtp.Value.Second.ToString();
            return date;
        }

        private void relacionComboYText()  //Carga los datos del viaje dependiendo del Chofer
        {
            conexion.Open();
            //Select que trae la patente del automovil del chofer, la descripcion del turno y el horario de inicio y fin
            String query = "SELECT Automovil_Patente, a.Turno_Descripcion, Turno_Horario_Inicio, Turno_Horario_Fin FROM OVERFANTASY.Automovil a JOIN OVERFANTASY.Turno t ON (a.Turno_Descripcion = t.Turno_Descripcion) WHERE Chofer_Username = '"+comboBox1.Text+"'";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader.GetString(0);  //Patente
                        textBox2.Text = reader.GetString(1);  //Turno
                        horarioInicioTurno = Decimal.ToInt32(reader.GetDecimal(2));
                        horarioFinTurno = Decimal.ToInt32(reader.GetDecimal(3)); 
                    }
                }
            }
            conexion.Close();

            DateTime rangoInicio = new DateTime(fechaInicio.Value.Year, fechaInicio.Value.Month, fechaInicio.Value.Day, horarioInicioTurno, 0, 0);
            DateTime rangoFin;
            if (horarioFinTurno == 24)
            {
                rangoFin = new DateTime(fechaInicio.Value.Year, fechaInicio.Value.Month, fechaInicio.Value.Day, 23, 59, 59);
            }
            else
            {
                rangoFin = new DateTime(fechaInicio.Value.Year, fechaInicio.Value.Month, fechaInicio.Value.Day, horarioFinTurno, 0, 0);
            }
            fechaInicio.MaxDate = rangoFin;
            fechaInicio.MinDate = rangoInicio;
        }
    }
}
