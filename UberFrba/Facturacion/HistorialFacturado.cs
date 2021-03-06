﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UberFrba.Facturacion
{
    public partial class HistorialFacturado : Form
    {
        BaseDeDatos bd;
        SqlConnection conexion;
        String cliente_Username;
        Facturacion facturacion;

        public HistorialFacturado(DataGridViewRow fila, Facturacion fact) //constructor llamado por el click en el boton del datagrid
        {
            InitializeComponent();
            bd = new BaseDeDatos();
            conexion = bd.getCon();
            this.facturacion = fact;
            cliente_Username = fila.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e) //boton cerrar
        {
            facturacion.Facturacion_Load(sender, e);
            facturacion.Show();
            this.Close();
        }

        private void HistorialFacturado_Load(object sender, EventArgs e)
        {
            //crear datagrid
            String select = "SELECT Viaje_Id, Viaje_Cantidad_Kilometros, Viaje_Hora_Inicio, Viaje_Hora_Fin, Chofer_Username, Cliente_Username, Turno_Descripcion, Viaje_Total FROM OVERFANTASY.Viaje ";
            select += "WHERE Factura_Nro IS NULL ";
            select += "AND Cliente_Username = '" + cliente_Username + "' ";
            select += " AND Viaje_Hora_Inicio BETWEEN CONVERT(datetime, '" + new DateTime(Configuracion.fechaAño(), Configuracion.fechaMes(), 1) + "',103) AND CONVERT(datetime, '" + new DateTime(Configuracion.fechaAño(), Configuracion.fechaMes(), DateTime.DaysInMonth(Configuracion.fechaAño(), Configuracion.fechaMes()), 23, 59, 59) + "',103)";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            Decimal total = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                total += Decimal.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
            }
            textBox1.Text = total.ToString();

        }

        private void button2_Click(object sender, EventArgs e) //realizar facturacion
        {
            String insert;
            conexion.Open();
            //creamos la factura
            insert = "INSERT INTO OVERFANTASY.Factura(Factura_Fecha_Inicio, Factura_Fecha_Fin, Cliente_Username, Factura_Total) ";
            insert += "VALUES (CONVERT(datetime, '" + new DateTime(Configuracion.fechaAño(), Configuracion.fechaMes(), 1) + "',103), CONVERT(datetime, '" + new DateTime(Configuracion.fechaAño(), Configuracion.fechaMes(), DateTime.DaysInMonth(Configuracion.fechaAño(), Configuracion.fechaMes()), 23, 59, 59) + "',103), '" + cliente_Username + "', " + textBox1.Text.Replace(',', '.') + ")";
            using (SqlCommand cmd = new SqlCommand(insert, conexion))
            {
                cmd.ExecuteNonQuery();
            }
            conexion.Close();
            MessageBox.Show("La Facturacion se ha realizado con exito", "Rendicion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
            //volvemos a mostrar la pantalla anterior actuualizada
            facturacion.Facturacion_Load(sender, e);
            facturacion.Show();
            this.Close();
        }
    }
}
