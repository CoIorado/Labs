using System;
using Human;

namespace Lab12
{
    public class DItem
    {
        public IHuman Data { get; set; }

        public DItem Next { get; set; }

        public DItem Previous { get; set; }

        public DItem(IHuman data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }

        public DItem()
        {
            Data = default(IHuman);
            Next = null;
            Previous = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
