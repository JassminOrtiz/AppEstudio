using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPruebaV1.DTOs
{
    public class VentaDTO
    {
        public string Cliente { get; set; }
        public string NumeroVenta { get; set; }
        public decimal Total { get; set; }
        public decimal PagoCon { get; set; }
        public decimal Cambio { get; set; }
        public string FechaRegistro { get; set; }
        public List<DetalleVentaDTO> DetalleVenta { get; set; } = new List<DetalleVentaDTO>();
    }
}
