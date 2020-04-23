using System;
using System.Collections.Generic;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////
            //  ЧАСТЬ 1  //
            ///////////////

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ЧАСТЬ 1");
            Console.ResetColor();

            IHuman[] people =
                {
                    new Person("Bob", "Marley", 26, "male"),
                    new Person("Homer", "Simpson", 36, "male"),
                    new Educator("Ann", "Smith", 35, "female", "HSE", 27000, "PI-19-1", "E-18-2", "BI-17-3"),
                    new Student("Jake", "Johnson", 19, "male", "HSE", "PI-19-1"),
                };

            Console.WriteLine("Сортировка по возрасту:");
            SortByAge(people);                                              //сортировка по возрасту
            foreach (Person person in people)
            {
                person.DisplayInfo();
                Console.WriteLine();
            }

            Console.WriteLine("Сортировка по имени:");
            Array.Sort(people, new SortByName());
            foreach (Person person in people)
            {
                person.DisplayInfo();
                Console.WriteLine();
            }

            ///////////////
            //  ЧАСТЬ 2  //
            ///////////////

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ЧАСТЬ 2");
            Console.ResetColor();

            IHuman[] males = Get(people, "male");                           //
            foreach (Person male in males)                                  //получение и
            {                                                               //вывод объектов
                male.DisplayInfo();                                         //мужского пола
                Console.WriteLine();                                        //из массива людей
            }                                                               //

            string[] femaleNames = GetNames(people, "female");              //
            foreach (string name in femaleNames)                            //получение и вывод всех имен
            {                                                               //
                Console.WriteLine(name);                                    //объектов женского пола
                Console.WriteLine();                                        //из массива людей
            }                                                               //


            IHuman oldestHuman = GetOldest(people);                         //получение и вывод объекта
            oldestHuman.DisplayInfo();                                      //с самым большим возрастом
            Console.WriteLine();

            Person clone = (Person)(people[2] as Person).Clone();           //клонирование объекта
            clone.DisplayInfo();                                            //и вывод информации
            Console.WriteLine();
        }

        public static IHuman[] Get(IHuman[] people, string gender)
        {
            if (!(gender.ToLower().Equals("male") || gender.ToLower().Equals("female")))
                return null;

            int genderCount = 0;
            foreach (IHuman person in people)
            {
                if (person.Gender.Equals(gender))
                    genderCount++;
            }

            if (genderCount == 0)
                return new Person[0];

            IHuman[] result = new IHuman[genderCount];
            int i = 0;
            foreach (IHuman person in people)
            {
                if (person.Gender.Equals(gender))
                    result[i++] =person;
            }

            return result;
        }       //получение всех объектов заданного пола из заданного массива объектов типа IHuman
        public static string[] GetNames(IHuman[] people, string gender)
        {
            if (!(gender.ToLower().Equals("male") || gender.ToLower().Equals("female")))
                return null;

            int genderCount = 0;
            foreach (IHuman person in people)
            {
                if (person.Gender.Equals(gender))
                    genderCount++;
            }

            if (genderCount == 0)
                return new string[0];

            string[] result = new string[genderCount];
            int i = 0;
            foreach (IHuman person in people)
            {
                if (person.Gender.Equals(gender))
                    result[i++] = $"{person.Name} {person.LastName}";
            }

            return result;
        }  //получение всех имен + фамилий заданного пола из заданного массива объектов типа IHuman
        public static IHuman GetOldest(IHuman[] people)
        {
            int maxAge = -1;

            foreach(IHuman person in people)
                if (person.Age > maxAge)
                    maxAge = person.Age;

            IHuman result = default;
            foreach (IHuman person in people)
                if (person.Age == maxAge)
                    result = person;

            return result;
        }                  //получение самого старшего человека (первого по списку, если их несколько) из массива объектов типа Person
        public static void SortByAge(IHuman[] persons)
        {
            if (persons.Length < 2)
                return;

            IHuman temp;
            for (int i = 0; i < persons.Length - 1; i++)
            {
                for (int j = i + 1; j < persons.Length; j++)
                {
                    if (persons[i].Age > persons[j].Age)
                    {
                        temp = persons[i];
                        persons[i] = persons[j];
                        persons[j] = temp;
                    }
                }
            }
        }                   //сортировка объектов по возрасту
        public static IHuman Find(IHuman[] persons, string name)
        {
            if (persons.Length == 0)
                return null;

            foreach (IHuman person in persons)
                if (person.Name.ToLower().Equals(name))
                    return person;

            return null;
        }         //поиск объекта по имени
        public static IHuman Find(IHuman[] persons, int age)
        {
            if (age <= 0 || age > 100)
                return null;

            foreach (IHuman person in persons)
                if (person.Age == age)
                    return person;

            return null;
        }             //поиск объекта по возрасту
        public static bool DoesExist(IHuman[] people, Type type)            //проверяет, существует ли в указанном массиве хоть один объект заданного типа
        {
            if (people.Length < 1)
                return false;

            foreach (IHuman p in people)
            {
                if (p.GetType().Equals(type))
                    return true;
            }

            return false;
        }
    }

    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message) { }
    }
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message) : base(message) { }
    }
    public class InvalidLastNameException : Exception
    {
        public InvalidLastNameException(string message) : base(message) { }
    }
    public class InvalidUniversityException : Exception
    {
        public InvalidUniversityException(string message) : base(message) { }
    }
    public class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message) { }
    }
    public class InvalidGroupException : Exception
    {
        public InvalidGroupException(string message) : base(message) { }
    }
    public class InvalidGenderException : Exception
    {
        public InvalidGenderException(string message) : base(message) { }
    }
}