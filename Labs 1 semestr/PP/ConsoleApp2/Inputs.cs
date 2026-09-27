/// <summary>
/// статический класс содержащий функции ввода
/// </summary>
static class Inputs
{
    /// <summary>
    /// функция для ввода целого числа
    /// </summary>
    /// <param name="text"> текст выводящийся перед вводом</param>
    /// <returns>введённое число</returns>
    public static int Input(string text)
    {
        int result;
        Console.Write(text);
        while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
        {
            Console.WriteLine("Ошибка ввода, введите целое число больше 0:");
        }
        return result;
    }
    /// <summary>
    /// Функция ввода вещественного числа
    /// </summary>
    /// <param name="text">текст выводящийся перед вводом</param>
    /// <returns>введённое число</returns>
    public static double InputDouble(string text)
    {
        double result;
        Console.Write(text);
        while (!double.TryParse(Console.ReadLine(), out result) || result <= 0)
        {
            Console.Write("Ошибка ввода, введите положительное вещественное число:");
        }
        return result;
    }
}