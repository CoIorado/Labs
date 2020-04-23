using System;

namespace Lab8
{
    [Serializable]
    public class Day
    {
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value >= 1 && value <= 31)
                    number = value;
            }
        }

        private int temperature;
        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= -100 && value <= 100)
                    temperature = value;
            }
        }
        
        public Day(int number, int temperature)
        {
            Number = number;
            Temperature = temperature;
        }

        public Day()
        {
            Number = 1;
            Temperature = 0;
        }
    }
}