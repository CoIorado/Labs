using System;

namespace Lab12
{
    /// <summary>
    /// Ячейка списка
    /// </summary>
    public class MyItem<T>
    {
        /// <summary>
        /// Данные, хранимые в ячейке списка
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Следующая ячейка списка
        /// </summary>
        public MyItem<T> Next { get; set; }

        public MyItem()
        {
            Data = default(T);
            Next = null;
        }

        public MyItem(T data)
        {
            Data = data;
            Next = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
