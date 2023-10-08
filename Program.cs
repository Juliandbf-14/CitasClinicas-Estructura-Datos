namespace CitasClinicas
{
    class Program
    {
        static void Main(string[] args)
        {   
            Program program = new Program();
            Paciente paciente = new Paciente();
            Medico medico = new Medico{
                Cedula = "2738191121",
                NombreCompleto = "Jesus Hernán Gonzalez Rámirez",
                Oficina = "404",
            };
            int respuesta = 0;

            while (respuesta == 0)
            {
                Console.WriteLine("Bienvenido al menú de opciones de la Clínica de las Americas");
                Console.WriteLine("Gestión de Citas");
                Console.WriteLine("1. Crear cita");
                Console.WriteLine("2. Modificar cita");
                Console.WriteLine("3. Cancelar cita");
                Console.WriteLine("_____________________________");
                Console.WriteLine("Manejo de Pacientes");
                Console.WriteLine("4. Estado de la cita del Paciente");
                Console.WriteLine("5. Atender paciente");
                Console.WriteLine("_____________________________");
                Console.WriteLine("0. Repetir Menú");
                

                if(respuesta == 1){
                    Console.WriteLine("Sigue con las instrucciones del Sistema para crear la cita.");

                    paciente = program.CrearCitaPaciente(paciente, medico);
                    bool registroExitoso = program.ValidarObjPaciente(paciente);

                    if(registroExitoso){
                        Console.WriteLine("El paciente ha sido registrado exitosamente.");
                        medico.Pacientes.Add(paciente);
                    } else {
                        Console.WriteLine("El paciente no pudo ser registrado exitosamente.");
                    }
                    respuesta = 0;
                }

                if (respuesta == 2){
                    paciente = program.ModificarCitaPaciente(medico.Pacientes);
                    if(paciente == null){
                        Console.WriteLine("El paciente no pudo ser encontrado, por ende no se puede modificar su cita.");
                    } else {
                        Console.WriteLine($"La fecha del paciente con cédula:{paciente.Cedula} y nombre: {paciente.NombreCompleto} fue modificada con éxito.");
                    }
                    respuesta = 0;
                }
                
                if(respuesta == 3){
                    program.EliminarCitaPaciente(medico.Pacientes);
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
                Console.WriteLine("Ocurrió un error al ingresar al paciente: " + e.Message);
                return null;
            }
        }

        public bool ValidarObjPaciente(Paciente objPaciente){
            if(string.IsNullOrEmpty(objPaciente.Cedula) && string.IsNullOrEmpty(objPaciente.NombreCompleto) && string.IsNullOrEmpty(objPaciente.Edad) && string.IsNullOrEmpty(objPaciente.Genero) && string.IsNullOrEmpty(objPaciente.Tipo) && objPaciente.MedicoAsignado == null  && objPaciente.FechaHoraCita.GetHashCode() == 0){
                return false;
            } else {
                return true;
            }
        }

        public static void PacienteToString(Paciente paciente){
            if(paciente !=  null){
                Console.WriteLine($"Los datos del paciente son los siguientes:\n"
                    + $"Cédula del paciente: {paciente.Cedula}"
                    + $"Nombre Completo del paciente: {paciente.NombreCompleto}"
                    + $"Edad del paciente: {paciente.Edad}"
                    + $"Género del paciente: {paciente.Genero}"
                    + $"Tipo de usuario del paciente: {paciente.Tipo}"
                    + $"Médico asignado al paciente: {paciente.MedicoAsignado.NombreCompleto}"
                    + $"Fecha y hora de la cita: {paciente.FechaHoraCita}"
                    + $"Oficina de la cita: {paciente.MedicoAsignado.Oficina}"
                    + $"Estado de la cita: {paciente.FechaHoraCita}"
                );
            }
        }
    
        public Paciente ModificarCitaPaciente(List<Paciente> pacientes){
            Paciente paciente = null;
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
            Paciente paciente = null;
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
            }
        }
    }
}
