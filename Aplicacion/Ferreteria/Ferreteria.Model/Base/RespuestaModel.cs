using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Model
{
    public class RespuestaModel<T>: ResultadoBaseModel
    {
        public RespuestaModel()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }
    }
}
