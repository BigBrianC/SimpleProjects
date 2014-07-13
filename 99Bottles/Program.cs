using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99Bottles
{
    class Program
    {
        public static void Write(ref int bottles)
        {
            if (bottles != 1)
           { 
                Console.WriteLine(bottles + " bottles of beer on the wall!");
                Console.WriteLine(bottles + " bottles of beer");
                Console.WriteLine("Take one down, pass it around");
                Console.WriteLine(bottles - 1 + " bottles of beer");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(bottles + " bottle of beer on the wall!");
                Console.WriteLine(bottles + " bottles of beer");
                Console.WriteLine("Take one down, pass it around");
                Console.WriteLine("No more bottles of beer");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            for (int bottles = 99; bottles > 0; bottles--)
            {
                Write(ref bottles);
            }
            Console.ReadKey();
        }
    }
}
