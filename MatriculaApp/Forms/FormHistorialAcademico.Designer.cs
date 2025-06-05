namespace MatriculaApp.Forms
{
    partial class FormHistorialAcademico
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbEstudiante;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblEstudiante;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cbEstudiante = new System.Windows.Forms.ComboBox();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblEstudiante = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();

            // ───── Label Estudiante ─────
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Location = new System.Drawing.Point(30, 25);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(120, 13);
            this.lblEstudiante.Text = "Seleccionar Estudiante:";

            // ───── ComboBox Estudiante ─────
            this.cbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudiante.Location = new System.Drawing.Point(160, 22);
            this.cbEstudiante.Name = "cbEstudiante";
            this.cbEstudiante.Size = new System.Drawing.Size(300, 21);
            this.cbEstudiante.SelectedIndexChanged += new System.EventHandler(this.cbEstudiante_SelectedIndexChanged);

            // ───── DataGridView Historial ─────
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(30, 60);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(740, 360);

            // ───── FormHistorialAcademico ─────
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEstudiante);
            this.Controls.Add(this.cbEstudiante);
            this.Controls.Add(this.dgvHistorial);
            this.Name = "FormHistorialAcademico";
            this.Text = "Historial Académico";
            this.Load += new System.EventHandler(this.FormHistorialAcademico_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
