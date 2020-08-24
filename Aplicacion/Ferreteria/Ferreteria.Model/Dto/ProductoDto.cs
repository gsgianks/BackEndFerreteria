using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Model
{
    public class ProductoDto
    {
        public Int32 Id { get; set; }
        public Int16 Id_Proveedor { get; set; }
        public byte Id_Categoria { get; set; }
        public string Nombre { get; set; }
        public decimal Precio_Costo { get; set; }
        public decimal Precio_Venta { get; set; }
        public decimal Utilidad { get; set; }
        public decimal Impuesto { get; set; }
        public Int16 Stock { get; set; }
        public decimal Descuento { get; set; }
        public string Codigo_Barra { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }
        public String Estado { get; set; }
    }
}
