using System;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormInstituto : Form
    {
        private readonly AppDbContext _context = new AppDbContext();

        public FormInstituto()
        {
            InitializeComponent();
            CargarInstitutos();
        }

        private void CargarInstitutos()
        {
            dgvInstitutos.DataSource = _context.Institutos
                .Select(i => new { i.InstitutoId, i.Nombre, i.Direccion })
                .ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtDireccion.Text == "")
                return;

            var instituto = new Instituto
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text
            };

            _context.Institutos.Add(instituto);
            _context.SaveChanges();
            CargarInstitutos();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var instituto = _context.Institutos.Find(id);
            if (instituto != null)
            {
                instituto.Nombre = txtNombre.Text;
                instituto.Direccion = txtDireccion.Text;

                _context.SaveChanges();
                CargarInstitutos();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var instituto = _context.Institutos.Find(id);
            if (instituto != null)
            {
                _context.Institutos.Remove(instituto);
                _context.SaveChanges();
                CargarInstitutos();
                LimpiarCampos();
            }
        }

        private void dgvInstitutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvInstitutos.Rows[e.RowIndex];
                txtId.Text = row.Cells["InstitutoId"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
            }
        }

        private void FormInstituto_Load(object sender, EventArgs e)
        {

        }
    }
}
