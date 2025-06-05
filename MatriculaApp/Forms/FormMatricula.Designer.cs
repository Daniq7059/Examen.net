using System.Windows.Forms; // ✅ NECESARIO para usar Label, TextBox, Button, etc.

namespace MatriculaApp.Forms
{
    partial class FormMatricula
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbEstudiante;
        private System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvMatriculas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbEstudiante = new System.Windows.Forms.ComboBox();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvMatriculas = new System.Windows.Forms.DataGridView();

            // ───── Labels ─────
            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new System.Drawing.Point(20, 20);
            lblId.AutoSize = true;

            Label lblEstudiante = new Label();
            lblEstudiante.Text = "Estudiante:";
            lblEstudiante.Location = new System.Drawing.Point(20, 60);
            lblEstudiante.AutoSize = true;

            Label lblPeriodo = new Label();
            lblPeriodo.Text = "Periodo:";
            lblPeriodo.Location = new System.Drawing.Point(20, 100);
            lblPeriodo.AutoSize = true;

            // ───── TextBox ID ─────
            this.txtId.Location = new System.Drawing.Point(100, 17);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 20);

            // ───── ComboBox Estudiante ─────
            this.cbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstudiante.Location = new System.Drawing.Point(100, 57);
            this.cbEstudiante.Name = "cbEstudiante";
            this.cbEstudiante.Size = new System.Drawing.Size(300, 21);

            // ───── ComboBox Periodo ─────
            this.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriodo.Location = new System.Drawing.Point(100, 97);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(200, 21);

            // ───── Botón Guardar ─────
            this.btnGuardar.Location = new System.Drawing.Point(20, 140);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // ───── Botón Eliminar ─────
            this.btnEliminar.Location = new System.Drawing.Point(120, 140);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ───── DataGridView ─────
            this.dgvMatriculas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatriculas.Location = new System.Drawing.Point(20, 190);
            this.dgvMatriculas.Name = "dgvMatriculas";
            this.dgvMatriculas.ReadOnly = true;
            this.dgvMatriculas.Size = new System.Drawing.Size(500, 200);
            this.dgvMatriculas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatriculas_CellClick);

            // ───── FormMatricula ─────
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.Controls.Add(lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(lblEstudiante);
            this.Controls.Add(this.cbEstudiante);
            this.Controls.Add(lblPeriodo);
            this.Controls.Add(this.cbPeriodo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvMatriculas);
            this.Name = "FormMatricula";
            this.Text = "Gestión de Matrículas";
            this.Load += new System.EventHandler(this.FormMatricula_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
