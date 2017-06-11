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
            db = new BaseDeDatos();
            conexion = db.getCon();
            filtro_combo();//method que sirve para generar el contenido de la comboBox de marca
            comboBox1.SelectedIndex = -1;//indece en blanco
        }

        public void ABMAutomovil_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2017DataSet.Automovil' table. You can move, or remove it, as needed.
            this.automovilTableAdapter.Fill(this.gD1C2017DataSet.Automovil);
            filtro_combo();//method que sirve para generar el contenido de la comboBox de marca
        }

        private string filtrado()//se utiliza para filtrar el DataGrid, lo utiliza el boton1 (Filtrar)
        {
            //se guarda los datos en variables
            string marca = comboBox1.Text;
            string modelo = textBox2.Text;
            string patente = textBox3.Text;
            string chofer = textBox4.Text;
            var final_lista = "";//variable que retorna al final
            var posFiltro = true;//flag 
            var filtrosBusqueda = new List<string>();//se crea una lista y dependiendo que se escribio en los textBox, se generan declarciones para el WHERE
            if (marca != "") filtrosBusqueda.Add("Automovil_marca LIKE '%" + marca + "%'");
            if (modelo != "") filtrosBusqueda.Add("Automovil_Modelo LIKE '%" + modelo + "%'");
            if (patente != "") filtrosBusqueda.Add("Automovil_patente LIKE '%" + patente + "%'");
            if (chofer != "") filtrosBusqueda.Add("Chofer_Username LIKE '%" + chofer + "%'");

            foreach (var filtro in filtrosBusqueda)//Loop para agregar los AND que necesita entre cada declaracion de la lista, y se guarda como un string en final_lista
            {
                if (!posFiltro)
                    final_lista += " AND " + filtro;
                else
                {
                    final_lista += filtro;
                    posFiltro = false;
                }
            }
            return final_lista;//Contiene las declaraciones separadas por AND o se encuentra vacia, se retorna para ser utilizada por el boton1
        }

        private void button4_Click(object sender, EventArgs e)//ciera la ventana
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//limpia los textbox y el comboBox, y limpia el filtro
        {
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            bindingSource1.Filter = "";
            automovilTableAdapter.Fill(gD1C2017DataSet.Automovil);
        }

        private void button1_Click(object sender, EventArgs e)//filtra utilizando el method filtrado()
        {
            
            string filtro = this.filtrado();
            bindingSource1.Filter = filtro;
        }

        private void button3_Click_1(object sender, EventArgs e)//Alta de Automovil
        {
            Agregar_Modificar_Automovil ama = new Agregar_Modificar_Automovil(this);
            ama.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)//Boton modificar del DaraGrid
            {
                Agregar_Modificar_Automovil ama = new Agregar_Modificar_Automovil(dataGridView1.Rows[e.RowIndex],this);
                ama.Show();
            }
            else
            {
                if (e.ColumnIndex == 7)//Boton Inhabilitar del DataGrid, se utiliza un trigger instead of delete para dar la baja logica
                {
                    automovilTableAdapter.DeleteAutomovil(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("El automovil se ha Inhabilitado Correctamente", "Baja Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                    automovilTableAdapter.Fill(gD1C2017DataSet.Automovil);
                }
            }
        }

        private void filtro_combo() //genera una lista para tener todas las MARCAS sin repetir utilizando un Select con un distinct
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
