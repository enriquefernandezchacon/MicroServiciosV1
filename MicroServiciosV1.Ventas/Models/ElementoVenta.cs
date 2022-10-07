namespace MicroServiciosV1.Ventas.Models
{
    public class ElementoVenta
    {
        public string VentaId { get; set; }
        public int Id { get; set; }
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
