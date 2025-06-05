using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormEstudiante : Form
    {
        private AppDbContext _context = new AppDbContext();

        public FormEstudiante()
        {
            InitializeComponent();
            CargarEstudiantes();
            CargarCombos();
        }

        private void CargarCombos()
        {
            cbCarrera.DataSource = _context.Carreras.ToList();
            cbCarrera.DisplayMember = "Nombre";
            cbCarrera.ValueMember = "CarreraId";
            cbCarrera.SelectedIndex = -1;

            cbApoderado.DataSource = _context.Apoderados.ToList();
            cbApoderado.DisplayMember = "Nombre";
            cbApoderado.ValueMember = "ApoderadoId";
            cbApoderado.SelectedIndex = -1;
        }

        private void CargarEstudiantes()
        {
            dgvEstudiantes.DataSource = _context.Estudiantes
                .Select(e => new
                {
                    e.EstudianteId,
                    e.Nombre,
                    e.Apellido,
                    e.DNI,
                    Carrera = e.Carrera.Nombre,
                    Apoderado = e.Apoderado != null ? e.Apoderado.Nombre : ""
                }).ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            cbCarrera.SelectedIndex = -1;
            cbApoderado.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var estudiante = new Estudiante
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                CarreraId = (int)cbCarrera.SelectedValue,
                ApoderadoId = cbApoderado.SelectedIndex != -1 ? (int?)cbApoderado.SelectedValue : null
            };

            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();
            CargarEstudiantes();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante != null)
            {
                estudiante.Nombre = txtNombre.Text;
                estudiante.Apellido = txtApellido.Text;
                estudiante.DNI = txtDNI.Text;
                estudiante.CarreraId = (int)cbCarrera.SelectedValue;
                estudiante.ApoderadoId = cbApoderado.SelectedIndex != -1 ? (int?)cbApoderado.SelectedValue : null;

                _context.SaveChanges();
                CargarEstudiantes();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
                CargarEstudiantes();
                LimpiarCampos();
            }
        }

        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvEstudiantes.Rows[e.RowIndex];
                txtId.Text = fila.Cells["EstudianteId"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                cbCarrera.Text = fila.Cells["Carrera"].Value.ToString();
                cbApoderado.Text = fila.Cells["Apoderado"].Value.ToString();
            }
        }

        private void FormEstudiante_Load(object sender, EventArgs e)
        {

        }
    }
}
