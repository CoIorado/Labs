using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab10
{
    public class Student : Person
    {
        private string university;
        public string University
        {
            get
            {
                return university;
            }
            set
            {
                if (value.Length > 2 && value.Length < 30)
                    university = value;
                else
                    throw new InvalidUniversityException("Некорректное название университета.");
            }
        }

        private string group;
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                if (Regex.IsMatch(value, @"..?-\d\d?-\d"))
                    group = value;
                else
                    throw new InvalidGroupException("Некорректное обозначение группы.");
            }
        }

        public Student(string name, string lastName, int age, string gender, string university, string group) : base(name, lastName, age, gender)
        {
            University = university;
            Group = group;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> University: ");

            Console.ResetColor();
            Console.WriteLine(University);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> Group: ");

            Console.ResetColor();
            Console.WriteLine(Group);
        }   //верно

        public void DisplayInfoStudent()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("> Type: ");

            Console.ResetColor();
            Console.WriteLine("Emloyee");

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
            Console.Write("> Groups: ");

            Console.ResetColor();
            Console.WriteLine(Group);

        }   //неверно

        public override object Clone()
        {
            return new Student(Name, LastName, Age, Gender, University, Group);
        }
    }
}