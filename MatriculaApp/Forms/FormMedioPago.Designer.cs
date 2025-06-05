using System.Windows.Forms;

namespace MatriculaApp.Forms
{
    partial class FormMedioPago
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvMediosPago;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvMediosPago = new System.Windows.Forms.DataGridView();

            // ───── Labels ─────
            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new System.Drawing.Point(20, 20);
            lblId.AutoSize = true;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new System.Drawing.Point(20, 60);
            lblNombre.AutoSize = true;

            Label lblDescripcion = new Label();
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Location = new System.Drawing.Point(20, 100);
            lblDescripcion.AutoSize = true;

            // ───── TextBox ID ─────
            this.txtId.Location = new System.Drawing.Point(100, 17);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(250, 20);

            // ───── TextBox Nombre ─────
            this.txtNombre.Location = new System.Drawing.Point(100, 57);
            this.txtNombre.Size = new System.Drawing.Size(300, 20);

            // ───── TextBox Descripción ─────
            this.txtDescripcion.Location = new System.Drawing.Point(100, 97);
            this.txtDescripcion.Size = new System.Drawing.Size(400, 20);

            // ───── Botón Guardar ─────
            this.btnGuardar.Location = new System.Drawing.Point(20, 140);
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // ───── Botón Editar ─────
            this.btnEditar.Location = new System.Drawing.Point(120, 140);
            this.btnEditar.Size = new System.Drawing.Size(75, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // ───── Botón Eliminar ─────
            this.btnEliminar.Location = new System.Drawing.Point(220, 140);
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ───── DataGridView ─────
            this.dgvMediosPago.Location = new System.Drawing.Point(20, 190);
            this.dgvMediosPago.Size = new System.Drawing.Size(500, 200);
            this.dgvMediosPago.ReadOnly = true;
            this.dgvMediosPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMediosPago.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMediosPago_CellClick);

            // ───── FormMedioPago ─────
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.Controls.Add(lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvMediosPago);
            this.Name = "FormMedioPago";
            this.Text = "Gestión de Medios de Pago";
            this.Load += new System.EventHandler(this.FormMedioPago_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMediosPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
