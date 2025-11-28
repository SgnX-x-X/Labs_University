using System.Reflection.Metadata;
using Microsoft.Win32.SafeHandles;
class Program
{
    static void Main()
    {
        History history = new History();
        bool isRunning = false;
        while (!isRunning)
        {
            switch (Menu.MenuSelection(["Калькулятор Стоимости поездки", "Вывод истории поездки", "Анализ поездок", "выход"],"========= МЕНЮ ========="))
            {
                case 0:
                    double typeCoef = 0;
                    double seasonCoef = 0;
                    string strType = "";
                    string strSeason = "";
                    double[] coef = new double[5] {1 , 1.2, 0.85, 1, 1.1};
                    double distance = Input("Введите расстояние (в км): ");
                    double fuelConsumption = Input("Введите средний расход топлива на 100 км (в литрах): ");
                    double fuelCostLiter = Input("Введите  цену топлива за литр (в рублях): ");
                    int vehicle = Menu.MenuSelection(["Легковой", "Грузовик", "Мотоцикл"], "Выберите транспорт: ");
                    switch (vehicle)
                    {
                        case 0:
                            typeCoef = coef[0];
                            strType = "Легковой";
                            break;
                        case 1:
                            typeCoef = coef[1];
                            strType = "Грузовик";
                            break;
                        case 2:
                            typeCoef = coef[2];
                            strType = "Мотоцикл";
                            break;
                    }
                    int season = Menu.MenuSelection(["Лето", "Зима"], "Выберите сезон: ");
                    switch (season)
                    {
                        case 0:
                            seasonCoef = coef[3];
                            strSeason = "Лето";
                            break;
                        case 1:
                            seasonCoef = coef[4];
                            strSeason = "Зима";
                            break;
                    }
                    double costNoSeason = CalculateFuelConsumption(distance, fuelConsumption, fuelCostLiter, typeCoef);
                    double totalCost = ApplySeasonalCoefficient(costNoSeason, seasonCoef);
                    history.SaveTripToHistory(distance, strType, strSeason, totalCost);
                    Console.WriteLine("=== Результаты расчета ===");
                    Console.WriteLine($"Стоимость топлива: {costNoSeason:F2}");
                    Console.WriteLine($"Сезонный коэффициент: {(seasonCoef - 1) * 100:F0}%");
                    Console.WriteLine($"Итоговая стоимость поездки: {totalCost:F2}");
                    Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
                    Console.ReadKey();
                    break;
                case 1:
                    history.ShowTripHistory();
                    Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
                    Console.ReadKey();
                    break;
                case 2:
                    history.AnalyzeTrips();
                    Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
                    Console.ReadKey();
                    break;
                case 3:
                    isRunning = Menu.MenuSelection(["да", "нет"], "Выйти?") == 0;
                    break;
                }
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
    static double CalculateFuelConsumption(double distance, double fuelConsumption, double fuelCost, double vehicleType)
        {
            double fuelConsumed = fuelConsumption * (distance / 100) * (1 + vehicleType);
            double cost = fuelConsumed * fuelCost;
            return cost;
        }

    static double ApplySeasonalCoefficient(double cost, double season)
    {
        return cost * (1 + season);
    }
    
}
