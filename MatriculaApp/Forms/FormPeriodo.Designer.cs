using System.Windows.Forms;

namespace MatriculaApp.Forms
{
    partial class FormPeriodo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox cbCiclo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvPeriodos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.cbCiclo = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvPeriodos = new System.Windows.Forms.DataGridView();

            // ───── Labels ─────
            Label lblId = new Label() { Text = "ID:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            Label lblAnio = new Label() { Text = "Año académico:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            Label lblCiclo = new Label() { Text = "Ciclo:", Location = new System.Drawing.Point(20, 100), AutoSize = true };

            // ───── TextBox y ComboBox ─────
            this.txtId.Location = new System.Drawing.Point(130, 17);
            this.txtId.ReadOnly = true;
            this.txtId.Width = 200;

            this.txtAnio.Location = new System.Drawing.Point(130, 57);
            this.txtAnio.Width = 200;

            this.cbCiclo.Location = new System.Drawing.Point(130, 97);
            this.cbCiclo.Width = 200;
            this.cbCiclo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCiclo.Items.AddRange(new object[] { "I", "II" });

            // ───── Botones ─────
            this.btnGuardar.Location = new System.Drawing.Point(20, 140);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Location = new System.Drawing.Point(120, 140);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(220, 140);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ───── DataGridView ─────
            this.dgvPeriodos.Location = new System.Drawing.Point(20, 190);
            this.dgvPeriodos.Size = new System.Drawing.Size(360, 200);
            this.dgvPeriodos.ReadOnly = true;
            this.dgvPeriodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeriodos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodos_CellClick);

            // ───── FormPeriodo ─────
            this.ClientSize = new System.Drawing.Size(420, 420);
            this.Controls.AddRange(new Control[]
            {
        lblId, this.txtId,
        lblAnio, this.txtAnio,
        lblCiclo, this.cbCiclo,
        this.btnGuardar, this.btnEditar, this.btnEliminar,
        this.dgvPeriodos
            });
            this.Text = "Gestión de Periodos Académicos";

            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
