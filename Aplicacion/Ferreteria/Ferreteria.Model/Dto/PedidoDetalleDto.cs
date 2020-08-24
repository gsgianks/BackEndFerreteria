using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Model
{
    public class PedidoDetalleDto
    {
        public Int64 id { get; set; }
        public Int32 Id_Pedido { get; set; }
        public Int32 Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public decimal Precio_Venta_Producto { get; set; }
        public Int16 Cantidad { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }
        public String Estado { get; set; }
    }
}
