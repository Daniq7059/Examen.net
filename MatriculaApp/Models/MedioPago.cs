using System.Collections.Generic;

namespace MatriculaApp.Models
{
    public class MedioPago
    {
        public int MedioPagoId { get; set; }
        public string Nombre { get; set; }
        // ✅ AGREGA ESTA PROPIEDAD FALTANTE
        public string Descripcion { get; set; }


        // ✅ Agrega esta propiedad
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
