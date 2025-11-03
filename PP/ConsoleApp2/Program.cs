internal class Program
{
    private static void Main(string[] args)
    {
        int choose;
        bool run = false;
        while (!run)
        {
            Console.Write("=========Меню=========\n1. Рассчитать поездку\n2. Выйти \nВведите ваш выбор(1-2):");
            while (!int.TryParse(Console.ReadLine(), out choose) || choose < 0 || choose > 2)
            {
                Console.Write("Ошибка ввода введите число от 1 до 2: ");
            }
            switch (choose)
            {
                case 1:
                    Trip();
                    break;
                case 2:
                    run = Quit(false);
                    break;
            }
        }
    }
    static void Trip()
    {
        try
        {
            float seasonCoef = 0;
            float typeCoef = 0;
            const float carCoef = 1;
            const float truckCoef = 1.2F;
            const float bikeCoef = 0.85F;
            const float summerCoef = 1;
            const float winterCoef = 1.1F;
            double distance = Program.Input("Введите расстояние(км): ");
            double fuelConsumption = Program.Input("Введите средний расход топлива на 100 км: ");
            double fuelCost = Program.Input("Введите  цену топлива за литр: ");
            int type;
            Console.Write("Выберите транспорт: \n 1.Легковой \n 2.Грузовик \n 3.Мотоцикл \nВыбор: ");
            while (!int.TryParse(Console.ReadLine(), out type) || type < 0 || type > 3)
            {
                Console.Write("Ошибка ввода\nВыберите транспорт(1-3): ");
            }
            switch (type)
            {
                case 1:
                    typeCoef = carCoef;
                    break;
                case 2:
                    typeCoef = truckCoef;
                    break;
                case 3:
                    typeCoef = bikeCoef;
                    break;
            }
            int season;
            Console.Write("Выберите сезон: \n1.Лето \n2.Зима \nВыбор: ");
            while (!int.TryParse(Console.ReadLine(), out season) || season < 0 || season > 2)
            {
                Console.Write("Ошибка ввода\nВыберите сезон(1-2): ");
            }
            switch (season)
            {
                case 1:
                    seasonCoef = summerCoef;
                    break;
                case 2:
                    seasonCoef = winterCoef;
                    break;
            }
            double fuelConsumed = fuelConsumption * (distance / 100) * typeCoef;
            double costNoSeason = (double)(fuelConsumed * fuelCost);
            double totalCost = costNoSeason * (double)seasonCoef;
            float seasonCoefProcent = (seasonCoef - 1) * 100;

            Console.WriteLine("====== Результаты расчета ======");
            Console.WriteLine($"Расход топлива: {fuelConsumed:F1} Л");
            Console.WriteLine($"Стоимость топлива: {costNoSeason:F2} руб");
            Console.WriteLine($"Сезонный коэффициент: {seasonCoefProcent:F0}%");
            Console.WriteLine($"Итоговая стоимость поездки: {totalCost:F2} руб");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("ошибка переполнения:\n" + ex);
        }
        finally
        {
            Console.WriteLine("Расчёт завершён");
            Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
            Console.ReadKey();
            Console.Clear();
        }

    }
    static double Input(string text)
    {
        double result = 0;
        while (result <= 0)
        {
            Console.Write(text);
            while (!Double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.WriteLine("Ошибка ввода, введите число больше нуля: ");
                Console.Write(text);
            }
        }
        return result;
    }
    static bool Quit(bool ex)
    {
        Console.WriteLine("Вы действительно хотите выйти? \nд/н: ");
        string? exit = Console.ReadLine();
        while (exit != "д" && exit != "н")
        {
            Console.Write("Ошибка ввода, введите д/н:");
            exit = Console.ReadLine();
        }
        if (exit == "д")
        {
            ex = true;
        }
        Console.Clear();
        return ex;
    }
}