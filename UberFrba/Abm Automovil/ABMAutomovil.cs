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

        public ABMAutomovil()
        {
            InitializeComponent();
            db = new BaseDeDatos();//DefaultView.ToTable(true, "productname")
            conexion = db.getCon();
            filtro_combo();
            comboBox1.SelectedIndex = -1;
        }

        public void ABMAutomovil_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2017DataSet.Automovil' table. You can move, or remove it, as needed.
            this.automovilTableAdapter.Fill(this.gD1C2017DataSet.Automovil);
            filtro_combo();
        }

        private string filtrado()
        {
            string marca = comboBox1.Text;
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
            comboBox1.SelectedIndex = -1;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            Agregar_Modificar_Automovil ama = new Agregar_Modificar_Automovil(this);
            ama.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Agregar_Modificar_Automovil ama = new Agregar_Modificar_Automovil(dataGridView1.Rows[e.RowIndex],this);
                ama.Show();
            }
            else
            {
                if (e.ColumnIndex == 7)
                {
                    //automovilTableAdapter.DeleteAutomovil(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //MessageBox.Show("El vehiculo se ha Inhabilitado Correctamente", "Baja Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                    //automovilTableAdapter.Fill(gD1C2017DataSet.Automovil);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void filtro_combo() 
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT distinct Automovil_marca FROM OVERFANTASY.Automovil", conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            IList<string> listName = new List<string>();
            listName.Add("");
            while (dr.Read())
            {
                listName.Add(dr[0].ToString());
            }
            listName = listName.Distinct().ToList();
            comboBox1.DataSource = listName;
            conexion.Close();            
        }



    }
}
