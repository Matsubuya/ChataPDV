using System;

namespace ChataPDV.BO
{
    public class Producto
    {
        public int? ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? InsertUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
    }
}
