using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab14
{
    public class MyEnumerator<T> : IEnumerator<T>
    {
        private  MyItem<T> Head { get; set; }
        private  MyItem<T> current;

        public MyEnumerator(MyLinkedList<T> linkedList)
        {
            Head = new  MyItem<T>();
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
