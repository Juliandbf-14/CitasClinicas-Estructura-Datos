using System.Diagnostics;

namespace CitasClinicas
{
    class Program
    {
        static void Main(string[] args)
        {   
            Program program = new Program();
            
            Medico medico = new Medico{
                Cedula = "2738191121",
                NombreCompleto = "Jesus Hernán Gonzalez Rámirez",
                Oficina = "404",
            };
            string respuesta = "0";

            while (respuesta == "0" && respuesta != string.Empty)
            {   
                Console.WriteLine("_____________________________");
                Console.WriteLine("Bienvenido al menú de opciones de la Clínica de las Americas");
                Console.WriteLine("Gestión de Citas");
                Console.WriteLine("1. Crear cita");
                Console.WriteLine("2. Modificar cita");
                Console.WriteLine("3. Cancelar cita");
                Console.WriteLine("_____________________________");
                Console.WriteLine("Manejo de Pacientes");
                Console.WriteLine("4. Ver lista de pacientes");
                Console.WriteLine("5. Estado de la cita del Paciente");
                Console.WriteLine("6. Atender paciente");
                Console.WriteLine("_____________________________");
                Console.WriteLine("0. Repetir Menú");
                Console.WriteLine("9. Salir");
                Console.WriteLine("Selecciona una opción:");
                respuesta = Console.ReadLine();


                if(respuesta == "1"){
                    Console.WriteLine("Sigue con las instrucciones del Sistema para crear la cita.");
                    Paciente paciente = new Paciente();
                    paciente = program.CrearCitaPaciente(paciente, medico);
                    bool registroExitoso = program.ValidarObjPaciente(paciente);

                    if(registroExitoso){
                        Console.WriteLine("El paciente ha sido registrado exitosamente.");
                        medico.Pacientes.Add(paciente);
                    } else {
                        Console.WriteLine("El paciente no pudo ser registrado exitosamente.");
                    }
                    respuesta = "0";
                }

                if (respuesta == "2"){
                    Paciente? pacienteCoincidente = medico.Pacientes.FirstOrDefault(x => x.Cedula == "12333");
                    pacienteCoincidente = program.ModificarCitaPaciente(medico.Pacientes);
                    if(pacienteCoincidente == null){
                        Console.WriteLine("El paciente no pudo ser encontrado, por ende no se puede modificar su cita.");
                    } else {
                        Console.WriteLine($"La fecha del paciente con cédula: {pacienteCoincidente.Cedula} y nombre: {pacienteCoincidente.NombreCompleto} fue modificada con éxito.");
                    }
                    respuesta = "0";
                }
                
                if(respuesta == "3"){
                    program.EliminarCitaPaciente(medico.Pacientes);
                    respuesta = "0";
                }

                if(respuesta == "4"){
                    if(medico.Pacientes.Count > 0){
                        foreach (Paciente itemPaciente in medico.Pacientes)
                        {
                            PacienteToString(itemPaciente);
                        }
                    } else {
                        Console.WriteLine("No hay citas en este momento");
                    }
                    respuesta = "0";
                }

                if(respuesta == "5"){
                    Console.WriteLine("Ingrese la cédula del paciente:");
                    string cedulaPaciente = "";
                    cedulaPaciente = Console.ReadLine();
                    if(!string.IsNullOrEmpty(cedulaPaciente)){
                        Paciente? pacienteEstado = medico.Pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                        if(pacienteEstado != null){
                            Console.WriteLine($"El estado de la cita del paciente {pacienteEstado.NombreCompleto} es: {pacienteEstado.EstadoCita}");
                        } else {
                            Console.WriteLine($"El paciente no existe");
                        }
                    } else {
                        Console.WriteLine($"La cédula {cedulaPaciente} no coincide con algún paciente");
                    }
                    respuesta = "0";
                }

                if(respuesta == "6"){
                    
                }
            }
        }

        public Paciente CrearCitaPaciente(Paciente paciente, Medico medico){
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

                Console.WriteLine("Ingrese el tipo de paciente( Afiliado(F) / Prepagado(P) ): ");
                paciente.Tipo = Console.ReadLine();

                paciente.MedicoAsignado = medico;
                paciente.OficinaCita = medico.Oficina;

                Console.WriteLine("Ingrese la fecha de la cita del paciente en el siguiente formato( día/mes/año ): ");
                paciente.FechaHoraCita = DateTime.Parse(Console.ReadLine());

                return paciente;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Ocurrió un error al ingresar al paciente: " + e.Message);
                return paciente;
            }
        }

        public bool ValidarObjPaciente(Paciente objPaciente){
            if(!string.IsNullOrEmpty(objPaciente.Cedula) && !string.IsNullOrEmpty(objPaciente.NombreCompleto) && !string.IsNullOrEmpty(objPaciente.Edad) && !string.IsNullOrEmpty(objPaciente.Genero) && !string.IsNullOrEmpty(objPaciente.Tipo) && objPaciente.MedicoAsignado != null  && objPaciente.FechaHoraCita.GetHashCode() > 0){
                return true;
            } else {
                return false;
            }
        }

        public static void PacienteToString(Paciente paciente){
            if(paciente !=  null){
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
                    + $"Estado de la cita: {paciente.FechaHoraCita}"
                    + "----------------------------------------------------------------------------"
                );
            }
        }
    
        public Paciente ModificarCitaPaciente(List<Paciente> pacientes){
            Paciente? paciente = null;
            Console.WriteLine("Ingresa la cédula del paciente:");
            string cedulaPaciente = Console.ReadLine();

            if(!string.IsNullOrEmpty(cedulaPaciente)){
                paciente = pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                if(paciente != null){
                    Console.WriteLine("Ingrese la nueva fecha de la cita del paciente en el siguiente formato( día/mes/año ):");
                    DateTime nuevaFecha = DateTime.Parse(Console.ReadLine());
                    paciente.FechaHoraCita = nuevaFecha;
                } else {
                    Console.WriteLine("No existe un paciente que coincida con esa información.");
                }
            }
            return paciente;
        }

        public void EliminarCitaPaciente(List<Paciente> pacientes){
            Paciente? paciente = null;
            Console.WriteLine("Ingresa la cédula del paciente:");
            string cedulaPaciente = Console.ReadLine();

            if(!string.IsNullOrEmpty(cedulaPaciente)){
                paciente = pacientes.FirstOrDefault(x => x.Cedula == cedulaPaciente);
                if(paciente != null){
                    PacienteToString(paciente);
                    if(pacientes.Remove(paciente)){
                        Console.WriteLine("La cita del paciente fue cancelada con éxito.");
                    }
                }
            } else {
                Console.WriteLine($"Ingresa un valor válido para la cédula");
            }
        }
    


    }
}
