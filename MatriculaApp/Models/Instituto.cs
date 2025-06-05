using System.Collections.Generic;

namespace MatriculaApp.Models
{
    public class Instituto
    {
        public int InstitutoId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
