using System;
using System.Linq;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormPeriodo : Form
    {
        private readonly AppDbContext _context = new AppDbContext();

        public FormPeriodo()
        {
            InitializeComponent();
            CargarPeriodos();
        }

        private void CargarPeriodos()
        {
            dgvPeriodos.DataSource = _context.Periodos
                .Select(p => new
                {
                    p.PeriodoId,
                    p.Anio,
                    p.Ciclo
                })
                .ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtAnio.Text = "";
            cbCiclo.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAnio.Text, out int anio) || cbCiclo.SelectedIndex == -1)
            {
                MessageBox.Show("Completa todos los campos correctamente.");
                return;
            }

            var periodo = new Periodo
            {
                Anio = anio,
                Ciclo = cbCiclo.Text
            };

            _context.Periodos.Add(periodo);
            _context.SaveChanges();

            CargarPeriodos();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var periodo = _context.Periodos.Find(id);
            if (periodo != null)
            {
                if (!int.TryParse(txtAnio.Text, out int anio)) return;

                periodo.Anio = anio;
                periodo.Ciclo = cbCiclo.Text;

                _context.SaveChanges();
                CargarPeriodos();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var periodo = _context.Periodos.Find(id);
            if (periodo != null)
            {
                _context.Periodos.Remove(periodo);
                _context.SaveChanges();
                CargarPeriodos();
                LimpiarCampos();
            }
        }

        private void dgvPeriodos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPeriodos.Rows[e.RowIndex];
            txtId.Text = row.Cells["PeriodoId"].Value.ToString();
            txtAnio.Text = row.Cells["Anio"].Value.ToString();
            cbCiclo.Text = row.Cells["Ciclo"].Value.ToString();
        }
    }
}
