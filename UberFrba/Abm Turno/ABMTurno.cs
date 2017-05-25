using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class ABMTurno : Form
    {
        public ABMTurno()
        {
            InitializeComponent();
        }

        private void ABMTurno_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gD1C2017DataSet.Turno' Puede moverla o quitarla según sea necesario.
            this.turnoTableAdapter.Fill(this.gD1C2017DataSet.Turno);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_Modificar_Turno amt = new Agregar_Modificar_Turno();
            amt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            turnoTableAdapter.FillBy(gD1C2017DataSet.Turno, textBox1.Text);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            turnoTableAdapter.Fill(gD1C2017DataSet.Turno);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Agregar_Modificar_Turno amt = new Agregar_Modificar_Turno(dataGridView1.Rows[e.RowIndex]);
                amt.Show();
            }
            else
            {
                if (e.ColumnIndex == 7)
                {
                    turnoTableAdapter.DeleteTurno(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("El Turno se ha Inhabilitado Correctamente", "Baja Turno", MessageBoxButtons.OK, MessageBoxIcon.None);
                    turnoTableAdapter.Fill(gD1C2017DataSet.Turno);
                }
            }
        }
    }
}
