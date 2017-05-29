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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rolNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gD1C2017DataSet1 = new UberFrba.GD1C2017DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet1)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNombreDataGridViewTextBoxColumn,
            this.rolEstadoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.rolBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(424, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(388, 150);
            this.dataGridView1.TabIndex = 0;
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
            // ABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 582);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ABMRol";
            this.Text = "ABMRol";
            this.Load += new System.EventHandler(this.ABMRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GD1C2017DataSet gD1C2017DataSet;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private GD1C2017DataSetTableAdapters.RolTableAdapter rolTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource rolBindingSource1;
        private GD1C2017DataSet gD1C2017DataSet1;
    }
}