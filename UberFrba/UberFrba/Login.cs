﻿using System;
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
        Menu menu;

        public Login(Menu menu)
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            this.menu = menu;
        }

        public void mostrarInicio()
        {

            Username1.Visible = true;
            Password1.Visible = true;

            LogLabel.Visible = true;
            LogInPrincipal.Visible = false;
            Salir1.Visible = false;
            IniciarSesion.Visible = true;
            Salir2.Visible = true;

            UsernameLogIn.Visible = true;
            PasswordLogIn.Visible = true;

            lineShape2.Visible = true;
            lineShape3.Visible = true;
            lineShape4.Visible = true;
            lineShape5.Visible = true;
            lineShape6.Visible = true;
            lineShape7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.mostrarInicio();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            menu.visibilidad = true;
            menu.Show();
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            menu.visibilidad = true;
            menu.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal id = 0;
            conexion.Open();
            if (UsernameLogIn.Text == "")
            {
                MessageBox.Show("Por favor ingrese un nombre de usuario", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                return;
            }
            if (PasswordLogIn.Text == "")
            {
                MessageBox.Show("Por favor ingrese su contraseña", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                return;
            }

            string query = "SELECT Usuario_Inhab_Intentos, Usuario_Estado" +
                           " FROM OVERFANTASY.Usuario WHERE Usuario_Username = '" + UsernameLogIn.Text + "'";
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

                query = "execute OVERFANTASY.verificarLogIn " + UsernameLogIn.Text + ", '" + PasswordLogIn.Text + "'";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "SELECT Usuario_Inhab_Intentos, Usuario_Estado FROM OVERFANTASY.Usuario WHERE Usuario_Username = '" + UsernameLogIn.Text + "'";
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


                if (RolLogIn.Text == "")
                {
                    int contador = 0;
                    query = "SELECT rxu.Rol_Id, Rol_Nombre FROM OVERFANTASY.Rol_Por_Usuario rxu JOIN OVERFANTASY.Rol r ON (rxu.Rol_Id = r.Rol_Id) WHERE Usuario_Username = '" + UsernameLogIn.Text + "'";
                    cmd.CommandText = query;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader.GetDecimal(0);
                            RolLogIn.Items.Add(reader.GetString(1));
                            RolLogIn.Text = reader.GetString(1);
                            contador = contador + 1;
                        }
                    }
                    if (contador > 1)
                    {
                        Rol1.Visible = true;
                        RolLogIn.Visible = true;
                        MessageBox.Show("Usted posee mas de un rol, por favor seleccione con el que quiere iniciar", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conexion.Close();
                        return;
                    }
                    else
                    {
                        if (contador == 0)
                        {
                            MessageBox.Show("Usted no posee ningun rol habilitado, Por favor comuniquese con un administrador", "Inicio de sesion erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            menu.visibilidad = true;
                            menu.Show();
                            menu.desplegarMenu(UsernameLogIn.Text, id);
                            this.Close();
                        }
                    }

                }
                else
                {
                    query = "SELECT Rol_Id FROM OVERFANTASY.Rol WHERE Rol_Nombre = '" + RolLogIn.Text + "'";
                    cmd.CommandText = query;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        id = reader.GetDecimal(0);
                    }
                    Rol1.Visible = false;
                    RolLogIn.Visible = false;

                    menu.visibilidad = true;
                    menu.Show();
                    menu.desplegarMenu(UsernameLogIn.Text, id);
                    this.Close();
                }
                conexion.Close();
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
