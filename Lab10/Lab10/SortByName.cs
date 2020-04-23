using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class SortByName : IComparer<IHuman>
    {
        public int Compare(IHuman x, IHuman y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
}