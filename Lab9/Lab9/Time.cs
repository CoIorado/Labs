using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Time
    {
        public static int Count { get; private set; } = 0;

        private int hours = -1;
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value >= 0 && value <= 23)
                    hours = value;
            }
        }

        private int minutes = -1;
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value >= 0 && value <= 59)
                    minutes = value;
            }
        }

        public Time()                               //если используется конструктор без параметров, то объекту присваивается текущее время
        {
            Hours = DateTime.Now.Hour;
            Minutes = DateTime.Now.Minute;
            Count++;
        }

        public Time(int hours, int minutes)
        {
            int inputHours = hours;
            int inputMinutes = minutes;

            if (inputMinutes >= 60)                 //если в конструктор передано значением минут больше, чем 59,
            {                                       //то целое число часов, входящих в это значение, передается свойству часов,
                inputHours += inputMinutes / 60;    //а остальное достается свойству, отвечающему за минуты
                inputMinutes %= 60;                 //
            }                                       //
            if (inputHours >= 24)                   //если количество часов оказалось больше, чем 23,
                inputHours %= 24;                   //то они приводятся к нужному значению делением по модулю на 24

            Hours = inputHours;
            Minutes = inputMinutes;
            Count++;
        }

        public override string ToString()           //переопределяемый метод, который возвращает строку типа 05:34
        {
            string result = null;

            if (Hours < 10) result = $"0{Hours}:";
            else result = $"{Hours}:";

            if (Minutes < 10) result += $"0{Minutes}";
            else result += Minutes;

            return result;
        }

        public static int Parse(Time time)
        {
            return time.Hours * 60 + time.Minutes;
        }

        public static Time Add(Time time, int sec)
        {
            if (sec < 0) throw new InvalidSecException();

            int min = sec / 60;

            int sum = time.Hours * 60 + time.Minutes + min;

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time Subtract(Time time, int sec)
        {
            if (sec < 0) throw new InvalidSecException();

            int min = sec / 60;

            int sum = time.Hours * 60 + time.Minutes - min;

            if (sum < 0) throw new SubtractErrorException();

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time Add(Time time1, Time time2)
        {
            int sum = time1.Hours * 60 + time2.Hours * 60 + time1.Minutes + time2.Minutes;

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time Subtract(Time time1, Time time2)
        {
            int sum = (time1.Hours * 60 + time1.Minutes) - (time2.Hours * 60 + time2.Minutes);

            if (sum < 0) throw new SubtractErrorException();

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public void Add(int sec)
        {
            if (sec < 0) throw new InvalidSecException();

            int min = sec / 60;

            int sum = this.Hours * 60 + this.Minutes + min;

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            if (resultHours >= 24)
                resultHours %= 24;

            this.Hours = resultHours;
            this.Minutes = resultMinutes;
        }

        public void Subtract(int sec)
        {
            if (sec < 0) throw new InvalidSecException();

            int min = sec / 60;

            int sum = Hours * 60 + Minutes - min;

            if (sum < 0) throw new SubtractErrorException();

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            this.Hours = resultHours;
            this.Minutes = resultMinutes;
        }

        public static Time operator +(Time time, int min)
        {
            if (min < 0) throw new InvalidMinuteException();

            int sum = time.Hours * 60 + time.Minutes + min;

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time operator +(int min, Time time)
        {
            if (min < 0) throw new InvalidMinuteException();

            int sum = time.Hours * 60 + time.Minutes + min;

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time operator +(Time time1, Time time2)
        {
            int sum = time1.Hours * 60 + time2.Hours * 60 + time1.Minutes + time2.Minutes;

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time operator -(Time time, int min)
        {
            if (min < 0) throw new InvalidMinuteException();

            int sum = time.Hours * 60 + time.Minutes - min;

            if (sum < 0) throw new SubtractErrorException();

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time operator -(int min, Time time)
        {
            if (min < 0) throw new InvalidMinuteException();

            int sum = min - (time.Hours * 60 + time.Minutes);

            if (sum < 0) throw new SubtractErrorException();

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time operator -(Time time1, Time time2)
        {
            int sum = (time1.Hours * 60 + time1.Minutes) - (time2.Hours * 60 + time2.Minutes);

            if (sum < 0) throw new SubtractErrorException();

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static Time operator ++(Time time)
        {
            Time result = new Time(time.Hours, time.Minutes + 1);
            
            return result;
        }

        public static Time operator --(Time time)
        {
            int sum = time.Hours * 60 + time.Minutes - 1;

            if (sum < 0) throw new SubtractErrorException();

            int resultHours = sum / 60;
            int resultMinutes = sum % 60;

            Time result = new Time(resultHours, resultMinutes);

            return result;
        }

        public static bool operator ==(Time time1, Time time2)
        {
            return (time1.Hours == time2.Hours && time1.Minutes == time2.Minutes);
        }

        public static bool operator !=(Time time1, Time time2)
        {
            return (time1.Hours != time2.Hours || time1.Minutes != time2.Minutes);
        }

        public static bool operator >(Time time1, Time time2)
        {
            int sum1 = time1.Hours * 60 + time2.Minutes;
            int sum2 = time2.Hours * 60 + time2.Minutes;

            return sum1 > sum2;
        }

        public static bool operator <(Time time1, Time time2)
        {
            int sum1 = time1.Hours * 60 + time1.Minutes;
            int sum2 = time2.Hours * 60 + time2.Minutes;

            return sum1 < sum2;
        }

        public static bool operator >=(Time time1, Time time2)
        {
            int sum1 = time1.Hours * 60 + time2.Minutes;
            int sum2 = time2.Hours * 60 + time2.Minutes;

            return sum1 >= sum2;
        }

        public static bool operator <=(Time time1, Time time2)
        {
            int sum1 = time1.Hours * 60 + time1.Minutes;
            int sum2 = time2.Hours * 60 + time2.Minutes;

            return sum1 <= sum2;
        }

        public static explicit operator int(Time time)
        {
            return time.Hours * 60 + time.Minutes;
        }

        public static implicit operator bool(Time time)
        {
            return time.Hours != 0 || time.Minutes != 0;
        }
    }

    public class SubtractErrorException : Exception { }
    public class InvalidHourException : Exception { }
    public class InvalidMinuteException : Exception { }
    public class InvalidSecException : Exception { }
}