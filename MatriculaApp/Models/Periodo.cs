using System;
using System.Collections.Generic;

namespace MatriculaApp.Models
{
    public class Periodo
    {
        public int PeriodoId { get; set; }
        public int Anio { get; set; }
        public string Ciclo { get; set; } // Ej: "I", "II"

        // ✅ Agrega esta propiedad
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
