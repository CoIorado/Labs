using System;

namespace lab4
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] array = Helper.CreateArray();

            Menu.Launch(array);
        }
    }

    static class Menu
    {
        public static void ShowInterface(int[] array)
        {
            Console.Clear();

            Console.WriteLine("Введите, какое действие необходимо произвести с массивом.");
            Console.WriteLine("Доступные команды:");
            Console.Write("1 - создать новый массив;\n" +
                "2 - удалить максимальный элемент из массива;\n" +
                "3 - добавить K элементов в начало массива;\n" +
                "4 - перевернуть массив;\n" +
                "5 - найти первый четный элемент в массиве;\n" +
                "6 - выполнить сортировку массива методом простого обмена;\n" +
                "0 - выйти.\n");
            Helper.OutputArray(array);
        }
        public static void Launch(int[] array)
        {
            ShowInterface(array);

            ConsoleKeyInfo command = default;

            while (command.KeyChar != '0')
            {
                command = Helper.InputCommand();
                ShowInterface(array);

                switch (command.KeyChar)
                {
                    case '0':
                        Console.Clear();                //выход из программы
                        break;
                    case '1':
                        array = Helper.CreateArray();
                        Helper.OutputArray(array);      //создание нового массива
                        ShowInterface(array);
                        break;
                    case '2':
                        DeleteMax(ref array);
                        Helper.OutputArray(array);      //удаление максимального элемента
                        ShowInterface(array);
                        break;
                    case '3':
                        AddElementsLeft(ref array);
                        Helper.OutputArray(array);      //добавление К элементов в начало
                        ShowInterface(array);
                        break;
                    case '4':
                        ReverseArray(ref array);
                        Helper.OutputArray(array);      //переворот массива
                        ShowInterface(array);
                        break;
                    case '5':
                        FindFirstEven(array);           //нахождение первого четного элемента и количества сравнений для его нахождения
                        break;
                    case '6':
                        SortBySimpleExchange(ref array);
                        ShowInterface(array);           //сортировка методом простого обмена
                        break;
                }
            }
        }


        public static void DeleteMax(ref int[] array)
        {
            int max = -1, count = 0;
            int[] arrayNew;

            for (int i = 0; i < array.Length; i++)
                if (array[i] > max) max = array[i];

            for (int i = 0; i < array.Length; i++)
                if (array[i] == max)
                {
                    count++;
                    for (int j = i; j < array.Length - 1; j++)
                        array[j] = array[j + 1];
                }

            arrayNew = new int[array.Length - count];

            for (int i = 0; i < arrayNew.Length; i++)
                arrayNew[i] = array[i];

            array = arrayNew;
        }

        public static void AddElementsLeft(ref int[] array)
        {
            int K;
            Console.WriteLine("Введите количество элементов К, которое нужно добавить в массив:");

            while (true)
            {
                try
                {
                    Console.Write("K = ");
                    K = int.Parse(Console.ReadLine());

                    if (K <= 0) throw new Exception();
                    break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пожалуйста, введите натуральное число.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            int[] arrayNew = new int[array.Length + K];
            Random rnd = new Random();

            for (int i = 0; i < K; i++)
                arrayNew[i] = rnd.Next(0, 100);
            for (int i = K; i < arrayNew.Length; i++)
                arrayNew[i] = array[i - K];

            array = arrayNew;
        }

        public static void ReverseArray(ref int[] array)
        {
            int tmp;

            for (int i = 0; i < array.Length / 2; i++)
            {
                tmp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = tmp;
            }
        }

        public static void FindFirstEven(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 == 0)
                {
                    Console.WriteLine($"Первый найденный четный элемент - {array[i]}\n" +
                        $"Количество сравнений, понадобившихся для нахождения - {i + 1}");
                    return;
                }
            Console.WriteLine("В массиве нет четных элементов!");
        }

        public static void SortBySimpleExchange(ref int[] array)
        {
            for (int i = 1; i < array.Length; i++)
                for (int j = array.Length - 1; j >= i; j--)
                    if (array[j] < array[j - 1])
                    {
                        int tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                    }
        }
    }

    static class Helper
    {
        public static ConsoleKeyInfo InputCommand()
        {
            ConsoleKeyInfo command;
            Console.WriteLine();
            while (true)
            {
                command = Console.ReadKey();

                if (command.KeyChar == '1' || command.KeyChar == '2' || command.KeyChar == '3' || command.KeyChar == '4' || command.KeyChar == '5' || command.KeyChar == '6' || command.KeyChar == '0')
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - неизвестная команда! Повторите ввод:");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return command;
        } //ввод команды в меню

        public static int InputN()
        {
            int N;
            Console.WriteLine("Введите количество элементов в массиве:");
            while (true)
            {
                try
                {
                    Console.Write("N = ");
                    N = int.Parse(Console.ReadLine());

                    if (N == 0) throw new ZeroException();
                    if (N < 0) throw new NegativeException();

                    break;
                }
                catch (ZeroException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введен пустой массив! Повторите попытку:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (NegativeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Количество элементов в массиве не может представлять из себя отрицательное число! Повторите попытку:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено не целое число! Повторите попытку");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return N;
        } //ввод количества элементов в массиве

        public static int[] CreateArray()
        {
            int[] array = new int[InputN()];

            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 100);

            return array;
        } //создание массива

        public static void OutputArray(int[] array)
        {
            if (array.Length != 0)
            {
                Console.WriteLine("\nВаш массив:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                for (int i = 0; i < array.Length; i++)
                    Console.Write($"{array[i]} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nВаш массив пуст!");
                Console.ForegroundColor = ConsoleColor.White;

            }
        } //вывод массива
    }

    class ZeroException : Exception { }
    class NegativeException : Exception { }
}