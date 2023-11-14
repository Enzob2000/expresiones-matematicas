using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace expresiones_matematicas
{
    internal class Program
    {
        static void Main(string[] args)

        {
            
            menu();





        }


            static void menu()
            {
            expresiones prueba = new expresiones();
            bool salir = false;

                while (!salir)

                {
                    Console.Clear();
                    Console.WriteLine("----- Menú -----");
                    Console.WriteLine("1. Cambiar a expresión postfija");
                    Console.WriteLine("2. Mostrar resultado");
                    Console.WriteLine("3. Salir");
                    Console.WriteLine("----------------");
                    Console.Write("Elige una opción: ");

                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                        Console.Clear();
                        prueba.validacionalfabetica();
                            
                            break;
                        case "2":
                        Console.Clear();
                        prueba.validacionumerica();
                            
                            break;
                        case "3":
                            Console.WriteLine("Saliendo del programa");
                            Console.ReadKey();
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, elige una opción válida.");
                            Console.ReadKey();
                        
                        break;
                    }

                    Console.WriteLine();
                }
            }
        }



    }





