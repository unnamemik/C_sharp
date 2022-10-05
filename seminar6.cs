/*Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

0, 7, 8, -2, -2 -> 2

1, -7, 567, 89, 223-> 3

Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

b1 = 2, k1 = 5, b2 = 4, k2 = 9-> (-0, 5; -0,5)

Необязательная к выполнению задача (не будет влиять на итоговую оценку ДЗ)
Дополнительная задача(задача со звёздочкой): Напишите программу, которая задаёт массив из n элементов, которые необходимо заполнить случайными значениями и сдвинуть элементы массива влево, или вправо на 1 позицию.

[8, 5, 1, 7, 0] - [5, 1, 7, 0, 8] - сдвиг влево

[8, 5, 1, 7, 0] - [0, 8, 5, 1, 7] - сдвиг вправо*/


class Seminar6
{

    static void Main()
    {
        int ex_num = 5;

        while (ex_num != 0)
        {
            if (ex_num != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;     // Блок меню
                Console.WriteLine("\nВведите номер, чтобы выбрать задачу: \n 1. Количество чисел больше нуля в массиве.\n 2. Точка пересечения двух прямых.\n " +
                    "3. Сдвиг элементов массива\n 4. Ряд Фибоначчи (без массива)" +
                    "\n Для выхода из программы введите 0\n");
                Console.ForegroundColor = ConsoleColor.Red;
                ex_num = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
            }

            switch (ex_num)                                             // Блок переключения на пункты меню
            {
                case 1:
                    findPositive();
                    break;
                case 2:
                    findCross();
                    break;
                case 3:
                    shiftArr();
                    break;
                case 4:
                    fibonacci();
                    break;
            }

            void findPositive()                                           //1. Количество чисел больше нуля в массиве.
            {
                Console.WriteLine("\nВведите числа: ");
                string? nums_str = Console.ReadLine();

                int count = 0;

                char[] separators = { ' ', ',', ';' };
                string[] str_arr = nums_str.Split(separators);

                for (int i = 0; i < str_arr.Length; i++)
                {
                    if (Convert.ToInt32(str_arr[i]) > 0) { count++; };
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nКоличество положительных чисел: " + count);
            }

            void findCross()                                                  //2. Точка пересечения двух прямых
            {
                Console.Write("\nВведите b1: ");
                double b1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("\nВведите k1: ");
                double k1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("\nВведите b2: ");
                double b2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("\nВведите k2: ");
                double k2 = Convert.ToDouble(Console.ReadLine());

                double x = (b2 - b1) / (k1 - k2);
                double y = k1 * ((b2 - b1) / (k1 - k2)) + b1;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nТочка пересечения двух прямых: [ {0} : {1} ]", Math.Round(x, 2), Math.Round(y,2));
            }

            void shiftArr()                                                    // 3.Сдвиг элементов массива
            {                                                     
                Console.Write("\nВведите размер массива: ");
                int arr_size = Convert.ToInt32(Console.ReadLine());

                int[] arr = new int[arr_size];
                int[] arr_left = new int[arr_size];
                int[] arr_right = new int[arr_size];

                Random rnd = new Random();
                for (int i = 0; i < arr_size; i++)
                {
                    arr[i] = rnd.Next(1, 99);
                }

                int index = arr[0];
                for (int i = 0; i < arr_size - 1; i++)
                {
                    arr_left[i] = arr[i + 1];
                }
                arr_left[arr_size - 1] = index;

                index = arr[arr_size - 1];
                for (int i = 1; i < arr_size; i++)
                {
                    arr_right[i] = arr[i - 1];
                }
                arr_right[0] = index;

                Console.WriteLine("\nИсходный массив: " + String.Join(", ", arr));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nСмещение влево: " + String.Join(", ", arr_left));
                Console.WriteLine("\nСмещение вправо: " + String.Join(", ", arr_right));
            }

            void fibonacci()                                                     // 4. Ряд Фибоначчи
            {
                Console.Write("\nВведите элемент - конец ряда: ");
                int num = Convert.ToInt32(Console.ReadLine());

                int fib1 = 0;
                int fib2 = 1;
                int fib_sum = 0;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nРяд Фибоначчи: 0, 1");
                for (int i = 0; i < num - 2; i++)
                {
                    fib_sum = fib1 + fib2;
                    fib1 = fib2;
                    fib2 = fib_sum;
                    Console.Write(", " + fib_sum);
                    Console.Write("\n\n");
                }
            }                        
        }
    }
}








