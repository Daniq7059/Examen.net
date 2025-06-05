using System.Collections.Generic;

namespace MatriculaApp.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

        public int CarreraId { get; set; }
        public virtual Carrera Carrera { get; set; }

        public int? ApoderadoId { get; set; }
        public virtual Apoderado Apoderado { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<HistorialAcademico> Historiales { get; set; }
    }
}
