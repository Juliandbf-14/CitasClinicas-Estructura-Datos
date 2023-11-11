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
                paciente.Cedula = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nombre completo del paciente: ");
                paciente.NombreCompleto = Console.ReadLine();

                Console.WriteLine("Ingrese la edad del paciente: ");
                paciente.Edad = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el género del paciente( Masculino(M) / Femenino(F) ): ");
                paciente.Genero = Console.ReadLine();

                Console.WriteLine("Ingrese el tipo de paciente( Afiliado(A) / Prepagado(P) ): ");
                paciente.Tipo = Console.ReadLine();

                paciente.MedicoAsignado = medico;
                paciente.OficinaCita = medico.Oficina;

                Console.WriteLine("Ingrese la fecha de la cita del paciente en el siguiente formato( día/mes/año ): ");
                paciente.FechaHoraCita = DateTime.Parse(Console.ReadLine());

                return new Paciente
                {
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
                Console.WriteLine("\nIngreso un valor invalido al momento de crear la cita." + e.Message);
                return paciente;
            }
        }

        public Paciente ModificarCitaPaciente(List<Paciente> pacientes)
        {
            try
            {
                Paciente? paciente = null;
                Console.WriteLine("Ingresa la cédula del paciente:");
                int? cedulaPaciente = int.Parse(Console.ReadLine());

                if (cedulaPaciente != 0 && cedulaPaciente != null)
                {
                    paciente = pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                    if (paciente != null)
                    {
                        Console.WriteLine("\nIngrese la nueva fecha de la cita del paciente en el siguiente formato( día/mes/año ):");
                        DateTime nuevaFecha = DateTime.Parse(Console.ReadLine());
                        paciente.FechaHoraCita = nuevaFecha;
                    }
                    else
                    {
                        Console.WriteLine("\nNo existe un paciente que coincida con esa información.");
                    }
                }
                return paciente;
            }
            catch (Exception)
            {
                Console.WriteLine("\nHubo un error al procesar la solicitud, vuelve a intentarlo..");
                return null;
            }
        }

        public void EliminarCitaPaciente(List<Paciente> pacientes)
        {
            try
            {
                Paciente? paciente = null;
                Console.WriteLine("Ingresa la cédula del paciente:");
                int? cedulaPaciente = int.Parse(Console.ReadLine());

                if (cedulaPaciente != 0 && cedulaPaciente != null)
                {
                    paciente = pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                    if (paciente != null)
                    {
                        if (pacientes.Remove(paciente))
                        {
                            Console.WriteLine("\nLa cita del paciente fue cancelada con éxito!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nIngresa un valor válido para la cédula");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nHubo un error al procesar la solicitud, vuelve a intentarlo..");
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

        public void EstadoCitaPaciente(Medico medico)
        {
            try
            {
                int? cedulaPaciente;
                do
                {
                    Console.WriteLine("Ingrese la cédula del paciente:");
                    cedulaPaciente = int.Parse(Console.ReadLine());

                    if (cedulaPaciente != 0 && cedulaPaciente != null)
                    {
                        Paciente? pacienteEstado = medico.Pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                        if (pacienteEstado != null)
                        {
                            Console.WriteLine($"\nEl estado de la cita del paciente {pacienteEstado.NombreCompleto} es: {pacienteEstado.EstadoCita}");
                        }
                        else
                        {
                            Console.WriteLine($"La cédula {cedulaPaciente} no coincide con algún paciente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo puedes dejar el campo de la cédula vacío.");
                        Console.WriteLine("\nInténtalo de nuevo...");
                    }
                } while (cedulaPaciente == 0 || cedulaPaciente == null);
            }
            catch (Exception)
            {
                Console.WriteLine("\nHubo un error al procesar la solicitud, vuelve a intentarlo..");
            }
        }

        public void AtenderCitaPaciente(Medico medico)
        {
            try
            {
                int? cedulaPaciente;
                do
                {
                    Console.WriteLine("Ingrese la cédula del paciente:");
                    cedulaPaciente = int.Parse(Console.ReadLine());

                    if (cedulaPaciente != 0 && cedulaPaciente != null)
                    {
                        Paciente? paciente = medico.Pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                        if (paciente != null)
                        {

                            // Validar que sea el primero en la lista
                            bool swPaciente = medico.Pacientes[0] == paciente;
                            if (swPaciente)
                            {
                                medico.Pacientes[0].EstadoCita = "atendida";
                                paciente = medico.Pacientes[0];
                                // medico.Pacientes = medico.Pacientes.Where(x => x.EstadoCita == "asignada").ToList();
                                Console.WriteLine($"\nLa cita del paciente {paciente.NombreCompleto} paso al estado: {paciente.EstadoCita}, por ende se eliminará de la lista de espera de pacientes");
                                medico.Pacientes.Remove(medico.Pacientes[0]);
                            }
                            else
                            {
                                Console.WriteLine($"\nEl paciente con nombre {paciente.NombreCompleto} esta en el turno {medico.Pacientes.IndexOf(paciente) + 1}, por ende no puede ser atendido en estos momentos");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"La cédula {cedulaPaciente} no coincide con algún paciente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo puedes dejar el campo de la cédula vacío.");
                        Console.WriteLine("\nInténtalo de nuevo...");
                    }
                } while (cedulaPaciente == 0 || cedulaPaciente == null);
            }
            catch (System.Exception)
            {
                Console.WriteLine("\nHubo un error al procesar la solicitud, vuelve a intentarlo..");
            }
            Console.WriteLine("SOY UN ERROR");
        }
    }
}