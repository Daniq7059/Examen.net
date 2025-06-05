using System.Windows.Forms;

namespace MatriculaApp.Forms
{
    partial class FormCarrera
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown nudDuracion;
        private System.Windows.Forms.ComboBox cbInstituto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvCarreras;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.nudDuracion = new System.Windows.Forms.NumericUpDown();
            this.cbInstituto = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvCarreras = new System.Windows.Forms.DataGridView();

            // NUEVOS LABELS
            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new System.Drawing.Point(20, 20);
            lblId.AutoSize = true;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new System.Drawing.Point(20, 60);
            lblNombre.AutoSize = true;

            Label lblDuracion = new Label();
            lblDuracion.Text = "Duración (ciclos):";
            lblDuracion.Location = new System.Drawing.Point(20, 100);
            lblDuracion.AutoSize = true;

            Label lblInstituto = new Label();
            lblInstituto.Text = "Instituto:";
            lblInstituto.Location = new System.Drawing.Point(20, 140);
            lblInstituto.AutoSize = true;

            // txtId
            this.txtId.Location = new System.Drawing.Point(140, 17);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 20);

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(140, 57);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 20);

            // nudDuracion
            this.nudDuracion.Location = new System.Drawing.Point(140, 97);
            this.nudDuracion.Maximum = 12;
            this.nudDuracion.Minimum = 1;
            this.nudDuracion.Value = 1;
            this.nudDuracion.Size = new System.Drawing.Size(100, 20);

            // cbInstituto
            this.cbInstituto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbInstituto.Location = new System.Drawing.Point(140, 137);
            this.cbInstituto.Size = new System.Drawing.Size(250, 21);

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(20, 180);
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnEditar
            this.btnEditar.Location = new System.Drawing.Point(110, 180);
            this.btnEditar.Size = new System.Drawing.Size(75, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(200, 180);
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // dgvCarreras
            this.dgvCarreras.Location = new System.Drawing.Point(20, 230);
            this.dgvCarreras.Size = new System.Drawing.Size(500, 200);
            this.dgvCarreras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarreras.ReadOnly = true;
            this.dgvCarreras.CellClick += new DataGridViewCellEventHandler(this.dgvCarreras_CellClick);

            // FormCarrera
            this.ClientSize = new System.Drawing.Size(560, 460);
            this.Controls.Add(lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(lblDuracion);
            this.Controls.Add(this.nudDuracion);
            this.Controls.Add(lblInstituto);
            this.Controls.Add(this.cbInstituto);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvCarreras);
            this.Name = "FormCarrera";
            this.Text = "Gestión de Carreras";
            this.Load += new System.EventHandler(this.FormCarrera_Load_1);

            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
