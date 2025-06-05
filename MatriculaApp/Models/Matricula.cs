using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MatriculaApp.Models
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }

        public int PeriodoId { get; set; }
        public virtual Periodo Periodo { get; set; }

        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; } // Activo, Retirado, etc.

        public virtual ICollection<DetalleMatricula> Detalles { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
