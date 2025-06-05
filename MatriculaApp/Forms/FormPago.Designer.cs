using System.Windows.Forms;

namespace MatriculaApp.Forms
{
    partial class FormPago
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbMatricula;
        private System.Windows.Forms.ComboBox cbMedioPago;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Button btnSubirArchivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvPagos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbMatricula = new System.Windows.Forms.ComboBox();
            this.cbMedioPago = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.btnSubirArchivo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvPagos = new System.Windows.Forms.DataGridView();

            // ───── Labels ─────
            Label lblId = new Label() { Text = "ID:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            Label lblMatricula = new Label() { Text = "Matrícula:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            Label lblMedio = new Label() { Text = "Medio de Pago:", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            Label lblFecha = new Label() { Text = "Fecha de Pago:", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            Label lblMonto = new Label() { Text = "Monto:", Location = new System.Drawing.Point(20, 180), AutoSize = true };
            Label lblEstado = new Label() { Text = "Estado:", Location = new System.Drawing.Point(20, 220), AutoSize = true };
            Label lblArchivoLabel = new Label() { Text = "Archivo:", Location = new System.Drawing.Point(20, 260), AutoSize = true };

            // ───── TextBox y ComboBox ─────
            this.txtId.Location = new System.Drawing.Point(140, 17);
            this.txtId.ReadOnly = true;
            this.txtId.Width = 200;

            this.cbMatricula.Location = new System.Drawing.Point(140, 57);
            this.cbMatricula.Width = 300;

            this.cbMedioPago.Location = new System.Drawing.Point(140, 97);
            this.cbMedioPago.Width = 250;

            this.dtpFecha.Location = new System.Drawing.Point(140, 137);
            this.dtpFecha.Width = 250;

            this.txtMonto.Location = new System.Drawing.Point(140, 177);
            this.txtMonto.Width = 150;

            this.cbEstado.Location = new System.Drawing.Point(140, 217);
            this.cbEstado.Width = 200;
            this.cbEstado.Items.AddRange(new object[] { "Pagado", "Pendiente", "Anulado" });

            this.lblArchivo.Location = new System.Drawing.Point(140, 257);
            this.lblArchivo.Width = 300;
            this.lblArchivo.Text = "Sin archivo";

            this.btnSubirArchivo.Location = new System.Drawing.Point(460, 253);
            this.btnSubirArchivo.Text = "Subir archivo";
            this.btnSubirArchivo.Click += new System.EventHandler(this.btnSubirArchivo_Click);

            this.btnGuardar.Location = new System.Drawing.Point(20, 300);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // ───── DataGridView ─────
            this.dgvPagos.Location = new System.Drawing.Point(20, 340);
            this.dgvPagos.Size = new System.Drawing.Size(740, 200);
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPagos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagos_CellClick);

            // ───── FormPago ─────
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.AddRange(new Control[]
            {
        lblId, this.txtId,
        lblMatricula, this.cbMatricula,
        lblMedio, this.cbMedioPago,
        lblFecha, this.dtpFecha,
        lblMonto, this.txtMonto,
        lblEstado, this.cbEstado,
        lblArchivoLabel, this.lblArchivo,
        this.btnSubirArchivo,
        this.btnGuardar,
        this.dgvPagos
            });
            this.Text = "Registro de Pagos";
            this.Load += new System.EventHandler(this.FormPago_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
