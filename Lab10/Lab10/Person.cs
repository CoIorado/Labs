using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Person : IHuman, ICloneable, IComparable<Person>
    {
        public void Move()
        {
            //moving
        }

        public void Eat()
        {
            //eating
        }

        public void Sleep()
        {
            //sleeping
        }

        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0 && value < 100)
                    age = value;
                else
                    throw new InvalidAgeException("Некорректное количество лет.");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 2 && value.Length < 15)
                    name = value;
                else
                    throw new InvalidNameException("Некорректное значение имени.");
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value.Length > 2 && value.Length < 20)
                    lastName = value;
                else
                    throw new InvalidLastNameException("Некорректное значение фамилии.");
            }
        }

        private string gender;
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value.ToLower().Equals("male") || value.ToLower().Equals("female"))
                    gender = value;
                else
                    throw new InvalidGenderException("Некорректное значение пола.");
            }
        }

        public Person(string name, string lastName, int age, string gender)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        public virtual void DisplayInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("> Type: ");

            Console.ResetColor();
            Console.WriteLine(this.GetType().Name);

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
        }   //правильный метод

        public void DisplayInfoPerson()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("> Type: ");

            Console.ResetColor();
            Console.WriteLine("Person");

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

        }   //неправильный метод, так как: 1) он предназначен для вывода информации только об объекте конкретного типа (в этом случае типа Person); 2) он будет присутствовать по всех производных классах, когда должен только в одном; 3) значительно усложняется вызов этого метода в полиморфическом массиве => нужен переопределяемый каждым производным классом метод с одним и тем же названием

        public virtual object Clone()
        {
            return new Person(Name, LastName, Age, Gender);
        }

        public virtual Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public int CompareTo(Person other)
        {
            if (this.Age > other.Age) return 1;
            if (this.Age < other.Age) return -1;

            return 0;
        }
    }
}