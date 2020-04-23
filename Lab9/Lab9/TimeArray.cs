using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9
{
    public class TimeArray
    {
        private Time[] array;
        private bool isInitialized = false;

        public TimeArray()
        {
            array = null;
        }

        public TimeArray(int size, bool isRandomFill)
        {
            if (size >= 0)
                array = new Time[size];
            else
                throw new NegativeSizeException();

            if (isRandomFill)
            {
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    int hours = rnd.Next(0, 24);
                    int minutes = rnd.Next(0, 60);

                    array[i] = new Time(hours, minutes);
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    int hours;
                    while (true)
                    {
                        Console.ResetColor();
                        Console.Write($"[element #{i + 1}] HOUR: ");
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            hours = int.Parse(Console.ReadLine());

                            if (hours >= 0 && hours < 24)
                                break;
                            else
                                throw new InvalidHourException();
                        }
                        catch
                        {
                            Console.Write("\a");
                        }
                    }

                    int minutes;
                    while (true)
                    {
                        Console.ResetColor();
                        Console.Write($"[element #{i + 1}] MINUTE: ");
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            minutes = int.Parse(Console.ReadLine());

                            if (minutes >= 0 && minutes < 60)
                                break;
                            else
                                throw new InvalidMinuteException();
                        }
                        catch
                        {
                            Console.Write("\a");
                        }
                    }
                    Console.ResetColor();

                    array[i] = new Time(hours, minutes);
                }
            }

            isInitialized = true;
        }

        public Time this[int hour]
        {
            get
            {
                if (!isInitialized)
                    throw new NotInitializedException();

                foreach (Time time in array)
                    if (time.Hours == hour)
                        return time;

                return null;
            }
            set
            {
                if (!isInitialized)
                    throw new NotInitializedException();
                else
                {
                    for (int i = 0; i < array.Length; i++)
                        if (array[i].Hours == hour)
                            array[i] = value;
                }
            }
        }

        public Time this[string time]                               //индекс time формата "10:14"
        {
            get
            {
                if (!isInitialized)
                    throw new NotInitializedException();

                Regex regex = new Regex(@"(\d\d?):(\d\d?)");
                Match match = regex.Match(time);
                int hours = int.Parse(match.Groups[1].Value);
                int minutes = int.Parse(match.Groups[2].Value);

                foreach (Time _time in array)
                {
                    if (_time.Hours == hours && minutes == _time.Minutes)
                        return _time;
                }

                return null;
            }
            set
            {
                if (!isInitialized)
                    throw new NotInitializedException();

                Regex regex = new Regex(@"(\d\d?):(\d\d?)");
                Match match = regex.Match(time);
                int hours = int.Parse(match.Groups[1].Value);
                int minutes = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < array.Length; i++)
                    if (array[i].Hours == hours && array[i].Minutes == minutes)
                        array[i] = value;
            }
        }

        public void Print()
        {
            if (!isInitialized)
            {
                throw new NotInitializedException();
            }

            if (array.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("> ARRAY IS EMPTY");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  TIME ARRAY:");
                foreach (Time time in array)
                {
                    Console.WriteLine("> " + time.ToString());
                }
                Console.ResetColor();
            }
        }

        public Time GetElement(int index)
        {
            if (isInitialized)
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                else
                    throw new IndexOutOfRangeException();
            }
            else
                throw new NotInitializedException();
        }

        public Time AverageTime()
        {
            if (!isInitialized)
                throw new NotInitializedException();

            int sum = 0;
            foreach (Time time in array)
                sum += time.Hours * 60 + time.Minutes;

            sum /= array.Length;

            int avgHours = sum / 60;
            int avgMinutes = sum % 60;

            return new Time(avgHours, avgMinutes);
        }
    }

    public class NegativeSizeException : Exception { }
    public class NotInitializedException : Exception { }
}