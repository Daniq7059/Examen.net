using System;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormHistorialAcademico : Form
    {
        private readonly AppDbContext _context = new AppDbContext();

        public FormHistorialAcademico()
        {
            InitializeComponent();
            CargarEstudiantes();
        }

        private void FormHistorialAcademico_Load(object sender, EventArgs e)
        {
            // Ya se carga desde el constructor
        }

        private void CargarEstudiantes()
        {
            var estudiantes = _context.Estudiantes
                .Select(e => new
                {
                    e.EstudianteId,
                    NombreCompleto = e.Nombre + " " + e.Apellido
                })
                .ToList();

            cbEstudiante.DataSource = estudiantes;
            cbEstudiante.DisplayMember = "NombreCompleto";
            cbEstudiante.ValueMember = "EstudianteId";
            cbEstudiante.SelectedIndex = -1;
        }


        private void cbEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstudiante.SelectedIndex == -1 || cbEstudiante.SelectedValue == null)
                return;

            if (cbEstudiante.SelectedValue is int estudianteId)
            {
                var historial = _context.DetallesMatricula
                    .Where(dm => dm.Matricula.EstudianteId == estudianteId)
                    .Select(dm => new
                    {
                        Curso = dm.Curso.Nombre,
                        Periodo = dm.Matricula.Periodo.Anio + " - " + dm.Matricula.Periodo.Ciclo,
                        Nota = dm.Nota,
                        Estado = dm.Estado
                    })
                    .ToList();

                dgvHistorial.DataSource = historial;
            }
        }
    }
}
