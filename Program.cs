using System;
using System.Collections.Generic;

namespace Gestión_Proyectos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Proyecto> lista_proyectos = new List<Proyecto>();

            int opcion;

            do
            {
                MostrarMenu();
                opcion = CastEntero("Ingrese una opción perteneciente al menú :");

                switch (opcion)
                {
                    case 1: //Crea proyectos

                        Console.WriteLine("¿Cuántos proyectos desea crear?");
                        int x = CastEntero("Ingrese un entero");

                        for (int i = 0; i < x; i++)
                        {
                            Console.WriteLine($"Proyecto {i+1}");
                            lista_proyectos.Add(CrearProyecto());
                        }
                        foreach (var item in lista_proyectos)
                        {
                            item.calcularCostoTotal(item.Costo_base, item.Integrantes);
                        }

                        break;

                    case 2: //Imprime lista de proyectos

                        ListarProyectos(lista_proyectos);

                        break;

                    case 3: //Agrega o retira integrantes

                        Console.WriteLine("Ingrese el código del proyecto al que va agregar o retirar integrantes");
                        string busqueda = Console.ReadLine();

                        Proyecto proyectoX = lista_proyectos.Find(proyecto => proyecto.Codigo == busqueda);

                        Console.WriteLine("¿Deseas agregar o retirar?");
                        Console.WriteLine("Ingrese 1 para agregar");
                        Console.WriteLine("Ingrese 2 para retirar");

                        int opc = CastEntero("Ingrese 1 o 2");

                        if (opc == 1)
                        {
                            Console.WriteLine("¿Cuántos integrantes vas a añadir?");
                            int cantidad_integrantes = CastEntero("Ingresa un entero");

                            for (int j = 0; j < cantidad_integrantes; j++)
                            {
                                Console.WriteLine("Nombre del integrante");
                                string nombre_integrante = Console.ReadLine();

                                Console.WriteLine($"Horas de dedicación semanal de {nombre_integrante}");
                                int horas = CastEntero("Ingrese un entero");

                                Persona personaX = new Persona(nombre_integrante, horas);
                                proyectoX.Integrantes.Add(personaX);
                            }
                            
                        }
                        else if(opc == 2)
                        {
                            Console.WriteLine("¿Cuántos integrantes vas a retirar?");
                            int cantidad_integrantes = CastEntero("Ingresa un entero");

                            if (cantidad_integrantes <= proyectoX.Integrantes.Count)
                            {
                                for (int k = 0; k < cantidad_integrantes; k++)
                                {
                                    Console.WriteLine("Ingrese el nombre del integrante que va a retirar");
                                    string nombre_retiro = Console.ReadLine();

                                    proyectoX.Integrantes.Remove(proyectoX.Integrantes.Find(integrante => integrante.Nombre == nombre_retiro));
                                }
                            }
                            else
                            {
                                Console.WriteLine("No puedes retirar más personas de las que hay en el proyecto");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ES UNA OPCIÓN ENTRE 1 y 2");
                        }
                        foreach (var item in lista_proyectos)
                        {
                            item.calcularCostoTotal(item.Costo_base, item.Integrantes);
                        }

                        break;

                    case 0: //mensaje despedida

                        Console.WriteLine("Hasta luego, vuelva pronto.");

                        break;

                    default: //opción default

                        Console.WriteLine("Ingrese una opción perteneciente al menú");

                        break;
                }

            } while (opcion != 0);
        }
        public static void MostrarMenu()
        {
            Console.WriteLine(" __________________________________________ ");
            Console.WriteLine("|                                          |");
            Console.WriteLine("| Bienvenido                               |");
            Console.WriteLine("| Escoge una opción del menú :             |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("| 1.Crear proyectos.                       |");
            Console.WriteLine("| 2.Mostrar información de los proyectos.  |");
            Console.WriteLine("| 3.Agregar o retirar integrantes.         |");
            Console.WriteLine("| 0.Salir                                  |");
            Console.WriteLine("|__________________________________________|");
        }
        public static Proyecto CrearProyecto()
        {
            List<Persona> lista_personas = new List<Persona>();

            Console.WriteLine("Ingrese el nombre del proyecto");
            string nombre_proyecto = Console.ReadLine();

            Console.WriteLine("Ingrese el código del proyecto");
            string codigo = Console.ReadLine();

            Console.WriteLine("¿Cuál es el costo base de su proyecto?");
            double costo = CastDouble("Ingresa un número");

            Console.WriteLine("¿Cuántos integrantes tiene su proyecto?");
            int cantidad_integrantes = CastEntero("Ingresa un entero");

            for (int i = 0; i < cantidad_integrantes; i++)
            {
                Console.WriteLine("Nombre del integrante");
                string nombre_integrante = Console.ReadLine();

                Console.WriteLine($"Horas de dedicación semanal de {nombre_integrante}");
                int horas = CastEntero("Ingrese un entero");

                Persona personaX = new Persona(nombre_integrante, horas);
                lista_personas.Add(personaX);
            }

            return new Proyecto(codigo, nombre_proyecto, costo, lista_personas);
        }
        public static void ListarProyectos(List<Proyecto> proyectos)
        {
            foreach (var proyecto in proyectos)
            {

                Console.WriteLine($"El proyecto de nombre {proyecto.Nombre}, de código {proyecto.Codigo} y costo base {proyecto.Costo_base}");
                Console.WriteLine("Tiene como integrantes a :");

                foreach (var integrante in proyecto.Integrantes)
                {
                    Console.WriteLine($"{integrante.Nombre} que dedica {integrante.Horas_dedicacion} horas a la semana y tiene salario {integrante.Salario}");
                }

                Console.WriteLine($"El costo total del proyecto es {proyecto.Costo_total}");
                Console.WriteLine("");

            }
        }
        //Función que utiliza Tryparse para retornar un entero
        public static int CastEntero(string mensaje)
        {
            int entero;
            bool validar;
            string item;
            do
            {
                Console.WriteLine(mensaje);
                item = Console.ReadLine();
                validar = int.TryParse(item, out entero);
            } while (!validar);
            return entero;
        }
        //Función que utiliza Tryparse para retornar un double
        public static double CastDouble(string mensaje)
        {
            double numero;
            bool validar;
            string item;
            do
            {
                Console.WriteLine(mensaje);
                item = Console.ReadLine();
                validar = double.TryParse(item, out numero);
            } while (!validar);
            return numero;
        }
    }
}
