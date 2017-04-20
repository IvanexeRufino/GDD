using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace UberFrba
{
    class BaseDeDatos
    {
        public string cadenaconexion;
        public string schema = "OVERFANTASY";
        public SqlConnection con;

        public BaseDeDatos() {
            try {
                this.cadenaconexion = Configuracion.leerConfiguracion();
                this.con = new SqlConnection(this.cadenaconexion);

            }
            catch (Exception ex) {
                MessageBox.Show("No se pudo realizar la conexion", ex.ToString());
            }

        }

        public SqlConnection getCon()
        {
            return con;
        }
    }
}
