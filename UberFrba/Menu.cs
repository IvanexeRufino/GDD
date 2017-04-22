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

namespace UberFrba
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public void desplegarMenu(String nombreDeUsuario, String rol) {

            String query = "SELECT Funcionalidad_Descripcion FROM OVERFANTASY.Funcionalidad_Por_Rol WHERE Rol_Nombre = '"+ rol +"'";
            BaseDeDatos bd = new BaseDeDatos();
            bd.getCon().Open();
            SqlCommand cmd = new SqlCommand(query, bd.getCon());
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read()) {
                switch (lector.GetString(0))
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
                        ABMAutomovil.Visible = true;
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
                    case "Solicitar Viaje":
                        SolicitarViaje.Visible = true;
                        break;
                }
                bd.getCon().Close();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }
    }
}
