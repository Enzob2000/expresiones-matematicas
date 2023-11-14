using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace expresiones_matematicas
{
    internal class expresiones
    {
        public int validacionalfabetica()
        {    
            string expresion;
            int parentesis = 0, operando = 0, operador = 0;
            string variable = "";
            List<string> operadores = new List<string>() { "+", "-", "*", "^", "/" };



            Console.WriteLine("Expresion que desea transformar a postfija");
            Console.WriteLine();
            expresion = Console.ReadLine();
            Console.WriteLine();


            for (int i = 0; i < expresion.Length; i++)
            {
                if (char.IsNumber(expresion[i]))
                {
                    Console.WriteLine("Error la expesion contiene numeros no se puede procesar");
                    Console.ReadKey();
                    return 0;
                    


                }


                variable = Convert.ToString(expresion[i]);

                if ((i == 0 || i == expresion.Length - 1) && operadores.IndexOf(variable) >= 0 || expresion.IndexOf("(") == -1 || ((operadores.IndexOf(variable) >= 0) && operadores.IndexOf(Convert.ToString(expresion[i + 2])) >= 0))
                {
                    Console.WriteLine("La expresion esta mal escrita");
                    Console.ReadKey();
                    return 0;
                }

                if (variable == "(") { parentesis++; continue; }

                if (variable == ")") { parentesis--; continue; }

                if (char.IsLetter(expresion[i])) { operando++; continue; }

                if (operadores.IndexOf(variable) >= 0) { operador++; continue; }

            }

            if (parentesis == 0 && operador == operando - 1)
            {

                return postfijaalfabetica(expresion);
            }
            else
            {
                Console.WriteLine("La expresion esta mal escrita");
                Console.ReadKey();
                return 0;
            }

        }

        public int postfijaalfabetica(string expresion)
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
            expresion_pila.clear();

            for (int i = expresion.Length - 1; i >= 0; i--)
            {

                expresion_pila.push(expresion[i]);


            }

            while (true)
            {
                salida = Convert.ToString(expresion_pila.pop());

                if (char.IsLetter(Convert.ToChar(salida)))
                {
                    operando1 = salida;
                    operador1 = Convert.ToString(expresion_pila.pop());
                    operando2 = Convert.ToString(expresion_pila.pop());

                    if (operadores.IndexOf(operador1) == -1 || !char.IsLetter(Convert.ToChar(operando1)) || !char.IsLetter(Convert.ToChar(operando2)))
                    {
                        Console.WriteLine("La expresion esta mal escrita");
                        Console.ReadKey();
                        return 0;
                    }

                    exprepost = exprepost + operando1 + operando2 + operador1 + operador2;

                    operador2 = "";

                }

                if (operadores.IndexOf(salida) >= 0)
                {
                    operador2 = salida;

                }


                if (Convert.ToInt64(expresion_pila.poptope()) == -1)
                {
                    break;
                }

            }
            
            Console.WriteLine("La forma postfija es " + exprepost);
            Console.ReadKey();

            return 1;
        }


        public int validacionumerica()
        {
            string expresion;
            int parentesis = 0, operando = 0, operador = 0;
            string variable = "";
            List<string> operadores = new List<string>() { "+", "-", "*", "^", "/" };



            Console.WriteLine("Expresion matematica a la cual desea conocer su resultado");
            Console.WriteLine();
            expresion = Console.ReadLine();
            Console.WriteLine();


            for (int i = 0; i < expresion.Length; i++)
            {
                if (char.IsLetter(expresion[i]))
                {
                    Console.WriteLine("Error la expesion contiene letras no se puede procesar");
                    Console.ReadKey();
                    return 0;


                }


                variable = Convert.ToString(expresion[i]);

                if ((i == 0 || i == expresion.Length - 1) && operadores.IndexOf(variable) >= 0 || expresion.IndexOf("(") == -1 || ((operadores.IndexOf(variable) >= 0) && operadores.IndexOf(Convert.ToString(expresion[i + 2])) >= 0))
                {
                    Console.WriteLine("La expresion esta mal escrita");
                    Console.ReadKey();
                    return 0;
                }

                if (variable == "(") { parentesis++; continue; }

                if (variable == ")") { parentesis--; continue; }

                if (char.IsNumber(expresion[i])) { operando++; continue; }

                if (operadores.IndexOf(variable) >= 0) { operador++; continue; }

            }

            if (parentesis == 0 && operador == operando - 1)
            {

               return resultado(expresion);
            }
            else
            {
                Console.WriteLine("La expresion esta mal escrita");
                Console.ReadKey();
                return 0;
            }

        }
        public int resultado(string expresion)
        {
           
            string operando1 = "";
            string operando2 = "";
            string operador1 = "";
            string operador2 = "+";
            string salida = "";
            string resul="0";
            object aux = "0";
            object sal;
            List<string> operadores = new List<string>() { "+", "-", "*", "^", "/" };

            pila expresion_pila = new pila();
            expresion_pila.clear();

            for (int i = expresion.Length - 1; i >= 0; i--)
            {

                expresion_pila.push(expresion[i]);


            }

            while (true)
            {
                salida = Convert.ToString(expresion_pila.pop());

                if (char.IsNumber(Convert.ToChar(salida)))
                {
                    operando1 = salida;
                    operador1 = Convert.ToString(expresion_pila.pop());
                    operando2 = Convert.ToString(expresion_pila.pop());

                    if (operadores.IndexOf(operador1) == -1 || !char.IsNumber(Convert.ToChar(operando1)) || !char.IsNumber(Convert.ToChar(operando2)))
                    {
                        Console.WriteLine("La expresion esta mal escrita");
                        Console.ReadKey();
                        return 0;
                    }

                    if (operador1 != "^")
                    {

                        aux = new DataTable().Compute(operando1 + operador1 + operando2, null);

                    }
                    else
                    {

                        double doble=0;
                        doble = Math.Pow(Convert.ToDouble(operando1), Convert.ToDouble(operando2));
                        aux = new DataTable().Compute(Convert.ToString(doble), null);

                    }
                    
                    
                        
                        resul = resul + operador2 + Convert.ToString(aux);

                    
                    
                }

                if (operadores.IndexOf(salida) >= 0)
                {
                    operador2 = salida;

                }
                
                

                if (Convert.ToInt64(expresion_pila.poptope()) == -1)
                {
                    break;
                }

            }
            string auxi = "";
            for(int i = 0; i < resul.Length; i++)
            {

                if ( i<resul.Length-3   && char.IsNumber(resul[i]) && Convert.ToString(resul[i+1])=="^" && char.IsNumber(resul[i+2]))
                {

                    double b;
                    string p1 = Convert.ToString(resul[i]);
                    string p2 = Convert.ToString(resul[i+2]);

                    b = Math.Pow(Convert.ToDouble(p1),Convert.ToDouble(p2));

                    i += 2;
                    auxi = auxi +Convert.ToString(b);
                }
                else
                {
                    auxi = auxi + Convert.ToString(resul[i]);

                }


            }


            sal = new DataTable().Compute(auxi, null);
            Console.WriteLine();
            Console.WriteLine("El resultado es " +Convert.ToString(sal));
            Console.ReadKey();
            
            return 1;
        }
    }
}

