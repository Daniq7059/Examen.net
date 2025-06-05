using System.Windows.Forms;

namespace MatriculaApp.Forms
{
    partial class FormCurso
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown nudCreditos;
        private System.Windows.Forms.NumericUpDown nudCiclo;
        private System.Windows.Forms.ComboBox cbCarrera;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvCursos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.nudCreditos = new System.Windows.Forms.NumericUpDown();
            this.nudCiclo = new System.Windows.Forms.NumericUpDown();
            this.cbCarrera = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvCursos = new System.Windows.Forms.DataGridView();

            // ───── Labels añadidos ─────
            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new System.Drawing.Point(20, 20);
            lblId.AutoSize = true;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new System.Drawing.Point(20, 60);
            lblNombre.AutoSize = true;

            Label lblCreditos = new Label();
            lblCreditos.Text = "Créditos:";
            lblCreditos.Location = new System.Drawing.Point(20, 100);
            lblCreditos.AutoSize = true;

            Label lblCiclo = new Label();
            lblCiclo.Text = "Ciclo:";
            lblCiclo.Location = new System.Drawing.Point(20, 140);
            lblCiclo.AutoSize = true;

            Label lblCarrera = new Label();
            lblCarrera.Text = "Carrera:";
            lblCarrera.Location = new System.Drawing.Point(20, 180);
            lblCarrera.AutoSize = true;

            // ───── Campos ─────
            this.txtId.Location = new System.Drawing.Point(100, 17);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 20);

            this.txtNombre.Location = new System.Drawing.Point(100, 57);
            this.txtNombre.Size = new System.Drawing.Size(250, 20);

            this.nudCreditos.Location = new System.Drawing.Point(100, 97);
            this.nudCreditos.Minimum = 1;
            this.nudCreditos.Maximum = 10;
            this.nudCreditos.Value = 1;
            this.nudCreditos.Size = new System.Drawing.Size(100, 20);

            this.nudCiclo.Location = new System.Drawing.Point(100, 137);
            this.nudCiclo.Minimum = 1;
            this.nudCiclo.Maximum = 12;
            this.nudCiclo.Value = 1;
            this.nudCiclo.Size = new System.Drawing.Size(100, 20);

            this.cbCarrera.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCarrera.Location = new System.Drawing.Point(100, 177);
            this.cbCarrera.Size = new System.Drawing.Size(250, 21);

            // ───── Botones ─────
            this.btnGuardar.Location = new System.Drawing.Point(20, 220);
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Location = new System.Drawing.Point(110, 220);
            this.btnEditar.Size = new System.Drawing.Size(75, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(200, 220);
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ───── DataGridView ─────
            this.dgvCursos.Location = new System.Drawing.Point(20, 270);
            this.dgvCursos.Size = new System.Drawing.Size(500, 200);
            this.dgvCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCursos_CellClick);

            // ───── Form ─────
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.Controls.Add(lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(lblCreditos);
            this.Controls.Add(this.nudCreditos);
            this.Controls.Add(lblCiclo);
            this.Controls.Add(this.nudCiclo);
            this.Controls.Add(lblCarrera);
            this.Controls.Add(this.cbCarrera);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvCursos);
            this.Name = "FormCurso";
            this.Text = "Gestión de Cursos";
            this.Load += new System.EventHandler(this.FormCurso_Load_1);

            ((System.ComponentModel.ISupportInitialize)(this.nudCreditos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCiclo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
