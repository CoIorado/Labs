using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab11
{
    public class Educator : Employee
    {
        private List<string> Groups = new List<string>();  //группы, в которых преподает данный преподаватель (вида ПИ-19-1)

        public Educator(string name, string lastName, int age, string gender, string university, int salary, params string[] groups) : base(name, lastName, age, gender, university, salary)
        {
            foreach (string group in groups)
            {
                if (Regex.IsMatch(group, @"..?-\d\d?-\d"))
                    Groups.Add(group);
                else
                    throw new InvalidGroupException("Некорректное обозначение группы");
            }
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> University: ");

            Console.ResetColor();
            Console.WriteLine(University);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> Salary: ");

            Console.ResetColor();
            Console.WriteLine(Salary);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> Groups: ");

            Console.ResetColor();
            for (int i = 0; i < Groups.Count; i++)
            {
                if (i != Groups.Count - 1)
                    Console.Write(Groups[i] + ", ");
                else
                    Console.WriteLine(Groups[i]);
            }
        }   //верно

        public void DisplayInfoEducator()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("> Type: ");

            Console.ResetColor();
            Console.WriteLine("Educator");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> Name: ");

            Console.ResetColor();
            Console.WriteLine(Name);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> Lastname: ");

            Console.ResetColor();
            Console.WriteLine(LastName);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> Age: ");

            Console.ResetColor();
            Console.WriteLine(Age);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> University: ");

            Console.ResetColor();
            Console.WriteLine(University);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> Salary: ");

            Console.ResetColor();
            Console.WriteLine(Salary);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> Groups: ");

            Console.ResetColor();
            for (int i = 0; i < Groups.Count; i++)
            {
                if (i != Groups.Count - 1)
                    Console.Write(Groups[i] + ", ");
                else
                    Console.WriteLine(Groups[i]);
            }

        }   //неверно

        public override object Clone()
        {
            string[] groups = new string[Groups.Count];
            int i = 0;
            foreach (string group in Groups)
                groups[i++] = group;

            Educator clone = new Educator(Name, LastName, Age, Gender, University, Salary, groups);
            return clone;
        }
    }
}