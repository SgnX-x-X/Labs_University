/// <summary>
/// Статический класс содержащий математическую игру
/// </summary>
static class MathGame
{
    /// <summary>
    /// запускает игру по отгадыванию ответа
    /// </summary>
    static public void Game()
    {
        int a = Inputs.Input("Введите число А: ");
        int b = Inputs.Input("Введите число Б: ");
        Console.Clear();
        Console.WriteLine("Попробуйте угадать результат, с точнойстью до 2 знаков поселе запятой за 3 попытки");
        double result = Formula(a, b);
        Guess(result);
        Console.Write("Чтобы вернуться в главное меню нажмите на любую кнопку");
        Console.ReadKey();
        Console.Clear();
    }
    static void Guess(double result)
    {
        for (int i = 3; i > 0; i--)
        {
            double att = Inputs.InputDouble("Введите число");
            if (result == att)
            {
                Console.WriteLine("Поздравляю вы угадали");
                i = 0;
            }
            else if (i != 1)
            {
                Console.Clear();
                Console.Write("Вы не угадали попробуйте снова \nКоличество оставшихся попыток: {0} \nВведите число:", i - 1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неповезло, вы проиграли");
            }
        }
    }
    static double Formula(int a, int b)
    {
        double numerator = Math.Log(Math.Pow(b, 5));
        double denominator = Math.Sin(a) + 1;
        double result = Math.PI * (numerator / denominator);
        result = Math.Round(result, 2);
        return result;
    }
}