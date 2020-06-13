using System;
using Human;
using System.Collections.Generic;

namespace Lab13
{
    public class MyCollection : LinkedList<IHuman>
    {
        public MyCollection()
        {
            Random rnd = new Random();
            object syncLock = new object();

            int capacity = rnd.Next(10, 30);
            for (int i = 0; i < capacity; i++)
            {
                IHuman human;
                lock (syncLock)
                {
                    human = RandomHuman(rnd);
                }
                this.AddRight(human);
            }
        }

        public MyCollection(int capacity)
        {
            if (capacity == 0)
            {
                Initialize(null);
            }

            Random rnd = new Random();
            object syncLock = new object();

            for (int i = 0; i < capacity; i++)
            {
                IHuman human;
                lock (syncLock)
                {
                    human = RandomHuman(rnd);
                }
                this.AddRight(human);
            }
        }

        public MyCollection(int capacity, IHuman data) : base(capacity, data) { }

        public MyCollection(IEnumerable<IHuman> sample) : base(sample) { }

        public void PrintTable()
        {
            if (Head == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("> LIST IS EMPTY <");
                Console.ResetColor();
                return;
            }

            int typeL = "Type".Length, nameL = "Name".Length, lastNameL = "Lastname".Length, genderL = "Gender".Length, ageL = "Age".Length, universityL = "University".Length, salaryL = "Salary".Length, groupsL = "Group(s)".Length;

            Item<IHuman> tmp = Head;
            while (tmp != null)
            {
                if (tmp.Data == null)
                {
                    tmp = tmp.Next;
                    continue;
                }

                if (tmp.Data.GetType().Name.Length > typeL)
                    typeL = tmp.Data.GetType().Name.Length;

                if (tmp.Data.Name.Length > nameL)
                    nameL = tmp.Data.Name.Length;

                if (tmp.Data.LastName.Length > lastNameL)
                    lastNameL = tmp.Data.LastName.Length;

                if (tmp.Data.Gender.ToString().Length > genderL)
                    genderL = tmp.Data.Gender.ToString().Length;

                if (tmp.Data.Age.ToString().Length > ageL)
                    ageL = tmp.Data.Age.ToString().Length;

                if (tmp.Data.GetType() == typeof(Student) && (tmp.Data as Student).University.Length > universityL)
                    universityL = (tmp.Data as Student).University.Length;

                if (tmp.Data.GetType() == typeof(Educator) && (tmp.Data as Educator).University.Length > universityL)
                    universityL = (tmp.Data as Educator).University.Length;

                if (tmp.Data.GetType() == typeof(Educator) && (tmp.Data as Educator).Salary.ToString().Length > salaryL)
                    salaryL = (tmp.Data as Educator).Salary.ToString().Length;

                if (tmp.Data.GetType() == typeof(Educator))
                {
                    string groups = "";
                    foreach (string group in (tmp.Data as Educator).Groups)
                        groups += group + ", ";
                    groups = groups.Remove(groups.Length - 2, 2);

                    if (groups.Length > groupsL)
                        groupsL = groups.Length;
                }

                tmp = tmp.Next;
            }

            string divider = "  |  ";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("| Index");
            Console.Write(divider.Remove(0, 1));

            Console.Write("Type");
            for (int i = 0; i < typeL - "Type".Length; i++)
                Console.Write(" ");
            Console.Write(divider);

            Console.Write("Name");
            for (int i = 0; i < nameL - "Name".Length; i++)
                Console.Write(" ");
            Console.Write(divider);

            Console.Write("Lastname");
            for (int i = 0; i < lastNameL - "Lastname".Length; i++)
                Console.Write(" ");
            Console.Write(divider);

            Console.Write("Gender");
            for (int i = 0; i < genderL - "Gender".Length; i++)
                Console.Write(" ");
            Console.Write(divider);

            Console.Write("Age");
            for (int i = 0; i < ageL - "Age".Length; i++)
                Console.Write(" ");
            Console.Write(divider);

            Console.Write("University");
            for (int i = 0; i < universityL - "University".Length; i++)
                Console.Write(" ");
            Console.Write(divider);

            Console.Write("Salary");
            for (int i = 0; i < salaryL - "Salary".Length; i++)
                Console.Write(" ");
            Console.Write(divider);

            Console.Write("Group(s)");
            for (int i = 0; i < groupsL - "Group(s)".Length; i++)
                Console.Write(" ");
            Console.Write("|");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(".");
            Console.ResetColor();
            Console.WriteLine();

            int index = 0;
            tmp = Head;
            while (tmp != null)
            {
                if (tmp.Data != null)
                {
                    if (tmp.Data.GetType() == typeof(Person))
                        Console.ForegroundColor = ConsoleColor.Cyan;

                    if (tmp.Data.GetType() == typeof(Student))
                        Console.ForegroundColor = ConsoleColor.Blue;

                    if (tmp.Data.GetType() == typeof(Educator))
                        Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (index < 10)
                    Console.Write($"|   {index} ");
                if (index >= 10)
                    Console.Write($"|   {index}");
                Console.Write(divider);

                if (tmp.Data == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("NULL");
                    tmp = tmp.Next;
                    continue;
                }

                Console.Write(tmp.Data.GetType().Name);
                for (int i = 0; i < typeL - tmp.Data.GetType().Name.Length; i++)
                    Console.Write(" ");
                Console.Write(divider);

                Console.Write(tmp.Data.Name);
                for (int i = 0; i < nameL - tmp.Data.Name.Length; i++)
                    Console.Write(" ");
                Console.Write(divider);

                Console.Write(tmp.Data.LastName);
                for (int i = 0; i < lastNameL - tmp.Data.LastName.Length; i++)
                    Console.Write(" ");
                Console.Write(divider);

                Console.Write(tmp.Data.Gender.ToString());
                for (int i = 0; i < genderL - tmp.Data.Gender.ToString().Length; i++)
                    Console.Write(" ");
                Console.Write(divider);

                Console.Write(tmp.Data.Age);
                for (int i = 0; i < ageL - tmp.Data.Age.ToString().Length; i++)
                    Console.Write(" ");
                Console.Write(divider);

                if (tmp.Data.GetType() == typeof(Person))
                {
                    Console.Write("-");
                    for (int i = 0; i < universityL - 1; i++)
                        Console.Write(" ");
                    Console.Write(divider);

                    Console.Write("-");
                    for (int i = 0; i < salaryL - 1; i++)
                        Console.Write(" ");
                    Console.Write(divider);

                    Console.Write("-");
                    for (int i = 0; i < groupsL - 1; i++)
                        Console.Write(" ");
                    Console.Write("|");
                }

                if (tmp.Data.GetType() == typeof(Student))
                {
                    Console.Write((tmp.Data as Student).University);
                    for (int i = 0; i < universityL - (tmp.Data as Student).University.Length; i++)
                        Console.Write(" ");
                    Console.Write(divider);

                    Console.Write("-");
                    for (int i = 0; i < salaryL - 1; i++)
                        Console.Write(" ");
                    Console.Write(divider);

                    Console.Write((tmp.Data as Student).Group);
                    for (int i = 0; i < groupsL - (tmp.Data as Student).Group.Length; i++)
                        Console.Write(" ");
                    Console.Write("|");
                }

                if (tmp.Data.GetType() == typeof(Educator))
                {
                    Console.Write((tmp.Data as Educator).University);
                    for (int i = 0; i < universityL - (tmp.Data as Educator).University.Length; i++)
                        Console.Write(" ");
                    Console.Write(divider);

                    Console.Write((tmp.Data as Educator).Salary);
                    for (int i = 0; i < salaryL - (tmp.Data as Educator).Salary.ToString().Length; i++)
                        Console.Write(" ");
                    Console.Write(divider);

                    string groups = "";
                    foreach (string group in (tmp.Data as Educator).Groups)
                        groups += group + ", ";
                    groups = groups.Remove(groups.Length - 2, 2);
                    Console.Write(groups);

                    for (int i = 0; i < groupsL - groups.Length; i++)
                        Console.Write(" ");
                    Console.Write("|");
                }

                Console.WriteLine();
                Console.ResetColor();
                index++;
                tmp = tmp.Next;
            }
        }

        public void Sort(SortType sortType)
        {
            switch (sortType)
            {
                case SortType.Age:
                    SortByAge();
                    return;
                case SortType.Gender:
                    SortByGender();
                    return;
                case SortType.Name:
                    SortByName();
                    return;
                case SortType.Lastname:
                    SortByLastName();
                    return;
                case SortType.Type:
                    SortByType();
                    return;
            }
        }

        private void SortByAge()
        {
            IHuman tmp;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (this[j + 1].Age < this[j].Age)
                    {
                        tmp = this[j + 1];
                        this[j + 1] = this[j];
                        this[j] = tmp;
                    }
                }
            }
        }

