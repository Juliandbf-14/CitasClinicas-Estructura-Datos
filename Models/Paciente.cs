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
        
        public DateTime? FechaHoraCita { get; set; }

        public string? OficinaCita { get; set; } = string.Empty;

        public string? EstadoCita { get; set; } = "asignada";

        public bool ValidarObjPaciente(Paciente objPaciente)
        {
            if (!string.IsNullOrEmpty(objPaciente.Cedula) && !string.IsNullOrEmpty(objPaciente.NombreCompleto) && !string.IsNullOrEmpty(objPaciente.Edad) && !string.IsNullOrEmpty(objPaciente.Genero) && !string.IsNullOrEmpty(objPaciente.Tipo) && objPaciente.MedicoAsignado != null && objPaciente.FechaHoraCita.HasValue)
            {
                return true;
            } else{
                return false;
            }
        }
    }
}