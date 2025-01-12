using System;
using System.Collections.Generic;

namespace AgendaTurnosClinica
{
    // Clase que representa un paciente
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaTurno { get; set; }

        // Constructor para inicializar los atributos del paciente
        public Paciente(string nombre, int edad, string especialidad, DateTime fechaTurno)
        {
            Nombre = nombre;
            Edad = edad;
            Especialidad = especialidad;
            FechaTurno = fechaTurno;
        }

        // Método para mostrar información del paciente
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}, Especialidad: {Especialidad}, Fecha del turno: {FechaTurno}";
        }
    }

    // Clase que gestiona la agenda de turnos
    public class Agenda
    {
        // Lista para almacenar los pacientes
        private List<Paciente> pacientes;

        // Constructor que inicializa la lista de pacientes
        public Agenda()
        {
            pacientes = new List<Paciente>();
        }

        // Método para agregar un paciente a la agenda
        public void AgregarPaciente(Paciente paciente)
        {
            pacientes.Add(paciente);
            Console.WriteLine("Turno registrado con éxito.");
        }

        // Método para visualizar todos los pacientes
        public void MostrarPacientes()
        {
            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
                return;
            }

            Console.WriteLine("Lista de turnos registrados:");
            foreach (var paciente in pacientes)
            {
                Console.WriteLine(paciente);
            }
        }

        // Método para consultar turnos por especialidad
        public void ConsultarPorEspecialidad(string especialidad)
        {
            var resultados = pacientes.FindAll(p => p.Especialidad.Equals(especialidad, StringComparison.OrdinalIgnoreCase));

            if (resultados.Count == 0)
            {
                Console.WriteLine($"No se encontraron turnos para la especialidad: {especialidad}");
                return;
            }

            Console.WriteLine($"Turnos para la especialidad {especialidad}:");
            foreach (var paciente in resultados)
            {
                Console.WriteLine(paciente);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la agenda
            Agenda agenda = new Agenda();

            // Menú principal
            while (true)
            {
                Console.WriteLine("\n--- Agenda de Turnos de Pacientes ---");
                Console.WriteLine("1. Agregar turno");
                Console.WriteLine("2. Ver todos los turnos");
                Console.WriteLine("3. Consultar turnos por especialidad");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Solicitar datos del paciente
                        Console.Write("Ingrese el nombre del paciente: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Ingrese la edad del paciente: ");
                        int edad = int.Parse(Console.ReadLine());

                        Console.Write("Ingrese la especialidad: ");
                        string especialidad = Console.ReadLine();

                        Console.Write("Ingrese la fecha del turno (AAAA-MM-DD): ");
                        DateTime fechaTurno = DateTime.Parse(Console.ReadLine());

                        // Crear y agregar paciente
                        Paciente paciente = new Paciente(nombre, edad, especialidad, fechaTurno);
                        agenda.AgregarPaciente(paciente);
                        break;

                    case "2":
                        // Mostrar todos los turnos
                        agenda.MostrarPacientes();
                        break;

                    case "3":
                        // Consultar turnos por especialidad
                        Console.Write("Ingrese la especialidad a consultar: ");
                        string especialidadConsulta = Console.ReadLine();
                        agenda.ConsultarPorEspecialidad(especialidadConsulta);
                        break;

                    case "4":
                        // Salir del programa
                        Console.WriteLine("Saliendo del sistema. ¡Hasta pronto!");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
