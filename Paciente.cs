using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClinicas
{
    public class Paciente
    {
        public string? Cedula { get; set; } = string.Empty;

        public string? NombreCompleto { get; set; } = string.Empty;

        public string? Edad { get; set; } = string.Empty;

        public string? Genero { get; set; } = string.Empty;

        public string? Tipo { get; set; } = string.Empty;
        
        public Medico MedicoAsignado { get; set; } = new Medico();
        
        // Se puede modificar
        public DateTime? FechaHoraCita { get; set; }

        public string? OficinaCita { get; set; } = string.Empty;

        public string? EstadoCita { get; set; } = "asignada";

    }
}