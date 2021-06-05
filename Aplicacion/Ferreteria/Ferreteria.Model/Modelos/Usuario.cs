using System;

namespace Ferreteria.Model
{
    public class Usuario
    {
        public Int16 Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Correo_Electronico { get; set; }
        public string Direccion { get; set; }
        //public string Rol { get; set; }
        public string Contrasena { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }
        public String Estado { get; set; }
    }
}
