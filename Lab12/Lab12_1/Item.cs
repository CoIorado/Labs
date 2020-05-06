using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Human;

namespace Lab12
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
