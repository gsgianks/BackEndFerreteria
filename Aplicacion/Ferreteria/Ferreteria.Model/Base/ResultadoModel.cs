using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Model
{
    public class ResultadoModel<T, J> : ResultadoBaseModel
    {
        public T Item { get; set; }
        public J ItemOptional { get; set; }
    }
}
