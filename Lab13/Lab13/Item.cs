using System;

namespace Lab13
{
    /// <summary>
    /// Ячейка списка
    /// </summary>
    public class Item<T>
    {
        /// <summary>
        /// Данные, хранимые в ячейке списка
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Следующая ячейка списка
        /// </summary>
        public Item<T> Next { get; set; }

        public Item()
        {
            Data = default(T);
            Next = null;
        }

        public Item(T data)
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
