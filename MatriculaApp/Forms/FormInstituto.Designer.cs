using System.Windows.Forms; // ✅ NECESARIO para usar Label, TextBox, Button, etc.

namespace MatriculaApp.Forms

{
    partial class FormInstituto
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvInstitutos;
    System.Windows.Forms.Label lblId = new System.Windows.Forms.Label();

    protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvInstitutos = new System.Windows.Forms.DataGridView();

            // ───── Labels ─────
            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new System.Drawing.Point(20, 20);
            lblId.AutoSize = true;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new System.Drawing.Point(20, 60);
            lblNombre.AutoSize = true;

            Label lblDireccion = new Label();
            lblDireccion.Text = "Dirección:";
            lblDireccion.Location = new System.Drawing.Point(20, 100);
            lblDireccion.AutoSize = true;

            // ───── TextBox ID ─────
            this.txtId.Location = new System.Drawing.Point(100, 17);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 20);

            // ───── TextBox Nombre ─────
            this.txtNombre.Location = new System.Drawing.Point(100, 57);
            this.txtNombre.Size = new System.Drawing.Size(300, 20);

            // ───── TextBox Dirección ─────
            this.txtDireccion.Location = new System.Drawing.Point(100, 97);
            this.txtDireccion.Size = new System.Drawing.Size(380, 20);

            // ───── Botones ─────
            this.btnGuardar.Location = new System.Drawing.Point(20, 140);
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Location = new System.Drawing.Point(120, 140);
            this.btnEditar.Size = new System.Drawing.Size(75, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(220, 140);
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ───── DataGridView ─────
            this.dgvInstitutos.Location = new System.Drawing.Point(20, 190);
            this.dgvInstitutos.Size = new System.Drawing.Size(500, 200);
            this.dgvInstitutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstitutos.ReadOnly = true;
            this.dgvInstitutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstitutos_CellClick);

            // ───── FormInstituto ─────
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.Controls.Add(lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvInstitutos);
            this.Name = "FormInstituto";
            this.Text = "Gestión de Institutos";
            this.Load += new System.EventHandler(this.FormInstituto_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvInstitutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
