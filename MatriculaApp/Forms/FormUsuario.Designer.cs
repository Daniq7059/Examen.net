using System.Windows.Forms;

namespace MatriculaApp.Forms
{
    partial class FormUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvUsuarios;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtId = new TextBox();
            txtNombreUsuario = new TextBox();
            txtContraseña = new TextBox();
            cbRol = new ComboBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dgvUsuarios = new DataGridView();

            // ───── Labels ─────
            Label lblId = new Label() { Text = "ID:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            Label lblUsuario = new Label() { Text = "Nombre de Usuario:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            Label lblContraseña = new Label() { Text = "Contraseña:", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            Label lblRol = new Label() { Text = "Rol:", Location = new System.Drawing.Point(20, 140), AutoSize = true };

            // ───── Campos ─────
            txtId.Location = new System.Drawing.Point(160, 17);
            txtId.ReadOnly = true;
            txtId.Width = 200;

            txtNombreUsuario.Location = new System.Drawing.Point(160, 57);
            txtNombreUsuario.Width = 200;

            txtContraseña.Location = new System.Drawing.Point(160, 97);
            txtContraseña.Width = 200;
            txtContraseña.PasswordChar = '*';

            cbRol.Location = new System.Drawing.Point(160, 137);
            cbRol.Width = 200;
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.Items.AddRange(new object[] { "Administrador", "Secretaria", "Docente" });

            // ───── Botones ─────
            btnGuardar.Location = new System.Drawing.Point(20, 180);
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += new System.EventHandler(btnGuardar_Click);

            btnEditar.Location = new System.Drawing.Point(120, 180);
            btnEditar.Text = "Editar";
            btnEditar.Click += new System.EventHandler(btnEditar_Click);

            btnEliminar.Location = new System.Drawing.Point(220, 180);
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += new System.EventHandler(btnEliminar_Click);

            // ───── DataGridView ─────
            dgvUsuarios.Location = new System.Drawing.Point(20, 230);
            dgvUsuarios.Size = new System.Drawing.Size(500, 200);
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.CellClick += new DataGridViewCellEventHandler(dgvUsuarios_CellClick);

            // ───── FormUsuario ─────
            this.ClientSize = new System.Drawing.Size(560, 460);
            this.Controls.AddRange(new Control[]
            {
        lblId, txtId,
        lblUsuario, txtNombreUsuario,
        lblContraseña, txtContraseña,
        lblRol, cbRol,
        btnGuardar, btnEditar, btnEliminar,
        dgvUsuarios
            });
            this.Text = "Gestión de Usuarios";

            ((System.ComponentModel.ISupportInitialize)(dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
