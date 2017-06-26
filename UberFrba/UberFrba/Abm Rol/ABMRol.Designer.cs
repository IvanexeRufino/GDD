namespace UberFrba.Abm_Rol
{
    partial class ABMRol
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
            this.gD1C2017DataSet = new UberFrba.GD1C2017DataSet();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rolTableAdapter = new UberFrba.GD1C2017DataSetTableAdapters.RolTableAdapter();
            this.rolBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gD1C2017DataSet1 = new UberFrba.GD1C2017DataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rolBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.rolIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Inhabilitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // gD1C2017DataSet
            // 
            this.gD1C2017DataSet.DataSetName = "GD1C2017DataSet";
            this.gD1C2017DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataMember = "Rol";
            this.rolBindingSource.DataSource = this.gD1C2017DataSet;
            // 
            // rolTableAdapter
            // 
            this.rolTableAdapter.ClearBeforeFill = true;
            // 
            // rolBindingSource1
            // 
            this.rolBindingSource1.DataMember = "Rol";
            this.rolBindingSource1.DataSource = this.gD1C2017DataSet;
            // 
            // gD1C2017DataSet1
            // 
            this.gD1C2017DataSet1.DataSetName = "GD1C2017DataSet";
            this.gD1C2017DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolIdDataGridViewTextBoxColumn,
            this.rolNombreDataGridViewTextBoxColumn,
            this.rolEstadoDataGridViewTextBoxColumn,
            this.Modificar,
            this.Inhabilitar});
            this.dataGridView1.DataSource = this.rolBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(544, 258);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // rolBindingSource2
            // 
            this.rolBindingSource2.DataMember = "Rol";
            this.rolBindingSource2.DataSource = this.gD1C2017DataSet;
            // 
            // rolIdDataGridViewTextBoxColumn
            // 
            this.rolIdDataGridViewTextBoxColumn.DataPropertyName = "Rol_Id";
            this.rolIdDataGridViewTextBoxColumn.HeaderText = "Rol_Id";
            this.rolIdDataGridViewTextBoxColumn.Name = "rolIdDataGridViewTextBoxColumn";
            this.rolIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rolNombreDataGridViewTextBoxColumn
            // 
            this.rolNombreDataGridViewTextBoxColumn.DataPropertyName = "Rol_Nombre";
            this.rolNombreDataGridViewTextBoxColumn.HeaderText = "Rol_Nombre";
            this.rolNombreDataGridViewTextBoxColumn.Name = "rolNombreDataGridViewTextBoxColumn";
            // 
            // rolEstadoDataGridViewTextBoxColumn
            // 
            this.rolEstadoDataGridViewTextBoxColumn.DataPropertyName = "Rol_Estado";
            this.rolEstadoDataGridViewTextBoxColumn.HeaderText = "Rol_Estado";
            this.rolEstadoDataGridViewTextBoxColumn.Name = "rolEstadoDataGridViewTextBoxColumn";
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            // 
            // Inhabilitar
            // 
            this.Inhabilitar.HeaderText = "Inhabilitar";
            this.Inhabilitar.Name = "Inhabilitar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(439, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Alta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 336);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ABMRol";
            this.Text = "ABMRol";
            this.Load += new System.EventHandler(this.ABMRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GD1C2017DataSet gD1C2017DataSet;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private GD1C2017DataSetTableAdapters.RolTableAdapter rolTableAdapter;
        private System.Windows.Forms.BindingSource rolBindingSource1;
        private GD1C2017DataSet gD1C2017DataSet1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Inhabilitar;
        private System.Windows.Forms.BindingSource rolBindingSource2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}