using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public interface IHuman
    {
        void Move();
        void Eat();
        void Sleep();
        void DisplayInfo();

        string Name { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        string Gender { get; set; }
    }
}