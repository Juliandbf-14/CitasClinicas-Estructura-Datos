using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClinicas
{
    public class Oficina
    {
        public string? Numero { get; set; } = string.Empty;

        public Medico Medico { get; set; } = new Medico();
    }
}