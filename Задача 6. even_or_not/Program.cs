/*Напишите программу, которая на вход принимает число и выдает, является ли число четным (делится ли оно на два без остатка). */




using System;

Console.WriteLine("Введите число : ");
double num = Convert.ToDouble(Console.ReadLine());

if (num%2 == 0)
{
    Console.WriteLine("Число четное");
}
else { Console.WriteLine("Число нечетное"); }