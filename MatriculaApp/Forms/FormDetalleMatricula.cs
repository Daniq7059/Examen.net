using System;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MatriculaApp.Forms
{
    public partial class FormDetalleMatricula : Form
    {
        private AppDbContext _context = new AppDbContext();

        public FormDetalleMatricula()
        {
            InitializeComponent();
            this.Load += FormDetalleMatricula_Load;
        }

     

        private void CargarDetalles()
        {
            dgvDetalles.DataSource = _context.DetallesMatricula
                .Include(d => d.Matricula)
                .Include(d => d.Curso)
                .Select(d => new
                {
                    d.DetalleMatriculaId,
                    Curso = d.Curso.Nombre,
                    MatriculaId = d.MatriculaId
                })
                .ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            cbMatricula.SelectedIndex = -1;
            cbCurso.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbMatricula.SelectedIndex == -1 || cbCurso.SelectedIndex == -1) return;

            int matriculaId = (int)cbMatricula.SelectedValue;
            int cursoId = (int)cbCurso.SelectedValue;

            bool yaExiste = _context.DetallesMatricula.Any(d =>
                d.MatriculaId == matriculaId && d.CursoId == cursoId);

            if (yaExiste)
            {
                MessageBox.Show("Este curso ya está asignado a la matrícula.");
                return;
            }

            var detalle = new DetalleMatricula
            {
                MatriculaId = matriculaId,
                CursoId = cursoId
            };

            _context.DetallesMatricula.Add(detalle);
            _context.SaveChanges();

            CargarDetalles();
            LimpiarCampos();
        }

        private void dgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDetalles.Rows[e.RowIndex];
                txtId.Text = row.Cells["DetalleMatriculaId"].Value.ToString();
                cbCurso.Text = row.Cells["Curso"].Value.ToString();
                cbMatricula.SelectedValue = row.Cells["MatriculaId"].Value;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var detalle = _context.DetallesMatricula.Find(id);
            if (detalle != null)
            {
                _context.DetallesMatricula.Remove(detalle);
                _context.SaveChanges();
                CargarDetalles();
                LimpiarCampos();
            }
        }

        private void FormDetalleMatricula_Load(object sender, EventArgs e)
        {
            var matriculas = _context.Matriculas
                .Include(m => m.Estudiante)
                .Include(m => m.Periodo)
                .ToList() // Se trae todo a memoria primero
                .Select(m => new
                {
                    m.MatriculaId,
                    Display = $"ID:{m.MatriculaId} - {m.Estudiante.Nombre} {m.Estudiante.Apellido} - {m.Periodo.Anio}-{m.Periodo.Ciclo}"
                })
                .ToList();

            cbMatricula.DataSource = matriculas;
            cbMatricula.DisplayMember = "Display";
            cbMatricula.ValueMember = "MatriculaId";

            cbCurso.DataSource = _context.Cursos.ToList();
            cbCurso.DisplayMember = "Nombre";
            cbCurso.ValueMember = "CursoId";

            cbMatricula.SelectedIndex = -1;
            cbCurso.SelectedIndex = -1;

            CargarDetalles();
        }

    }
}
