using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Model
{
    public class Pedido
    {
        public Int32 Id { get; set; }
        public Int16 Id_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Direccion { get; set; }
        public String Estado { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }
    }
}
