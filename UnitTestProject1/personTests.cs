using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class personTests
    {
        public void ListOfPersons()
        {
            var names = new[] { "Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon", "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy", "Siu" };

            Console.WriteLine("Create a list of Persons, each with one of the names");

            foreach (string s in (string[])names.ToArray())
            {
                Console.WriteLine(s);
            }
        }


        public void PersonsNameStartsWithM()
        {
            var names = new[] { "Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon", "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy", "Siu" };

            Console.WriteLine("Create the same list then get a subset with only people whose names start with M");

            var mStarts = from s in names.ToList() where s.StartsWith("M") select s;

            foreach (string s in (string[])mStarts.ToArray())
            {
                Console.WriteLine(s);
            }
        }

        public void UpperCase()
        {
            var names = new[] { "Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon", "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy", "Siu" };

            Console.WriteLine("Create the same list then get a list everyones names in uppercase ");

            var upper = names.Select(x => x.ToUpper()).ToArray();

            foreach (string s in (string[])upper.ToArray())
            {
                Console.WriteLine(s);
            }
        }

        public void ArrayLengthofName()
        {

            var names = new[] { "Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon", "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy", "Siu" };

            Console.WriteLine("Create the same list then get a and array if int with the length of each name");

            foreach (string s in (string[])names.ToArray())
            {
                Console.WriteLine(s + " --> " + s.Length);
            }
        }

        public void OrderedByName()
        {

            var names = new[] { "Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon", "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy", "Siu" };

            Console.WriteLine("Create the same list then get a list with only the name shortened to the first three letters ordered by name");

            var strfirst3charorder = names.Select(x => x.Substring(0, 3)).OrderBy(x => x);

            foreach (string s in (string[])strfirst3charorder.ToArray())
            {
                Console.WriteLine(s);
            }
        }
    }
}
