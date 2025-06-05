using System.Collections.Generic;

namespace MatriculaApp.Models
{
    public class Apoderado
    {
        public int ApoderadoId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
