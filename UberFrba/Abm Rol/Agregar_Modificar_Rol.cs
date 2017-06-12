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

namespace UberFrba.Abm_Rol
{
    public partial class Agregar_Modificar_Rol : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        decimal idAnterior;
        List<int> indicesAnteriores = new List<int>();
        ABMRol abm;

        public Agregar_Modificar_Rol(ABMRol abm) //constructor alta rol
        {
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            cargarFuncionalidades();
            comboBox1.Visible = false; //combobox estado
            button1.Visible = false; //boton modificar
            label2.Visible = false;
            this.abm = abm;
        }

        public Agregar_Modificar_Rol(DataGridViewRow row, ABMRol abm) //constructor modificacion rol 
        {
            this.abm = abm;
            idAnterior = Decimal.Parse(row.Cells[0].Value.ToString());
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            InitializeComponent();
            cargarFuncionalidades();
            button2.Visible = false; //boton alta
            textBox1.Text = row.Cells[1].Value.ToString(); // nombre
            if (row.Cells[2].Value.ToString().Equals("I"))
            {
                comboBox1.Text = "Inhabilitado";
            }
            else
            {
                comboBox1.Text = "Habilitado";
            }
            conexion.Open();
            string query = "SELECT Funcionalidad_Descripcion FROM OVERFANTASY.Funcionalidad_Por_rol WHERE ROL_Id = '"+row.Cells[0].Value.ToString()+"'";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        switch (reader.GetString(0)) //tildes en las checkbox para los roles predefinidos
                        {
                            case "ABM Automovil":
                                checkedListBox1.SetItemCheckState(0, CheckState.Checked);
                                indicesAnteriores.Add(0);
                                break;
                            case "ABM Chofer":
                                checkedListBox1.SetItemCheckState(1, CheckState.Checked);
                                indicesAnteriores.Add(1);
                                break;
                            case "ABM Clientes":
                                checkedListBox1.SetItemCheckState(2, CheckState.Checked);
                                indicesAnteriores.Add(2);
                                break;
                            case "ABM Rol":
                                checkedListBox1.SetItemCheckState(3, CheckState.Checked);
                                indicesAnteriores.Add(3);
                                break;
                            case "ABM Turno":
                                checkedListBox1.SetItemCheckState(4, CheckState.Checked);
                                indicesAnteriores.Add(4);
                                break;
                            case "Facturacion a Cliente":
                                checkedListBox1.SetItemCheckState(5, CheckState.Checked);
                                indicesAnteriores.Add(5);
                                break;
                            case "Listado Estadistico":
                                checkedListBox1.SetItemCheckState(6, CheckState.Checked);
                                indicesAnteriores.Add(6);
                                break;
                            case "Registro de Viaje":
                                checkedListBox1.SetItemCheckState(7, CheckState.Checked);
                                indicesAnteriores.Add(7);
                                break;
                            case "Rendicion de Cuentas":
                                checkedListBox1.SetItemCheckState(8, CheckState.Checked);
                                indicesAnteriores.Add(8);
                                break;
                        }   
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //boton limpiar
        {
            textBox1.Clear();
            comboBox1.Text = "Habilitado";
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void button3_Click(object sender, EventArgs e) // boton cerrar
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //boton alta
        {
            int cantDeErrores = 0;
            if (textBox1.Text.Equals("") || checkedListBox1.CheckedItems.Count == 0)
            {
                cantDeErrores++;
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cantDeErrores == 0)
            {
                try
                {
                    //verifico si el nombre del rol existe
                    rolTableAdapter.InsertRol(textBox1.Text);
                    decimal id = obtenerIdDelRol();
                    foreach (int i in checkedListBox1.CheckedIndices)
                    {
                        switch(i) {
                            case(0):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "ABM Automovil");
                                break;
                            case (1):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "ABM Chofer");
                                break;
                            case (2):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "ABM Clientes");
                                break;
                            case (3):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "ABM Rol");
                                break;
                            case (4):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "ABM Turno");
                                break;
                            case (5):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "Facturacion a Cliente");
                                break;
                            case (6):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "Listado Estadistico");
                                break;
                            case (7):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "Registro de Viaje");
                                break;
                            case (8):
                                funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(id, "Rendicion de Cuentas");
                                break;
                        }
                    }
                    MessageBox.Show("El rol se ha creado exitosamente", "Alta Rol", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.abm.ABMRol_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("El nombre solicitado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //boton modificar
        {
            int cantDeErrores = 0;
            String estado;
            String funcionalidad;
            if (textBox1.Text.Equals("") || checkedListBox1.CheckedItems.Count == 0) //rol sin nombre o sin funcionalidades
            {
                cantDeErrores++;
                MessageBox.Show("Por favor llene los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cantDeErrores == 0)
            {
                try
                {
                    if(comboBox1.Text.Equals("Habilitado")) //habilito rol
                    {
                        estado = "H";
                        rolTableAdapter.UpdateRol(textBox1.Text, estado, idAnterior);
                    } else {
                        //deshabilito rol y se ejecuta el trigger por el delete
                        estado = "I";
                        rolTableAdapter.UpdateRol(textBox1.Text, estado, idAnterior);
                        rolTableAdapter.DeleteRol(idAnterior);
                        MessageBox.Show("El Rol se ha Inhabilitado Correctamente, se han eliminado todas las relaciones con sus usuarios", "Baja Rol", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (indicesAnteriores.Contains(i) && !checkedListBox1.CheckedIndices.Contains(i))
                        {
                            funcionalidad = obtenerFuncionalidad(i);
                            funcionalidad_Por_RolTableAdapter1.DeleteFuncionalidadPorRol(idAnterior, funcionalidad); //saco funcionalidades
                        }
                        if (!indicesAnteriores.Contains(i) && checkedListBox1.CheckedIndices.Contains(i))
                        {
                            funcionalidad = obtenerFuncionalidad(i);
                            funcionalidad_Por_RolTableAdapter1.InsertFuncionalidadPorRol(idAnterior, funcionalidad); //agrego funcionalidades
                        }
                    }
                    MessageBox.Show("El rol se ha modificado exitosamente", "Moficicacion Rol", MessageBoxButtons.OK, MessageBoxIcon.None);
                    abm.ABMRol_Load(sender,e);
                }
                catch
                {
                    MessageBox.Show("El nombre solicitado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cargarFuncionalidades()
        {
            conexion.Open();
            string query = "SELECT Funcionalidad_Descripcion FROM OVERFANTASY.Funcionalidad";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        checkedListBox1.Items.Add(reader.GetString(0));
                    }
                }
            }
            conexion.Close();
        }

        private decimal obtenerIdDelRol()
        {
            decimal id;
            conexion.Open();
            string query = "SELECT Rol_Id FROM OVERFANTASY.Rol WHERE Rol_Nombre = '" + textBox1.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    id = reader.GetDecimal(0);
                }
            }
            conexion.Close();
            return id;
        }

        private String obtenerFuncionalidad(int id)
        {
            switch (id)
            {
                case (0):
                    return "ABM Automovil";
                case (1):
                    return "ABM Chofer";
                case (2):
                    return "ABM Clientes";
                case (3):
                    return "ABM Rol";
                case (4):
                    return "ABM Turno";
                case (5):
                    return "Facturacion a Cliente";
                case (6):
                    return "Listado Estadistico";
                case (7):
                    return "Registro de Viaje";
                case (8):
                    return "Rendicion de Cuentas";
                default:
                    return "mal";
            }
        }
    }
}
