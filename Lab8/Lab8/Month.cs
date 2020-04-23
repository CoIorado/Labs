using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    [Serializable]
    public class Month
    {
        public List<Day> Days { get; set; } = new List<Day>();
        
        public Day this[int dayNumber]
        {
            get
            {
                foreach (Day day in Days)
                    if (day.Number == dayNumber)
                        return day;
                return null;
            }
            set
            {
                for (int i = 0; i < Days.Count; i++)
                    if (Days[i].Number == dayNumber)
                        Days[i] = value;
            }
        }

        public Day this[string temperature]
        {
            get
            {
                foreach (Day day in Days)
                    if (day.Temperature == int.Parse(temperature))
                        return day;
                return null;
            }
            set
            {
                for (int i = 0; i < Days.Count; i++)
                    if (Days[i].Temperature == int.Parse(temperature))
                        Days[i] = value;
            }
        }

        public Month() { }

        public void Sort()
        {
            for (int i = 0; i < Days.Count; i++)
            {
                for (int j = 0; j < Days.Count - 1; j++)
                {
                    if (Days[j].Number > Days[j + 1].Number)
                    {
                        Day temp = Days[j + 1];
                        Days[j + 1] = Days[j];
                        Days[j] = temp;
                    }
                }
            }
        }
    }
}