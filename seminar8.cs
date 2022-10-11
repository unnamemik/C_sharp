using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        int arrayRangeMin = -10;
        int arrayRangeMax = 10;
        int ex_num = 6;

        while (ex_num != 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;                                // Блок меню
            Console.WriteLine("\nДля корректного отображения перейдите в полноэкранный режим.\n" +
                "\nВведите номер, чтобы выбрать задачу:\n\n" +
                " 1. Нахождение строки с наименьшим элементом \n" +
                " 2. Сортировка элементов массива в строках\n" +
                " 3. Умножение матриц\n" +
                " 4. Спиральная матрица \n" +
                " 5. Вывод элементов трехмерного массива с индексами.\n\n" +
                " Для выхода из программы введите 0\n");
            Console.ForegroundColor = ConsoleColor.Red;
            ex_num = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            if (ex_num > 0 && ex_num < 6)
            {
                switch (ex_num)                                                        // Блок переключения на пункты меню
                {
                    case 1:
                        FindMinSum();
                        break;
                    case 2:
                        SortedArray();
                        break;
                    case 3:
                        MultMatrix();
                        break;
                    case 4:
                        SpiralMatrix();
                        break;
                    case 5:
                        Array3D();
                        break;
                }

                void FindMinSum()
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Нахождение строки с наименьшим элементом.");
                    Console.ForegroundColor = ConsoleColor.White;
                    int rows = UserInput("\nВведите количество строк:\t");
                    int columns = UserInput("Введите количество столбцов:\t");
                    int[,] array = new int[rows, columns];

                    CreateArray(array);
                    WriteArray(array);

                    int minRow = 0;
                    int minSum = 0;
                    int rowSum;

                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        rowSum = 0;
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            rowSum += array[i, j];
                        }

                        if (minSum > rowSum)
                        {
                            minSum = rowSum;
                            minRow = i + 1;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"\n  Наименьшая сумма элементов ({minSum}) найдена в {minRow}-ой строке");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                void SortedArray()
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Сортировка элементов массива в строках по убыванию.");
                    Console.ForegroundColor = ConsoleColor.White;
                    int rows = UserInput("\nВведите количество строк:\t");
                    int columns = UserInput("Введите количество столбцов:\t");
                    int[,] array = new int[rows, columns];

                    CreateArray(array);
                    WriteArray(array);

                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            for (int k = 0; k < array.GetLength(1) - 1; k++)
                            {
                                if (array[i, k] < array[i, k + 1])
                                {
                                    (array[i, k + 1], array[i, k]) = (array[i, k], array[i, k + 1]);
                                }
                            }
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n Сортированный массив:\n");
                    WriteArray(array);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                void MultMatrix()
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Умножение матриц (по умолчанию - совместимых):\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    int m1_rows = UserInput("Введите число строк 1-й матрицы: ");
                    int m1m2_rc = UserInput("Введите число столбцов 1-й матрицы и строк 2-й: ");
                    int m2_columns = UserInput("Введите число столбцов 2-й матрицы: ");

                    int[,] matrix1 = new int[m1_rows, m1m2_rc];
                    CreateArray(matrix1);
                    Console.WriteLine("  Первая матрица:\n");
                    WriteArray(matrix1);

                    int[,] matrix2 = new int[m1m2_rc, m2_columns];
                    CreateArray(matrix2);
                    Console.WriteLine("  Вторая матрица:\n");
                    WriteArray(matrix2);

                    int[,] resultMatrix = new int[m1_rows, m2_columns];

                    for (int i = 0; i < resultMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < resultMatrix.GetLength(1); j++)
                        {
                            int sum = 0;
                            for (int k = 0; k < matrix1.GetLength(1); k++)
                            {
                                sum += matrix1[i, k] * matrix2[k, j];
                            }
                            resultMatrix[i, j] = sum;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n  Произведение:\n");
                    WriteArray(resultMatrix);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                void SpiralMatrix()
                {
                    Console.Clear();
                    int matrixSize = UserInput("\nВведите размерность матрицы: ");
                    int[,] spiralMatrix = new int[matrixSize, matrixSize];

                    int start = 1;
                    int i = 0;
                    int j = 0;
                    while (start <= spiralMatrix.GetLength(0) * spiralMatrix.GetLength(1))
                    {
                        spiralMatrix[i, j] = start;
                        start++;
                        if (i <= j + 1 && i + j < spiralMatrix.GetLength(1) - 1) { j++; }
                        else if (i < j && i + j >= spiralMatrix.GetLength(0) - 1) { i++; }
                        else if (i >= j && i + j > spiralMatrix.GetLength(1) - 1) { j--; }
                        else { i--; }
                    }
                    Console.WriteLine();
                    WriteSpiralArray(spiralMatrix);
                }

                void WriteSpiralArray(int[,] array)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            Console.Write("{0, 5}", array[i, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }

                void Array3D()
                {
                    Console.Clear();

                    int x = InputNumbers("Введите размерность X: ");
                    int y = InputNumbers("Введите размерность Y: ");
                    int z = InputNumbers("Введите размерность Z: ");

                    int[,,] array3D = new int[x, y, z];
                    Create3DArray(array3D, x, y, z);
                    WriteArray(array3D);

                    int InputNumbers(string input)
                    {
                        Console.Write(input);
                        int output = Convert.ToInt32(Console.ReadLine());
                        return output;
                    }
                    Console.WriteLine();

                    void WriteArray(int[,,] array3D)
                    {
                        for (int i = 0; i < array3D.GetLength(0); i++)
                        {
                            for (int j = 0; j < array3D.GetLength(1); j++)
                            {
                                Console.Write("Координаты [x;y]:");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"[{i};{j}] ");
                                Console.ForegroundColor = ConsoleColor.White;
                                for (int k = 0; k < array3D.GetLength(2); k++)
                                {
                                    Console.Write("\tZ:");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("[{0}]=", k);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\t{0}", array3D[i, j, k]);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                    }

                    void Create3DArray(int[,,] arr, int l, int m, int n)
                    {
                        Random rnd = new();
                        for (l = 0; l < x; l++)
                        {
                            for (m = 0; m < y; m++)
                            {
                                for (n = 0; n < z; n++)
                                {
                                    arr[l, m, n] = rnd.Next(arrayRangeMin, arrayRangeMax);
                                }
                            }
                        }
                    }
                }

                ///////////////////////////////////////// Общие методы /////////////////////////////////////////

                int UserInput(string input)
                {
                    Console.Write(input);
                    int output = int.Parse(Console.ReadLine());
                    return output;
                }

                void CreateArray(int[,] array)
                {
                    Console.WriteLine("\n Массив чисел: \n\t");
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            array[i, j] = new Random().Next(arrayRangeMin, arrayRangeMax);
                        }
                    }
                }

                void WriteArray(int[,] array)
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            Console.Write("{0, 5}", array[i, j]);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}