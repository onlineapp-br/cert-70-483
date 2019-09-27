using System;
using System.Collections.Generic;
using System.Linq;

namespace delegate_from_scratch
{
    class Program
    {
        delegate void EliadeDelegate();

        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        static void Foo()
        {
            System.Console.WriteLine("Foo");
        }

        static void Bar()
        {
            System.Console.WriteLine("Bar");
        }
    }
}
