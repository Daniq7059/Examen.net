using System;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormCurso : Form
    {
        private AppDbContext _context = new AppDbContext();

        public FormCurso()
        {
            InitializeComponent();
            this.Load += FormCurso_Load;
        }

        private void FormCurso_Load(object sender, EventArgs e)
        {
            cbCarrera.DataSource = _context.Carreras.ToList();
            cbCarrera.DisplayMember = "Nombre";
            cbCarrera.ValueMember = "CarreraId";
            cbCarrera.SelectedIndex = -1;

            CargarCursos();
        }

        private void CargarCursos()
        {
            dgvCursos.DataSource = _context.Cursos
                .Select(c => new
                {
                    c.CursoId,
                    NombreCurso = c.Nombre,
                    c.Creditos,
                    c.Ciclo,
                    NombreCarrera = c.Carrera.Nombre
                })
                .ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            nudCreditos.Value = 1;
            nudCiclo.Value = 1;
            cbCarrera.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cbCarrera.SelectedIndex == -1) return;

            var curso = new Curso
            {
                Nombre = txtNombre.Text,
                Creditos = (int)nudCreditos.Value,
                Ciclo = (int)nudCiclo.Value,
                CarreraId = (int)cbCarrera.SelectedValue
            };

            _context.Cursos.Add(curso);
            _context.SaveChanges();
            CargarCursos();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var curso = _context.Cursos.Find(id);
            if (curso != null)
            {
                curso.Nombre = txtNombre.Text;
                curso.Creditos = (int)nudCreditos.Value;
                curso.Ciclo = (int)nudCiclo.Value;
                curso.CarreraId = (int)cbCarrera.SelectedValue;

                _context.SaveChanges();
                CargarCursos();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var curso = _context.Cursos.Find(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                _context.SaveChanges();
                CargarCursos();
                LimpiarCampos();
            }
        }

        private void dgvCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvCursos.Rows[e.RowIndex];
                txtId.Text = row.Cells["CursoId"].Value.ToString();
                txtNombre.Text = row.Cells["NombreCurso"].Value.ToString();
                nudCreditos.Value = Convert.ToDecimal(row.Cells["Creditos"].Value);
                nudCiclo.Value = Convert.ToDecimal(row.Cells["Ciclo"].Value);
                cbCarrera.Text = row.Cells["NombreCarrera"].Value.ToString();
            }
        }

        private void FormCurso_Load_1(object sender, EventArgs e)
        {

        }
    }
}
