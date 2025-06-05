using System;

namespace MatriculaApp.Models
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int MatriculaId { get; set; }
        public virtual Matricula Matricula { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        public int MedioPagoId { get; set; }
        public virtual MedioPago MedioPago { get; set; }

        public string Estado { get; set; } // Pagado, Pendiente, Anulado
        public string ComprobanteUrl { get; set; }
    }
}
