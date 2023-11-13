using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace expresiones_matematicas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            validacion();



        }


         static void validacion()
        { 
            string expresion;
            int parentesis = 0,operando=0,operador=0;
            string variable="";
            List<string> operadores = new List<string>() { "+","-","*","^","/" };
           


            Console.WriteLine("Expresion que desea transformar a postfija");
            expresion = Console.ReadLine();


            for (int i = 0; i < expresion.Length; i++)
            {
                if (char.IsNumber(expresion[i]))
                {
                    Console.WriteLine("Error la expesion contiene numeros no se puede procesar");
                    Console.ReadKey();
                    

                }


                variable = Convert.ToString(expresion[i]);

                if (variable == "(") { parentesis++;continue; }

                if (variable == ")") { parentesis--;continue; }

                if (char.IsLetter(expresion[i])) { operando++;continue; }

                if (operadores.IndexOf(variable) >= 0) { operador++;continue; }

            }

            if (parentesis==0 && operador == operando-1)
            {

                Console.WriteLine("La expresion esta bien escrita");
                Console.ReadKey();
                postfija(expresion);
            }
            else
            {
                Console.WriteLine("La expresion no es mal escrita");
                Console.ReadKey();
            }

          }

        static void postfija(string expresion)
        {
            string exprepost = "";
            string operando1 = "";
            string operando2 = "";
            string operador1 = "";
            string operador2 = "";
            string salida = "";
            string expreint = "";
            List<string> operadores = new List<string>() { "+", "-", "*", "^", "/" };

            pila expresion_pila = new pila();

            for (int i = expresion.Length-1; i >=0; i--)
            {

                expresion_pila.push(expresion[i]);


            }

            while (true)
            {
                salida =Convert.ToString( expresion_pila.pop());
                
                if (char.IsLetter(char.Parse(salida)))
                {
                    operando1 = salida;     
                    operador1 = Convert.ToString(expresion_pila.pop());
                    operando2 = Convert.ToString(expresion_pila.pop());

                    if (operadores.IndexOf(operador1) == -1)
                    {
                        Console.WriteLine("La expresion esta mal escrita");
                        Console.ReadKey();
                    }

                    expreint =expreint+ operando1 + operando2 + operador1 + operador2;

                    operador2 = "";

                }

                if (operadores.IndexOf(salida)>=0)
                {
                    operador2 = salida;
                
                }


                if (Convert.ToInt64( expresion_pila.poptope())==-1)
                {
                    break;
                }

            }

            Console.WriteLine(expreint);
        }

     }
}



