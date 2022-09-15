/* Напишите программу, которая на вход принимает два числа и выдает, какое число большее, а какое меньшее.*/


using System;

Console.WriteLine("Введите первое число: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите второе число: ");
double num2 = Convert.ToDouble(Console.ReadLine());

if (num1 > num2)
{
    Console.WriteLine("Большее число: " + num1);
    // Console.WriteLine("Меньшее число: " + num2);
}
else { 
    Console.WriteLine("Большее число: " + num2); 
    // Console.WriteLine("Меньшее число: " + num1);
}
     