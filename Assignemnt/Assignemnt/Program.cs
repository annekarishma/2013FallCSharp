using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnt
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Person per = new Person();
           Support s = new Support();*/
            Program prog = new Program();
            var names = new[] { "Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon", "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy", "Siu" };
            //string[] all=new string[names.Length];

            prog.Name = names;
            //Console.WriteLine("Create a list of Persons, each with one of the names");
            if (prog.Name != null)
            {
                foreach (string name in prog.Name)
                {
                    Console.WriteLine(name);
                }

            }
            else
                throw new ArgumentNullException();

            prog.PersonNameWithIntialM(prog.Name);
            prog.NamesInUppercase(prog.Name);
            prog.LengthOfPersonNames(prog.Name);
            prog.SubStringWithThreeLetters(prog.Name);

            Console.ReadKey();

        }
        private string[] pname;
        public string[] Name
        {
            set
            {
                pname = value;

            }
            get
            {

                return pname;
            }

        }
        public void PersonNameWithIntialM(string[] stringarray)
        {
            int count = 0;
            Console.WriteLine("Create the same list then get a subset with only people whose names start with M");
            var minitial = from s in stringarray.ToList() where s.StartsWith("M") select s;
            foreach (string name in minitial)
            {
                Console.WriteLine(name);
               /* if (count == 0)
                {
                    throw new Exception();
                } */

            }
        }
        public void NamesInUppercase(string[] array)
        {

            Console.WriteLine("==============Names in Upper case======================");
            foreach (string s in array)
            {

                Console.WriteLine(s.ToUpper());
            }


        }

        public void LengthOfPersonNames(string[] stringarray)
        {
            //3
            Console.WriteLine("=============== Length Of Person Names============== ");

            foreach (string s in stringarray)
            {
                Console.Write(s + "=" + s.Length);
            }

        }
        public void SubStringWithThreeLetters(string[] stringarray)
        {
            //4
            Console.WriteLine("==================Sub string with Threee Letters============");
            foreach (string s in stringarray)
            {
                Console.WriteLine(s.Substring(0, 3));
            }
        }

    }// end of class program
}
