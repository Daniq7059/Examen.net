using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormCarrera : Form
    {
        private AppDbContext _context = new AppDbContext();

        public FormCarrera()
        {
            InitializeComponent();
            this.Load += FormCarrera_Load;
        }

        private void FormCarrera_Load(object sender, EventArgs e)
        {
            cbInstituto.DataSource = _context.Institutos.ToList();
            cbInstituto.DisplayMember = "Nombre";
            cbInstituto.ValueMember = "InstitutoId";
            cbInstituto.SelectedIndex = -1;

            CargarCarreras();
        }

        private void CargarCarreras()
        {
            dgvCarreras.DataSource = _context.Carreras
                .Select(c => new
                {
                    c.CarreraId,
                    NombreCarrera = c.Nombre,
                    c.Duracion,
                    NombreInstituto = c.Instituto.Nombre
                })
                .ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            nudDuracion.Value = 1;
            cbInstituto.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cbInstituto.SelectedIndex == -1) return;

            var carrera = new Carrera
            {
                Nombre = txtNombre.Text,
                Duracion = (int)nudDuracion.Value,
                InstitutoId = (int)cbInstituto.SelectedValue
            };

            _context.Carreras.Add(carrera);
            _context.SaveChanges();

            CargarCarreras();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var carrera = _context.Carreras.Find(id);
            if (carrera != null)
            {
                carrera.Nombre = txtNombre.Text;
                carrera.Duracion = (int)nudDuracion.Value;
                carrera.InstitutoId = (int)cbInstituto.SelectedValue;

                _context.SaveChanges();
                CargarCarreras();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var carrera = _context.Carreras.Find(id);
            if (carrera != null)
            {
                _context.Carreras.Remove(carrera);
                _context.SaveChanges();
                CargarCarreras();
                LimpiarCampos();
            }
        }

        private void dgvCarreras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvCarreras.Rows[e.RowIndex];
                txtId.Text = row.Cells["CarreraId"].Value.ToString();
                txtNombre.Text = row.Cells["NombreCarrera"].Value.ToString();
                nudDuracion.Value = Convert.ToDecimal(row.Cells["Duracion"].Value);
                cbInstituto.Text = row.Cells["NombreInstituto"].Value.ToString();
            }
        }

        private void FormCarrera_Load_1(object sender, EventArgs e)
        {

        }
    }
}
