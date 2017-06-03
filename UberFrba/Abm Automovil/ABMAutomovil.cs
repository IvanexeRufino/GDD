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

namespace UberFrba.Abm_Automovil
{
    public partial class ABMAutomovil : Form
    {
        SqlConnection conexion;
        BaseDeDatos db; 
        DataTable dt;

        public ABMAutomovil()
        {
            InitializeComponent();
            db = new BaseDeDatos();
            conexion = db.getCon();
        }

        private void ABMAutomovil_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2017DataSet.Automovil' table. You can move, or remove it, as needed.
            this.automovilTableAdapter.Fill(this.gD1C2017DataSet.Automovil);

        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Agregar_Modificar_Automovil ama = new Agregar_Modificar_Automovil();
            //ama.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                //Agregar_Modificar_Automovil ama = new Agregar_Modificar_Automovil(dataGridView1.Rows[e.RowIndex]);
                //ama.Show();
            }
            else
            {
                if (e.ColumnIndex == 7)
                {
                    //automovilTableAdapter.DeleteAutomovil(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //MessageBox.Show("El vehiculo se ha Inhabilitado Correctamente", "Baja Turno", MessageBoxButtons.OK, MessageBoxIcon.None);
                    //automovilTableAdapter.Fill(gD1C2017DataSet.Automovil);
                }
            }
        }

        private string filtrado()
        {
            string marca = textBox1.Text;
            string modelo = textBox2.Text;
            string patente = textBox3.Text;
            string chofer = textBox4.Text;
            var final_lista = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (marca != "") filtrosBusqueda.Add("Automovil_marca LIKE '%" + marca + "%'");
            if (modelo != "") filtrosBusqueda.Add("Automovil_Modelo LIKE '%" + modelo + "%'");
            if (patente != "") filtrosBusqueda.Add("Automovil_patente LIKE '%" + patente + "%'");
            if (chofer != "") filtrosBusqueda.Add("Chofer_Username LIKE '%" + chofer + "%'");

            foreach (var filtro in filtrosBusqueda)
            {
                if (!posFiltro)
                    final_lista += " AND " + filtro;
                else
                {
                    final_lista += filtro;
                    posFiltro = false;
                }
            }
            return final_lista;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            bindingSource1.Filter = "";
            automovilTableAdapter.Fill(gD1C2017DataSet.Automovil);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string filtro = this.filtrado();
            bindingSource1.Filter = filtro;
        }

    }
}
