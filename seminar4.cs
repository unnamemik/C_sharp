using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class Seminar3
{

    static void Main()
    {
        //Console.OutputEncoding = Encoding.UTF8;
        int ex_num = 6;

        while (ex_num != 0)
        {
            if (ex_num != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;     // Блок меню
                Console.WriteLine("\nВведите номер, чтобы выбрать задачу: \n 1. Возведение в степень \n 2. Сумма цифр в числе\n " +
                    "3. Массив из N элементов\n 4. Максимальный элемент массива [-10; 10] \n 5. Разница средних арифметических двух массивов в битах" +
                    "\n Для выхода из программы введите 0\n");
                Console.ForegroundColor = ConsoleColor.Red;
                ex_num = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
            }

            switch (ex_num)                                        // Блок переключения на пункты меню
            {
                case 1:
                    degree();
                    break;
                case 2:
                    num_sum();
                    break;
                case 3:
                    mas_set();
                    break;
                case 4:
                    max_in_mas();
                    break;
                case 5:
                    average_in_bits();
                    break;
            }


            void degree()                                           // Блок вычисления степени
            {
                Console.Write("\n\nВведите число-основание: ");
                double num_base = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nВведите число-степень: ");
                double num_degree = Convert.ToDouble(Console.ReadLine());

                double res = Math.Pow(num_base, num_degree);

                Console.WriteLine("\nОтвет: {0}^{1} = {2}\n", num_base, num_degree, res);
            }

            void num_sum()                                           // Блок вычисления суммы цифр в числе
            {
                Console.Write("\n\nВведите число: ");
                string num = Console.ReadLine();
                int dig_sum = 0;
                for (int i = 0; i < num.Length; i++)

                {
                    dig_sum = Convert.ToInt32(num.Substring(i, 1)) + dig_sum;
                }

                Console.WriteLine("\nСумма цифр в числе {0} равна {1}", num, dig_sum);
            }

            void mas_set()                                                     // Блок вывода массива по заданному размеру
            {
                Console.Write("\n\nВведите число - размер массива: ");
                int arr_length = int.Parse(Console.ReadLine());

                Console.WriteLine("\nМассив из {0} элементов:\n", arr_length);

                Random random = new Random();
                for (int i = 0; i < arr_length; i++)
                {
                    Console.Write(random.Next(1, 100) + " ");
                }
                Console.Write("\n\n");
            }

            void max_in_mas()                                                     // Блок поиска максимального в массиве
            {
                Console.Write("\n\nМассив чисел: \n\n");
                Random random = new Random();
                int max_num = -11;

                for (int i = 0; i < 11; i++)
                {
                    int rnd = random.Next(-10, 10);
                    max_num = (max_num < rnd) ? rnd : max_num;
                    Console.Write(rnd + "  ");
                }
                Console.Write("\n\nМаксимальное число в массиве: {0}\n\n", max_num);
            }

            void average_in_bits()                                                     // Блок вычисления среднего арифметического в битах
            {
                Console.Write("\n\nВведите число - размер первого массива: ");
                int arr_length1 = int.Parse(Console.ReadLine());

                Console.Write("\nВведите число - размер второго массива: ");
                int arr_length2 = int.Parse(Console.ReadLine());

                int[] arr1 = new int[arr_length1];
                int[] arr2 = new int[arr_length2];

                double sum_arr1 = 0;
                double sum_arr2 = 0;

                Random random = new Random();

                Console.Write("\nПервый массив чисел: \n");
                for (int i = 0; i < arr_length1; i++)
                {
                    Console.Write("  {0}", arr1[i] = random.Next(1, 10));
                    sum_arr1 = sum_arr1 + arr1[i];
                }

                Console.Write("\nВторой массив чисел: \n");
                for (int i = 0; i < arr_length2; i++)
                {
                    Console.Write("  {0}", arr2[i] = random.Next(1, 10));
                    sum_arr2 = sum_arr2 + arr2[i];
                }
                double average1 = sum_arr1 / arr_length1;
                double average2 = sum_arr2 / arr_length2;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\nСреднее арифметическое первого массива: {0}", Math.Round(average1, 2));
                Console.Write("\nСреднее арифметическое второго массива: {0}\n", Math.Round(average2, 2));

                double max_num = (average1 >= average2) ? average1 : average2;
                double min_num = (average2 < average1) ? average2 : average1;

                int result = Convert.ToInt32(max_num - min_num);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nРазница (округленная) между средними арифметическими числами:\n     - в десятичном виде:  " + Convert.ToString(result) + 
                    "\n     - в двоичном виде:  " + Convert.ToString(result, toBase: 2) + "\n\n");
            }
        }
    }
}