using System;
using System.Collections;
using System.Collections.Generic;
using Human;

namespace Lab14
{
    public class LinkedList : IEnumerable<IHuman>
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item Head { get; private set; }

        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item Tail { get; private set; }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count
        {
            get
            {
                if (Head == null)
                    return 0;

                int count = 0;
                Item tmp = Head;
                while (tmp != null)
                {
                    count++;
                    tmp = tmp.Next;
                }
                return count;
            }
        }

        /// <summary>
        /// Создание пустого списка
        /// </summary>
        public LinkedList()
        {
            Initialize(null);
        }

        /// <summary>
        /// Создание списка с заданным числом элементов (данные элементов заполняются по умолчанию)
        /// </summary>
        /// <param name="capacity">Размер списка</param>
        public LinkedList(int capacity)
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

            Item newItem = new Item();
            Initialize(newItem);

            for (int i = 1; i < capacity; i++)
            {
                Item tmp = new Item();
                Tail.Next = tmp;
                Tail = tmp;
            }
        }

        /// <summary>
        /// Создание списка с заданным числом элементов и заданным значением элементов
        /// </summary>
        /// <param name="capacity">Размер списка</param>
        /// <param name="data">Данные в каждой ячейке</param>
        public LinkedList(int capacity, IHuman data)
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

            Item item = new Item(data);
            Initialize(item);

            for (int i = 1; i < capacity; i++)
            {
                Item tmp = new Item(data);
                Tail.Next = tmp;
                Tail = tmp;
            }
        }

        /// <summary>
        /// Создание списка на основе другого списка такого же типа
        /// </summary>
        /// <param name="sample">Список, взятый за основу</param>
        public LinkedList(IEnumerable<IHuman> sample)
        {
            bool isFirstIteration = true;

            foreach (IHuman data in sample)
            {
                Item newItem = new Item(data);

                if (isFirstIteration)
                {
                    Initialize(newItem);
                    isFirstIteration = false;
                    continue;
                }

                Tail.Next = newItem;
                Tail = newItem;
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

                Item tmp = Head;

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

                Item newItem = new Item(value);

                if (index == 0)
                {
                    Item tmp = Head.Next;
                    Head = newItem;
                    Head.Next = tmp;
                    return;
                }

                Item current = Head.Next;
                Item previous = Head;

                for (int i = 0; i < Count - 1; i++)
                {
                    if (i == index - 1)
                    {
                        Item tmp = current.Next;
                        previous.Next = newItem;
                        newItem.Next = tmp;
                        current = newItem;
                    }
                    current = current.Next;
                    previous = previous.Next;
                }
            }
        }

        /// <summary>
        /// Вывод элементов списка в консоль
        /// </summary>
        public void Print()
        {
            if (Head == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("> LIST IS EMPTY <");
                Console.ResetColor();
                return;
            }

            Item tmp = Head;
            Random rnd = new Random();

            while (tmp != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (tmp.Data == null)
                {
                    Console.WriteLine("NULL >>");
                    tmp = tmp.Next;
                    continue;
                }
                Console.Write(tmp.Data.GetType().Name.ToUpper() + " >> ");

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
            
            Item tmp = Head;
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

        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="data">Добавляемый элемент</param>
        public void AddRight(IHuman data)
        {
            Item newItem = new Item(data);

            if (Head != null)
            {
                Tail.Next = newItem;
                Tail = newItem;
            }
            else
            {
                Initialize(newItem);
            }
        }

        /// <summary>
        /// Добавление элемента в начало списка
        /// </summary>
        /// <param name="data">Добавляемый элемент</param>
        public void AddLeft(IHuman data)
        {
            Item newItem = new Item(data);

            if (Head != null)
            {
                newItem.Next = Head;
                Head = newItem;
            }
            else
            {
                Initialize(newItem);
            }
        }

        /// <summary>
        /// Добавление элемента на заданную позицию (элемент, стоявший на заданной позиции будет сдвинут)
        /// </summary>
        /// <param name="index">Позиция элемента</param>
        /// <param name="data">Добавляемый элемент</param>
        public void AddAt(int index, IHuman data)
        {
            Item newItem = new Item(data);

            if (Head == null && index == 0)
            {
                Initialize(newItem);
                return;
            }

            if (index == 0)
            {
                newItem.Next = Head;
                Head = newItem;
                return;
            }

            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            Item tmp = Head;

            for (int i = 0; i < Count; i++)
            {
                if (i == index - 1)
                {
                    newItem.Next = tmp.Next;
                    tmp.Next = newItem;
                    return;
                }
                tmp = tmp.Next;
            }
        }

        /// <summary>
        /// Возвращает ссылку на элемент из списка
        /// </summary>
        /// <param name="data">Значение элемента</param>
        /// <returns>Ссылка на элемент с заданным значением</returns>
        public IHuman Find(IHuman data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data == data)
                    return tmp.Data;
                tmp = tmp.Next;
            }
            return default(IHuman);
        }

        /// <summary>
        /// Удаление из списка первого вхождения элемента с заданным значением
        /// </summary>
        /// <param name="data">Значение элемента</param>
        /// <returns>Был ли удален элемент</returns>
        public bool Remove(IHuman data)
        {
            if (Head == null)                   //если головной элемент пуст, то весь список также пуст
            {
                return false;
            }

            if (Head.Data == data)              //если первый объект равен заданному значению, то "удаляем" его и завершаем функцию
            {
                Head = Head.Next;
                return true;
            }

            Item previous = Head;
            Item current = Head.Next;

            while (current != null)
            {
                if (current.Data == data)
                {
                    previous.Next = current.Next;
                    return true;
                }
                previous = previous.Next;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Удаление из списка первого вхождения элемента с заданным значением имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Был ли удален элемент</returns>
        public bool Remove(string name)
        {
            if (Head == null)                                   //если головной элемент пуст, то весь список также пуст
            {
                return false;
            }

            if (Head.Data.Name.ToLower() == name.ToLower())     //если первый объект равен заданному значению, то "удаляем" его и завершаем функцию
            {
                Head = Head.Next;
                return true;
            }

            Item previous = Head;
            Item current = Head.Next;

            while (current != null)
            {
                if (current.Data.Name.ToLower() == name.ToLower())
                {
                    previous.Next = current.Next;
                    return true;
                }
                previous = previous.Next;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Удаление из списка первого вхождения элемента с заданным значением возраста
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <returns>Был ли удален элемент</returns>
        public bool Remove(int age)
        {
            if (Head == null)                       //если головной элемент пуст, то весь список также пуст
            {
                return false;
            }

            if (Head.Data.Age == age)             //если первый объект равен заданному значению, то "удаляем" его и завершаем функцию
            {
                Head = Head.Next;
                return true;
            }

            Item previous = Head;
            Item current = Head.Next;

            while (current != null)
            {
                if (current.Data.Age == age)
                {
                    previous.Next = current.Next;
                    return true;
                }
                previous = previous.Next;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Удаление из списка первого вхождения элемента с заданным значением гендера
        /// </summary>
        /// <param name="gender">Гендер</param>
        /// <returns></returns>
        public bool Remove(Gender gender)
        {
            if (Head == null)                           //если головной элемент пуст, то весь список также пуст
            {
                return false;
            }

            if (Head.Data.Gender == gender)             //если первый объект равен заданному значению, то "удаляем" его и завершаем функцию
            {
                Head = Head.Next;
                return true;
            }

            Item previous = Head;
            Item current = Head.Next;

            while (current != null)
            {
                if (current.Data.Gender == gender)
                {
                    previous.Next = current.Next;
                    return true;
                }
                previous = previous.Next;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Удаление из списка всех вхождений элементов с заданным значением
        /// </summary>
        /// <param name="data">Значение элементов</param>
        /// <returns>Был ли удален хотя бы один элемент</returns>
        public bool RemoveAll(IHuman data)
        {
            if (Head == null)                        //если пуст головной элемент, то пуст и весь список
                return false;

            LinkedList newList = new LinkedList();   //новый список
            Item tmp = Head;                         //текущий элемент
            bool isRemoved = false;

            while (tmp != null)                      //пока не конец списка
            {
                if (tmp.Data != data)                //если текущий объект не хранит заданное значение
                    newList.AddRight(tmp.Data);      //добавляем его в новый список
                else
                    isRemoved = true;
                tmp = tmp.Next;                      //переходим на следующий объект текущего списка
            }

            Head = newList.Head;                     //
            Tail = newList.Tail;                     //присвоение нового списка текущему списку

            return isRemoved;
        }

        /// <summary>
        /// Удаление из списка всех вхождений элементов с заданным значением имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Был ли удален хотя бы один элемент</returns>
        public bool RemoveAll(string name)
        {
            if (Head == null)                        //если пуст головной элемент, то пуст и весь список
                return false;

            LinkedList newList = new LinkedList();   //новый список
            Item tmp = Head;                         //текущий элемент
            bool isRemoved = false;

            while (tmp != null)                                 //пока не конец списка
            {
                if (tmp.Data.Name.ToLower() != name.ToLower())  //если текущий объект не хранит заданное значение
                    newList.AddRight(tmp.Data);                 //добавляем его в новый список
                else
                    isRemoved = true;
                tmp = tmp.Next;                      //переходим на следующий объект текущего списка
            }

            Head = newList.Head;                     //
            Tail = newList.Tail;                     //присвоение нового списка текущему списку

            return isRemoved;
        }

        /// <summary>
        /// Удаление из списка всех вхождений элементов с заданным значением возраста
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <returns>Был ли удален хотя бы один элемент</returns>
        public bool RemoveAll(int age)
        {
            if (Head == null)                        //если пуст головной элемент, то пуст и весь список
                return false;

            LinkedList newList = new LinkedList();   //новый список
            Item tmp = Head;                         //текущий элемент
            bool isRemoved = false;

            while (tmp != null)                      //пока не конец списка
            {
                if (tmp.Data.Age != age)           //если текущий объект не хранит заданное значение
                    newList.AddRight(tmp.Data);      //добавляем его в новый список
                else
                    isRemoved = true;
                tmp = tmp.Next;                      //переходим на следующий объект текущего списка
            }

            Head = newList.Head;                     //
            Tail = newList.Tail;                     //присвоение нового списка текущему списку

            return isRemoved;
        }

        /// <summary>
        /// Удаление из списка всех вхождений элементов с заданным значением гендера
        /// </summary>
        /// <param name="gender">Гендер</param>
        /// <returns>Был ли удален хотя бы один элемент</returns>
        public bool RemoveAll(Gender gender)
        {
            if (Head == null)                        //если пуст головной элемент, то пуст и весь список
                return false;

            LinkedList newList = new LinkedList();   //новый список
            Item tmp = Head;                         //текущий элемент
            bool isRemoved = false;

            while (tmp != null)                      //пока не конец списка
            {
                if (tmp.Data.Gender != gender)       //если текущий объект не хранит заданное значение
                    newList.AddRight(tmp.Data);      //добавляем его в новый список
                else
                    isRemoved = true;
                tmp = tmp.Next;                      //переходим на следующий объект текущего списка
            }

            Head = newList.Head;                     //
            Tail = newList.Tail;                     //присвоение нового списка текущему списку

            return isRemoved;
        }

        /// <summary>
        /// Удаление из списка элемента с заданным индексом
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            if (index == 0)
            {
                Head = Head.Next;
                return;
            }

            Item previous = Head;
            Item current = Head.Next;

            for (int i = 0; i < Count; i++)
            {
                if (i == index - 1)
                {
                    previous.Next = current.Next;
                    return;
                }
                previous = previous.Next;
                current = current.Next;
            }
        }

        /// <summary>
        /// Удаление из списка множества элементов
        /// </summary>
        /// <param name="startIndex">Номер с которого начинается удаление</param>
        /// <param name="count">Количество удаляемых элементов</param>
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

            Item tmp = Head;

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

        /// <summary>
        /// Удаление всех объектов из списка
        /// </summary>
        public void Clear()
        {
            Initialize(null);
        }

        /// <summary>
        /// Инициализация элементов Head и Tail заданным объектом
        /// </summary>
        /// <param name="item"></param>
        private void Initialize(Item item)
        {
            Head = item;
            Tail = item;
        }

        //Обобщенный нумератор
        public IEnumerator<IHuman> GetEnumerator()
        {
            Item tmp = Head;

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
