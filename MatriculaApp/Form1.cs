using System;
using System.Windows.Forms;
using MatriculaApp.Forms;

namespace MatriculaApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void btnEstudiantes_Click(object sender, EventArgs e) => new FormEstudiante().ShowDialog();
        private void btnCursos_Click(object sender, EventArgs e) => new FormCurso().ShowDialog();
        private void btnMatriculas_Click(object sender, EventArgs e) => new FormMatricula().ShowDialog();
        private void btnPagos_Click(object sender, EventArgs e) => new FormPago().ShowDialog();
        private void btnUsuarios_Click(object sender, EventArgs e) => new FormUsuario().ShowDialog();
        private void btnMediosPago_Click(object sender, EventArgs e) => new FormMedioPago().ShowDialog();
        private void btnApoderados_Click(object sender, EventArgs e) => new FormApoderado().ShowDialog();
        private void btnCarreras_Click(object sender, EventArgs e) => new FormCarrera().ShowDialog();
        private void btnInstitutos_Click(object sender, EventArgs e) => new FormInstituto().ShowDialog();
        private void btnPeriodos_Click(object sender, EventArgs e) => new FormPeriodo().ShowDialog();
        private void btnHistorial_Click(object sender, EventArgs e) => new FormHistorialAcademico().ShowDialog();
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void btnDetalleMatricula_Click(object sender, EventArgs e)
        {
            FormDetalleMatricula frm = new FormDetalleMatricula();
            frm.ShowDialog();
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
