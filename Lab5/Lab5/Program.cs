using System;
using System.Collections.Generic;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.DisplayMain();
        }
    }

    static class Menu
    {
        public static void DisplayMain()
        {
            Console.WriteLine("Доступные команды:");
            Console.Write("1 - работа с одномерным массивом\n" +
                "2 - работа с двумерным массивом\n" +
                "3 - работа с рваным массивом\n" +
                "0 - выход\n");

            ConsoleKeyInfo command = default;

            while (true)
            {
                command = InputCommand('0', '1', '2', '3');

                switch (command.KeyChar)
                {
                    case '0':
                        Console.Clear();
                        return;
                    case '1':
                        Console.Clear();
                        int[] array1 = new int[0];
                        DisplaySide(array1);
                        return;
                    case '2':
                        Console.Clear();
                        int[,] array2 = new int[0, 0];
                        DisplaySide(array2);
                        return;
                    case '3':
                        Console.Clear();
                        int[][] array3 = new int[0][];
                        DisplaySide(array3);
                        return;
                }
            }
        } //отобразить главное меню
        private static void DisplaySide(int[] array)
        {
            Console.WriteLine("Команды для работы с одномерным массивом:");
            Console.Write("1 - создать массив\n" +
                "2 - вывести массив\n" +
                "3 - удалить первый четный элемент\n" +
                "0 - назад\n");

            ConsoleKeyInfo command = default;

            while (true)
            {
                command = InputCommand('0', '1', '2', '3');

                switch (command.KeyChar)
                {
                    case '0':
                        Console.Clear();
                        DisplayMain();
                        return;
                    case '1':
                        Console.Clear();

                        Console.WriteLine("Выберите способ заполнения массива:");
                        Console.Write("1 - заполнить массив с помощью датчика случайных чисел\n" +
                            "2 - заполнить массив вручную\n" +
                            "0 - назад\n");

                        ConsoleKeyInfo command1 = default;

                        while (true)
                        {
                            command1 = InputCommand('0', '1', '2');
                            int sec;

                            switch (command1.KeyChar)
                            {
                                case '0':
                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                                case '1':
                                    Console.Clear();
                                    ArrayOperations.FillArrayRandom(out array);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nМассив создан.");
                                    Console.ResetColor();

                                    sec = DateTime.Now.Second;                  //для вывода сообщения "Массив создан"
                                    while (DateTime.Now.Second < sec + 1) { }   //

                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                                case '2':
                                    Console.Clear();
                                    ArrayOperations.FillArrayManually(out array);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nМассив создан.");
                                    Console.ResetColor();

                                    sec = DateTime.Now.Second;                  //для вывода сообщения "Массив создан"
                                    while (DateTime.Now.Second < sec + 1) { }   //

                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                            }
                        }
                    case '2':
                        ArrayOperations.PrintArray(array);
                        break;
                    case '3':
                        Console.WriteLine();
                        if (array.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ваш массив пуст! Создайте массив и повторите попытку.");
                            Console.ResetColor();

                            break;
                        }

                        ArrayOperations.DeleteFirstEven(ref array);
                        break;
                }
            }
        }  //отобразить меню для работы с одномерным массивом
        private static void DisplaySide(int[,] array)
        {
            Console.WriteLine("Команды для работы с двумерным массивом:");
            Console.Write("1 - создать массив\n" +
                "2 - вывести массив\n" +
                "3 - добавить строку в массив\n" +
                "0 - назад\n");

            ConsoleKeyInfo command = default;

            while (true)
            {
                command = InputCommand('0', '1', '2', '3');

                switch (command.KeyChar)
                {
                    case '0':
                        Console.Clear();
                        DisplayMain();
                        return;
                    case '1':
                        Console.Clear();

                        Console.WriteLine("Выберите способ заполнения массива:");
                        Console.Write("1 - заполнить массив с помощью датчика случайных чисел\n" +
                            "2 - заполнить массив вручную\n" +
                            "0 - назад\n");

                        ConsoleKeyInfo command1 = default;

                        while (true)
                        {
                            command1 = InputCommand('0', '1', '2');
                            int sec;

                            switch (command1.KeyChar)
                            {
                                case '0':
                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                                case '1':
                                    Console.Clear();
                                    ArrayOperations.FillArrayRandom(out array);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nМассив создан.");
                                    Console.ResetColor();

                                    sec = DateTime.Now.Second;                  //для вывода сообщения "Массив создан"
                                    while (DateTime.Now.Second < sec + 1) { }   //

                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                                case '2':
                                    Console.Clear();
                                    ArrayOperations.FillArrayManually(out array);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nМассив создан.");
                                    Console.ResetColor();

                                    sec = DateTime.Now.Second;                  //для вывода сообщения "Массив создан"
                                    while (DateTime.Now.Second < sec + 1) { }   //

                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                            }
                        }
                    case '2':
                        ArrayOperations.PrintArray(array);
                        break;
                    case '3':
                        Console.WriteLine();
                        if (array.GetLength(0) == 0 || array.GetLength(1) == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ваш массив пуст! Создайте массив и повторите попытку.");
                            Console.ResetColor();

                            break;
                        }

                        Console.WriteLine("Выберите способ заполнения добавляемой строки:");
                        Console.Write("1 - заполнение с помощью датчика случайных чисел\n" +
                            "2 - заполнение вручную\n");

                        ConsoleKeyInfo command2 = default;

                        while (true)
                        {
                            command2 = InputCommand('1', '2');

                            switch (command2.KeyChar)
                            {
                                case '1':
                                    Console.WriteLine();
                                    ArrayOperations.AddRow(ref array);
                                    break;
                                case '2':
                                    Console.WriteLine();
                                    ArrayOperations.AddRow(ref array, "manual");
                                    break;
                            }
                            break;
                        }
                        break;
                }
            }
        } //отобразить меню для работы с двумерным массивом
        private static void DisplaySide(int[][] array)
        {
            Console.WriteLine("Команды для работы с рваным массивом:");
            Console.Write("1 - создать массив\n" +
                "2 - вывести массив\n" +
                "3 - удалить строку/строки с максимальной длиной\n" +
                "0 - назад\n");

            ConsoleKeyInfo command = default;

            while (true)
            {
                command = InputCommand('0', '1', '2', '3');

                switch (command.KeyChar)
                {
                    case '0':
                        Console.Clear();
                        DisplayMain();
                        return;
                    case '1':
                        Console.Clear();

                        Console.WriteLine("Выберите способ заполнения массива:");
                        Console.Write("1 - заполнить массив с помощью датчика случайных чисел\n" +
                            "2 - заполнить массив вручную\n" +
                            "0 - назад\n");

                        ConsoleKeyInfo command1 = default;

                        while (true)
                        {
                            command1 = InputCommand('0', '1', '2');
                            int sec;

                            switch (command1.KeyChar)
                            {
                                case '0':
                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                                case '1':
                                    Console.Clear();
                                    ArrayOperations.FillArrayRandom(out array);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nМассив создан.");
                                    Console.ResetColor();

                                    sec = DateTime.Now.Second;                  //для вывода сообщения "Массив создан"
                                    while (DateTime.Now.Second < sec + 1) { }   //

                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                                case '2':
                                    Console.Clear();
                                    ArrayOperations.FillArrayManually(out array);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nМассив создан.");
                                    Console.ResetColor();

                                    sec = DateTime.Now.Second;                  //для вывода сообщения "Массив создан"
                                    while (DateTime.Now.Second < sec + 1) { }   //

                                    Console.Clear();
                                    DisplaySide(array);
                                    return;
                            }
                        }
                    case '2':
                        ArrayOperations.PrintArray(array);
                        break;
                    case '3':
                        Console.WriteLine();
                        if (array.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ваш массив пуст! Создайте массив и повторите попытку.");
                            Console.ResetColor();

                            break;
                        }

                        ArrayOperations.DeleteLongestRow(ref array);
                        break;
                }
            }
        } //отобразить меню для работы с рваным массивом
        private static ConsoleKeyInfo InputCommand(params char[] commands)
        {
            ConsoleKeyInfo command = default;
            Console.WriteLine();
            bool stop = false;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                command = Console.ReadKey();
                Console.ResetColor();

                foreach (char tmp in commands)      //
                {                                   //если введенная команда соответствует одной из заданных комманд,          
                    if (command.KeyChar == tmp)     //то цикл останавливается и возвращается значение
                        stop = true;                //
                }                                   //иначе выводится ошибка о неизвестной команде
                if (stop) break;                    //

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - неизвестная команда! Повторите ввод:");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return command;
        } //ввод команды в меню
    }
    static class ArrayOperations
    {
        private static int InputArrayElement(string element = "элементов")
        {
            int N;
            Console.WriteLine($"Введите количество {element} массива:");

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    N = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                    if (N == 0) throw new ZeroLengthException();

                    if (N < 0) throw new NegativeLengthException();

                    break;
                }
                catch (ZeroLengthException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введен пустой массив! Повторите попытку:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (NegativeLengthException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Количество {element} массива не может представлять из себя отрицательное число! Повторите попытку:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено не целое число! Повторите попытку:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            return N;
        } //универсальная функция для ввода каких-либо чисел для массива
        public static void FillArrayManually(out int[] array, int length = -1)
        {
            if (length == -1)
                length = InputArrayElement();

            array = new int[length];

            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"{i + 1}-й элемент: ");
                        array[i] = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введено не целое число! Повторите попытку:");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        } //заполнение одномерного массива вручную
        public static void FillArrayManually(out int[,] array)
        {
            int rows = InputArrayElement("строк");
            int columns = InputArrayElement("столбцов");

            array = new int[rows, columns];
            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"{i + 1}-я строка:");
                for (int j = 0; j < columns; j++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write($"{j + 1}-й элемент: ");
                            array[i, j] = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введено не целое число! Повторите попытку:");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                Console.WriteLine();
            }
        } //заполнение двумерного массива вручную
        public static void FillArrayManually(out int[][] array)
        {
            int rows = InputArrayElement("строк");
            array = new int[rows][];

            for (int i = 0; i < array.Length; i++)
            {
                int elements = InputArrayElement($"элементов в {i + 1}-й строке");
                array[i] = new int[elements];
            }

            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i + 1}-я строка:");
                for (int j = 0; j < array[i].Length; j++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write($"{j + 1}-й элемент: ");
                            array[i][j] = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введено не целое число! Повторите попытку:");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                Console.WriteLine();
            }
        } //заполнение рваного массива вручную
        public static void FillArrayRandom(out int[] array, int length = -1)
        {
            if (length == -1)
                array = new int[InputArrayElement()];
            else
                array = new int[length];
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(-1000, 1000);
        } //заполнение одномерного массива с помощью ДСЧ
        public static void FillArrayRandom(out int[,] array)
        {
            Random rnd = new Random();
            int rows = InputArrayElement("строк");
            int columns = InputArrayElement("столбцов");

            array = new int[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    array[i, j] = rnd.Next(-1000, 1000);
        } //заполнение двумерного массива с помощью ДСЧ
        public static void FillArrayRandom(out int[][] array)
        {
            Random rnd = new Random();
            int rows = InputArrayElement("строк");
            array = new int[rows][];

            for (int i = 0; i < array.Length; i++)
            {
                int elements = InputArrayElement($"элементов в {i + 1}-й строке");
                array[i] = new int[elements];
            }

            foreach (int[] row in array)
                for (int i = 0; i < row.Length; i++)
                    row[i] = rnd.Next(-1000, 1000);
        } //заполнение рваного массива с помощью ДСЧ
        public static void PrintArray(int[] array)
        {
            Console.WriteLine();
            if (array.Length != 0)
            {
                Console.WriteLine("Ваш массив:");
                Console.ForegroundColor = ConsoleColor.Green;

                for (int i = 0; i < array.Length; i++)
                    Console.Write($"{array[i]} ");
                Console.WriteLine();

                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Ваш массив пуст!");
                Console.ResetColor();
            }
        } //вывод одномерного массива
        public static void PrintArray(int[,] array)
        {
            Console.WriteLine();
            if (array.GetLength(0) != 0 && array.GetLength(1) != 0)
            {
                int difference, maxLength = -1;

                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j].ToString().Length > maxLength)
                            maxLength = array[i, j].ToString().Length;

                Console.WriteLine();
                Console.WriteLine("Ваш массив:");
                Console.ForegroundColor = ConsoleColor.Green;

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        difference = maxLength - array[i, j].ToString().Length;
                        for (int k = 0; k < difference; k++)
                            Console.Write(" ");
                        Console.Write($"{array[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Ваш массив пуст!");
                Console.ResetColor();
            }
        } //вывод двумерного массива
        public static void PrintArray(int[][] array)
        {
            Console.WriteLine();
            if (array.Length != 0)
            {
                int difference, maxLength = -1;

                foreach (int[] row in array)
                    for (int i = 0; i < row.Length; i++)
                        if (row[i].ToString().Length > maxLength)
                            maxLength = row[i].ToString().Length;

                Console.WriteLine("Ваш массив:");
                Console.ForegroundColor = ConsoleColor.Green;

                foreach (int[] row in array)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        difference = maxLength - row[i].ToString().Length;
                        for (int k = 0; k < difference; k++)
                            Console.Write(" ");
                        Console.Write($"{row[i]} ");
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Ваш массив пуст!");
                Console.ResetColor();
            }
        } //вывод рваного массива
        public static void DeleteFirstEven(ref int[] array)
        {
            int[] arrayNew;
            int index = -1, element = default;

            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 == 0)
                {
                    index = i;
                    element = array[i];
                    break;
                }

            if (index == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("В массиве отсутствуют четные элементы.");
                Console.ResetColor();
                return;
            }

            arrayNew = new int[array.Length - 1];

            for (int i = 0; i < array.Length; i++)
                if (i < index) arrayNew[i] = array[i];
                else if (i > index) arrayNew[i - 1] = array[i];

            array = arrayNew;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nИз массива удален элемент: ");
            Console.ResetColor();
            Console.WriteLine(element);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Индекс удаленного элемента: ");
            Console.ResetColor();
            Console.WriteLine(index);
        } //удаление первого четного элемента из одномерного массива
        public static void AddRow(ref int[,] array, string inputType = "random")
        {
            int[] addRow = default;
            if (inputType.ToLower().Equals("random"))
                FillArrayRandom(out addRow, array.GetLength(1));
            if (inputType.ToLower().Equals("manual"))
                FillArrayManually(out addRow, array.GetLength(1));

            Console.WriteLine("\nВведите индекс добавляемой строки:");
            int index;

            while (true)
            {
                try
                {
                    index = int.Parse(Console.ReadLine());
                    if (index < 0 || index > array.GetLength(0)) throw new OutOfRangeException();
                    break;
                }
                catch (OutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введенный индекс выходит за допустимые границы! Повторите попытку:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено не целое число! Повторите попытку:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            int[,] arrayNew = new int[array.GetLength(0) + 1, array.GetLength(1)];
            bool flag = false;

            for (int i = 0; i < arrayNew.GetLength(0); i++)
            {
                if (i == index)
                {
                    flag = true;
                    for (int j = 0; j < arrayNew.GetLength(1); j++)
                        arrayNew[i, j] = addRow[j];
                    continue;
                }

                if (!flag)
                    for (int j = 0; j < arrayNew.GetLength(1); j++)
                        arrayNew[i, j] = array[i, j];
                else
                    for (int j = 0; j < arrayNew.GetLength(1); j++)
                        arrayNew[i, j] = array[i - 1, j];
            }

            array = arrayNew;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nВ массив добавлена строка с индексом: ");
            Console.ResetColor();
            Console.WriteLine(index);
        } //добавление строки в двумерный массив
        public static void DeleteLongestRow(ref int[][] array)
        {
            int maxRowLength = -1, maxRowsCount = 0;
            var maxRowIndexes = new List<int>();     //список исключительно для вывода информации об удаленных строках
            var indexes = new List<int>();           //список для индексов строк, длина которых не равна максимальной

            foreach (int[] row in array)
                if (row.Length > maxRowLength)
                    maxRowLength = row.Length;

            for (int j = 0; j < array.Length; j++)
                if (array[j].Length == maxRowLength)
                {
                    maxRowsCount++;
                    maxRowIndexes.Add(j);
                }
                else
                    indexes.Add(j);

            int[][] arrayNew = new int[array.Length - maxRowsCount][];

            int i = 0;
            foreach (int index in indexes)
            {
                arrayNew[i] = new int[array[index].Length];

                for (int j = 0; j < arrayNew[i].Length; j++)
                    arrayNew[i][j] = array[index][j];

                i++;
            }

            array = arrayNew;

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            if (maxRowsCount == 1)
            {
                Console.Write($"Из массива удалена строка с индексом: ");
                Console.ResetColor();
                Console.WriteLine(maxRowIndexes[0]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Длина удаленной строки: ");
                Console.ResetColor();
                Console.WriteLine(maxRowLength);
            }
            else
            {
                Console.Write("Из массива удалены строки с индексами: ");
                Console.ResetColor();
                foreach (int index in maxRowIndexes)
                    Console.Write($"{index} ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nДлина удаленных строк: ");
                Console.ResetColor();
                Console.WriteLine(maxRowLength);
            }
            Console.WriteLine();
        } //удаление строк с максимальной длиной из рваного массива
    }

    class ZeroLengthException : Exception { }   //исключение для нулевой длины массива
    class NegativeLengthException : Exception { }   //исключение для отрицательной длины массива
    class OutOfRangeException : Exception { } //свое исключение для выхода за границы массива
}
