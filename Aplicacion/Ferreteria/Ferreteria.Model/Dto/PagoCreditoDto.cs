using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Model
{
    public class PagoCreditoDto
    {
        public Int32 Id { get; set; }
        public decimal Monto { get; set; }
        public decimal Abono { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public String Estado { get; set; }
    }
}
