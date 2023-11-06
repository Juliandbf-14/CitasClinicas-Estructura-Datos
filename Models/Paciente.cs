namespace CitasClinicas
{
    public class Paciente
    {
        public int? Cedula { get; set; }

        public string? NombreCompleto { get; set; } = string.Empty;

        public int? Edad { get; set; }

        public string? Genero { get; set; } = string.Empty;

        public string? Tipo { get; set; } = string.Empty;
        
        public Medico MedicoAsignado { get; set; } = new Medico();
        
        public DateTime? FechaHoraCita { get; set; }

        public string? OficinaCita { get; set; } = string.Empty;

        public string? EstadoCita { get; set; } = "asignada";

        public bool ValidarObjPaciente(Paciente objPaciente)
        {   
            bool validarCedula = objPaciente.Cedula != 0 && objPaciente.Cedula != null;
            bool validarNombre = !string.IsNullOrEmpty(objPaciente.NombreCompleto);
            bool validarEdad = objPaciente.Edad != 0 && objPaciente.Edad != null;
            bool validarGenero = !string.IsNullOrEmpty(objPaciente.Genero) && (objPaciente.Genero == "M" || objPaciente.Genero == "F");
            bool validarTipo = !string.IsNullOrEmpty(objPaciente.Tipo) && (objPaciente.Tipo == "A" || objPaciente.Tipo == "P");
            bool validarMedico = objPaciente.MedicoAsignado != null;
            bool validarFecha = objPaciente.FechaHoraCita.HasValue;

            if (validarCedula && validarNombre && validarEdad && validarGenero && validarTipo && validarMedico && validarFecha){
                return true;
            } else{
                return false;
            }
        }
    }
}