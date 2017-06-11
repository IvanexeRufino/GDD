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
        string choferInicial;


        public Agregar_Modificar_Automovil(ABMAutomovil abm)//Se ejecuta cuando se quiere dar un alta
        {
            this.abm = abm;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            button2.Hide();//se esconde el boton de modificacion
            comboBox1.Visible = false;//se esconde la comboBox de Estado
            label4.Visible = false;//y su label
            filtro_combo();//se filtra la comboBox de marcas para que tenga un seleccion acotada
            filtro_turno();//se filtra la comboBox de turnos
            filtro_chofer();//se filtra la comboBox de choferes
        }

        public Agregar_Modificar_Automovil(DataGridViewRow row, ABMAutomovil abm)//Se ejecuta cuando se quiere modificar un automovil
        {
            this.abm = abm;
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            comboBox1.Visible = true;//comboBox de estado
            label4.Visible = true;//y su label
            button1.Hide();//se esconde el boton de alta
            filtro_combo();//se filtra la comboBox de marcas para que tenga un seleccion acotada
            filtro_turno();//se filtra la comboBox de turnos
            filtro_chofer();//se filtra la comboBox de choferes
            textBox1.Text = row.Cells[0].Value.ToString();//patente
            patenteVieja = row.Cells[0].Value.ToString();//patente
            comboBox4.Text = row.Cells[1].Value.ToString();//marca
            textBox3.Text = row.Cells[2].Value.ToString();//modelo
            estadoInicial = row.Cells[3].Value.ToString();//estado
            comboBox3.Text = row.Cells[4].Value.ToString();//turno
            choferInicial = row.Cells[5].Value.ToString();//chofer
            comboBox2.Text  = row.Cells[5].Value.ToString();//chofer
            if (row.Cells[3].Value.ToString().Equals("I"))//se selecciona el estado adecuado
            {
                comboBox1.Text = "Inhabilitado";
            }
            else
            {
                comboBox1.Text = "Habilitado";
            }            
        }


        private void button3_Click(object sender, EventArgs e)//ciera la ventana
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)//limpia lo escrito
        {
            textBox1.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)//Botno de alta
        {
            if (!textBox1.Text.Equals("") && !textBox3.Text.Equals(""))//Se verifica que los campos esten completos
            {
                if (automovilTableAdapter.Patente(textBox1.Text) != null)//se verifica que la patente no exista en la base de datos
                {
                    MessageBox.Show("La patente ya existe", "Error de patente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
                else
                {
                    if (automovilTableAdapter.getChoferes(comboBox2.Text) == 0)//se verifica que el chofer no tenga otros automoviles habilitados
                    {

                        automovilTableAdapter.Insert(textBox1.Text, comboBox4.Text, textBox3.Text, "H", comboBox3.Text, comboBox2.Text);
                        MessageBox.Show("El Automovil se ha creado exitosamente", "Alta Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                        abm.ABMAutomovil_Load(sender, e);
                        this.Close();
                    }
                    else //Si el chofer tiene otro automovil habilitado...
                    {
                        //... Se abre una ventana que pregunta si quiere deshabilitar el automovil que el chofer tiene habilitado, en caso contrario falla el alta
                        if (MessageBox.Show("El chofer ya tiene un automovil asignado, desea inhabilatarlo?", "Chofer ocupado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            string patente = automovilTableAdapter.TraemePatente(comboBox2.Text).ToString();//Se busca el automovil del chofer
                            automovilTableAdapter.DeleteAutomovil(patente);//deshabilita automovil
                            automovilTableAdapter.Insert(textBox1.Text, comboBox4.Text, textBox3.Text, "H", comboBox3.Text, comboBox2.Text);
                            MessageBox.Show("El Automovil se ha creado exitosamente", "Alta Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                            abm.ABMAutomovil_Load(sender, e);
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("El chofer seleccionado ya tiene asignado un automovil habilitado", "Error de chofer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button2_Click(object sender, EventArgs e)//Boton de modificacion
        {
            if (!textBox1.Text.Equals("") && !textBox3.Text.Equals(""))//Se verifica que los campos esten completos
            {
                //se verifica que la patente no exista en la base de datos en caso de que haya sido cambiada
                if (automovilTableAdapter.Patente(textBox1.Text) != null && textBox1.Text.ToUpper() != patenteVieja.ToUpper())
                {
                    MessageBox.Show("La patente ya existe", "Error de patente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
                else
                {
                    //Si el automovil se quiere que quede habilitado
                    if (comboBox1.Text == "Habilitado")
                    {
                        //se comprueba si el automovil ya estaba habilitado y si era el mismo chofer
                        if ((estadoInicial == "H" || estadoInicial == "h") && choferInicial == comboBox2.Text)
                        {
                            automovilTableAdapter.UpdateAutomovil(textBox1.Text, comboBox4.Text, textBox3.Text, "H", comboBox3.Text, comboBox2.Text, patenteVieja);
                            MessageBox.Show("El Automovil se ha modificado exitosamente", "Modificar Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                            abm.ABMAutomovil_Load(sender, e);
                            this.Close();
                        }
                        else
                        {
                            //En caso de que el automovil antes se encontraba inhabilitado o el chofer se cambio, se verifica que el chofer no tengo ya un automovil habilitado
                            if (automovilTableAdapter.getChoferes(comboBox2.Text) == 0)               
                            {
                                //si el chofer no tenia automovil habilitado se modifica sin problemas
                                automovilTableAdapter.UpdateAutomovil(textBox1.Text, comboBox4.Text, textBox3.Text, "H", comboBox3.Text, comboBox2.Text, patenteVieja);
                                MessageBox.Show("El Automovil se ha modificado exitosamente", "Modificar Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                                abm.ABMAutomovil_Load(sender, e);
                                this.Close();
                            }
                            else
                            {
                                //si el chofer tiene un automovil habilitado, se abre una ventana que pregunta si quiere deshabilitar el automovil que el chofer tiene habilitado, en caso contrario falla la modificacion
                                if (MessageBox.Show("El chofer ya tiene un automovil asignado, desea inhabilatarlo?", "Chofer ocupado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    string patente = automovilTableAdapter.TraemePatente(comboBox2.Text).ToString();//Se busca el automovil del chofer
                                    automovilTableAdapter.DeleteAutomovil(patente);//se inhabilita el automovil
                                    automovilTableAdapter.UpdateAutomovil(textBox1.Text, comboBox4.Text, textBox3.Text, "H", comboBox3.Text, comboBox2.Text, patenteVieja);
                                    MessageBox.Show("El Automovil se ha modificado exitosamente", "Modificar Automovil", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    abm.ABMAutomovil_Load(sender, e);
                                    this.Close();
                                    //MessageBox.Show("El automovil del chofer a sido inhabilitado con exito", "Automovil inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.None);
                                }
                                else
                                {
                                    MessageBox.Show("El chofer seleccionado ya tiene asignado un automovil habilitado", "Error de chofer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else//En caso de que el automovil quede inhabilitado
                    {
                        automovilTableAdapter.UpdateAutomovil(textBox1.Text, comboBox4.Text, textBox3.Text, "I", comboBox3.Text, comboBox2.Text, patenteVieja);
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

        private void filtro_combo()  //genera una lista para tener todas las MARCAS sin repetir utilizando un Select con un distinct
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
        private void filtro_chofer() //genera los items de la comboBox de choferes
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT distinct usuario_username FROM OVERFANTASY.Chofer", conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            IList<string> listName = new List<string>();
            while (dr.Read())
            {
                listName.Add(dr[0].ToString());
            }
            listName = listName.Distinct().ToList();
            comboBox2.DataSource = listName;
            conexion.Close();
        }
        private void filtro_turno() //genera los items de la comboBox de turnos
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT distinct turno_descripcion FROM OVERFANTASY.turno", conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            IList<string> listName = new List<string>();
            while (dr.Read())
            {
                listName.Add(dr[0].ToString());
            }
            listName = listName.Distinct().ToList();
            comboBox3.DataSource = listName;
            conexion.Close();
        }
    }
}