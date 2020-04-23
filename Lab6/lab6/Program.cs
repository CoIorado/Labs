using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab6
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
        public static void DisplayMain() //главное меню
        {
            Console.WriteLine("Доступные команды:");
            Console.Write("1 - работа с одномерным массивом\n" +
                "2 - работа со строками\n" +
                "0 - выход\n");

            ConsoleKeyInfo command = default;

            while (true)
            {
                command = Helper.InputCommand('0', '1', '2');

                switch (command.KeyChar)
                {
                    case '0':
                        Console.Clear();
                        return;
                    case '1':
                        Console.Clear();
                        DisplayArrayMenu(null);
                        return;
                    case '2':
                        Console.Clear();
                        DisplayStringMenu(null);
                        return;
                }
            }
        }
        private static void DisplayArrayMenu(int[] array) //меню для работы с числовым одномерным массивом
        {
            Console.WriteLine("Команды для работы с одномерным массивом:");
            Console.Write("1 - создать массив\n" +
                "2 - вывести массив\n" +
                "3 - отсортировать только четные элементы массива\n" +
                "0 - назад\n");

            ConsoleKeyInfo command = default;

            while (true)
            {
                command = Helper.InputCommand('0', '1', '2', '3');

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
                            command1 = Helper.InputCommand('0', '1', '2');
                            int length;

                            switch (command1.KeyChar)
                            {
                                case '0':
                                    Console.Clear();
                                    DisplayArrayMenu(array);
                                    return;
                                case '1':
                                    Console.Clear();
                                    length = Helper.InputLength();
                                    array = ArrayOperation.CreateArrayRandom(length);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nМассив создан.");
                                    Console.ResetColor();

                                    Thread.Sleep(1000);     //задержка в 1 сек, чтобы надпись "Массив создан" не пропадала сразу

                                    Console.Clear();
                                    DisplayArrayMenu(array);
                                    return;
                                case '2':
                                    Console.Clear();
                                    length = Helper.InputLength();
                                    array = ArrayOperation.CreateArrayManually(length);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nМассив создан.");
                                    Console.ResetColor();

                                    Thread.Sleep(1000);

                                    Console.Clear();
                                    DisplayArrayMenu(array);
                                    return;
                            }
                        }
                    case '2':
                        ArrayOperation.PrintArray(array);
                        break;
                    case '3':
                        Console.WriteLine();
                        try
                        {
                            if (array.Length == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ваш массив пуст! Создайте массив и повторите попытку.");
                                Console.ResetColor();

                                break;
                            }

                            ArrayOperation.SortEven(ref array);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Четные элементы в массиве отсортированы.");
                            Console.ResetColor();
                            break;
                        }
                        catch (NullReferenceException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы еще не создали массив! Создайте массив и повторите попытку.");
                            Console.ResetColor();
                            break;
                        }
                }
            }
        }
        private static void DisplayStringMenu(string str) //меню для работы со строкой
        {
            Console.WriteLine("Команды для работы со строкой:");
            Console.Write("1 - создать строку\n" +
                "2 - вывести строку\n" +
                "3 - перевернуть каждое нечетное предложение в строке\n" +
                "0 - назад\n");

            ConsoleKeyInfo command = default;

            while (true)
            {
                command = Helper.InputCommand('0', '1', '2', '3');

                switch (command.KeyChar)
                {
                    case '0':
                        Console.Clear();
                        DisplayMain();
                        return;
                    case '1':
                        Console.Clear();

                        Console.WriteLine("Выберите способ создания строки:");
                        Console.Write("1 - ввести текст с клавиатуры\n" +
                            "2 - использовать генератор случайных предложений\n" +
                            "0 - назад\n");

                        ConsoleKeyInfo command1 = default;

                        while (true)
                        {
                            command1 = Helper.InputCommand('0', '1', '2');
                            int length;

                            switch (command1.KeyChar)
                            {
                                case '0':
                                    Console.Clear();
                                    DisplayStringMenu(str);
                                    return;
                                case '1':
                                    Console.Clear();
                                    Console.WriteLine("Введите текст здесь:");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    str = Console.ReadLine();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nСтрока создана.");
                                    Console.ResetColor();

                                    Thread.Sleep(1000);

                                    Console.Clear();
                                    DisplayStringMenu(str);
                                    return;
                                case '2':
                                    Console.Clear();
                                    length = Helper.InputLength("предложений в тексте");
                                    str = StringOperation.CreateStringRandom(length);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nСтрока создана.");
                                    Console.ResetColor();

                                    Thread.Sleep(1000);

                                    Console.Clear();
                                    DisplayStringMenu(str);
                                    return;
                            }
                        }
                    case '2':
                        Console.WriteLine();
                        try
                        {
                            if (str.Length == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Ваша строка пуста!");
                                Console.ResetColor();
                                break;
                            }

                            Console.WriteLine("\nВаша строка: ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(str);
                            Console.ResetColor();
                            break;
                        }
                        catch (NullReferenceException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы еще ничего не создали! Создайте строку и повторите попытку.");
                            Console.ResetColor();
                            break;
                        }
                    case '3':
                        Console.WriteLine();
                        try
                        {
                            if (str.Length == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ваша строка пуста! Введите что-нибудь и повторите попытку.");
                                Console.ResetColor();
                                break;
                            }

                            int result = StringOperation.ReverseNotEvenSentence(ref str);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            if (result == 1)
                            {
                                Console.WriteLine("Нечетные предложения перевернуты.");
                                Console.ResetColor();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("В введенной строке нет ни одного предложения.");
                                Console.ResetColor();
                                break;
                            }

                        }
                        catch (NullReferenceException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы еще ничего не создали! Создайте строку и повторите попытку.");
                            Console.ResetColor();
                            break;
                        }
                }
            }
        }
    }

    static class ArrayOperation
    {
        public static int[] CreateArrayManually(int length) //создание массива с ручным заполнением
        {
            int[] array = new int[length];

            for (int i = 0; i < array.Length; i++)
                array[i] = Helper.InputArrayElement(i);

            return array;
        }
        public static int[] CreateArrayRandom(int length, int init = -100, int end = 100) //создание массива с помощью ДСЧ
        {
            int[] array = new int[length];
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(init, end);

            return array;
        }
        public static void SortEven(ref int[] array) //сортировка только четных элементов массива
        {
            int[] evenNumbers = new int[array.Length];  //специальный массив для промежуточного хранения и сортировки четных элементов
            int evenCount = 0;  //кол-во четных элементов в массиве

            for (int i = 0, j = 0; i < array.Length; i++)   //подсчет кол-ва четных элементов и передача их в спец. массив
                if (array[i] % 2 == 0)
                {
                    evenCount++;
                    evenNumbers[j] = array[i];
                    j++;
                }

            if (evenCount == 0) return;

            Array.Resize(ref evenNumbers, evenCount);     //оставить в массиве только четные элементы из исходного массива
            Array.Sort(evenNumbers);

            for (int i = 0, j = 0; i < array.Length; i++)   //присвоение четным элементам исходного массива тех же, только отсортированных элементов
                if (array[i] % 2 == 0)
                {
                    array[i] = evenNumbers[j];
                    j++;
                }
        }
        public static void PrintArray(int[] array) //вывод одномерного массива
        {
            Console.WriteLine();
            try
            {
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
            }
            catch (NullReferenceException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы еще не создали массив! Создайте массив и повторите попытку.");
                Console.ResetColor();
            }
        }
    }
    static class StringOperation
    {
        public static int ReverseNotEvenSentence(ref string str) //переворот каждого нечетного предложения (возвращает -1, если предложений нет; 1, если есть)
        {
            if (str.IndexOf('.') == -1 && str.IndexOf('!') == -1 && str.IndexOf('?') == -1)    //если нет ни одного предложения,
                return -1;                                                                     //то метод завершает работу и возвращает -1

            List<char> marks = new List<char>();           //в список по порядку следования в исходной строке добавляются все знаки, разделяющие предложения
            foreach (char symbol in str)
            {
                if (symbol.Equals('.')) marks.Add('.');
                if (symbol.Equals('!')) marks.Add('!');
                if (symbol.Equals('?')) marks.Add('?');
            }

            str = str.Trim(); //удаление бесполезных пробелов слева и справа строки
            str = str.Replace(". ", ".");   //замена для простого разделения строки на предложения
            str = str.Replace("! ", "!");   //
            str = str.Replace("? ", "?");   //(рассчитывается, что после предложения ставится знак и ОДИН пробел)

            string remainder = default; //остаток от строки (после последнего знака могут остаться символы, не входящие в предложения)
            if (str.LastIndexOf('.') > str.LastIndexOf('?') && str.LastIndexOf('.') > str.LastIndexOf('!')) //алгоритм удаления остатка для четкого разделения по предложениям
            {
                remainder = str.Substring(str.LastIndexOf('.') + 1);    //если последнее предложение заканчивается точкой,
                str = str.Remove(str.LastIndexOf('.'));                 //то остаток записывается в remainder и удаляется из str
            }
            else if (str.LastIndexOf('?') > str.LastIndexOf('.') && str.LastIndexOf('?') > str.LastIndexOf('!'))
            {
                remainder = str.Substring(str.LastIndexOf('?') + 1);
                str = str.Remove(str.LastIndexOf('?'));
            }
            else if (str.LastIndexOf('!') > str.LastIndexOf('.') && str.LastIndexOf('!') > str.LastIndexOf('?'))
            {
                remainder = str.Substring(str.LastIndexOf('!') + 1);
                str = str.Remove(str.LastIndexOf('!'));
            }

            string[] sentences = str.Split('.', '!', '?'); //разделение строки на массив подстрок

            str = null; //"обнуление" строки для записи новых значений

            for (int i = 0; i < sentences.Length; i += 2)   //переворот четных по индексу (но нечетных по порядку) предложений
            {
                char[] sentenceChar = sentences[i].ToCharArray();
                Array.Reverse(sentenceChar);
                sentences[i] = new string(sentenceChar);
            }

            int j = 0;                                  //
            foreach (string sentence in sentences)      //восстановление исходной строки
                str += sentence + marks[j++] + ' ';     //с измененными предложениями
            str += remainder;                           //

            return 1;
        }
        public static string CreateStringRandom(int length) //генератор случайных предложений
        {
            if (length == 0) return "";
            if (length < 0) return null;

            string[] words = { "Привет", "Массив", "Колбаса", "Смартфон", "Яблоко", "Стул", "Бассейн", "Мяч", "Книга", "Ботинки", "Сделал", "Пришел", "Плавать", "Слово", "Телефон", "Холодильник", "Коробка",  //мини База данных из
                               "Клей", "Строить", "Браузер", "Сишарп", "Кот", "Собака", "Монитор", "Мышь", "Клавиатура", "Дисплей", "Лампа", "Снег", "Ручка", "Карандаш", "Гулять"};                            //32-x слов
            Random rnd = new Random();
            string str = null;

            str += words[rnd.Next(0, words.Length)] + ' ';  //добавляет в str случайное слово из массива words (первое слово с большой буквы, остальные - с маленькой с помощью функции ToLower()

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; i < rnd.Next(0, words.Length); j++) //создание предложения с случайным числом слов
                {
                    string sign = "";           //вычисление шанса
                    int odd = rnd.Next(0, 5);   //на постановку запятой
                    if (odd == 2) sign = ",";   //(шанс = 0.2)

                    str += words[rnd.Next(0, words.Length)].ToLower() + sign + ' ';
                }
                str += words[rnd.Next(0, words.Length)].ToLower();  //добавление последнего слова в предложения без пробела в конце

                int mark = rnd.Next(0, 3);      //
                if (mark == 0) str += ". ";     //постановка случайного знака
                if (mark == 1) str += "! ";     //в конце предложения
                if (mark == 2) str += "? ";     //

                if (i != length - 1)                                //если это было не последнее предложение,
                    str += words[rnd.Next(0, words.Length)] + ' ';  //то добавляем первое слово с большой буквы следующего предложения
            }

            return str;
        }
    }
    static class Helper
    {
        public static int InputLength(string name = "элементов массива") //ввод длины массива или строки с названием в виде входящего параметра
        {
            int N;
            Console.WriteLine($"Введите количество {name}:");

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    N = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                    if (N < 0) throw new NegativeLengthException();

                    break;
                }
                catch (NegativeLengthException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Количество {name} не может представлять из себя отрицательное число! Повторите попытку:");
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
        }
        public static int InputArrayElement(int index) //ввод элемента массива
        {
            int element;

            while (true)
            {
                Console.Write($"{index + 1}-й элемент: ");
                try
                {
                    element = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено не целое число! Повторите попытку.");
                    Console.ResetColor();
                }
            }

            return element;
        }
        public static ConsoleKeyInfo InputCommand(params char[] commands) //ввод команды в меню
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
        }
    }

    class NegativeLengthException : Exception { } //исключение для отрицательной длины массива
}
