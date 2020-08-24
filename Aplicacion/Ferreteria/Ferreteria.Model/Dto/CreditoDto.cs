using System;

namespace Ferreteria.Model
{
    public class CreditoDto
    {
        public Int64 id { get; set; }
        public Int16 Id_Usuario { get; set; }
        public Int32 Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public decimal Precio_Venta_Producto { get; set; }
        public Int16 Cantidad { get; set; }
        public Int32? Id_Pago { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }
        public String Estado { get; set; }
    }
}
