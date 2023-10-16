using System.Diagnostics;

namespace CitasClinicas.Operaciones
{
    public class OperacionesPaciente
    {
        public Paciente CrearCitaPaciente(Medico medico)
        {   
            Paciente paciente = new Paciente();
            try
            {
                Console.WriteLine("Ingrese la cédula del paciente: ");
                paciente.Cedula = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre completo del paciente: ");
                paciente.NombreCompleto = Console.ReadLine();

                Console.WriteLine("Ingrese la edad del paciente: ");
                paciente.Edad = Console.ReadLine();

                Console.WriteLine("Ingrese el género del paciente( Masculino(M) / Femenino(F) ): ");
                paciente.Genero = Console.ReadLine();

                Console.WriteLine("Ingrese el tipo de paciente( Afiliado(A) / Prepagado(P) ): ");
                paciente.Tipo = Console.ReadLine();

                paciente.MedicoAsignado = medico;
                paciente.OficinaCita = medico.Oficina;

                Console.WriteLine("Ingrese la fecha de la cita del paciente en el siguiente formato( día/mes/año ): ");
                paciente.FechaHoraCita = DateTime.Parse(Console.ReadLine());

                return new Paciente{
                    Cedula = paciente.Cedula,
                    NombreCompleto = paciente.NombreCompleto,
                    Edad = paciente.Edad,
                    Genero = paciente.Genero,
                    Tipo = paciente.Tipo,
                    FechaHoraCita = paciente.FechaHoraCita
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine("Ocurrió un error al ingresar al paciente: " + e.Message);
                return paciente;
            }
        }

        public Paciente ModificarCitaPaciente(List<Paciente> pacientes)
        {
            Paciente? paciente = null;
            Console.WriteLine("Ingresa la cédula del paciente:");
            string cedulaPaciente = Console.ReadLine();

            if (!string.IsNullOrEmpty(cedulaPaciente))
            {
                paciente = pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                if (paciente != null)
                {
                    Console.WriteLine("Ingrese la nueva fecha de la cita del paciente en el siguiente formato( día/mes/año ):");
                    DateTime nuevaFecha = DateTime.Parse(Console.ReadLine());
                    paciente.FechaHoraCita = nuevaFecha;
                }
                else
                {
                    Console.WriteLine("No existe un paciente que coincida con esa información.");
                }
            }
            return paciente;
        }

        public void EliminarCitaPaciente(List<Paciente> pacientes)
        {
            Paciente? paciente = null;
            Console.WriteLine("Ingresa la cédula del paciente:");
            string cedulaPaciente = Console.ReadLine();

            if (!string.IsNullOrEmpty(cedulaPaciente))
            {
                paciente = pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                if (paciente != null)
                {
                    PacienteToString(paciente);
                    if (pacientes.Remove(paciente))
                    {
                        Console.WriteLine("La cita del paciente fue cancelada con éxito.");
                    }
                }
            } else {
                Console.WriteLine($"Ingresa un valor válido para la cédula");
            }
        }

        public void PacienteToString(Paciente paciente)
        {
            if (paciente != null)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine($"Los datos del paciente son los siguientes:\n"
                    + "\n"
                    + $"Cédula del paciente: {paciente.Cedula}\n"
                    + $"Nombre Completo del paciente: {paciente.NombreCompleto}\n"
                    + $"Edad del paciente: {paciente.Edad}\n"
                    + $"Género del paciente: {paciente.Genero}\n"
                    + $"Tipo de usuario del paciente: {paciente.Tipo}\n"
                    + $"Médico asignado al paciente: {paciente.MedicoAsignado.NombreCompleto}\n"
                    + $"Fecha y hora de la cita: {paciente.FechaHoraCita}\n"
                    + $"Oficina de la cita: {paciente.MedicoAsignado.Oficina}\n"
                    + $"Estado de la cita: {paciente.FechaHoraCita}\n"
                    + "----------------------------------------------------------------------------"
                );
            }
        }

        public void EstadoCitaPaciente(Medico medico){
            string? cedulaPaciente;
            do
            {
                Console.WriteLine("Ingrese la cédula del paciente:");
                cedulaPaciente = Console.ReadLine();

                if (!string.IsNullOrEmpty(cedulaPaciente))
                {
                    Paciente? pacienteEstado = medico.Pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                    if (pacienteEstado != null){
                        Console.WriteLine($"El estado de la cita del paciente {pacienteEstado.NombreCompleto} es: {pacienteEstado.EstadoCita}");
                    } else {
                        Console.WriteLine($"La cédula {cedulaPaciente} no coincide con algún paciente");
                    }
                } else {
                    Console.WriteLine("No puedes dejar el campo de la cédula vacío.");
                    Console.WriteLine("Inténtalo de nuevo...");
                }
            } while (string.IsNullOrEmpty(cedulaPaciente));
        }
    }
}