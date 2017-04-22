using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace UberFrba
{

    public partial class Login : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;

        public Login()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
        }

        public void mostrarInicio()
        {

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label10.Visible = true;

            button7.Visible = false;
            button8.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;

            comboBox1.Visible = true;
            lineShape1.Visible = true;
            conexion.Open();
            string query = "SELECT Rol_Nombre FROM OVERFANTASY.rol";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader.GetString(0));
                    }
                }
            }
            conexion.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.mostrarInicio();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor ingrese un nombre de usuario", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Por favor ingrese su contraseña", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                return;
            }

            string query = "SELECT Usuario_Inhab_Intentos, Usuario_Estado" +
                           " FROM OVERFANTASY.Usuario WHERE Usuario_Username = '" + textBox1.Text + "'";
            int intentosFallidosAntes;
            String habilitado;
            int intentosFallidosDespues;
            String habilitadoDespues;

            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("El usuario ingresado no existe", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conexion.Close();
                        return;
                    }

                    intentosFallidosAntes = reader.GetInt16(0);
                    habilitado = reader.GetString(1);
                }

                if (habilitado.Contains('I'))
                {
                    MessageBox.Show("Su cuenta de usuario esta inhabilitada", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexion.Close();
                    return;
                }

                query = "execute OVERFANTASY.verificarLogIn " + textBox1.Text + ", '" + textBox3.Text + "'";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "SELECT Usuario_Inhab_Intentos, Usuario_Estado FROM OVERFANTASY.Usuario WHERE Usuario_Username = '" + textBox1.Text + "'";
                cmd.CommandText = query;



                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    intentosFallidosDespues = reader.GetInt16(0);
                    habilitadoDespues = reader.GetString(1);
                }

                if (intentosFallidosAntes < intentosFallidosDespues)
                {
                    MessageBox.Show("Contraseña Inválida", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (habilitadoDespues.Contains('I'))
                    {
                        MessageBox.Show("Su cuenta ha sido deshabilitada, por favor aguarde unos minutos", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conexion.Close();
                    return;
                }


                if (comboBox1.Text == "")
                {
                    int contador = 0;
                    query = "SELECT Rol_Nombre FROM OVERFANTASY.Rol_Por_Usuario WHERE Usuario_Username = '" + textBox1.Text + "'";
                    cmd.CommandText = query;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader.GetString(0));
                            comboBox2.Text = reader.GetString(0);
                            contador = contador + 1;
                        }
                    }
                    if (contador > 1)
                    {
                        label5.Visible = true;
                        comboBox2.Visible = true;
                        MessageBox.Show("Usted posee mas de un rol, por favor seleccione con el que quiere iniciar", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conexion.Close();
                        return;
                    }
                    else
                    {
                        this.Hide();
                        Menu mp = new Menu();
                        mp.Show();
                        mp.desplegarMenu(textBox1.Text, comboBox2.Text);
                    }

                }
                else
                {
                    this.Hide();
                    Menu mp = new Menu();
                    mp.Show();
                    mp.desplegarMenu(textBox1.Text, comboBox2.Text);
                }
                conexion.Close();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            conexion.Open();

            if (textBox2.Text == "")
            {
                MessageBox.Show("Por favor ingrese un nombre de usuario", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Por favor ingrese su contraseña", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                return;
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Por favor ingrese su rol", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                return;
            }

            string query = "INSERT INTO OVERFANTASY.Usuario(Usuario_Username, Usuario_Password) VALUES ('" + textBox2.Text + "', '" + textBox4.Text + "')";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.ExecuteNonQuery();
                query = "INSERT INTO OVERFANTASY.Rol_Por_Usuario(Rol_Nombre, Usuario_Username) VALUES ('" + comboBox1.Text + "', '" + textBox2.Text + "')";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }

            this.Hide();
            Menu mp = new Menu();
            mp.Show();
            mp.desplegarMenu(textBox2.Text, comboBox1.Text);

            conexion.Close();
        }
    }
}
