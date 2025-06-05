using System.Collections.Generic;

namespace MatriculaApp.Models
{
    public class Carrera
    {
        public int CarreraId { get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; } // en ciclos

        // Relación con Instituto (clave foránea)
        public int InstitutoId { get; set; }
        public virtual Instituto Instituto { get; set; }

        // Relaciones con otras entidades
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
