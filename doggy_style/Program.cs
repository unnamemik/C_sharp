internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введите скорость движения первого друга в км/ч: ");
        double v1 = Convert.ToDouble(Console.ReadLine()); // 'Введите скорость движения первого друга в км/ч: '

        Console.Write("\n А теперь скорость движения второго друга: ");
        double v2 = Convert.ToDouble(Console.ReadLine()); // 'А теперь скорость движения второго друга: '

        Console.Write("\n... и скорость бега собаки (по умолчанию она всегда быстрее друзей): ");
        double v_dog = Convert.ToDouble(Console.ReadLine()); //... и скорость бега собаки (по умолчанию она всегда быстрее друзей):'

        Console.Write("\nОни идут навстречу друг другу? (yes/no) ");
        string? dir = (Console.ReadLine()); //Они идут навстречу друг другу? (yes/no)'

        Console.Write("\nКакое между ними расстояние в километрах? ");
        double distance = Convert.ToDouble(Console.ReadLine()); // 'Какое между ними расстояние в километрах?'


        double v_summ = 0;  //# Сумма (или разница) скорости друзей
        double meet_quant = 0; //  # Количество пробегов собаки
        double s_meet = 0.005; //  # расстояние встречи
        double meet_flag = 0; //  # Момент встречи собаки с одним из друзей
        double t1 = 0;
        double t2 = 0; //  # Время пробега собаки

        if (dir == ("yes") || dir == ("y"))
        { //  # Выясняем направление движения
            v_summ = (v1 + v2);
        }

        else if (dir == ("no") || dir == ("n"))
        {
            if (v1 > v2) { v_summ = v1 - v2; }
            else { v_summ = (v2 - v1); }
        }

        while (distance > s_meet)
        {
            if (meet_flag == 0)
            {
                t1 = distance / (v1 + v_dog);
                distance = distance - v_summ * t1;
                meet_flag = 1;
                meet_quant += 1;
            }
            if (meet_flag == 1)
            {
                t2 = distance / (v2 + v_dog);
                distance = distance - v_summ * t2;
                meet_flag = 0;
                meet_quant += 1;
            }

        }
        Console.Write("\nСобака пробежит между друзьями {0} раз, пока между ними не будет полметра. \n\n\n", meet_quant);
    }
}