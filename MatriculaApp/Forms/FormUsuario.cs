using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MatriculaApp.Models;

namespace MatriculaApp.Forms
{
    public partial class FormUsuario : Form
    {
        private readonly AppDbContext _context = new AppDbContext();

        public FormUsuario()
        {
            InitializeComponent();
            CargarUsuarios();
            cbRol.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = _context.Usuarios
                .Select(u => new
                {
                    u.UsuarioId,
                    u.NombreUsuario,
                    u.Rol
                })
                .ToList();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombreUsuario.Text = "";
            txtContraseña.Text = "";
            cbRol.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            var usuario = new Usuario
            {
                NombreUsuario = txtNombreUsuario.Text.Trim(),
                ContraseñaHash = HashPassword(txtContraseña.Text),
                Rol = cbRol.Text
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            CargarUsuarios();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                usuario.NombreUsuario = txtNombreUsuario.Text.Trim();
                if (!string.IsNullOrEmpty(txtContraseña.Text))
                {
                    usuario.ContraseñaHash = HashPassword(txtContraseña.Text);
                }
                usuario.Rol = cbRol.Text;

                _context.SaveChanges();
                CargarUsuarios();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                CargarUsuarios();
                LimpiarCampos();
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUsuarios.Rows[e.RowIndex];
            txtId.Text = row.Cells["UsuarioId"].Value.ToString();
            txtNombreUsuario.Text = row.Cells["NombreUsuario"].Value.ToString();
            cbRol.Text = row.Cells["Rol"].Value.ToString();
            txtContraseña.Text = ""; // No mostrar hash ni contraseña actual
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
