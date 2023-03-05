using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

class Seminar3
{

    static void Main()
    {
        int ex_num = 5;

        while (ex_num != 0)
        {
            if (ex_num != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;     // Блок меню
                Console.WriteLine("\nВведите номер, чтобы выбрать задачу: \n 1. Палиндром\n 2. Длина отрезка в 3D\n 3. Таблица кубов\n 4. Площадь круга \n Для выхода из программы введите 0\n");
                ex_num = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
            }

            switch (ex_num)                                        // Блок переключения на пункты меню
            {
                case 1:
                    palind();
                    break;
                case 2:
                    coor3d();
                    break;
                case 3:
                    cube();
                    break;
                case 4:
                    circle();
                    break;
            }


            void palind()                                           // Блок поиска палиндрома
            {
                Console.Write("\nВведите число : ");
                string num = (Console.ReadLine());

                char[] arr_num = num.ToCharArray();
                Array.Reverse(arr_num);
                string rev_num = new string(arr_num);

                if (num == rev_num)
                {
                    Console.WriteLine("\nВведенное число - палиндром\n");
                }
                else
                {
                    Console.WriteLine("\nВведенное число - не палиндром\n");
                }
            }

            void coor3d()                                           // Блок вычисления длины отрезка в трехмерном пространстве
            {
                Console.Write("Введите X1: ");
                double X1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите Y1: ");
                double Y1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите Z1: ");
                double Z1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nВведите X2: ");
                double X2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите Y2: ");
                double Y2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите Z1: ");
                double Z2 = Convert.ToDouble(Console.ReadLine());

                double dist = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2) + Math.Pow((Z2 - Z1), 2));

                Console.WriteLine("\nДлина отрезка между точками = {0}", Math.Round(dist, 2));
            }

            void cube()                                                     // Блок таблицы кубов
            {
                Console.Write("\nВведите число: ");
                double digit = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nКубы чисел от 1 до {0}: \n", digit);
                for (int i = 1; i <= digit; i++)
                {
                    Console.WriteLine(Math.Pow(i, 3));
                }
            }

            void circle()                                                     // Блок вычисления площади круга
            {
                Console.Write("\nВведите радиус: ");
                double rad = Convert.ToDouble(Console.ReadLine());
                double circ_sq = Math.Round((Math.PI * Math.Pow(rad, 2)), 0);

                string circ_sq_str = Convert.ToString(circ_sq);
                int circ_sq_max = int.MinValue;
                foreach (int elem in circ_sq_str)
                {
                    
                    if (circ_sq_max < elem)
                    {
                        circ_sq_max = elem;
                    }                    
                }
                Console.WriteLine("\nПлощадь круга равна: {0}, максимальное число = {1} \n", circ_sq_str, Convert.ToChar(circ_sq_max));
            }
        }
    }
}