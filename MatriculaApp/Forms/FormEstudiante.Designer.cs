// Diseño: FormEstudiante.Designer.cs
using System.Windows.Forms;

namespace MatriculaApp.Forms
{
    partial class FormEstudiante
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.ComboBox cbCarrera;
        private System.Windows.Forms.ComboBox cbApoderado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvEstudiantes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new TextBox();
            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtDNI = new TextBox();
            this.cbCarrera = new ComboBox();
            this.cbApoderado = new ComboBox();
            this.btnGuardar = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();
            this.dgvEstudiantes = new DataGridView();

            // ───── Labels ─────
            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new System.Drawing.Point(20, 20);
            lblId.AutoSize = true;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new System.Drawing.Point(20, 60);
            lblNombre.AutoSize = true;

            Label lblApellido = new Label();
            lblApellido.Text = "Apellido:";
            lblApellido.Location = new System.Drawing.Point(20, 100);
            lblApellido.AutoSize = true;

            Label lblDNI = new Label();
            lblDNI.Text = "DNI:";
            lblDNI.Location = new System.Drawing.Point(20, 140);
            lblDNI.AutoSize = true;

            Label lblCarrera = new Label();
            lblCarrera.Text = "Carrera:";
            lblCarrera.Location = new System.Drawing.Point(20, 180);
            lblCarrera.AutoSize = true;

            Label lblApoderado = new Label();
            lblApoderado.Text = "Apoderado:";
            lblApoderado.Location = new System.Drawing.Point(20, 220);
            lblApoderado.AutoSize = true;

            // ───── Campos ─────
            this.txtId.Location = new System.Drawing.Point(100, 17);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 20);

            this.txtNombre.Location = new System.Drawing.Point(100, 57);
            this.txtNombre.Size = new System.Drawing.Size(250, 20);

            this.txtApellido.Location = new System.Drawing.Point(100, 97);
            this.txtApellido.Size = new System.Drawing.Size(250, 20);

            this.txtDNI.Location = new System.Drawing.Point(100, 137);
            this.txtDNI.Size = new System.Drawing.Size(150, 20);

            this.cbCarrera.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCarrera.Location = new System.Drawing.Point(100, 177);
            this.cbCarrera.Size = new System.Drawing.Size(250, 21);

            this.cbApoderado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbApoderado.Location = new System.Drawing.Point(100, 217);
            this.cbApoderado.Size = new System.Drawing.Size(250, 21);

            // ───── Botones ─────
            this.btnGuardar.Location = new System.Drawing.Point(20, 260);
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Location = new System.Drawing.Point(110, 260);
            this.btnEditar.Size = new System.Drawing.Size(75, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(200, 260);
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ───── DataGridView ─────
            this.dgvEstudiantes.Location = new System.Drawing.Point(20, 310);
            this.dgvEstudiantes.Size = new System.Drawing.Size(600, 200);
            this.dgvEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstudiantes.ReadOnly = true;
            this.dgvEstudiantes.CellClick += new DataGridViewCellEventHandler(this.dgvEstudiantes_CellClick);

            // ───── Form ─────
            this.ClientSize = new System.Drawing.Size(650, 530);
            this.Controls.Add(lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(lblApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(lblDNI);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(lblCarrera);
            this.Controls.Add(this.cbCarrera);
            this.Controls.Add(lblApoderado);
            this.Controls.Add(this.cbApoderado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvEstudiantes);
            this.Name = "FormEstudiante";
            this.Text = "Gestión de Estudiantes";
            this.Load += new System.EventHandler(this.FormEstudiante_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
