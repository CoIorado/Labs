using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab13
{
    public class Enumerator<T> : IEnumerator<T>
    {
        private Item<T> Head { get; set; }
        private Item<T> current;

        public Enumerator(LinkedList<T> linkedList)
        {
            Head = new Item<T>();
            Head.Next = linkedList.Head;
            current = this.Head;
        }

        public T Current => current.Data;

        object IEnumerator.Current => current.Data;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (current.Next == null)
            {
                Reset();
                return false;
            }

            current = current.Next;
            return true;
        }

        public void Reset()
        {
            current = Head;
        }
    }
}
