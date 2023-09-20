using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static int ArrayLength = 10;
        static void Main(string[] args)
        {
            //task48();
            /*Задана последовательность N вещественных чисел. Вычислить сумму чисел, порядковые номера которых являются:
            а) простыми числами;
            б) числами Фибоначчи.
            */
            //task55();
            /*Сформировать массив простых множителей заданного числа.
            */
            //task74();
            /*Дана последовательность вещественных чисел а1, a2, ..., а15. Определить, есть ли в последовательности отрицательные числа. 
            В случае положительного ответа определить порядковый номер первого из них.
            */
            //task111();
            /*
             На k-e место одномерного массива вещественных чисел вставить элемент, равный среднему арифметическому элементов массива.
            */
            //task172();
            /*
             Написать алгоритм смены мест в заданном массиве 1-го элемента с последним, 2-го с предпоследним и так далее.
             */
        }
        static void task172()
        {
            Random random = new Random();
            int[] array = new int[ArrayLength];
            Console.WriteLine("Изначальный массив целых чисел:");
            for (int i = 0; i < ArrayLength; i++)
            {
                array[i] = random.Next(20) - 10;
                Console.Write(array[i] + " ");
            }
            //Алгоритм смены мест в заданном массиве
            for (int i = 0; i < array.Length/2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
            Console.WriteLine("Массив после смены мест элементов:");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
        }

        static void task111()
        {
            Random random = new Random();
            double[] array = new double[ArrayLength];
            Console.WriteLine("Одномерный массив вещественных чисел:");
            for (int i = 0; i < ArrayLength; i++)
            {
                array[i] = (random.NextDouble()) * 20 - 10;
                Console.WriteLine(array[i]);
            }
            Console.WriteLine($"Введите число от 1 до {ArrayLength}: ");
            int numberK;
            while (true)
            {
                try
                {
                    numberK = int.Parse(Console.ReadLine());
                    if (numberK < 1 || numberK > ArrayLength)
                    {
                        Console.WriteLine("Число должно быть меньше либо равно 10 или больше либо равно 1.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Число должно быть целым и быть меньше либо равно {ArrayLength} или больше либо равно 1.");
                }
            }
            double sum = 0;
            foreach (double item in array)
            {
                sum += item;
            }
            //Изменяем размер массива и переносим все значения с К-того места на один 
            Array.Resize(ref array, ArrayLength + 1);
            Array.Copy(array, numberK - 1, array, numberK, array.Length - numberK);
            array[numberK - 1] = sum / ArrayLength;
            Console.WriteLine("Новый массив с К-тым элементом который равняется среднему арифметическому элементов массива:");
            foreach (double item in array)
            {
                Console.WriteLine(item);
            }
        }
        static void task74()
        {
            Random random = new Random();
            double[] array = new double[15];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (random.NextDouble()) * 20 - 10;
                Console.WriteLine(array[i]);
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    Console.WriteLine("Первое отрицательное число находится под порядковым номером {0}", i + 1);
                    return;
                }
            }
            Console.WriteLine("В последовательности нет отрицательных чисел.");
        }
        static void task55()
        {
            int number;
            Console.Write("Введите число: ");
            while (true)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 2)
                    {
                        Console.WriteLine("Число должно быть больше или равно 2.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Число должно быть целым и быть больше или равно 2.");
                }
            }
            Console.WriteLine("Массив простых множителей числа {0}:", number);
            int[] primeFactors = new int[0];
            int divisor = 2; // Начинаем с делителя 2
            while (number > 1)
            {
                // Проверяем, является ли divisor делителем number
                while (number % divisor == 0)
                {
                    Array.Resize(ref primeFactors, primeFactors.Length + 1);
                    primeFactors[primeFactors.Length - 1] = divisor;
                    number /= divisor;
                }
                // Увеличиваем делитель
                divisor++;
            }
            foreach (int factor in primeFactors)
            {
                Console.WriteLine(factor);
            }
        }
        static void task48()
        {
            int number;
            Console.Write("Введите число N (размер массива): ");
            while (true)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1)
                    {
                        Console.WriteLine("Число должно быть больше или равно 1.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Число должно быть целым и быть больше или равно 1.");
                }
            }
            Random random = new Random();
            double[] array = new double[number];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (random.NextDouble()) * 20 - 10;
                Console.WriteLine(array[i]);
            }
            int[] fibonacciNumbers = GenerateFibonacciNumbers(array.Length);
            double sumPrimes = 0;
            double sumFibonacci = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPrime(i+1))
                {
                    sumPrimes += array[i];
                }
                if (fibonacciNumbers.Contains(i))
                {
                    sumFibonacci += array[i];
                }
            }
            Console.WriteLine("Сумма чисел с простыми порядковыми номерами: " + sumPrimes);
            Console.WriteLine("Сумма чисел с порядковыми номерами чисел Фибоначчи: " + sumFibonacci);
        }
        /// <summary>
        /// Функция для определения является ли переданное число простым
        /// </summary>
        /// <param name="n">Порядковый номер который мы хотим проверить</param>
        /// <returns>Возвращает bool true если число простое false в другом случае</returns>
        static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Функция которая создаёт массив который хранит ряд Фибоначчи до заданного числа
        /// </summary>
        /// <param name="n">Число до которого необходимо найти ряд Фибоначчи</param>
        /// <returns>Возвращает массив в котором записан ряд Фибоначчи</returns>
        static int[] GenerateFibonacciNumbers(int n)
        {
            int[] fibonacciNumbers = new int[0];
            int a = 0, temp, b = 1;
            do
            {
                Array.Resize(ref fibonacciNumbers, fibonacciNumbers.Length + 1);
                fibonacciNumbers[fibonacciNumbers.Length - 1] = a;
                temp = a;
                a = b;
                b = temp + b;
            }
            while (fibonacciNumbers[fibonacciNumbers.Length - 1] < n);
            return fibonacciNumbers;
        }
    }
}
