namespace MatriculaApp.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string ContraseñaHash { get; set; }
        public string Rol { get; set; } // Administrador, Secretaria, Docente
    }
}
