namespace Proyecto_Final_PA.Buscar
{
    partial class frm_Buscar
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboTabla = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cboCampoEspecifico = new System.Windows.Forms.ComboBox();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla";
            // 
            // cboTabla
            // 
            this.cboTabla.FormattingEnabled = true;
            this.cboTabla.Location = new System.Drawing.Point(53, 16);
            this.cboTabla.Name = "cboTabla";
            this.cboTabla.Size = new System.Drawing.Size(121, 21);
            this.cboTabla.TabIndex = 1;
            this.cboTabla.SelectedIndexChanged += new System.EventHandler(this.cambiar);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(547, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Campo Especifico";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(242, 16);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 5;
            this.txtId.TextChanged += new System.EventHandler(this.filtrarID);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(429, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.TextChanged += new System.EventHandler(this.listarNombre);
            // 
            // cboCampoEspecifico
            // 
            this.cboCampoEspecifico.FormattingEnabled = true;
            this.cboCampoEspecifico.Location = new System.Drawing.Point(645, 15);
            this.cboCampoEspecifico.Name = "cboCampoEspecifico";
            this.cboCampoEspecifico.Size = new System.Drawing.Size(151, 21);
            this.cboCampoEspecifico.TabIndex = 7;
            this.cboCampoEspecifico.SelectedIndexChanged += new System.EventHandler(this.campoCambiar);
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(645, 61);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(151, 20);
            this.txtFiltrar.TabIndex = 8;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // dgvTabla
            // 
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla.Location = new System.Drawing.Point(320, 132);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.Size = new System.Drawing.Size(242, 212);
            this.dgvTabla.TabIndex = 9;
            // 
            // frm_Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 412);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.cboCampoEspecifico);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTabla);
            this.Controls.Add(this.label1);
            this.Name = "frm_Buscar";
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.frm_Buscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cboCampoEspecifico;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.DataGridView dgvTabla;
    }
}