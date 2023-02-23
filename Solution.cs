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
    
    
    