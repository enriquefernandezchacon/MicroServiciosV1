using System;
using System.Collections.Generic;

namespace MicroServiciosV1.Ventas.Models
{
    public class Venta
    {
        public string Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public string ClienteId { get; set; }
        public double Total { get; set; }

        public List<ElementoVenta> Elementos { get; set; }
    }
}
