using System;
using Human;
using System.Collections.Generic;

namespace Lab13
{
    public delegate void CollectionHandler(object sender, CollectionHandlerEventArgs args);

    public class MyNewCollection : MyCollection
    {
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public string CollectionName { get; set; } = typeof(MyNewCollection).Name;

        public MyNewCollection() : base() { }

        public MyNewCollection(int capacity) : base(capacity) { }

        public MyNewCollection(int capacity, IHuman data) : base(capacity, data) { }

        public MyNewCollection(IEnumerable<IHuman> sample) : base(sample) { }

        public new IHuman this[int index]
        {
            get => base[index];

            set
            {
                base[index] = value;

                Dictionary<int, IHuman> indexDataPairs = new Dictionary<int, IHuman>();
                indexDataPairs.Add(index, value);

                CollectionReferenceChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, ChangeType.Reference, indexDataPairs));
            }
        }

        public new void AddRight(IHuman data)
        {
            base.AddRight(data);

            Dictionary<int, IHuman> indexDataPairs = new Dictionary<int, IHuman>();
            indexDataPairs.Add(Count - 1, data);

            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, ChangeType.Add, indexDataPairs));
        }

        public new void AddLeft(IHuman data)
        {
            base.AddLeft(data);

            Dictionary<int, IHuman> indexDataPairs = new Dictionary<int, IHuman>();
            indexDataPairs.Add(Count - 1, data);

            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, ChangeType.Add, indexDataPairs));
        }

        public new void AddAt(int index, IHuman data)
        {
            base.AddAt(index, data);

            Dictionary<int, IHuman> indexDataPairs = new Dictionary<int, IHuman>();
            indexDataPairs.Add(index, data);

            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, ChangeType.Add, indexDataPairs));
        }

        public new bool Remove(IHuman data)
        {
            int index = IndexOf(data);
            bool isRemoved = base.Remove(data);

            if (isRemoved)
            {
                Dictionary<int, IHuman> indexDataPairs = new Dictionary<int, IHuman>();
                indexDataPairs.Add(index, data);

                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, ChangeType.Remove, indexDataPairs));
            }

            return isRemoved;
        }

        public new bool RemoveAll(IHuman data)
        {
            if (Head == null)                                   
                return false;

            Dictionary<int, IHuman> indexDataPairs = new Dictionary<int, IHuman>();

            MyNewCollection newList = new MyNewCollection(0);
            Item<IHuman> tmp = Head;
            int index = 0;

            bool isRemoved = false;
            while (tmp != null)
            {
                if (data == null && tmp.Data == null || tmp.Data.Equals(data))
                {
                    tmp = tmp.Next;
                    isRemoved = true;
                    indexDataPairs.Add(index, data);
                    continue;
                }
                newList.AddRight(tmp.Data);
                tmp = tmp.Next;
                index++;
            }

            Head = newList.Head;               
            Tail = newList.Tail;                    


            if (isRemoved)
            {
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, ChangeType.Remove, indexDataPairs));
            }

            return isRemoved;
        }

        public new bool RemoveAt(int index)
        {
            IHuman data = base[index];
            bool isRemoved = base.RemoveAt(index);

            if (isRemoved)
            {
                Dictionary<int, IHuman> indexDataPairs = new Dictionary<int, IHuman>();
                indexDataPairs.Add(index, data);

                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, ChangeType.Remove, indexDataPairs));
            }

            return isRemoved;
        }

        public new bool RemoveRange(int startIndex, int count)
        {
            Dictionary<int, IHuman> indexDataPairs = new Dictionary<int, IHuman>();

            for (int i = 0; i < count; i++)
            {
                indexDataPairs.Add(startIndex + i, base[startIndex + i]);
            }

            bool isRemoved = base.RemoveRange(startIndex, count);

            if (isRemoved)
            {
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, ChangeType.Remove, indexDataPairs));
            }

            return isRemoved;
        }
    }
}