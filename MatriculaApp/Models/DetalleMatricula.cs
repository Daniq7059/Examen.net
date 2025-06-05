using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MatriculaApp.Models
{
    public class DetalleMatricula
    {
        public int DetalleMatriculaId { get; set; }

        public int MatriculaId { get; set; }
        public virtual Matricula Matricula { get; set; }

        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        // ✅ AGREGA ESTOS CAMPOS NUEVOS:
        public decimal Nota { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; } // Aprobado, Desaprobado, Retirado, etc.
    }
}
