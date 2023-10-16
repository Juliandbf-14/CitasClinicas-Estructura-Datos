namespace CitasClinicas
{
    public class Medico
    {
        public string Cedula { get; set; } = string.Empty;

        public string NombreCompleto { get; set;} = string.Empty;

        public string Oficina { get; set; } = string.Empty;

        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
    }
}