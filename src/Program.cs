using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Отработки_основ_программирования
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();
                string input = Console.ReadLine();
                if (input == "0") break;

                try
                {
                    int choice = int.Parse(input);
                    RunTask(choice);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
                Console.ReadKey();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Выберите номер задания:");
            Console.WriteLine("1. Разработайте программу, которая принимает четыре числа и находит среднее значение между ними");
            Console.WriteLine("2. Разработайте программу-калькулятор, в которой можно выбрать действие для двух вводимых пользователем чисел");
            Console.WriteLine("3. Разработайте программу для конвертации температуры между градусами Цельсия, Кельвина, Фаренгейта");
            Console.WriteLine("4. Разработайте программу, которая позволяет определить имя файла (с расширением) по введенному пути");
            Console.WriteLine("5. Разработайте программу для нахождения самого длинного слова в предложении"); 
            Console.WriteLine("6. Разработайте программу, которая может перемножить два массива значений"); 
            Console.WriteLine("7. Разработайте программу, которая может найти максимальное и минимальное число из пяти введенных"); 
            Console.WriteLine("8. Разработайте программу, которая выводит “пирамиду” из чисел из количества уровней, введенных пользователем"); 
            Console.WriteLine("9. Напечатать полную таблицу умножения в виде:"); 
            Console.WriteLine("10. Разработайте программу, которая выводит “пирамиду” из чисел из количества уровней, введенных пользователем (Вариант 11)"); 
            Console.WriteLine("0. Выход");
            Console.WriteLine("Введите номер задания (или '0' для выхода):");
        }

        static void RunTask(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;
                case 8: Task8(); break;
                case 9: Task9(); break;
                case 10: Task10(); break; 
                default: Console.WriteLine("Неверный ввод."); break;
            }
        }

        static void Task1()
        {
            Console.Clear();
            Console.WriteLine("Задача 1: Среднее арифметическое четырех чисел");

            double[] numbers = GetFourNumbers();
            if (numbers == null) return; 

            double average = numbers.Average();
            Console.WriteLine($"Среднее значение: {average}");
            Console.WriteLine("Задача завершена...");
        }

        static double[] GetFourNumbers()
        {
            double[] numbers = new double[4];
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    Console.Write($"Введите число {i + 1}: ");
                    if (double.TryParse(Console.ReadLine(), out double num))
                    {
                        numbers[i] = num;
                        break;
                    }
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
            }
            return numbers;
        }


        static void Task2()
        {
            Console.Clear();
            Console.WriteLine("Задача 2: Калькулятор");

            double num1 = GetDouble("Введите первое число: ");
            double num2 = GetDouble("Введите второе число: ");

            if (double.IsNaN(num1) || double.IsNaN(num2)) return; 

            int choice = GetIntChoice("Выберите операцию (1-5):\n1. Сложение\n2. Вычитание\n3. Умножение\n4. Деление\n5. Остаток от деления\nВаш выбор: ", 1, 5);
            if (choice == -1) return; //Ошибка ввода

            double result = Calculate(num1, num2, choice);
            if (double.IsNaN(result)) return; 

            Console.WriteLine($"Результат: {result}");
            Console.WriteLine("Задача завершена...");
        }

        static double Calculate(double num1, double num2, int choice)
        {
            switch (choice)
            {
                case 1: return num1 + num2;
                case 2: return num1 - num2;
                case 3: return num1 * num2;
                case 4:
                    if (num2 == 0)
                    {
                        Console.WriteLine("Ошибка: Деление на ноль!");
                        return double.NaN;
                    }
                    return num1 / num2;
                case 5: return num1 % num2;
                default: return double.NaN;
            }
        }

        static void Task3()
        {
            Console.Clear();
            Console.WriteLine("Задача 3: Конвертер температур");
            double temp = GetDouble("Введите температуру в Цельсиях: ");
            if (double.IsNaN(temp)) return;
            double fahrenheit = temp * 9 / 5 + 32;
            Console.WriteLine($"{temp}°C = {fahrenheit}°F");
            Console.WriteLine("Задача завершена...");
        }

       static void Task4()
 {
     Console.Clear(); Console.WriteLine("Задача 4: Определение имени файла по пути.");
     Console.Write("Введите путь к файлу: ");
     string path = Console.ReadLine();
     if (File.Exists(path))
     {
         string fileName = Path.GetFileName(path); Console.WriteLine($"Имя файла: {fileName}");
     }
     else
     {
         throw new FileNotFoundException("Файл не найден.");
     }
     WaitForKey();
 }

        static void Task5()
        {
            Console.Clear();
            Console.WriteLine("Задача 5: Самое длинное слово");

            string sentence = GetString("Введите предложение: ");
            if (string.IsNullOrWhiteSpace(sentence))
            {
                Console.WriteLine("Пустое предложение.");
                return;
            }

            string longestWord = sentence.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                          .OrderByDescending(word => word.Length)
                                          .First();

            Console.WriteLine($"Самое длинное слово: {longestWord}");
            Console.WriteLine("Задача завершена...");
        }



        static void Task6()
        {
            Console.Clear();
            Console.WriteLine("Задача 6: Перемножение массивов");

            int[] arr1 = GetIntArray("Введите элементы первого массива через пробел: ");
            int[] arr2 = GetIntArray("Введите элементы второго массива через пробел: ");

            if (arr1 == null || arr2 == null || arr1.Length != arr2.Length)
            {
                Console.WriteLine("Ошибка: Массивы должны быть одинаковой длины и содержать только числа.");
                return;
            }

            int[] result = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] * arr2[i];
            }

            Console.WriteLine("Результат:");
            Console.WriteLine(string.Join(" ", result));
            Console.WriteLine("Задача завершена...");
        }


        static void Task7()
        {
            Console.Clear();
            Console.WriteLine("Задача 7: Максимум и минимум из пяти чисел");

            double[] numbers = GetFiveNumbers();
            if (numbers == null) return;

            double min = numbers.Min();
            double max = numbers.Max();

            Console.WriteLine($"Минимальное число: {min}");
            Console.WriteLine($"Максимальное число: {max}");
            Console.WriteLine("Задача завершена...");
        }

        static double[] GetFiveNumbers()
        {
            double[] numbers = new double[5];
            for (int i = 0; i < 5; i++)
            {
                numbers[i] = GetDouble($"Введите число {i + 1}: ");
                if (double.IsNaN(numbers[i])) return null; //Ошибка ввода
            }
            return numbers;
        }


        static void Task8()
        {
            Console.Clear();
            Console.WriteLine("Задача 8: Пирамида чисел");

            int numLevels = GetInt("Введите количество уровней пирамиды (целое положительное число): ");
            if (numLevels <= 0)
            {
                Console.WriteLine("Ошибка: Количество уровней должно быть положительным.");
                return;
            }

            for (int i = 1; i <= numLevels; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Задача завершена...");
        }
        static void Task9()
        {
            Console.Clear();
            Console.WriteLine("Задача 9: Таблица умножения");

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.Write($"{i} x {j} = {i * j}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Задача завершена...");
        }

        static void Task10()
        {
            Console.Clear();
            Console.WriteLine("Задача 10: Пирамида чисел (Вариант 11)");

            int numLevels = GetPositiveInt("Введите количество уровней пирамиды: ");
            if (numLevels <= 0) return; 

            PrintPyramid(numLevels);
            Console.WriteLine("Задача завершена...");
        }

        static void PrintPyramid(int numLevels)
        {
            for (int i = 1; i <= numLevels; i++)
            {
                
                for (int k = 0; k < numLevels - i; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }

      

        static double GetDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double num)) return num;
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }

        static int GetInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int num)) return num;
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
        static int GetIntChoice(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine($"Некорректный ввод. Введите число от {min} до {max}.");
            }
        }
        static int[] GetIntArray(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                string[] numbersStr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = new int[numbersStr.Length];
                bool success = true;
                for (int i = 0; i < numbersStr.Length; i++)
                {
                    if (!int.TryParse(numbersStr[i], out numbers[i]))
                    {
                        success = false;
                        break;
                    }
                }
                if (success) return numbers;
                Console.WriteLine("Ошибка: Введите целые числа через пробел или запятую.");
            }
        }
        static int GetPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int num) && num > 0)
                {
                    return num;
                }
                Console.WriteLine("Ошибка! Введите положительное целое число.");
            }
        }

        static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        static void WaitForKey()
{
    Console.WriteLine("Задача завершена, нажмите на любую клавишу, чтобы вернуться к списку задач"); Console.ReadKey();
}
    }
}
