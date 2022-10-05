class Seminar3
{
    static void Main()
    {
        int ex_num = 7;

        while (ex_num != 0)
        {
            if (ex_num != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;     // Блок меню
                Console.WriteLine("\nВведите номер, чтобы выбрать задачу: \n 1. Количество четных чисел в массиве трехзначных чисел. \n 2. Сумма элементов массива с нечетным индексом\n " +
                    "3. Разница между max и min в массиве.\n 4. Разница средних арифметических двух массивов \n 5. Определение свойств последовательности массива \n " +
                    "6. Та самая задача с семинара (произведение пар элементов с краев)" +
                    "\n Для выхода из программы введите 0\n");
                Console.ForegroundColor = ConsoleColor.Red;
                ex_num = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
            }

            switch (ex_num)                                        // Блок переключения на пункты меню
            {
                case 1:
                    searchEven();
                    break;
                case 2:
                    oddIndexSum();
                    break;
                case 3:
                    maxMinDiff();
                    break;
                case 4:
                    averageDiff();
                    break;
                case 5:
                    defineProp();
                    break;
                case 6:
                    multPairs();
                    break;
            }

            void searchEven()                                           // Блок вычисления четного в массиве триплетов
            {
                Console.Write("\n\nВведите количество триплетов: ");
                int triple_quant = Convert.ToInt32(Console.ReadLine());
                int[] arr = fillArray(triple_quant, 100, 999);
                printArray(arr);

                int count = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] / 100 % 2 == 0) { count++; }
                    if (arr[i] / 10 % 2 == 0) { count++; }
                    if (arr[i] % 2 == 0) { count++; }
                }
                Console.WriteLine("\nКоличество четных чисел: {0}", count);
            }

            void oddIndexSum()                                           // Блок вычисления суммы элементов с нечетными индексами
            {
                Console.Write("\n\nВведите размер массива: ");
                int arr_size = Convert.ToInt32(Console.ReadLine());
                int[] arr = fillArray(arr_size, 1, 100);
                printArray(arr);
                int odd_sum = 0;

                for (int i = 0; i < arr_size; i++)
                {
                    odd_sum = (i % 2 != 0) ? odd_sum + arr[i] : odd_sum;
                }
                Console.WriteLine("\nСумма элементов с нечетными индексами {0}", odd_sum);
            }

            void maxMinDiff()                                                     // Разница между min и max
            {
                Console.Write("\n\nВведите размер массива: ");
                int arr_size = Convert.ToInt32(Console.ReadLine());
                int[] arr = fillArray(arr_size, 1, 100);
                printArray(arr);

                int max_in_mas = arr.Max();
                int min_in_mas = arr.Min();
                int diff = max_in_mas - min_in_mas;

                Console.Write("\n\nМаксимальное число: {0}, \nМинимальное число: {1}, \n\nРазница: {2}\n\n",
                    max_in_mas, min_in_mas, diff);
            }

            void averageDiff()                                                     // Блок вычисления разницы среднего арифметического двух массивов
            {
                Console.Write("\n\nВведите число - размер массива: ");
                int unit_arr_size = Convert.ToInt32(Console.ReadLine());
                int[] unit_arr = fillArray(unit_arr_size, 1, 99);

                printArray(unit_arr);

                int odd_sum = 0;
                int even_sum = 0;
                int odd_arr_size = 0;
                int even_arr_size = 0;
                int[] odd_arr = new int[odd_arr_size];
                int[] even_arr = new int[even_arr_size];

                for (int i = 0; i < unit_arr_size; i++)
                {
                    if (unit_arr[i] % 2 == 1)
                    {
                        odd_sum = odd_sum + unit_arr[i];
                        odd_arr_size++;
                        Array.Resize(ref odd_arr, odd_arr_size);
                        odd_arr[odd_arr_size - 1] = unit_arr[i];
                    }
                    else if (unit_arr[i] % 2 == 0)
                    {
                        even_sum = even_sum + unit_arr[i];
                        even_arr_size++;
                        Array.Resize(ref even_arr, even_arr_size);
                        even_arr[even_arr_size - 1] = unit_arr[i];
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nНечетный  ");
                printArray(odd_arr);
                Console.Write("\nЧетный  ");
                printArray(even_arr);

                double odd_average = odd_sum / odd_arr_size;
                double even_average = even_sum / even_arr_size;
                double max_num = (odd_average >= even_average) ? odd_average : even_average;
                double min_num = (even_average < odd_average) ? even_average : odd_average;

                if (odd_average == even_average) { Console.WriteLine("\n\nСреднее арифметическое первого массива равно среднему арифметическому второго:  {0}", odd_average); }
                else
                {
                    Console.WriteLine("\n\nСреднее арифметическое нечетного массива: {0}", Math.Round(odd_average, 2));
                    Console.WriteLine("\nСреднее арифметическое четного массива: {0}", Math.Round(even_average, 2));
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nРазница между средними арифметическими числами:  {0} ", Math.Round(max_num - min_num, 2) + "\n\n");
            }

            void defineProp()                                                     // Блок определения последовательности
            {
                Console.Write("\n\nВведите число - размер массива: ");
                int arr_size = Convert.ToInt32(Console.ReadLine());
                int[] arr = fillArray(arr_size, 1, 99);
                printArray(arr);

                int determ_rise = 0;
                int determ_fall = 0;
                int determ_eq = 0;
                int determ_chaot = 0;

                for (int i = 0; i < arr_size - 1; i++)
                {
                    if (arr[i] < arr[i + 1]) { determ_rise++; }
                    else if (arr[i] > arr[i + 1]) { determ_fall++; }
                    else if (arr[i] == arr[i + 1]) { determ_eq++; }
                    else { determ_chaot++; }
                }

                Console.Write("\n\nЭлементы в массиве ");
                if (determ_rise == arr_size-1) { Console.Write("расположены по возрастанию.\n"); }
                else if (determ_fall == arr_size-1) { Console.Write("расположены по убыванию.\n"); }
                else if (determ_eq == arr_size - 1) { Console.Write("равны.\n"); }
                else { Console.Write("расположены хаотично.\n"); }
            }

            void multPairs()                                                                           // умножение пар элементов с концов массива
            {
                Console.Write("\n\nВведите число - размер массива: ");
                int arr_size = Convert.ToInt32(Console.ReadLine());
                int[] arr = fillArray(arr_size, 1, 10);
                printArray(arr);

                int half_size = (arr_size + 1) / 2;

                int[] half_arr = new int[half_size];
                for (int i = 0; i < half_size; i++)
                {
                    half_arr[i] = arr[i] * arr[arr_size - 1];
                    arr_size--;
                }
                Console.WriteLine("\nПроизведение пар элементов от краев к центру:");
                printArray(half_arr);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int[] fillArray(int size, int min, int max, int sum_arr = 0)
            {
                Random rnd = new Random();
                int[] filledArray = new int[size];
                for (int i = 0; i < filledArray.Length; i++)
                {
                    filledArray[i] = rnd.Next(min, max + 1);
                    sum_arr = sum_arr + filledArray[i];
                }
                return filledArray;
            }

            void printArray(int[] arr)
            {
                Console.WriteLine("\nМассив чисел: \n");
                Console.WriteLine("[" + String.Join(",", arr) + "]");
            }
        }
    }
}