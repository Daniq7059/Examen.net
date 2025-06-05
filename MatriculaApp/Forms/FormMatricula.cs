using System;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormMatricula : Form
    {
        private readonly AppDbContext _context = new AppDbContext();

        public FormMatricula()
        {
            InitializeComponent();
            CargarEstudiantes();
            CargarPeriodos();
            CargarMatriculas();
        }

        private void CargarEstudiantes()
        {
            cbEstudiante.DataSource = _context.Estudiantes.ToList();
            cbEstudiante.DisplayMember = "Nombre";
            cbEstudiante.ValueMember = "EstudianteId";
            cbEstudiante.SelectedIndex = -1;
        }

        private void CargarPeriodos()
        {
            cbPeriodo.DataSource = _context.Periodos.ToList();
            cbPeriodo.DisplayMember = "Ciclo";
            cbPeriodo.ValueMember = "PeriodoId";
            cbPeriodo.SelectedIndex = -1;
        }

        private void CargarMatriculas()
        {
            dgvMatriculas.DataSource = _context.Matriculas
                .Select(m => new
                {
                    m.MatriculaId,
                    Estudiante = m.Estudiante.Nombre,
                    Periodo = m.Periodo.Ciclo,
                    Fecha = m.FechaRegistro
                }).ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            cbEstudiante.SelectedIndex = -1;
            cbPeriodo.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbEstudiante.SelectedIndex == -1 || cbPeriodo.SelectedIndex == -1)
                return;

            var matricula = new Matricula
            {
                EstudianteId = (int)cbEstudiante.SelectedValue,
                PeriodoId = (int)cbPeriodo.SelectedValue,
                FechaRegistro = DateTime.Now
            };

            _context.Matriculas.Add(matricula);
            _context.SaveChanges();

            CargarMatriculas();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var matricula = _context.Matriculas.Find(id);
            if (matricula != null)
            {
                _context.Matriculas.Remove(matricula);
                _context.SaveChanges();
                CargarMatriculas();
                LimpiarCampos();
            }
        }

        private void dgvMatriculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMatriculas.Rows[e.RowIndex];
                txtId.Text = row.Cells["MatriculaId"].Value.ToString();
                cbEstudiante.Text = row.Cells["Estudiante"].Value.ToString();
                cbPeriodo.Text = row.Cells["Periodo"].Value.ToString();
            }
        }

        private void FormMatricula_Load(object sender, EventArgs e)
        {

        }
    }
}
