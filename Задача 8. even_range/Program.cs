/*Напишите программу, которая на входе принимает число (N), а на выходе показывает все четные числа от 1 до N. */




using System;

Console.WriteLine("Введите число : ");
double num = Convert.ToDouble(Console.ReadLine());

double count = 1;

while (num>1)
{
    if (count % 2 == 0)
    {
      Console.Write(" " + count);        
    }
    num--;
    count++;
}