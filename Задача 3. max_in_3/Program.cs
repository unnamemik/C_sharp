/*Напишите программу, которая принимает на вход три числа и выдает максимальное из этих чисел */


using System;

Console.WriteLine("Введите первое число: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите второе число: ");
double num2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите третье число: ");
double num3 = Convert.ToDouble(Console.ReadLine());

double max_median = (num1 > num2) ? num1 : num2;
   
if (max_median > num3)
{
    Console.WriteLine("Наибольшее число: " + max_median);
}
else { Console.WriteLine("Наибольшее число: " + num3); }