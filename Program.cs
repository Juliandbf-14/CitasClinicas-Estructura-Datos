using CitasClinicas.Operaciones;

namespace CitasClinicas
{
    class Program
    {
        static void Main(string[] args)
        {
            OperacionesPaciente operaciones = new OperacionesPaciente();
            Medico medico = new Medico{
                Cedula = "2738191121",
                NombreCompleto = "Jesus Hernán Gonzalez Rámirez",
                Oficina = "404",
            };
            string respuesta = "0";
            string opcionCitas;


            while (respuesta == "0" && respuesta != string.Empty)
            {
                Console.WriteLine("______________________________________________________________");
                Console.WriteLine("Bienvenido al menú de opciones de la Clínica de las Americas");
                Console.WriteLine("1. Gestión de Citas");
                Console.WriteLine("2. Manejo de Pacientes");
                Console.WriteLine("3. Salir");
                Console.WriteLine("______________________________________________________________");
                Console.WriteLine("Selecciona una opción:");
                respuesta = Console.ReadLine();


                while (respuesta == "1")
                {   
                    Console.WriteLine("_____________________________");
                    Console.WriteLine("Menú de Gestión de Citas");
                    Console.WriteLine("1. Crear cita.");
                    Console.WriteLine("2. Modificar cita.");
                    Console.WriteLine("3. Cancelar cita.");
                    Console.WriteLine("4. Volver al menú principal.");
                    Console.WriteLine("_____________________________");

                    Console.WriteLine("Selecciona una opción:");
                    opcionCitas = Console.ReadLine();

                    // Creación de Citas
                    if (opcionCitas == "1")
                    {   
                        Console.WriteLine("Sigue con las instrucciones del Sistema para crear la cita.");
                        Paciente paciente = operaciones.CrearCitaPaciente(medico);
                        bool registroExitoso = paciente.ValidarObjPaciente(paciente);

                        if (registroExitoso)
                        {
                            Console.WriteLine("El paciente ha sido registrado exitosamente.");
                            medico.Pacientes.Add(paciente);
                        } else {
                            Console.WriteLine("El paciente no pudo ser registrado exitosamente.");
                        }
                        respuesta = "1";
                    }

                    // Modificación de la fecha de la cita
                    if (opcionCitas == "2")
                    {
                        Paciente? pacienteCoincidente = operaciones.ModificarCitaPaciente(medico.Pacientes);
                        if (pacienteCoincidente == null)
                        {
                            Console.WriteLine("El paciente no pudo ser encontrado, por ende no se puede modificar su cita.");
                        } else {
                            Console.WriteLine($"La fecha del paciente con cédula: {pacienteCoincidente.Cedula} y nombre: {pacienteCoincidente.NombreCompleto} fue modificada con éxito.");
                        }
                        respuesta = "1";
                    }
                    
                    // Eliminar cita del paciente
                    if (opcionCitas == "3")
                    {
                        operaciones.EliminarCitaPaciente(medico.Pacientes);
                        respuesta = "1";
                    }

                    // Salir al menú Principal
                    if (opcionCitas == "4")
                        respuesta = "0";
                }

                while(respuesta == "2")
                {
                    Console.WriteLine("_____________________________");
                    Console.WriteLine("1. Ver lista de pacientes");
					Console.WriteLine("2. Estado de la cita del Paciente");
					Console.WriteLine("3. Atender paciente");
                    Console.WriteLine("4. Volver al menú principal");
                    Console.WriteLine("_____________________________");
                    Console.WriteLine("Escoge una opción: ");
                    string opcionPacientes = Console.ReadLine();

                    // Ver la lista de los pacientes 
                    if(opcionPacientes == "1"){
                        if (medico.Pacientes.Count > 0)
                        {
                            foreach (Paciente itemPaciente in medico.Pacientes)
                            {
                                operaciones.PacienteToString(itemPaciente);
                            }
                        } else {
                            Console.WriteLine("No hay citas en este momento");
                        }
                        respuesta = "2";
                    }

                    // Ver el estado del paciente 
                    if(opcionPacientes == "2"){
                        operaciones.EstadoCitaPaciente(medico);
                        respuesta = "2";
                    }

                    // TODO: Agregar método para atender las citas

                    if(opcionPacientes == "4"){
                        respuesta = "0";
                    }
                }

                if (respuesta == "3")
                {
                    break;
                }
            }
        }
    }
}
