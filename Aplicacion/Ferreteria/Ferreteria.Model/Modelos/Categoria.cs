using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Model
{
    public class Categoria
    {
        public Int16 Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }
    }
}
