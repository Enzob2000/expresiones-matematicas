using System;
using System.Collections.Generic;
using System.Text;

namespace expresiones_matematicas
{
    internal class pila
    {
        #region atributos
        protected const int max = 99;
        object[] elementos;
        int tope;
        #endregion

        public pila()
        {
            tope = -1;
            elementos = new object[max];
        }


        private bool vacio()
        {
            return (tope == -1);
        }

        private bool lleno()
        {
            return (tope == max - 1);
        }

        public void push(object dato)
        {
            if (lleno())
            {
                Console.WriteLine("Error. Pila llena");
                Console.ReadKey();
            }
            else
            {
                tope++;
                elementos[tope] = dato;

            }
        }

        public object pop()
        {
            if (vacio())
            {
                Console.WriteLine("Error. Pila vacia.");
                Console.ReadKey();
                return (null);
            }
            else
            {
                object D;
                D = elementos[tope];
                tope--;
                return (D);
            }
        }

        public void imprimir()
        {
            if (vacio())
            {
                Console.WriteLine("\nError. pila vacia.");
                Console.ReadKey();
            }
            else
            {
                object d;
                pila pa = new pila();
                while (!vacio())
                {
                    d = pop();
                    Console.WriteLine(d);
                    pa.push(d);
                }

                while (!pa.vacio())
                {
                    push(pa.pop());
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public object poptope()
        {
            if (vacio())
            {
                //Console.WriteLine("Error. Pila vacia.");
                //Console.ReadKey();
                return (-1);
            }
            else
            {
                object D;
                D = elementos[tope];
                return (D);
            }
        }

        public int count()
        {
            return tope + 1;
        }

        public void clear()
        {
            tope = -1;
        }
    }
}
