Console.WriteLine("Введите число : ");
int num;

while (!int.TryParse(Console.ReadLine(), out num))
{
    Console.WriteLine("Неправильный ввод, попробуйте еще раз");
}

if (num > 99)
{
    Console.WriteLine("Третья цифра в числе " + num.ToString()[2]);
}
else if (num < 100)
{
    Console.WriteLine("В числе меньше трех разрядов!");
}
