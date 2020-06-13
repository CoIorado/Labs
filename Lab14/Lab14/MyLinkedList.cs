using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab14
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class MyLinkedList<T> : IEnumerable<T>, ICloneable
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public MyItem<T> Head { get; private set; }

        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public MyItem<T> Tail { get; private set; }

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
                MyItem<T> tmp = Head;
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
        public MyLinkedList()
        {
            Initialize(null);
        }

        /// <summary>
        /// Создание списка с заданным числом элементов (данные элементов заполняются по умолчанию)
        /// </summary>
        /// <param name="capacity">Размер списка</param>
        public MyLinkedList(int capacity)
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

            MyItem<T> item = new MyItem<T>();
            Initialize(item);

            for (int i = 1; i < capacity; i++)
            {
                MyItem<T> tmp = new MyItem<T>();
                Tail.Next = tmp;
                Tail = tmp;
            }
        }

        /// <summary>
        /// Создание списка с заданным числом элементов и заданным значением элементов
        /// </summary>
        /// <param name="capacity">Размер списка</param>
        /// <param name="data">Данные в каждой ячейке</param>
        public MyLinkedList(int capacity, T data)
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

            MyItem<T> item = new MyItem<T>(data);
            Initialize(item);

            for (int i = 1; i < capacity; i++)
            {
                MyItem<T> tmp = new MyItem<T>(data);
                Tail.Next = tmp;
                Tail = tmp;
            }
        }

        /// <summary>
        /// Создание списка на основе другого списка такого же типа
        /// </summary>
        /// <param name="sample">Список, взятый за основу</param>
        public MyLinkedList(IEnumerable<T> sample)
        {
            bool isFirstIteration = true;

            foreach (T data in sample)
            {
                MyItem<T> newItem = new MyItem<T>(data);

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

        public T this[int index]
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

                MyItem<T> tmp = Head;

                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                        return tmp.Data;
                    tmp = tmp.Next;
                }

                return default(T);
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

                MyItem<T> newItem = new MyItem<T>(value);

                if (index == 0)
                {
                    MyItem<T> tmp = Head.Next;
                    Head = newItem;
                    Head.Next = tmp;
                    return;
                }

                MyItem<T> current = Head.Next;
                MyItem<T> previous = Head;

                for (int i = 0; i < Count - 1; i++)
                {
                    if (i == index - 1)
                    {
                        MyItem<T> tmp = current.Next;
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

            MyItem<T> tmp = Head;
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
                Console.Write(tmp.Data.GetType().Name.ToUpper() + " >> ");

                Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 16);
                Console.WriteLine(tmp.ToString());
                tmp = tmp.Next;
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Добавление произвольного количества элементов в конец списка
        /// </summary>
        /// <param name="data">Добавляемые элементы</param>
        public void AddRight(params T[] data)
        {
            if (data.Length == 0)
            {
                return;
            }

            foreach (T d in data)
            {
                MyItem<T> item = new MyItem<T>(d);

                if (Head != null)               //если список не пустой
                {
                    Tail.Next = item;
                    Tail = item;
                }
                else
                {
                    Initialize(item);
                }
            }
        }

        /// <summary>
        /// Добавление произвольного количества элементов в начало списка
        /// </summary>
        /// <param name="data">Добавляемые элементы</param>
        public void AddLeft(params T[] data)
        {
            if (data.Length == 0)
            {
                return;
            }

            int flag = 1;                                           //флаг на случай, если список пуст

            if (Head == null)
            {
                Initialize(new MyItem<T>(data[data.Length-1]));     //инициализируем список последним элементом из массива data
                flag++;
            }

            for (int i = data.Length - flag; i >= 0; i--)           //начинаем цикл с data - 2 вместо data - 1 если список был пуст
            {
                MyItem<T> item = new MyItem<T>(data[i]);
                item.Next = Head;
                Head = item;
            }
        }

        /// <summary>
        /// Добавление одного элемента на заданную позицию (элемент, стоявший на заданной позиции будет сдвинут)
        /// </summary>
        /// <param name="index">Позиция элемента</param>
        /// <param name="data">Добавляемый элемент</param>
        public void AddAt(int index, T data)
        {
            MyItem<T> newItem = new MyItem<T>(data);

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

            MyItem<T> tmp = Head;

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
        public T Find(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            MyItem<T> tmp = Head;

            while (tmp != null)
            {
                if (tmp.Data.Equals(data))
                    return tmp.Data;
                tmp = tmp.Next;
            }
            return default(T);
        }

        /// <summary>
        /// Удаление из списка первого вхождения элемента с заданным значением
        /// </summary>
        /// <param name="data">Значение элемента</param>
        public void Remove(T data)
        {
            if (Head == null)                       //если головной элемент пуст, то весь список также пуст
            {
                return;
            }

            if (data == null && Head.Data == null || Head.Data.Equals(data))
            {
                Head = Head.Next;
                return;
            }

            MyItem<T> previous = Head;
            MyItem<T> current = Head.Next;

            while (current != null)
            {
                if (data == null && current.Data == null || current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    return;
                }
                previous = previous.Next;
                current = current.Next;
            }
        }

        /// <summary>
        /// Удаление из списка всех вхождений элементов с заданным значением
        /// </summary>
        /// <param name="data">Значение элементов</param>
        public void RemoveAll(T data)
        {
            if (Head == null)                   //если пуст головной элемент, то пуст и весь список
                return;

            MyLinkedList<T> newList = new MyLinkedList<T>();    //новый списк
            MyItem<T> tmp = Head;                               //текущий элемент

            while (tmp != null)                 //пока не конец списка
            {
                if (data == null && tmp.Data == null || tmp.Data.Equals(data))
                {
                    tmp = tmp.Next;
                    continue;
                }
                newList.AddRight(tmp.Data);     
                tmp = tmp.Next;                 //переходим на следующий объект текущего списка
            }

            Head = newList.Head;                //
            Tail = newList.Tail;                //присвоение нового списка текущему списку
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

            MyItem<T> previous = Head;
            MyItem<T> current = Head.Next;

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

            MyItem<T> tmp = Head;

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
        private void Initialize(MyItem<T> item)
        {
            Head = item;
            Tail = item;
        }

        //Обобщенный нумератор
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        //Необобщенный нумератор
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyLinkedList<T> ShallowCopy()
        {
            return (MyLinkedList<T>)this.MemberwiseClone();
        }

        public object Clone()
        {
            MyLinkedList<T> cloneList = new MyLinkedList<T>();

            MyItem<T> tmp = Head;

            while (tmp != null)
            {
                cloneList.AddRight(tmp.Data);
                tmp = tmp.Next;
            }

            return cloneList;
        }
    }
}