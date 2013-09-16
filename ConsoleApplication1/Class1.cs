using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Class1
    {
        public void Linq1()
        {
            int[] numbers = { 1, 0, 4, 5, 5, 8, 3, 2, 6 };
            var lowNums =
                from n in numbers
                where n < 5
                select n;
            Console.WriteLine("Numbers < 5 : ");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }
    }

}
