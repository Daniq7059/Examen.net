namespace MatriculaApp.Models
{
    public class HistorialAcademico
    {
        public int HistorialAcademicoId { get; set; }

        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }

        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        public decimal NotaFinal { get; set; }
        public string Estado { get; set; } // Aprobado, Desaprobado, Retirado
    }
}
