// Hello Everyone
using System;
using System.Collections.Generic;

namespace ConsoleApp7
{

    class MyCharStack // Клас стека char для зчитування / запис прикладу
    {
        LinkedList<char> _items = new LinkedList<char>();
      
    
        public void Push(char value)
        {
            _items.AddLast(value);
        }

        public char Pop()
        {
            char result = _items.Last.Value;
            _items.RemoveLast();
            return result;
        }
        public int Count()
        {
            return _items.Count;
        }

        public char Peek()
        {
            return _items.Last.Value;
        }
    
    }
    
    
    class MyDoubleStack // Клас стека double для всіх розрахунків
    {
        LinkedList<double> _items = new LinkedList<double>();


        public void Push(double value)
        {
            _items.AddLast(value);
        }

        public double Pop()
        {
            double result = _items.Last.Value;
            _items.RemoveLast();
            return result;
        }
        public int Count()
        {
            return _items.Count;
        }

        public double Peek()
        {
            return _items.Last.Value;
        }

    }
    class Rpn
    {
        //Метод повертає true, якщо символ, що перевіряється - роздільник ("пробіл")
        static private bool isDelimeter(char c)
        {
            string probel = " ";
            if (probel.IndexOf(c) != -1)
                return true;
            return false;
        }

        //Метод повертає true, якщо символ, що перевіряється - оператор
        static private bool isOperator(char с)
        {
            string templateOperators = "+-/*^()";
            if (templateOperators.IndexOf(с) != -1)
                return true;
            return false;
        }

        //Метод повертає пріоритет оператора
        static private byte priorityOfOperators(char symbol)
        {
            switch (symbol)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }
        //Метод проведення всіх операцій калькулятора
        static public double Calculate(string input)
        {
            return CalculateFunc(GetPolishOutput(input)); 
        }

        static private string GetPolishOutput(string input)
        {
            string output = ""; 
            MyCharStack operatorsStack = new MyCharStack(); 

            for (int i = 0; i < input.Length; i++) 
            {
                
                if (isDelimeter(input[i]))
                    continue; 

                
                if (Char.IsDigit(input[i])) 
                {
                   
                    while (!isDelimeter(input[i]) && !isOperator(input[i]))
                    {
                        Console.Write(input[i] + "|");
                        output += input[i]; 
                        i++; 

                        if (i == input.Length) break; 
                    }

                    output += " "; 
                    i--; 
                }

                
                if (isOperator(input[i])) 
                {
                    Console.Write(input[i] + "|");
                    if (input[i] == '(') 
                        operatorsStack.Push(input[i]); 
                    else if (input[i] == ')') 
                    {
                        
                        char stringWithOps = operatorsStack.Pop();

                        while (stringWithOps != '(')
                        {
                            output += stringWithOps.ToString() + ' ';
                            stringWithOps = operatorsStack.Pop();
                        }
                    }
                    else 
                    {
                        if (operatorsStack.Count() > 0) 
                            if (priorityOfOperators(input[i]) <= priorityOfOperators(operatorsStack.Peek())) 
                                output += operatorsStack.Pop().ToString() + " "; 

                        operatorsStack.Push(char.Parse(input[i].ToString())); 

                    }
                }
            }

            
            while (operatorsStack.Count() > 0)
                output += operatorsStack.Pop() + " ";

            Console.WriteLine();
            Console.WriteLine("Приклад у постфіксному записі : " + output); 
            return output; 
        }
    
    