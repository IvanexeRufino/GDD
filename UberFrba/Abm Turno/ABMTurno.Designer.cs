namespace UberFrba.Abm_Turno
{
    partial class ABMTurno
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.turnoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gD1C2017DataSet = new UberFrba.GD1C2017DataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.turnoTableAdapter = new UberFrba.GD1C2017DataSetTableAdapters.TurnoTableAdapter();
            this.turnoDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoHorarioInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoHorarioFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoPrecioBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoValorKilometroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(680, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 90);
            this.button1.TabIndex = 0;
            this.button1.Text = "Alta de Turno";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.turnoDescripcionDataGridViewTextBoxColumn,
            this.turnoHorarioInicioDataGridViewTextBoxColumn,
            this.turnoHorarioFinDataGridViewTextBoxColumn,
            this.turnoPrecioBaseDataGridViewTextBoxColumn,
            this.turnoValorKilometroDataGridViewTextBoxColumn,
            this.turnoEstadoDataGridViewTextBoxColumn,
            this.Modificar,
            this.Eliminar});
            this.dataGridView1.DataSource = this.turnoBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(844, 294);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // turnoBindingSource1
            // 
            this.turnoBindingSource1.DataMember = "Turno";
            this.turnoBindingSource1.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.gD1C2017DataSet;
            this.bindingSource1.Position = 0;
            // 
            // gD1C2017DataSet
            // 
            this.gD1C2017DataSet.DataSetName = "GD1C2017DataSet";
            this.gD1C2017DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 128);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrado";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(674, 81);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 31);
            this.button4.TabIndex = 4;
            this.button4.Text = "Limpiar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(674, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "Filtrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 31);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 492);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 90);
            this.button3.TabIndex = 3;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // turnoTableAdapter
            // 
            this.turnoTableAdapter.ClearBeforeFill = true;
            // 
            // turnoDescripcionDataGridViewTextBoxColumn
            // 
            this.turnoDescripcionDataGridViewTextBoxColumn.DataPropertyName = "Turno_Descripcion";
            this.turnoDescripcionDataGridViewTextBoxColumn.HeaderText = "Turno_Descripcion";
            this.turnoDescripcionDataGridViewTextBoxColumn.Name = "turnoDescripcionDataGridViewTextBoxColumn";
            this.turnoDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoHorarioInicioDataGridViewTextBoxColumn
            // 
            this.turnoHorarioInicioDataGridViewTextBoxColumn.DataPropertyName = "Turno_Horario_Inicio";
            this.turnoHorarioInicioDataGridViewTextBoxColumn.HeaderText = "Turno_Horario_Inicio";
            this.turnoHorarioInicioDataGridViewTextBoxColumn.Name = "turnoHorarioInicioDataGridViewTextBoxColumn";
            this.turnoHorarioInicioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoHorarioFinDataGridViewTextBoxColumn
            // 
            this.turnoHorarioFinDataGridViewTextBoxColumn.DataPropertyName = "Turno_Horario_Fin";
            this.turnoHorarioFinDataGridViewTextBoxColumn.HeaderText = "Turno_Horario_Fin";
            this.turnoHorarioFinDataGridViewTextBoxColumn.Name = "turnoHorarioFinDataGridViewTextBoxColumn";
            this.turnoHorarioFinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoPrecioBaseDataGridViewTextBoxColumn
            // 
            this.turnoPrecioBaseDataGridViewTextBoxColumn.DataPropertyName = "Turno_Precio_Base";
            this.turnoPrecioBaseDataGridViewTextBoxColumn.HeaderText = "Turno_Precio_Base";
            this.turnoPrecioBaseDataGridViewTextBoxColumn.Name = "turnoPrecioBaseDataGridViewTextBoxColumn";
            this.turnoPrecioBaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoValorKilometroDataGridViewTextBoxColumn
            // 
            this.turnoValorKilometroDataGridViewTextBoxColumn.DataPropertyName = "Turno_Valor_Kilometro";
            this.turnoValorKilometroDataGridViewTextBoxColumn.HeaderText = "Turno_Valor_Kilometro";
            this.turnoValorKilometroDataGridViewTextBoxColumn.Name = "turnoValorKilometroDataGridViewTextBoxColumn";
            this.turnoValorKilometroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoEstadoDataGridViewTextBoxColumn
            // 
            this.turnoEstadoDataGridViewTextBoxColumn.DataPropertyName = "Turno_Estado";
            this.turnoEstadoDataGridViewTextBoxColumn.HeaderText = "Turno_Estado";
            this.turnoEstadoDataGridViewTextBoxColumn.Name = "turnoEstadoDataGridViewTextBoxColumn";
            this.turnoEstadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Inhabilitar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // ABMTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 602);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "ABMTurno";
            this.Text = "ABMTurno";
            this.Load += new System.EventHandler(this.ABMTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private GD1C2017DataSet gD1C2017DataSet;
        private GD1C2017DataSetTableAdapters.TurnoTableAdapter turnoTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.BindingSource turnoBindingSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoHorarioInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoHorarioFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoPrecioBaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoValorKilometroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}