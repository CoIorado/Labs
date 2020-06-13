using System;
using Human;

namespace Lab14
{
    public class Item
    {
        public IHuman Data { get; set; }

        public Item Next { get; set; }

        public Item(IHuman data)
        {
            Data = data;
            Next = null;
        }

        public Item()
        {
            Data = default(IHuman);
            Next = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
