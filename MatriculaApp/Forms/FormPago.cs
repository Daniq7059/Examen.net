using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormPago : Form
    {
        private readonly AppDbContext _context = new AppDbContext();
        private string _archivoSeleccionado = "";

        public FormPago()
        {
            InitializeComponent();
            CargarMediosPago();
            CargarMatriculas();
            CargarPagos();
        }

        private void CargarMediosPago()
        {
            cbMedioPago.DataSource = _context.MediosPago.ToList();
            cbMedioPago.DisplayMember = "Nombre";
            cbMedioPago.ValueMember = "MedioPagoId";
            cbMedioPago.SelectedIndex = -1;
        }

        private void CargarMatriculas()
        {
            cbMatricula.DataSource = _context.Matriculas
                .Select(m => new
                {
                    m.MatriculaId,
                    NombreCompleto = m.Estudiante.Nombre + " - " + m.Periodo.Anio + " " + m.Periodo.Ciclo
                }).ToList();

            cbMatricula.DisplayMember = "NombreCompleto";
            cbMatricula.ValueMember = "MatriculaId";
            cbMatricula.SelectedIndex = -1;
        }

        private void CargarPagos()
        {
            dgvPagos.DataSource = _context.Pagos
                .Select(p => new
                {
                    p.PagoId,
                    Estudiante = p.Matricula.Estudiante.Nombre,
                    Periodo = p.Matricula.Periodo.Anio + " " + p.Matricula.Periodo.Ciclo,
                    MedioPago = p.MedioPago.Nombre,
                    p.Monto,
                    p.Fecha,
                    p.Estado,
                    p.ComprobanteUrl
                }).ToList();
        }

        private void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Archivos PDF|*.pdf|Imágenes|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _archivoSeleccionado = ofd.FileName;
                lblArchivo.Text = Path.GetFileName(_archivoSeleccionado);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbMatricula.SelectedIndex == -1 || cbMedioPago.SelectedIndex == -1 || cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtId.Text))
            {
                // NUEVO PAGO
                var nuevoPago = new Pago
                {
                    MatriculaId = (int)cbMatricula.SelectedValue,
                    MedioPagoId = (int)cbMedioPago.SelectedValue,
                    Fecha = dtpFecha.Value,
                    Monto = monto,
                    Estado = cbEstado.Text,
                    ComprobanteUrl = GuardarArchivoComprobante()
                };

                _context.Pagos.Add(nuevoPago);
            }
            else
            {
                // MODIFICAR EXISTENTE
                int idPago = int.Parse(txtId.Text);
                var pagoExistente = _context.Pagos.Find(idPago);

                if (pagoExistente == null)
                {
                    MessageBox.Show("Pago no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pagoExistente.MatriculaId = (int)cbMatricula.SelectedValue;
                pagoExistente.MedioPagoId = (int)cbMedioPago.SelectedValue;
                pagoExistente.Fecha = dtpFecha.Value;
                pagoExistente.Monto = monto;
                pagoExistente.Estado = cbEstado.Text;

                // Solo reemplaza si se seleccionó nuevo archivo
                if (!string.IsNullOrEmpty(_archivoSeleccionado))
                {
                    pagoExistente.ComprobanteUrl = GuardarArchivoComprobante();
                }

                _context.Entry(pagoExistente).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();
            CargarPagos();
            LimpiarCampos();
        }

        private string GuardarArchivoComprobante()
        {
            if (string.IsNullOrEmpty(_archivoSeleccionado)) return "";

            string destino = Path.Combine("Comprobantes", Path.GetFileName(_archivoSeleccionado));
            Directory.CreateDirectory("Comprobantes");
            File.Copy(_archivoSeleccionado, destino, true);
            return destino;
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtMonto.Text = "";
            cbEstado.SelectedIndex = -1;
            cbMedioPago.SelectedIndex = -1;
            cbMatricula.SelectedIndex = -1;
            lblArchivo.Text = "Sin archivo";
            _archivoSeleccionado = "";
        }

        private void dgvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPagos.Rows[e.RowIndex];

            txtId.Text = row.Cells["PagoId"].Value.ToString();
            txtMonto.Text = row.Cells["Monto"].Value.ToString();
            cbEstado.Text = row.Cells["Estado"].Value.ToString();

            // Cargar valores en combo seleccionados (si no están ya seleccionados)
            string nombreEstudiante = row.Cells["Estudiante"].Value.ToString();
            cbMatricula.SelectedIndex = cbMatricula.FindStringExact(nombreEstudiante);

            string nombreMedio = row.Cells["MedioPago"].Value.ToString();
            cbMedioPago.SelectedIndex = cbMedioPago.FindStringExact(nombreMedio);

            lblArchivo.Text = Path.GetFileName(row.Cells["ComprobanteUrl"].Value?.ToString() ?? "");
        }

        private void FormPago_Load(object sender, EventArgs e)
        {

        }
    }
}
