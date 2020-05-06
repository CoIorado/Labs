using System;
using System.Collections;
using System.Collections.Generic;
using Human;

namespace Lab12
{
    public class DoubleLinkedList : IEnumerable<IHuman>
    {
        public DItem Head { get; private set; }

        public DItem Tail { get; private set; }

        public int Count
        {
            get
            {
                if (Head == null)
                    return 0;

                int count = 0;
                DItem tmp = Head;
                while (tmp != null)
                {
                    count++;
                    tmp = tmp.Next;
                }
                return count;
            }
        }

        public DoubleLinkedList()
        {
            Initialize(null);
        }

        public DoubleLinkedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new IndexOutOfRangeException(nameof(capacity));
            }
            if (capacity == 0)
            {
                Initialize(null);
                return;
            }

            DItem tmp = new DItem();
            Initialize(tmp);

            for (int i = 1; i < capacity; i++)
            {
                tmp = new DItem();
                Tail.Next = tmp;
                tmp.Previous = Tail;
                Tail = tmp;
            }
        }

        public DoubleLinkedList(int capacity, IHuman data)
        {
            if (capacity < 0)
            {
                throw new IndexOutOfRangeException(nameof(capacity));
            }
            if (capacity == 0)
            {
                Initialize(new DItem(data));
                return;
            }

            DItem tmp = new DItem(data);
            Initialize(tmp);

            //Добавление в начало
            for (int i = 1; i < capacity; i++)
            {
                tmp = new DItem(data);
                Tail.Next = tmp;
                tmp.Previous = Tail;
                Tail = tmp;
            }

            //Добавление в конец
            //for (int i = capacity; i > 1; i--)
            //{
            //    tmp = new DItem(data);
            //    Head.Previous = tmp;
            //    tmp.Next = Head;
            //    Head = tmp;
            //}
        }

        public DoubleLinkedList(IEnumerable<IHuman> sample)
        {
            bool isFirstIteration = true;

            foreach (IHuman human in sample)
            {
                DItem tmp = new DItem(human);

                if (isFirstIteration)
                {
                    Initialize(tmp);
                    isFirstIteration = false;
                    continue;
                }

                Tail.Next = tmp;
                tmp.Previous = Tail;
                Tail = tmp;
            }
        }

        public IHuman this[int index]
        {
            get
            {
                if (Head == null)
                {
                    throw new NullReferenceException();
                }

                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }

                DItem tmp = Head;

                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                        return tmp.Data;
                    tmp = tmp.Next;
                }

                return default(IHuman);
            }
            set
            {
                if (Head == null)
                {
                    throw new NullReferenceException();
                }

                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }

                DItem newItem = new DItem(value);

                if (index == 0)
                {
                    DItem saveNext = Head.Next;
                    Head = newItem;
                    Head.Next = saveNext;
                    return;
                }

                if (index == Count - 1)
                {
                    Tail.Previous.Next = newItem;
                    newItem.Previous = Tail.Previous;
                    Tail = newItem;
                    return;
                }

                DItem tmp = Head;

                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                    {
                        tmp.Previous.Next = newItem;
                        newItem.Previous = tmp.Previous;
                        newItem.Next = tmp.Next;
                        newItem.Next.Previous = newItem;
                        return;
                    }
                    tmp = tmp.Next;
                }
            }
        }

        public void Print()
        {
            if (Head == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(">> LIST IS EMPTY <<");
                Console.ResetColor();
                return;
            }

            DItem tmp = Head;
            Random rnd = new Random();

            while (tmp != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (tmp.Data == null)
                {
                    Console.WriteLine("NULL");
                    tmp = tmp.Next;
                    continue;
                }
                Console.Write(tmp.Data.GetType().Name.ToUpper() + " >> ") ;

                Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 16);
                Console.WriteLine(tmp.ToString());
                tmp = tmp.Next;
            }
            Console.WriteLine();
            Console.ResetColor();
        }

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

            DItem tmp = Head;
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

        public void AddRight(IHuman data)
        {
            DItem newItem = new DItem(data);

            if (Tail == null)
            {
                Initialize(newItem);
                return;
            }

            newItem.Previous = Tail;
            Tail.Next = newItem;
            Tail = newItem;
        }

        public void AddLeft(IHuman data)
        {
            DItem newItem = new DItem(data);

            if (Head == null)
            {
                Initialize(newItem);
                return;
            }

            Head.Previous = newItem;
            newItem.Next = Head;
            Head = newItem;
        }

        public void AddAt(int index, IHuman data)
        {
            DItem newItem = new DItem(data);

            if (Head == null && index == 0)
            {
                Initialize(newItem);
                return;
            }

            if (index == 0)
            {
                Head.Previous = newItem;
                newItem.Next = Head;
                Head = newItem;
                return;
            }

            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            DItem tmp = Head;

            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    newItem.Next = tmp;
                    newItem.Previous = tmp.Previous;
                    tmp.Previous.Next = newItem;
                    tmp.Previous = newItem;
                    return;
                }
                tmp = tmp.Next;
            }
        }

        public IHuman Find(IHuman data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data == data)
                    return tmp.Data;
                tmp = tmp.Next;
            }

            return default(IHuman);
        }

        public bool Contains(IHuman data)
        {
            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data == data)
                    return true;
                tmp = tmp.Next;
            }
            return false;
        }

        public bool Contains(string name)
        {
            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Name.ToLower() == name.ToLower())
                    return true;
                tmp = tmp.Next;
            }
            return false;
        }

        public bool Contains(int age)
        {
            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Age == age)
                    return true;
                tmp = tmp.Next;
            }
            return false;
        }

        public bool Contains(Gender gender)
        {
            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Gender == gender)
                    return true;
                tmp = tmp.Next;
            }
            return false;
        }

        public bool Remove(IHuman data)
        {
            if (Head == null)
            {
                return false;
            }

            if (Head.Data == data)
            {
                Head = Head.Next;
                return true;
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data == data)
                {
                    tmp.Previous.Next = tmp.Next;
                    if (tmp != Tail)
                        tmp.Next.Previous = tmp.Previous;
                    return true;
                }
                tmp = tmp.Next;
            }

            return false;
        }

        public bool Remove(string name)
        {
            if (Head == null)
            {
                return false;
            }

            if (Head.Data.Name.ToLower() == name.ToLower())
            {
                Head = Head.Next;
                return true;
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Name.ToLower() == name.ToLower())
                {
                    tmp.Previous.Next = tmp.Next;
                    if (tmp != Tail)
                        tmp.Next.Previous = tmp.Previous;
                    return true;
                }
                tmp = tmp.Next;
            }

            return false;
        }

        public bool Remove(int age)
        {
            if (Head == null)
            {
                return false;
            }

            if (Head.Data.Age == age)
            {
                Head = Head.Next;
                return false;
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Age == age)
                {
                    tmp.Previous.Next = tmp.Next;
                    if (tmp != Tail)
                        tmp.Next.Previous = tmp.Previous;
                    return true;
                }
                tmp = tmp.Next;
            }

            return false;
        }

        public bool Remove(Gender gender)
        {
            if (Head == null)
            {
                return false;
            }

            if (Head.Data.Gender == gender)
            {
                Head = Head.Next;
                return true;
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Gender == gender)
                {
                    tmp.Previous.Next = tmp.Next;
                    if (tmp != Tail)
                        tmp.Next.Previous = tmp.Previous;
                    return true;
                }
                tmp = tmp.Next;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (Head == null)
            {
                return;
            }

            DItem tmp = Head;

            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    if (tmp == Head)
                    {
                        Head = Head.Next;
                    }
                    else if (tmp == Tail)
                    {
                        Tail.Previous.Next = null;
                    }
                    else
                    {
                        tmp.Previous.Next = tmp.Next;
                        tmp.Next.Previous = tmp.Previous;
                    }
                    return;
                }
                tmp = tmp.Next;
            }
        }

        public bool RemoveAll(IHuman data)
        {
            if (Head == null)
            {
                return false;
            }

            bool isRemoved = false;
            while (Head.Data == data)
            {
                Head = Head.Next;
                isRemoved = true;
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data == data)
                {
                    tmp.Previous.Next = tmp.Next;
                    if (tmp != Tail)
                        tmp.Next.Previous = tmp.Previous;
                    isRemoved = true;
                }
                tmp = tmp.Next;
            }

            return isRemoved;
        }

        public bool RemoveAll(string name)
        {
            if (Head == null)
            {
                return false;
            }

            bool isRemoved = false;
            while (Head.Data.Name.ToLower() == name.ToLower())
            {
                Head = Head.Next;
                isRemoved = true;
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Name.ToLower() == name.ToLower())
                {
                    tmp.Previous.Next = tmp.Next;
                    if (tmp != Tail)
                        tmp.Next.Previous = tmp.Previous;
                    isRemoved = true;
                }
                tmp = tmp.Next;
            }

            return isRemoved;
        }

        public bool RemoveAll(int age)
        {
            if (Head == null)
            {
                return false;
            }

            bool isRemoved = false;
            while (Head.Data.Age == age)
            {
                Head = Head.Next;
                isRemoved = true;
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Age == age)
                {
                    tmp.Previous.Next = tmp.Next;
                    if (tmp != Tail)
                        tmp.Next.Previous = tmp.Previous;
                    isRemoved = true;
                }
                tmp = tmp.Next;
            }

            return isRemoved;
        }

        public bool RemoveAll(Gender gender)
        {
            if (Head == null)
            {
                return true;
            }

            bool isRemoved = false;
            while (Head.Data.Gender == gender)
            {
                Head = Head.Next;
                isRemoved = true;
            }

            DItem tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Gender == gender)
                {
                    tmp.Previous.Next = tmp.Next;
                    if (tmp != Tail)
                        tmp.Next.Previous = tmp.Previous;
                    isRemoved = true;
                }
                tmp = tmp.Next;
            }

            return isRemoved;
        }

        public void RemoveRange(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= Count || (startIndex + count) > Count)
            {
                throw new IndexOutOfRangeException(nameof(startIndex));
            }
            if (count == 0)
            {
                return;
            }
            if (count < 0)
            {
                throw new NegativeCountException(nameof(count));
            }

            DItem tmp = Head;

            for (int i = 0; i < Count; i++)
            {
                if (i == startIndex)
                {
                    for (int j = 0; j < count; j++)
                        this.RemoveAt(i);
                }
                tmp = tmp.Next;
            }
        }

        public void Clear()
        {
            Initialize(null);
        }

        public void Initialize(DItem item)
        {
            Head = item;
            Tail = item;
        }

        public IEnumerator<IHuman> GetEnumerator()
        {
            DItem tmp = Head;

            while (tmp != null)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}