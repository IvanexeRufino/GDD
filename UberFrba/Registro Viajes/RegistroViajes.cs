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
        String username;

        public RegistroViajes(String username)
        {
            InitializeComponent();
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            this.username = username;
        }
    }
}