        private void SortByName()
        {
            IHuman tmp;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (this[j + 1].Name.CompareTo(this[j].Name) == -1)
                    {
                        tmp = this[j + 1];
                        this[j + 1] = this[j];
                        this[j] = tmp;
                    }
                }
            }

        }

        private void SortByLastName()
        {
            IHuman tmp;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (this[j + 1].LastName.CompareTo(this[j].LastName) == -1)
                    {
                        tmp = this[j + 1];
                        this[j + 1] = this[j];
                        this[j] = tmp;
                    }
                }
            }

        }

        private void SortByGender()
        {
            IHuman tmp;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (this[j + 1].Gender > this[j].Gender)
                    {
                        tmp = this[j + 1];
                        this[j + 1] = this[j];
                        this[j] = tmp;
                    }
                }
            }
        }

        private void SortByType()
        {
            IHuman tmp;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (this[j + 1] is Person && this[j] is Student || this[j + 1] is Person && this[j] is Educator)
                    {
                        tmp = this[j + 1];
                        this[j + 1] = this[j];
                        this[j] = tmp;
                    }
                    if (this[j + 1] is Student && this[j] is Educator)
                    {
                        tmp = this[j + 1];
                        this[j + 1] = this[j];
                        this[j] = tmp;
                    }
                }
            }
        }

        private static IHuman RandomHuman(Random rnd)
        {
            string[] types = { "Person", "Student", "Educator" };
            string[] maleNames = { "Noah", "William", "James", "Oliver", "Benjamin", "Elijah", "Lucas", "Mason", "Alexander", "Ethan", "Jacob", "Michael", "Daniel", "Henry", "Jackson", "Sebastian" };
            string[] femaleNames = { "Olivia", "Emma", "Isabella", "Sophia", "Mia", "Amelia", "Evelyn", "Emily", "Ella", "Scarlett", "Madison", "Luna", "Grace", "Chloe", "Penelope", "Riley" };
            string[] lastNames = { "Smith", "Hall", "Stewart", "Price", "Johnson", "Allen", "Bennett", "Williams", "Jones", "Brown", "Davis", "Perry", "Cooper", "Adams", "Baker", "Thomas", "Taylor", "Jackson", "White", "Harris", "Martin", "Howard" };
            string[] universities = { "California Institute of Technology", "Stanford University", "University of Washington", "Northwestern University", "Duke University", "Cornell University", "Columbia University", "Johns Hopkins University", "University of Pennsylvania", "University of Chicago", "Yale University", "Harvard University", "Princeton University", "Massachusetts Institute of Technology" };
            string[] groupNames = { "PI", "EC", "PH", "MATH", "HIST", "CH", "IT", "ART", "PE", "BS", "SS", "LAT", "PSHE", "WW", "LR", "PT" };

            string randomType = types[rnd.Next(0, types.Length)];

            Gender randomGender = (Gender)rnd.Next(0, 2);

            string randomName = default;
            if (randomGender == Gender.Male)
                randomName = maleNames[rnd.Next(0, maleNames.Length)];
            else
                randomName = femaleNames[rnd.Next(0, femaleNames.Length)];

            string randomLastName = lastNames[rnd.Next(0, lastNames.Length)];

            int randomAge = rnd.Next(1, 100);

            string randomUniversity = universities[rnd.Next(0, universities.Length)];

            int randomSalary = rnd.Next(5000, 200000);

            string[] randomGroups = new string[rnd.Next(1, 6)];
            for (int i = 0; i < randomGroups.Length; i++)
            {
                string randomGroup = $"{groupNames[rnd.Next(0, groupNames.Length)]}-{rnd.Next(10, 21)}-{rnd.Next(1, 6)}";
                randomGroups[i] = randomGroup;
            }

            switch (randomType)
            {
                case "Person":
                    return new Person(randomName, randomLastName, randomAge, randomGender);
                case "Student":
                    return new Student(randomName, randomLastName, randomAge, randomGender, randomUniversity, randomGroups[rnd.Next(0, randomGroups.Length)]);
                case "Educator":
                    return new Educator(randomName, randomLastName, randomAge, randomGender, randomUniversity, randomSalary, randomGroups);
            }

            return default(IHuman);
        }
    }
}
