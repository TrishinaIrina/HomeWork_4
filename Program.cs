using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4_string_array_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrays();
            //DeleteA();
            //DeleteWordContains();
            //SquareBrackets();
            //Two_dimensionalArray();
            //Two_dimensionalArray2();
            //Two_dimensionalArray3();
            //UntilPoint();

            //if (Lucky()) Console.WriteLine("Yes"); 
            //else Console.WriteLine("No");

            //ConvertTo();
            //ReversNumber();
            //DeleteChar();
            //ReplaceDouble();
            //CountNumber();
            //FindOne();
            //OtherCharacters();
            //СommonStartLetter();
            //CountP();
            //CountWordInText();
            //СountWord();
            SumNumber();

        }

        //Напечатать весь массив целых чисел
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("");
        }

        //Удалить элемент из массива по индексу
        public static T[] DeleteByIndex<T>(T[] array, int index)
        {
            T[] newArray = new T[array.Length - 1];
            int ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == index) continue;
                newArray[ind++] = array[i];
            }
            return newArray;
        }

        //Удаление элементов из массива по значению (размер конечного массива уменьшу)
        public static int[] DeleteByValue(int[] array, int value)
        {
            int[] bufArray = new int[array.Length];
            int ind = 0;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    count++;
                    continue;
                }
                bufArray[ind++] = array[i];
            }
            int[] newArray = new int[array.Length - count];
            for (int i = 0; i < array.Length - count; i++)
            {
                newArray[i] = bufArray[i];
            }
            return newArray;
        }


        //Вставить элемент в массив по индексу
        public static T[] InsertAt<T>(T[] array, T value, int index)
        {
            int indexNewArray = 0;
            int indexArray = 0;
            T[] newArray = new T[array.Length + 1];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (index == i)
                {
                    newArray[indexNewArray++] = value;
                }
                else
                    newArray[indexNewArray++] = array[indexArray++];
            }
            return newArray;
        }

        public static void Arrays()
        {
            int[] array = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 100);
            }

            PrintArray(array);

            //Найти индекс максимального значения в массиве(воспользоваться функцией)
            int max = array.Max();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == max)
                {
                    Console.WriteLine("Индекс элемента с максимальным значением: " + i);
                }
            }

            //Найти индекс максимального четного значения в массиве
            max = -1; // т.к. сгенерировали только положительные
            int indexMax = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max && array[i] % 2 == 0)
                {
                    max = array[i];
                    indexMax = i;
                }
            }
            Console.WriteLine("Индекс максимального четного значения в массиве: " + indexMax);

            //Удалить элемент из массива по индексу.
            Console.WriteLine("Удаляем элемент с индексом 5");
            array = DeleteByIndex(array, 5);
            PrintArray(array);

            //Удаление элементов из массива по значению
            Console.WriteLine("Удаляем элемент со значением 30 (если оно есть): ");
            array = DeleteByValue(array, 30);
            PrintArray(array);

            //Вставить элемент в массив по индексу
            Console.WriteLine("Вставляем в начало массива цифру 77: ");
            array = InsertAt(array, 77, 0);
            PrintArray(array);

            //Удалить те элементы массива, которые встречаются в нем ровно два раза
            int count = 1;
            int index2 = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                        if (count == 2) index2 = j;
                    }
                }
                if (count == 2)
                {
                    array = DeleteByIndex(array, i);
                    array = DeleteByIndex(array, index2 - 1); // -1 потому что после первой операции DeleteByIndex массив стал короче
                }
                count = 1;
                index2 = 0;
            }
            Console.WriteLine("Элементы встречаюшиеся ровно 2 раза удалены из масива");
            PrintArray(array);
        }

        //Удалить из строки слова, в которых есть буква 'a'
        public static void DeleteA()
        {
            Console.WriteLine("Введите строку (на латинице): ");
            string str = Console.ReadLine();
            string[] array = str.Split(' ');
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains("a"))
                {
                    array = DeleteByIndex(array, i);
                }
            }
            str = string.Join(" ", array);
            Console.WriteLine(str);
        }

        //Удалить из строки слова, в которых есть хоть одна буква последнего слова
        public static void DeleteWordContains()
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            string[] array = str.Split(' ');
            string last = array[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < last.Length; j++)
                {
                    string buf = Convert.ToString(last[j]);
                    if (array[i].Contains(buf))
                    {
                        array = DeleteByIndex(array, i);
                        i--;
                        break;
                    }
                }
            }
            str = string.Join(" ", array);
            Console.WriteLine("Все слова, в которых есть хоть одна буква последнего слова, удалены: " + str);
        }

        //	В строке все слова, которые начинаются и заканчиваются одной буквой, выделить квадратными скобками
        public static void SquareBrackets()
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            string[] array = str.Split(' ');
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i][0] == array[i][array[i].Length - 1])
                {
                    array[i] = array[i].Insert(0, "[");
                    array[i] = array[i].Insert(array[i].Length, "]");
                }
            }
            str = string.Join(" ", array);
            Console.WriteLine("Все слова, которые начинаются и заканчиваются одной буквой, выделены квадратными скобками: " + str);
        }

        private static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        //Обнулить элементы тех строк, на пересечении которых с главной диагональю стоит четный элемент
        public static void Two_dimensionalArray()
        {
            int[,] array = new int[10, 10];
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = rnd.Next(10, 99);
            }
            PrintArray(array);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == j && array[i, j] % 2 == 0)
                    {
                        for (int k = 0; k < array.GetLength(1); k++)
                        {
                            array[i, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("Обнулены элементы тех строк, на пересечении которых с главной диагональю стоит четный элемент");
            PrintArray(array);

        }

        //Обнулить элементы тех столбцов, на пересечении которых с главной диагональю стоит четный элемент
        public static void Two_dimensionalArray2()
        {
            int[,] array = new int[10, 10];
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = rnd.Next(10, 99);
            }
            PrintArray(array);
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (i == j && array[i, j] % 2 == 0)
                        for (int k = 0; k < array.GetLength(0); k++)
                            array[k, j] = 0;
            Console.WriteLine("Обнулены элементы тех столбцов, на пересечении которых с главной диагональю стоит четный элемент");
            PrintArray(array);
        }

        public static int[,] DeleteColumn(int[,] array, int index)
        {
            int[,] newArray = new int[array.GetLength(0), array.GetLength(1) - 1];
            int I = 0;
            int J = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == index) continue;
                    else
                    {
                        newArray[I, J++] = array[i, j];
                    }
                }
                I++;
                J = 0;
            }
            return newArray;
        }


        //Удалить те столбцы, в которых встречается хотя бы два одинаковых элемента
        public static void Two_dimensionalArray3()
        {
            int[,] array = new int[5, 5];
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = rnd.Next(1, 9);
            }
            PrintArray(array);

            for (int j = 0; j < array.GetLength(1); j++)
            {
                int count = 0;
                for (int i = 0; i < array.GetLength(0) - 1; i++)
                {
                    for (int m = i + 1; m < array.GetLength(0); m++)
                    {
                        if (array[i, j] == array[m, j])
                        {
                            count++;
                            break;
                        }
                    }
                }
                if (count > 0)
                {
                    if (array.GetLength(1) == 1)
                    {
                        Console.WriteLine("Удален весь массив, т.к. в каждом столбце есть пвторяющиеся числа");
                        return;
                    }
                    array = DeleteColumn(array, j);
                    j--;
                }
            }
            Console.WriteLine("Удалены те столбцы, в которых встречается хотя бы два одинаковых элемента");
            PrintArray(array);
        }

        /*•	Написать программу, которая считывает символы с клавиатуры, пока не будет введена точка. 
         * Программа должна сосчитать количество введенных пользователем пробелов. 
         * (Подсказка. IF, Length)*/
        public static void UntilPoint()
        {
            string str = "";
            char buf = ' ';
            int count = 0;
            while (true)
            {
                buf = Convert.ToChar(Console.Read());
                if (buf == '.')
                {
                    str += buf;
                    break;
                }
                else str += buf;
                if (buf == ' ')
                    count++;
            }
            Console.WriteLine(str);
            Console.WriteLine("Количество введенных пробелов: " + count);
        }

        /*•	Ввести с клавиатуры номер трамвайного билета (6-значное число) и проверить является ли 
         * данный билет счастливым (если на билете напечатано шестизначное число, и сумма первых трёх 
         * цифр равна сумме последних трёх, то этот билет считается счастливым).
           (Подсказка. SUBSTRING, LENGTH)*/
        public static bool Lucky()
        {

            int half1 = 0;
            int half2 = 0;
            string str = Console.ReadLine();
            if (str.Length != 6) return false;
            else
            {
                int[] array = new int[str.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Convert.ToInt32(str[i]);
                    if (i >= 0 && i <= 2) half1 += array[i];
                    else half2 += array[i];
                }
                if (half1 == half2) return true;
                else return false;
            }
        }

        /*•	Числовые значения символов нижнего регистра в коде ASCII отличаются от значений
         * символов верхнего регистра на величину 32. Используя эту информацию, 
         * написать программу, которая считывает с клавиатуры и конвертирует все символы 
         * нижнего регистра в символы верхнего регистра и наоборот.*/
        public static void ConvertTo()
        {
            string c = Console.ReadLine();
            string C = c.ToUpper();
            if (c == C) c = c.ToLower();
            else c = c.ToUpper();
            Console.WriteLine(c);
        }

        /*•	Дано целое число N (> 0), найти число, полученное при прочтении числа N справа
         * налево. Например, если было введено число 345, то программа должна вывести число 543.
           (Подсказка – вспомните что есть строка, и как мы с ней можем работать)*/
        public static void ReversNumber()
        {
            string number = Console.ReadLine();
            string output = new string(number.ToCharArray().Reverse().ToArray());
            int newNumber = Convert.ToInt32(output);
            Console.WriteLine(newNumber);
        }

        /*•	Объявить одномерный (5 элементов ) массив с именем A и двумерный массив (3 строки, 4 столбца) дробных чисел с именем B. 
         * Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, а двумерный массив В случайными числами с помощью циклов. 
         * Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы. Найти в данных массивах общий максимальный элемент,
         * минимальный элемент, общую сумму всех элементов, общее произведение всех элементов, сумму четных элементов массива А, сумму нечетных столбцов массива В.
         
         •	Дан двумерный массив размерностью 5×5, заполненный случайными числами из диапазона от –100 до 100. Определить сумму элементов массива, расположенных между минимальным и максимальным элементами
            Подсказка – Random rnd = new Random, rnd.Next(1, 15).  ЭТИ ДВА ЗАДАНИЯ УЖЕ БЫЛИ В ПРЕДЫДУЩЕМ ДЗ, НЕ СТАЛА ДУБЛИРОВАТЬ*/



        /*•	Есть строка (любая), нужно удалить из этой строки знаки / и \*/
        public static void DeleteChar()
        {
            Console.WriteLine("введите строку");
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\\' || str[i] == '/')
                {
                    string subString1 = str.Substring(0, i);
                    string subString2 = str.Substring(i + 1);
                    str = subString1 + subString2;
                    i--;
                }
            }
            Console.WriteLine(str);
        }

        //•	Составьте программу, которая в слове «класс» две одинаковые буквы заменяет цифрой «1»
        public static void ReplaceDouble()
        {
            string forExampleClass = Console.ReadLine();
            for (int i = 0; i < forExampleClass.Length - 1; i++)
            {
                if (forExampleClass[i] == forExampleClass[i + 1])
                {
                    forExampleClass = forExampleClass.Replace(forExampleClass[i], '1');
                }
            }
            Console.WriteLine(forExampleClass);
        }


        //	Написать программу, подсчитывающую количество цифр в заданной строке.
        public static void CountNumber()
        {
            string str = Console.ReadLine();
            int count = 0;
            int buf;
            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i].ToString(), out buf)) count++;
            }
            Console.WriteLine("Количество цифр в строке: " + count);
        }


        //•	Дан текст. Определить, есть ли в тексте слово one.
        public static void FindOne()
        {
            string str = Console.ReadLine();
            if (str.Contains("one"))
                Console.WriteLine("contains the word \"one\"");
            else
                Console.WriteLine("does not contains the word \"one\"");
        }


        //•	Дан текст. Определить, содержит ли он символы, отличающиеся от букв и цифр.
        public static void OtherCharacters()
        {
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]) || char.IsLetter(str[i]) || str[i] == ' ') continue;
                else
                {
                    Console.WriteLine("Cодержит символы, отличающиеся от букв и цифр");
                    return;
                }
            }
            Console.WriteLine("Не содержит символы, отличающиеся от букв и цифр");
        }

        //•	Нужно ввести текст и определить, на какую букв начинается больше всего слов в тексте.
        public static void СommonStartLetter()
        {
            string str = Console.ReadLine();
            string[] array = str.Split(' ');
            int max = 0;
            char charMax = array[0][0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                int count = 1;
                char FirstLetter1 = array[i][0];
                for (int j = i + 1; j < array.Length; j++)
                {
                    char FirstLetter2 = array[j][0];
                    if (FirstLetter1 == FirstLetter2 || FirstLetter1 == Char.ToUpper(FirstLetter2) || FirstLetter1 == Char.ToLower(FirstLetter2))
                        count++;
                }
                if (count > max)
                {
                    max = count;
                    charMax = array[i][0];
                }
            }
            Console.WriteLine("больше всего слов начинаются на букву: " + charMax);
            Console.WriteLine("Она встречается в начале слова: " + max + " раз");
        }

        //•	Дана строка, посчитать количество вхождений буквы P.
        public static void CountP()
        {
            string str = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'p' || str[i] == 'P') count++;
            }
            Console.WriteLine("Количество вхождений буквы P: " + count);
        }

        //•	Ввести небольшой текст (с пробелами) в строку S.
        //Подсчитать количество слов в строке и вывести все слова в столбик.
        public static void CountWordInText()
        {
            string S = Console.ReadLine();
            string[] array = S.Split(' ');
            for (int i = 0; i < array.Length; i++) //чтобы слова в столбик вывелись без знаков препинания или скобок
            {
                array[i] = array[i].Trim('.');
                array[i] = array[i].Trim(',');
                array[i] = array[i].Trim('(');
                array[i] = array[i].Trim(')');
            }
            Console.WriteLine("Количество слов в тексте: " + array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        /*•	Дана строка символов. Группы символов, разделенные пробелами и не содержащие пробелов
         * внутри себя, будем называть словами. 
         * Найти количество слов, у которых первый и последний символы совпадают между собой 
         * (если можно с комментариями).*/

        public static void СountWord() // определяем метод
        {
            string str = Console.ReadLine(); //считываем строку
            string[] array = str.Split(' '); //разделяем строку на массив стрингов по пробелу
            int count = 0;                    //счетчик
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length == 1)
                {
                    count++;         // если в слове 1 буква, то можно сказать что в слове
                    continue;        ///первый и последний символ совпадают между собой
                }
                else if (array[i][0] == array[i][array[i].Length - 1] || array[i][0] == Char.ToUpper(array[i][array[i].Length - 1]) || array[i][0] == Char.ToLower(array[i][array[i].Length - 1]))
                    count++;
                //сравниваю первый и последний символ каждого слова.
                //два доп условия, чтобы учесть регистр
                //Если равны счетчик++ и дальше по циклу
            }
            Console.WriteLine("количество слов, у которых первый и последний символы совпадают между собой: " + count); //вывод результата на консоль
        }



        /*За решение этой задачи, первым трем сникерс
         * Дана строка символов, состоящая из цифр от 0 до 9 и пробелов.
         * Группы цифр, разделенные пробелами (одним или несколькими) и не содержащие пробелов внутри себя, 
         * будем называть словами. Рассматривая эти слова как числа, определить и напечатать сумму чисел, 
         * оканчивающихся на цифры 3 или 4*/
        public static void SumNumber()
        {
            int sum = 0;
            string str = Console.ReadLine();
            str = str.Trim(' ');                           //уберем пробелы в начеле/конце (если они есть)
            for (int i = 0; i < str.Length - 1; i++) //уберем лишние пробелы внутри строки (Length - 1 чтобы не выйти за пределы массива символов)
            {
                if (str[i] == ' ' && str[i + 1] == ' ')
                {
                    str = str.Remove(i, 1);
                    i--;
                }
            }
            string[] array = str.Split(' '); //разделяем строку на массив стрингов по оставшимся единичным пробелам
            for (int i = 0; i < array.Length; i++)
            {
                int number = int.Parse(array[i]); // каждый элемент массива преобразуем в число
                if (number % 10 == 3 || number % 10 == 4) sum += number; // добавляем в сумму если число оканчиватеся на 3 или 4
            }
            Console.WriteLine("Сумма чисел оканчивающихся на цифры 3 или 4: " + sum);
        }


    }
}

    