using System;
using System.Data.Common;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;                                  // на случай разной кодировки

Console.ForegroundColor = ConsoleColor.Cyan;                             // Ввод данных
Console.Write("\nСоздание нового массива.");
Console.ForegroundColor = ConsoleColor.White;
Console.Write("\n\n  Введите количество строк: ");

int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("\n  Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

double[,] matrix = new double[rows, columns];

/////////////////////////////////////////////////////////////////////      //Блок вызова модулей
createArr();
searchPos(matrix);
Thread.Sleep(2000);
columnAverage(matrix);
Thread.Sleep(2000);
calcCorners();
Thread.Sleep(2000);
binomialFunc();
/////////////////////////////////////////////////////////////////////            

void createArr()                                                            // Создание массива
{
    Console.WriteLine("\n  Массив элементов: \n");
    Random random = new();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = random.Next(-10, 10) + random.NextDouble();
            Console.Write("{0, 8}", Math.Round(matrix[i, j], 2));
        }
        Console.WriteLine();
    }
}

void searchPos(double[,] matrix_pos)                                          // Поиск элемента по индексу
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("\n\nПоиск элемента в заданном массиве:\n");
    Console.ForegroundColor = ConsoleColor.White;
    bool repeat = true;
    while (repeat)
    {
        Console.Write("\n  Введите индекс строки: ");
        int row_index = Convert.ToInt32(Console.ReadLine());

        Console.Write("\n  Введите индекс столбца: ");
        int column_index = Convert.ToInt32(Console.ReadLine());

        try
        {
            Console.Write("\n  Элемент с заданным индексом: {0} \n\n", Math.Round(matrix_pos[row_index, column_index], 2));

            ///////////////////////////////////////////////////////////////////////     Просто для красоты. )
            for (int i = 0; i < rows; i++)
            {
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.ForegroundColor = i == row_index && j == column_index ? ConsoleColor.Red : ConsoleColor.White; ;

                        Console.Write("{0, 8}", Math.Round(matrix_pos[i, j], 2));
                    }
                    Console.WriteLine();
                }

            }
            repeat = false;
            ///////////////////////////////////////////////////////////////////////
        }

        catch (IndexOutOfRangeException)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n  Элемент с таким индексом не существует!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine("\n");
    }
}

void columnAverage(double[,] matrix)                                     // Вычисление среднего арифметического по столбцам
{
    double column_average = 0;
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\nСреднее арифметическое по столбцам:");
    Console.ForegroundColor = ConsoleColor.White;
    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            column_average += matrix[j, i];
        }
        Console.Write("\nСреднее арифметическое {0}-го столбца = {1, 5}", i + 1, Math.Round(column_average / rows, 2));
    }
    Console.WriteLine("\n");
}

void calcCorners()                                                     // Сравнение столбцов с угловыми элементами
{
    double column_sum = 0;
    int corner_flag = 0;
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\nСравнение столбцов с угловыми элементами\n");
    Console.ForegroundColor = ConsoleColor.White;

    double corner_sum = matrix[0, 0] + matrix[0, columns - 1] + matrix[rows - 1, 0] + matrix[rows - 1, columns - 1];

    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            column_sum += matrix[j, i];
            if (corner_sum > column_sum) { corner_flag++; }
        }
    }
    Console.Write(corner_flag != 0 ? "  Сумма угловых элементов превышает сумму элементов одного из столбцов\n\n"
        : "  Сумма угловых элементов не превышает сумму элементов любого столбца\n\n");
}

void binomialFunc()                                                    //Треугольник Паскаля
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("\n\nТреугольник паскаля:\n");
    Console.ForegroundColor = ConsoleColor.White;
    int n = 24;
    while (n > 23)
    {
        Console.Write("\n  Введите показатель степени n: ");            //Ограничение по степени - переполнение double. 
        n = Convert.ToInt32(Console.ReadLine());
    }

    Console.Write("\n\n");

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j <= n - i; j++)
        {
            Console.Write("   ");
        }
        for (int k = 0; k <= i; k++)
        {
            Console.Write("{0,6}", factorial(i) / (factorial(k) * factorial(i - k)));
        }
        Console.WriteLine();
    }
    Console.ReadLine();
}

double factorial(int n)
{
    double i, x = 1;
    for (i = 1; i <= n; i++) { x *= i; }
    return x;
}