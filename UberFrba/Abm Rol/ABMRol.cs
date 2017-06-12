using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class ABMRol : Form
    {
        public ABMRol()
        {
            InitializeComponent();
        }

        public void ABMRol_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gD1C2017DataSet.Rol' Puede moverla o quitarla según sea necesario.
            this.rolTableAdapter.Fill(this.gD1C2017DataSet.Rol);

        }

        private void button1_Click(object sender, EventArgs e) //boton cerrar
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //boton alta rol
        {
            Agregar_Modificar_Rol amr = new Agregar_Modificar_Rol(this);
            amr.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //boton modificar del data grid
            {
                Agregar_Modificar_Rol amr = new Agregar_Modificar_Rol(dataGridView1.Rows[e.RowIndex], this);
                amr.Show();
            }
            else
            {
                if (e.ColumnIndex == 4) //boton inhabilitar del datagrid
                {
                    rolTableAdapter.DeleteRol(Decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    MessageBox.Show("El Rol se ha Inhabilitado Correctamente, se han eliminado todas las relaciones con sus usuarios", "Baja Rol", MessageBoxButtons.OK, MessageBoxIcon.None);
                    rolTableAdapter.Fill(gD1C2017DataSet.Rol);
                }
            }
        }
    }
}
