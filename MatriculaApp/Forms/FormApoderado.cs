using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormApoderado : Form
    {
        private AppDbContext _context = new AppDbContext();

        public FormApoderado()
        {
            InitializeComponent();
            CargarApoderados();
        }

        private void CargarApoderados()
        {
            dgvApoderados.DataSource = _context.Apoderados
                .Select(a => new { a.ApoderadoId, a.Nombre, a.Telefono, a.Direccion })
                .ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") return;

            var apoderado = new Apoderado
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text
            };

            _context.Apoderados.Add(apoderado);
            _context.SaveChanges();

            CargarApoderados();
            LimpiarCampos();
        }

        private void dgvApoderados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvApoderados.Rows[e.RowIndex];
                txtId.Text = row.Cells["ApoderadoId"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var apoderado = _context.Apoderados.Find(id);
            if (apoderado != null)
            {
                apoderado.Nombre = txtNombre.Text;
                apoderado.Telefono = txtTelefono.Text;
                apoderado.Direccion = txtDireccion.Text;

                _context.SaveChanges();
                CargarApoderados();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var apoderado = _context.Apoderados.Find(id);
            if (apoderado != null)
            {
                _context.Apoderados.Remove(apoderado);
                _context.SaveChanges();
                CargarApoderados();
                LimpiarCampos();
            }
        }

        private void FormApoderado_Load(object sender, EventArgs e)
        {

        }
    }
}
