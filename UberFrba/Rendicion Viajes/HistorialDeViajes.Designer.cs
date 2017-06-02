namespace UberFrba.Rendicion_Viajes
{
    partial class HistorialDeViajes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CostoDeViaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.viajeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viajeCantidadKilometrosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viajeHoraInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viajeHoraFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choferUsernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteUsernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rendicionNroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viajeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD1C2017DataSet = new UberFrba.GD1C2017DataSet();
            this.viajeTableAdapter = new UberFrba.GD1C2017DataSetTableAdapters.ViajeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viajeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(856, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 77);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 77);
            this.button2.TabIndex = 1;
            this.button2.Text = "Realizar Rendicion";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.viajeIdDataGridViewTextBoxColumn,
            this.viajeCantidadKilometrosDataGridViewTextBoxColumn,
            this.viajeHoraInicioDataGridViewTextBoxColumn,
            this.viajeHoraFinDataGridViewTextBoxColumn,
            this.choferUsernameDataGridViewTextBoxColumn,
            this.clienteUsernameDataGridViewTextBoxColumn,
            this.turnoDescripcionDataGridViewTextBoxColumn,
            this.rendicionNroDataGridViewTextBoxColumn,
            this.CostoDeViaje});
            this.dataGridView1.DataSource = this.viajeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(953, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // CostoDeViaje
            // 
            this.CostoDeViaje.HeaderText = "Costo De Viaje";
            this.CostoDeViaje.Name = "CostoDeViaje";
            this.CostoDeViaje.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total De Viajes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Porcentaje A Cobrar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total a Pagar:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(856, 199);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(109, 20);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(926, 223);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(39, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(856, 247);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(109, 20);
            this.textBox3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "%";
            // 
            // viajeIdDataGridViewTextBoxColumn
            // 
            this.viajeIdDataGridViewTextBoxColumn.DataPropertyName = "Viaje_Id";
            this.viajeIdDataGridViewTextBoxColumn.HeaderText = "Viaje_Id";
            this.viajeIdDataGridViewTextBoxColumn.Name = "viajeIdDataGridViewTextBoxColumn";
            this.viajeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viajeCantidadKilometrosDataGridViewTextBoxColumn
            // 
            this.viajeCantidadKilometrosDataGridViewTextBoxColumn.DataPropertyName = "Viaje_Cantidad_Kilometros";
            this.viajeCantidadKilometrosDataGridViewTextBoxColumn.HeaderText = "Viaje_Cantidad_Kilometros";
            this.viajeCantidadKilometrosDataGridViewTextBoxColumn.Name = "viajeCantidadKilometrosDataGridViewTextBoxColumn";
            this.viajeCantidadKilometrosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viajeHoraInicioDataGridViewTextBoxColumn
            // 
            this.viajeHoraInicioDataGridViewTextBoxColumn.DataPropertyName = "Viaje_Hora_Inicio";
            this.viajeHoraInicioDataGridViewTextBoxColumn.HeaderText = "Viaje_Hora_Inicio";
            this.viajeHoraInicioDataGridViewTextBoxColumn.Name = "viajeHoraInicioDataGridViewTextBoxColumn";
            this.viajeHoraInicioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viajeHoraFinDataGridViewTextBoxColumn
            // 
            this.viajeHoraFinDataGridViewTextBoxColumn.DataPropertyName = "Viaje_Hora_Fin";
            this.viajeHoraFinDataGridViewTextBoxColumn.HeaderText = "Viaje_Hora_Fin";
            this.viajeHoraFinDataGridViewTextBoxColumn.Name = "viajeHoraFinDataGridViewTextBoxColumn";
            this.viajeHoraFinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // choferUsernameDataGridViewTextBoxColumn
            // 
            this.choferUsernameDataGridViewTextBoxColumn.DataPropertyName = "Chofer_Username";
            this.choferUsernameDataGridViewTextBoxColumn.HeaderText = "Chofer_Username";
            this.choferUsernameDataGridViewTextBoxColumn.Name = "choferUsernameDataGridViewTextBoxColumn";
            this.choferUsernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteUsernameDataGridViewTextBoxColumn
            // 
            this.clienteUsernameDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Username";
            this.clienteUsernameDataGridViewTextBoxColumn.HeaderText = "Cliente_Username";
            this.clienteUsernameDataGridViewTextBoxColumn.Name = "clienteUsernameDataGridViewTextBoxColumn";
            this.clienteUsernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoDescripcionDataGridViewTextBoxColumn
            // 
            this.turnoDescripcionDataGridViewTextBoxColumn.DataPropertyName = "Turno_Descripcion";
            this.turnoDescripcionDataGridViewTextBoxColumn.HeaderText = "Turno_Descripcion";
            this.turnoDescripcionDataGridViewTextBoxColumn.Name = "turnoDescripcionDataGridViewTextBoxColumn";
            this.turnoDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rendicionNroDataGridViewTextBoxColumn
            // 
            this.rendicionNroDataGridViewTextBoxColumn.DataPropertyName = "Rendicion_Nro";
            this.rendicionNroDataGridViewTextBoxColumn.HeaderText = "Rendicion_Nro";
            this.rendicionNroDataGridViewTextBoxColumn.Name = "rendicionNroDataGridViewTextBoxColumn";
            this.rendicionNroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viajeBindingSource
            // 
            this.viajeBindingSource.DataMember = "Viaje";
            this.viajeBindingSource.DataSource = this.gD1C2017DataSet;
            // 
            // gD1C2017DataSet
            // 
            this.gD1C2017DataSet.DataSetName = "GD1C2017DataSet";
            this.gD1C2017DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viajeTableAdapter
            // 
            this.viajeTableAdapter.ClearBeforeFill = true;
            // 
            // HistorialDeViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 375);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "HistorialDeViajes";
            this.Text = "HistorialDeViajes";
            this.Load += new System.EventHandler(this.HistorialDeViajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viajeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private GD1C2017DataSet gD1C2017DataSet;
        private System.Windows.Forms.BindingSource viajeBindingSource;
        private GD1C2017DataSetTableAdapters.ViajeTableAdapter viajeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn viajeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viajeCantidadKilometrosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viajeHoraInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viajeHoraFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn choferUsernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteUsernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rendicionNroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoDeViaje;
    }
}