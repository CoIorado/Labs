using System;

namespace Lab9
{
    public class Program
    {
        static void Main(string[] args)
        {
            ///*------------------------------------------------------------------------------------------------------------------------------------*/
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine("\nЧАСТЬ 1");
            //Console.ResetColor();
            ///*------------------------------------------------------------------------------------------------------------------------------------*/

            //Time timeNow = new Time();          //по умолчанию ставится текущее время
            //Console.WriteLine("timeNow: " + timeNow);
            //Time time1 = new Time(12, 45);      //время в формате 12:45
            //Console.WriteLine("time1: " + time1.ToString());
            //Time time2 = new Time(22, 35);      //22:35
            //Console.WriteLine("time2: " + time2.ToString());
            //Console.WriteLine();

            //int hour1 = time1.Hours;        //12
            //Console.WriteLine("hour1 = " + hour1);
            //int minute1 = time1.Minutes;    //45
            //Console.WriteLine("minute1 = " + minute1);
            //Console.WriteLine();

            //int hour2 = time2.Hours;        //22
            //Console.WriteLine("hour2 = " + hour2);
            //int minute2 = time2.Minutes;    //35
            //Console.WriteLine("minute2 = " + minute2);
            //Console.WriteLine();

            //time1.Add(900);     //13:00
            //time2.Add(60);      //22:36
            //Console.WriteLine("12:45 + 900sec = " + time1.ToString());
            //Console.WriteLine("22:35 + 60sec = " + time2.ToString());
            //Console.WriteLine();

            //time1 = Time.Add(time1, 1500);  //13:25
            //time2 = Time.Add(time2, 600);   //22:46
            //Console.WriteLine("13:00 + 1500sec = " + time1.ToString());
            //Console.WriteLine("22:36 + 600sec = " + time2.ToString());
            //Console.WriteLine();

            //time1.Subtract(60);                                 //13:24
            //Console.WriteLine("13:25 - 60sec = " + time1.ToString());
            //time1 = Time.Subtract(time1, new Time(13, 24));     //00:00
            //Console.WriteLine("13:24 - 13:24 = " + time1.ToString());
            ////time2 = Time.Subtract(time2, new Time(23, 00));   //ошибка
            //Console.WriteLine();

            //Console.WriteLine("Кол-во созданных объектов типа Time: " + Time.Count);  //3
            //Console.WriteLine();

            ///*------------------------------------------------------------------------------------------------------------------------------------*/
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine("\nЧАСТЬ 2");
            //Console.ResetColor();
            ///*------------------------------------------------------------------------------------------------------------------------------------*/

            //Time time3 = new Time(4, 59);
            //Console.WriteLine("time3: " + time3.ToString());
            //Console.WriteLine();

            //time3++;    //05:00
            //Console.WriteLine("time3++ = " + time3.ToString());
            //time3--;    //04:59
            //Console.WriteLine("time3-- = " + time3.ToString());
            //Console.WriteLine();

            //++time3;    //05:00
            //Console.WriteLine("++time3 = " + time3.ToString());
            //--time3;    //04:59
            //Console.WriteLine("--time3 = " + time3.ToString());
            //Console.WriteLine();

            //Console.WriteLine("(int)time3 = " + (int)time3);    //299
            //Console.WriteLine();

            //Console.Write("time3 (bool) = ");
            //Console.WriteLine(time3);            //True
            //Console.Write("00:00 (bool) = ");
            //Console.WriteLine(new Time(0, 0));   //False
            //Console.WriteLine();

            //Time sumTime = time3 + new Time(23, 59);    //04:58
            //Console.WriteLine("time3 + new Time(23, 59) = " + sumTime.ToString());
            //sumTime = time3 + 2;                        //05:00
            //Console.WriteLine("time3 + 2min = " + sumTime.ToString());
            //sumTime = 60 + time3;                       //06:00
            //Console.WriteLine("60min + time3 = " + sumTime.ToString());
            //Console.WriteLine();

            //Time subTime = time3 - new Time(0, 12);     //04:48
            //Console.WriteLine("time3 + new Time(0, 12) = " + subTime.ToString());
            //subTime = time3 - 61;                       //03:47
            //Console.WriteLine("time3 - 61min = " + subTime.ToString());
            //subTime = 600 - time3;                      //06:13
            //Console.WriteLine("600min - time3 = " + subTime.ToString());
            //Console.WriteLine();

            //Console.WriteLine($"time3 > 02:23 - " + (time3 > new Time(02, 23)));    //true
            //Console.WriteLine($"time3 < 04:58 - " + (time3 < new Time(04, 58)));    //false
            //Console.WriteLine($"time3 >= 01:01 - " + (time3 >= new Time(01, 01)));  //true
            //Console.WriteLine($"time3 <= 04:59 - " + (time3 <= new Time(04, 59)));  //true
            //Console.WriteLine();

            ///*------------------------------------------------------------------------------------------------------------------------------------*/
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine("\nЧАСТЬ 3");
            //Console.ResetColor();
            ///*------------------------------------------------------------------------------------------------------------------------------------*/

            //TimeArray timeArray1 = new TimeArray(10, true);
            //Console.WriteLine("timeArray1:");
            //timeArray1.Print();
            //try
            //{
            //    Time time4 = timeArray1[16];
            //    time4 = timeArray1.GetElement(2);
            //    time4 = timeArray1["12:45"];
            //    timeArray1[12] = new Time();
            //    timeArray1["11:34"] = new Time(11, 35);
            //}
            //catch { }
            //Time avgTime = timeArray1.AverageTime();
            //Console.WriteLine("AVERAGE TIME: " + avgTime.ToString());
            //Console.WriteLine();

            //TimeArray timeArray2 = new TimeArray(10, false);
            //Console.WriteLine("timeArray2:");
            //timeArray2.Print();
        }
    }
}