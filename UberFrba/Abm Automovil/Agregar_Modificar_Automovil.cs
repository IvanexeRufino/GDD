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

namespace UberFrba.Abm_Automovil
{
    public partial class Agregar_Modificar_Automovil : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        ABMAutomovil abm;
        string patenteVieja = "";
        string estadoInicial;


        public Agregar_Modificar_Automovil(ABMAutomovil abm)
        {
            this.abm = abm;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button2.Hide();
            comboBox1.Visible = false;
            label4.Visible = false;
            filtro_combo();

        }

        public Agregar_Modificar_Automovil(DataGridViewRow row, ABMAutomovil abm)
        {
            this.abm = abm;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            comboBox1.Visible = true;
            label4.Visible = true;
            button1.Hide();
            filtro_combo();
            textBox1.Text = row.Cells[0].Value.ToString();
            patenteVieja = row.Cells[0].Value.ToString();
            comboBox4.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            estadoInicial = row.Cells[3].Value.ToString();
            if (row.Cells[3].Value.ToString().Equals("I"))
            {
                comboBox1.Text = "Inhabilitado";
            }
            else
            {
                comboBox1.Text = "Habilitado";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            comboBox4.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)//alta
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals(""))
            {
                if (automovilTableAdapter.Patente(textBox1.Text) != null)
                {
                    MessageBox.Show("La patente ya existe", "Error de patente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
                else
                {
                    if (automovilTableAdapter.getChoferes(comboBox2.Text) == 0)
                    {

                        automovilTableAdapter.Insert(textBox1.Text, comboBox4.Text, textBox3.Text, "H", comboBox3.Text, comboBox2.Text);
                        MessageBox.Show("El Automovil se ha creado exitosamente", "Alta Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                        abm.ABMAutomovil_Load(sender, e);
                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show("La chofer seleccionado ya tiene asignado un automovil habilitado", "Error de chofer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Agregar_Modificar_Automovil_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gD1C2017DataSet.Automovil' table. You can move, or remove it, as needed.
            this.automovilTableAdapter.Fill(this.gD1C2017DataSet.Automovil);
            // TODO: This line of code loads data into the 'gD1C2017DataSet.Turno' table. You can move, or remove it, as needed.
            this.turnoTableAdapter.Fill(this.gD1C2017DataSet.Turno);
            // TODO: This line of code loads data into the 'gD1C2017DataSet.Chofer' table. You can move, or remove it, as needed.
            this.choferTableAdapter.Fill(this.gD1C2017DataSet.Chofer);

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals(""))
            {
                if (automovilTableAdapter.Patente(textBox1.Text) != null && textBox1.Text.ToUpper() != patenteVieja.ToUpper())
                {
                    MessageBox.Show("La patente ya existe", "Error de patente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
                else
                {
                    if (comboBox1.Text == "Habilitado")
                    {
                        if (estadoInicial == "H" || estadoInicial == "h")
                        {
                            automovilTableAdapter.UpdateAutomovil(textBox1.Text, comboBox4.Text, textBox3.Text, "H", comboBox3.Text, comboBox2.Text);
                            MessageBox.Show("El Automovil se ha modificado exitosamente", "Modificar Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                            abm.ABMAutomovil_Load(sender, e);
                            this.Close();
                        }
                        else
                        {
                            if (automovilTableAdapter.getChoferes(comboBox2.Text) == 0)
                            {
                                automovilTableAdapter.UpdateAutomovil(textBox1.Text, comboBox4.Text, textBox3.Text, "H", comboBox3.Text, comboBox2.Text);
                                MessageBox.Show("El Automovil se ha modificado exitosamente", "Modificar Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                                abm.ABMAutomovil_Load(sender, e);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("La chofer seleccionado ya tiene asignado un automovil habilitado", "Error de chofer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        automovilTableAdapter.UpdateAutomovil(textBox1.Text, comboBox4.Text, textBox3.Text, "I", comboBox3.Text, comboBox2.Text);
                        MessageBox.Show("El Automovil se ha modificado exitosamente", "Modificar Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                        abm.ABMAutomovil_Load(sender, e);
                        this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filtro_combo()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT distinct Automovil_marca FROM OVERFANTASY.Automovil", conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            IList<string> listName = new List<string>();
            while (dr.Read())
            {
                listName.Add(dr[0].ToString());
            }
            listName = listName.Distinct().ToList();
            comboBox4.DataSource = listName;
            conexion.Close();
        }

    }
}