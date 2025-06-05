using System.Collections.Generic;

namespace MatriculaApp.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int Ciclo { get; set; }

        public int CarreraId { get; set; }
        public virtual Carrera Carrera { get; set; }

        public virtual ICollection<DetalleMatricula> DetallesMatricula { get; set; }
        public virtual ICollection<HistorialAcademico> Historiales { get; set; }
    }
}
