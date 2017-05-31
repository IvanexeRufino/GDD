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
            this.SuspendLayout();
            // 
            // RegistroViajes
            // 
            this.ClientSize = new System.Drawing.Size(631, 342);
            this.Name = "RegistroViajes";
            this.Text = "Registrar Viaje";
            this.ResumeLayout(false);

        }

        #endregion

        private GD1C2017DataSet gD1C2017DataSet;
        private System.Windows.Forms.BindingSource viajeBindingSource;
        private GD1C2017DataSetTableAdapters.ViajeTableAdapter viajeTableAdapter;
    }
}