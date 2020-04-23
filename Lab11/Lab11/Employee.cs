using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public abstract class Employee : Person
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

        private int salary;
        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value >= 0)
                    salary = value;
                else
                    throw new InvalidSalaryException("Некорректное значение зарплаты.");
            }
        }

        public Employee(string name, string lastName, int age, string gender, string university, int salary) : base(name, lastName, age, gender)
        {
            University = university;
            Salary = salary;
        }
    }
}