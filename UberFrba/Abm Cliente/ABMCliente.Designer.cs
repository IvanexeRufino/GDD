namespace UberFrba.Abm_Cliente
{
    partial class ABMCliente
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
            this.gD1C2017DataSet = new UberFrba.GD1C2017DataSet();
            this.gD1C2017DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clienteTableAdapter = new UberFrba.GD1C2017DataSetTableAdapters.ClienteTableAdapter();
            this.usuarioUsernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteApellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDNIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteFechaNacimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDireccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientePisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDepartamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteCodigoPostalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteMailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientetelefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteLocalidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuarioUsernameDataGridViewTextBoxColumn,
            this.clienteNombreDataGridViewTextBoxColumn,
            this.clienteApellidoDataGridViewTextBoxColumn,
            this.clienteDNIDataGridViewTextBoxColumn,
            this.clienteFechaNacimientoDataGridViewTextBoxColumn,
            this.clienteDireccionDataGridViewTextBoxColumn,
            this.clientePisoDataGridViewTextBoxColumn,
            this.clienteDepartamentoDataGridViewTextBoxColumn,
            this.clienteCodigoPostalDataGridViewTextBoxColumn,
            this.clienteMailDataGridViewTextBoxColumn,
            this.clientetelefonoDataGridViewTextBoxColumn,
            this.clienteLocalidadDataGridViewTextBoxColumn,
            this.Modificar,
            this.Eliminar});
            this.dataGridView1.DataSource = this.clienteBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1444, 321);
            this.dataGridView1.TabIndex = 0;
            // 
            // gD1C2017DataSet
            // 
            this.gD1C2017DataSet.DataSetName = "GD1C2017DataSet";
            this.gD1C2017DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gD1C2017DataSetBindingSource
            // 
            this.gD1C2017DataSetBindingSource.DataSource = this.gD1C2017DataSet;
            this.gD1C2017DataSetBindingSource.Position = 0;
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "Cliente";
            this.clienteBindingSource.DataSource = this.gD1C2017DataSetBindingSource;
            // 
            // clienteTableAdapter
            // 
            this.clienteTableAdapter.ClearBeforeFill = true;
            // 
            // usuarioUsernameDataGridViewTextBoxColumn
            // 
            this.usuarioUsernameDataGridViewTextBoxColumn.DataPropertyName = "Usuario_Username";
            this.usuarioUsernameDataGridViewTextBoxColumn.HeaderText = "Usuario_Username";
            this.usuarioUsernameDataGridViewTextBoxColumn.Name = "usuarioUsernameDataGridViewTextBoxColumn";
            // 
            // clienteNombreDataGridViewTextBoxColumn
            // 
            this.clienteNombreDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Nombre";
            this.clienteNombreDataGridViewTextBoxColumn.HeaderText = "Cliente_Nombre";
            this.clienteNombreDataGridViewTextBoxColumn.Name = "clienteNombreDataGridViewTextBoxColumn";
            // 
            // clienteApellidoDataGridViewTextBoxColumn
            // 
            this.clienteApellidoDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Apellido";
            this.clienteApellidoDataGridViewTextBoxColumn.HeaderText = "Cliente_Apellido";
            this.clienteApellidoDataGridViewTextBoxColumn.Name = "clienteApellidoDataGridViewTextBoxColumn";
            // 
            // clienteDNIDataGridViewTextBoxColumn
            // 
            this.clienteDNIDataGridViewTextBoxColumn.DataPropertyName = "Cliente_DNI";
            this.clienteDNIDataGridViewTextBoxColumn.HeaderText = "Cliente_DNI";
            this.clienteDNIDataGridViewTextBoxColumn.Name = "clienteDNIDataGridViewTextBoxColumn";
            // 
            // clienteFechaNacimientoDataGridViewTextBoxColumn
            // 
            this.clienteFechaNacimientoDataGridViewTextBoxColumn.DataPropertyName = "Cliente_FechaNacimiento";
            this.clienteFechaNacimientoDataGridViewTextBoxColumn.HeaderText = "Cliente_FechaNacimiento";
            this.clienteFechaNacimientoDataGridViewTextBoxColumn.Name = "clienteFechaNacimientoDataGridViewTextBoxColumn";
            // 
            // clienteDireccionDataGridViewTextBoxColumn
            // 
            this.clienteDireccionDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Direccion";
            this.clienteDireccionDataGridViewTextBoxColumn.HeaderText = "Cliente_Direccion";
            this.clienteDireccionDataGridViewTextBoxColumn.Name = "clienteDireccionDataGridViewTextBoxColumn";
            // 
            // clientePisoDataGridViewTextBoxColumn
            // 
            this.clientePisoDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Piso";
            this.clientePisoDataGridViewTextBoxColumn.HeaderText = "Cliente_Piso";
            this.clientePisoDataGridViewTextBoxColumn.Name = "clientePisoDataGridViewTextBoxColumn";
            // 
            // clienteDepartamentoDataGridViewTextBoxColumn
            // 
            this.clienteDepartamentoDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Departamento";
            this.clienteDepartamentoDataGridViewTextBoxColumn.HeaderText = "Cliente_Departamento";
            this.clienteDepartamentoDataGridViewTextBoxColumn.Name = "clienteDepartamentoDataGridViewTextBoxColumn";
            // 
            // clienteCodigoPostalDataGridViewTextBoxColumn
            // 
            this.clienteCodigoPostalDataGridViewTextBoxColumn.DataPropertyName = "Cliente_CodigoPostal";
            this.clienteCodigoPostalDataGridViewTextBoxColumn.HeaderText = "Cliente_CodigoPostal";
            this.clienteCodigoPostalDataGridViewTextBoxColumn.Name = "clienteCodigoPostalDataGridViewTextBoxColumn";
            // 
            // clienteMailDataGridViewTextBoxColumn
            // 
            this.clienteMailDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Mail";
            this.clienteMailDataGridViewTextBoxColumn.HeaderText = "Cliente_Mail";
            this.clienteMailDataGridViewTextBoxColumn.Name = "clienteMailDataGridViewTextBoxColumn";
            // 
            // clientetelefonoDataGridViewTextBoxColumn
            // 
            this.clientetelefonoDataGridViewTextBoxColumn.DataPropertyName = "Cliente_telefono";
            this.clientetelefonoDataGridViewTextBoxColumn.HeaderText = "Cliente_telefono";
            this.clientetelefonoDataGridViewTextBoxColumn.Name = "clientetelefonoDataGridViewTextBoxColumn";
            // 
            // clienteLocalidadDataGridViewTextBoxColumn
            // 
            this.clienteLocalidadDataGridViewTextBoxColumn.DataPropertyName = "Cliente_Localidad";
            this.clienteLocalidadDataGridViewTextBoxColumn.HeaderText = "Cliente_Localidad";
            this.clienteLocalidadDataGridViewTextBoxColumn.Name = "clienteLocalidadDataGridViewTextBoxColumn";
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "DNI:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(167, 108);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(170, 20);
            this.textBox3.TabIndex = 6;
            // 
            // ABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 581);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ABMCliente";
            this.Text = "ABMCliente";
            this.Load += new System.EventHandler(this.ABMCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2017DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource gD1C2017DataSetBindingSource;
        private GD1C2017DataSet gD1C2017DataSet;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private GD1C2017DataSetTableAdapters.ClienteTableAdapter clienteTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioUsernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteApellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDNIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteFechaNacimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDireccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientePisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDepartamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteCodigoPostalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteMailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientetelefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteLocalidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}