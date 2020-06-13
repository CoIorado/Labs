using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab13
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class LinkedList<T> : IEnumerable<T>, ICloneable
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<T> Head { get; protected set; }

        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<T> Tail { get; protected set; }

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
                Item<T> tmp = Head;
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

            Item<T> item = new Item<T>();
            Initialize(item);

            for (int i = 1; i < capacity; i++)
            {
                Item<T> tmp = new Item<T>();
                Tail.Next = tmp;
                Tail = tmp;
            }
        }

        /// <summary>
        /// Создание списка с заданным числом элементов и заданным значением элементов
        /// </summary>
        /// <param name="capacity">Размер списка</param>
        /// <param name="data">Данные в каждой ячейке</param>
        public LinkedList(int capacity, T data)
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

            Item<T> item = new Item<T>(data);
            Initialize(item);

            for (int i = 1; i < capacity; i++)
            {
                Item<T> tmp = new Item<T>(data);
                Tail.Next = tmp;
                Tail = tmp;
            }
        }

        /// <summary>
        /// Создание списка на основе другого списка такого же типа
        /// </summary>
        /// <param name="sample">Список, взятый за основу</param>
        public LinkedList(IEnumerable<T> sample)
        {
            bool isFirstIteration = true;

            foreach (T data in sample)
            {
                Item<T> newItem = new Item<T>(data);

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

                Item<T> tmp = Head;

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

                Item<T> newItem = new Item<T>(value);

                if (index == 0)
                {
                    Item<T> tmp = Head.Next;
                    Head = newItem;
                    Head.Next = tmp;
                    return;
                }

                Item<T> current = Head.Next;
                Item<T> previous = Head;

                for (int i = 0; i < Count - 1; i++)
                {
                    if (i == index - 1)
                    {
                        Item<T> tmp = current.Next;
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

            Item<T> tmp = Head;
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
        /// Получение индекса элемента по его значению
        /// </summary>
        /// <param name="data">Значением элемента</param>
        /// <returns>Индекс первого вхождения элемента с заданным значением; -1, если элемент не найден</returns>
        public int IndexOf(T data)
        {
            if (Head == null)
                return -1;

            Item<T> tmp = Head;
            int index = 0;

            while (tmp != null)
            {
                if (tmp.Data.Equals(data))
                    return index;

                index++;
                tmp = tmp.Next;
            }

            return -1;
        }

        /// <summary>
        /// Добавление произвольного количества элементов в конец списка
        /// </summary>
        /// <param name="data">Добавляемые элементы</param>
        public void AddRight(T data)
        {
            Item<T> item = new Item<T>(data);

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

        /// <summary>
        /// Добавление произвольного количества элементов в начало списка
        /// </summary>
        /// <param name="data">Добавляемые элементы</param>
        public void AddLeft(T data)
        {
            Item<T> item = new Item<T>(data);

            if (Head != null)
            {
                item.Next = Head;
                Head = item;
            }
            else
            {
                Initialize(item);
            }
        }

        /// <summary>
        /// Добавление одного элемента на заданную позицию (элемент, стоявший на заданной позиции будет сдвинут)
        /// </summary>
        /// <param name="index">Позиция элемента</param>
        /// <param name="data">Добавляемый элемент</param>
        public void AddAt(int index, T data)
        {
            Item<T> newItem = new Item<T>(data);

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

            Item<T> tmp = Head;

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

            Item<T> tmp = Head;

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
        public bool Remove(T data)
        {
            if (Head == null)                       //если головной элемент пуст, то весь список также пуст
            {
                return false;
            }

            if (data == null && Head.Data == null || Head.Data.Equals(data))
            {
                Head = Head.Next;
                return true;
            }

            Item<T> previous = Head;
            Item<T> current = Head.Next;

            while (current != null)
            {
                if (data == null && current.Data == null || current.Data.Equals(data))
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
        public bool RemoveAll(T data)
        {
            if (Head == null)                               //если пуст головной элемент, то пуст и весь список
                return false;

            LinkedList<T> newList = new LinkedList<T>();    //новый списк
            Item<T> tmp = Head;                             //текущий элемент

            bool isRemoved = false;
            while (tmp != null)                             //пока не конец списка
            {
                if (data == null && tmp.Data == null || tmp.Data.Equals(data))
                {
                    tmp = tmp.Next;
                    isRemoved = true;
                    continue;
                }
                newList.AddRight(tmp.Data);     
                tmp = tmp.Next;                             //переходим на следующий объект текущего списка
            }

            Head = newList.Head;                            //
            Tail = newList.Tail;                            //присвоение нового списка текущему списку
            return isRemoved;
        }

        /// <summary>
        /// Удаление из списка элемента с заданным индексом
        /// </summary>
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            if (index == 0)
            {
                Head = Head.Next;
                return true;
            }

            Item<T> previous = Head;
            Item<T> current = Head.Next;

            for (int i = 0; i < Count; i++)
            {
                if (i == index - 1)
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
        /// Удаление из списка множества элементов
        /// </summary>
        /// <param name="startIndex">Номер с которого начинается удаление</param>
        /// <param name="count">Количество удаляемых элементов</param>
        public bool RemoveRange(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= Count || (startIndex + count) > Count)
            {
                throw new IndexOutOfRangeException(nameof(startIndex));
            }
            if (count == 0)
            {
                return false;
            }
            if (count < 0)
            {
                throw new NegativeCountException(nameof(count));
            }

            Item<T> tmp = Head;

            for (int i = 0; i < Count; i++)
            {
                if (i == startIndex)
                {
                    for (int j = 0; j < count; j++)
                        this.RemoveAt(i);
                }
                tmp = tmp.Next;
            }

            return true;
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
        protected void Initialize(Item<T> item)
        {
            Head = item;
            Tail = item;
        }

        //Обобщенный нумератор
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        //Необобщенный нумератор
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Поверхностное копирование коллекции
        /// </summary>
        public LinkedList<T> ShallowCopy()
        {
            return (LinkedList<T>)this.MemberwiseClone();
        }

        /// <summary>
        /// Глубокое копирование коллекции
        /// </summary>
        public object Clone()
        {
            LinkedList<T> cloneList = new LinkedList<T>();

            Item<T> tmp = Head;

            while (tmp != null)
            {
                cloneList.AddRight(tmp.Data);
                tmp = tmp.Next;
            }

            return cloneList;
        }
    }
}