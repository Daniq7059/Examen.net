using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormMedioPago : Form
    {
        private readonly AppDbContext _context = new AppDbContext();

        public FormMedioPago()
        {
            InitializeComponent();
            CargarMediosPago();
        }

        private void FormMedioPago_Load(object sender, EventArgs e)
        {
            ConfigurarPlaceholders(txtNombre, "Nombre del medio de pago");
            ConfigurarPlaceholders(txtDescripcion, "Descripción del medio de pago");
        }

        private void ConfigurarPlaceholders(TextBox textBox, string placeholder)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void CargarMediosPago()
        {
            dgvMediosPago.DataSource = _context.MediosPago
                .Select(m => new { m.MedioPagoId, m.Nombre, m.Descripcion })
                .ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "Nombre del medio de pago";
            txtDescripcion.Text = "Descripción del medio de pago";
            txtNombre.ForeColor = Color.Gray;
            txtDescripcion.ForeColor = Color.Gray;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.ForeColor == Color.Gray)
                return;

            var medio = new MedioPago
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.ForeColor == Color.Gray ? "" : txtDescripcion.Text.Trim()
            };

            _context.MediosPago.Add(medio);
            _context.SaveChanges();

            CargarMediosPago();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var medio = _context.MediosPago.Find(id);
            if (medio != null)
            {
                medio.Nombre = txtNombre.Text.Trim();
                medio.Descripcion = txtDescripcion.ForeColor == Color.Gray ? "" : txtDescripcion.Text.Trim();

                _context.SaveChanges();
                CargarMediosPago();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var medio = _context.MediosPago.Find(id);
            if (medio != null)
            {
                _context.MediosPago.Remove(medio);
                _context.SaveChanges();
                CargarMediosPago();
                LimpiarCampos();
            }
        }

        private void dgvMediosPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMediosPago.Rows[e.RowIndex];
                txtId.Text = row.Cells["MedioPagoId"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtNombre.ForeColor = Color.Black;
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtDescripcion.ForeColor = Color.Black;
            }
        }
    }
}
