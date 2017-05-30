namespace UberFrba.Registro_Viajes
{
    partial class RegistroViajes
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.viajeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choferUsernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.automovilPatenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viajeCantidadKilometrosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viajeHoraInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viajeHoraFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteUsernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viajeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD1C2017DataSet = new UberFrba.GD1C2017DataSet();
            this.viajeTableAdapter = new UberFrba.GD1C2017DataSetTableAdapters.ViajeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viajeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.viajeIdDataGridViewTextBoxColumn,
            this.choferUsernameDataGridViewTextBoxColumn,
            this.automovilPatenteDataGridViewTextBoxColumn,
            this.turnoDescripcionDataGridViewTextBoxColumn,
            this.viajeCantidadKilometrosDataGridViewTextBoxColumn,
            this.viajeHoraInicioDataGridViewTextBoxColumn,
            this.viajeHoraFinDataGridViewTextBoxColumn,
            this.clienteUsernameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.viajeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(841, 217);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // viajeIdDataGridViewTextBoxColumn
            // 
            this.viajeIdDataGridViewTextBoxColumn.DataPropertyName = "Viaje_Id";
            this.viajeIdDataGridViewTextBoxColumn.HeaderText = "Viaje_Id";
            this.viajeIdDataGridViewTextBoxColumn.Name = "viajeIdDataGridViewTextBoxColumn";
            this.viajeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // choferUsernameDataGridViewTextBoxColumn
            // 
            this.choferUsernameDataGridViewTextBoxColumn.DataPropertyName = "Chofer_Username";
            this.choferUsernameDataGridViewTextBoxColumn.HeaderText = "Chofer_Username";
            this.choferUsernameDataGridViewTextBoxColumn.Name = "choferUsernameDataGridViewTextBoxColumn";
            this.choferUsernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.choferUsernameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.choferUsernameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // automovilPatenteDataGridViewTextBoxColumn
            // 
            this.automovilPatenteDataGridViewTextBoxColumn.DataPropertyName = "Automovil_Patente";
            this.automovilPatenteDataGridViewTextBoxColumn.HeaderText = "Automovil_Patente";
            this.automovilPatenteDataGridViewTextBoxColumn.Name = "automovilPatenteDataGridViewTextBoxColumn";
            this.automovilPatenteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoDescripcionDataGridViewTextBoxColumn
            // 
            this.turnoDescripcionDataGridViewTextBoxColumn.DataPropertyName = "Turno_Descripcion";
            this.turnoDescripcionDataGridViewTextBoxColumn.HeaderText = "Turno_Descripcion";
            this.turnoDescripcionDataGridViewTextBoxColumn.Name = "turnoDescripcionDataGridViewTextBoxColumn";
            this.turnoDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
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
            // clienteUsernameDataGridViewTextBoxColumn
            // 
            this.clienteUsernameDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Username";
            this.clienteUsernameDataGridViewTextBoxColumn.HeaderText = "Cliente_Username";
            this.clienteUsernameDataGridViewTextBoxColumn.Name = "clienteUsernameDataGridViewTextBoxColumn";
            this.clienteUsernameDataGridViewTextBoxColumn.ReadOnly = true;
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
            // RegistroViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 340);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RegistroViajes";
            this.Text = "Registro de Viajes";
            this.Load += new System.EventHandler(this.RegistroViajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viajeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private GD1C2017DataSet gD1C2017DataSet;
        private System.Windows.Forms.BindingSource viajeBindingSource;
        private GD1C2017DataSetTableAdapters.ViajeTableAdapter viajeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn viajeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn choferUsernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn automovilPatenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viajeCantidadKilometrosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viajeHoraInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viajeHoraFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteUsernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}