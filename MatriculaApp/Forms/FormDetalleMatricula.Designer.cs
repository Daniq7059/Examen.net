using System.Windows.Forms;

namespace MatriculaApp.Forms
{
    partial class FormDetalleMatricula
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbMatricula;
        private System.Windows.Forms.ComboBox cbCurso;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvDetalles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbMatricula = new System.Windows.Forms.ComboBox();
            this.cbCurso = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();

            // ───── Labels ─────
            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new System.Drawing.Point(20, 20);
            lblId.AutoSize = true;

            Label lblMatricula = new Label();
            lblMatricula.Text = "Matrícula:";
            lblMatricula.Location = new System.Drawing.Point(20, 60);
            lblMatricula.AutoSize = true;

            Label lblCurso = new Label();
            lblCurso.Text = "Curso:";
            lblCurso.Location = new System.Drawing.Point(20, 100);
            lblCurso.AutoSize = true;

            // ───── Campos ─────
            this.txtId.Location = new System.Drawing.Point(100, 17);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 20);

            this.cbMatricula.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbMatricula.Location = new System.Drawing.Point(100, 57);
            this.cbMatricula.Size = new System.Drawing.Size(250, 21);

            this.cbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCurso.Location = new System.Drawing.Point(100, 97);
            this.cbCurso.Size = new System.Drawing.Size(250, 21);

            // ───── Botones ─────
            this.btnGuardar.Location = new System.Drawing.Point(20, 140);
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(120, 140);
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ───── DataGridView ─────
            this.dgvDetalles.Location = new System.Drawing.Point(20, 190);
            this.dgvDetalles.Size = new System.Drawing.Size(500, 200);
            this.dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.CellClick += new DataGridViewCellEventHandler(this.dgvDetalles_CellClick);

            // ───── Form ─────
            this.ClientSize = new System.Drawing.Size(550, 420);
            this.Controls.Add(lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(lblMatricula);
            this.Controls.Add(this.cbMatricula);
            this.Controls.Add(lblCurso);
            this.Controls.Add(this.cbCurso);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvDetalles);
            this.Name = "FormDetalleMatricula";
            this.Text = "Detalle de Matrícula";
            this.Load += new System.EventHandler(this.FormDetalleMatricula_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
