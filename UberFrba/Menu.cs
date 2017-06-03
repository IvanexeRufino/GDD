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

namespace UberFrba
{
    public partial class Menu : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        String username;

        public Menu()
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
        }

        public void desplegarMenu(String nombreDeUsuario, decimal rol)
        {
            this.username = nombreDeUsuario;
            conexion.Open();
            string query = "SELECT Funcionalidad_Descripcion FROM OVERFANTASY.Funcionalidad_Por_Rol WHERE Rol_id = " + rol + "";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        switch (reader.GetString(0))
                        {
                            case "ABM Rol":
                                ABMRol.Visible = true;
                                break;
                            case "ABM Clientes":
                                ABMCliente.Visible = true;
                                break;
                            case "ABM Chofer":
                                ABMChofer.Visible = true;
                                break;
                            case "ABM Turno":
                                ABMTurno.Visible = true;
                                break;
                            case "ABM Automovil":
                                ABMAutomovilBut.Visible = true;
                                break;
                            case "Rendicion de Cuentas":
                                RendicionCuentas.Visible = true;
                                break;
                            case "Facturacion a Cliente":
                                Facturacion.Visible = true;
                                break;
                            case "Listado Estadistico":
                                ListadoEstadistico.Visible = true;
                                break;
                            case "Registro de Viaje":
                                RegistroViajes.Visible = true;
                                break;
                        }
                    }
                }
            }
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abm_Rol.ABMRol abmRol = new Abm_Rol.ABMRol();
            abmRol.Show();
        }

        private void ABMClienteBut_Click(object sender, EventArgs e)
        {
            Abm_Cliente.ABMCliente abmCliente = new Abm_Cliente.ABMCliente();
            abmCliente.Show();
        }

        private void ABMChoferBut_Click(object sender, EventArgs e)
        {
            Abm_Chofer.ABMChofer abmChofer = new Abm_Chofer.ABMChofer();
            abmChofer.Show();
        }

        private void ABMTurnoBut_Click(object sender, EventArgs e)
        {
            Abm_Turno.ABMTurno abmTurno = new Abm_Turno.ABMTurno();
            abmTurno.Show();
        }

        private void ABMAutomovilBut_Click(object sender, EventArgs e)
        {
            Abm_Automovil.ABMAutomovil abmAutomovil = new Abm_Automovil.ABMAutomovil();
            abmAutomovil.Show();
        }

        private void RendicionCuentas_Click(object sender, EventArgs e)
        {
            Rendicion_Viajes.RendicionViajes rendicion = new Rendicion_Viajes.RendicionViajes();
            rendicion.Show();
        }

        private void Facturacion_Click(object sender, EventArgs e)
        {
            Facturacion.Facturacion facturacion = new Facturacion.Facturacion();
            facturacion.Show();
        }

        private void ListadoEstadistico_Click(object sender, EventArgs e)
        {
            Listado_Estadistico.ListadoEstadistico listado = new Listado_Estadistico.ListadoEstadistico();
            listado.Show();
        }

        private void RegistroViajes_Click(object sender, EventArgs e)
        {
            Registro_Viajes.RegistroViajes registro = new Registro_Viajes.RegistroViajes(username);
            registro.Show();
        }

        private void SolicitarViaje_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no se encuentra disponible", "Error de implementacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conexion.Close();
            return;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
