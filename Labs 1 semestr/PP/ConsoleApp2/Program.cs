using System.Reflection.Metadata;
using Microsoft.Win32.SafeHandles;
class Program
{
    public static readonly Dictionary<string,double> vehicles = new Dictionary<string, double> { { "Машина", 1.0 }, { "Грузовик", 1.2 }, {"Мотоцикл", 0.85} };
    public static readonly Dictionary<string,double> seasons = new Dictionary<string, double>{ { "Лето", 1 }, { "Зима", 1.2 } };
    static void Main()
    {
        TripCalcilator histori = new TripCalcilator();
        bool isRunning = false;
        while (!isRunning)
        {
            try
            {
                switch (Menu.MenuSelection(["Калькулятор Стоимости поездки", "Вывод истории поездки", "Анализ поездок", "выход"],"============== МЕНЮ =============="))
                    {
                    case 0:
                        string strType = "";
                        string strSeason = "";
                        double distance = Inputs.InputDouble("Введите расстояние (в км): ");
                        double fuelConsumption = Inputs.InputDouble("Введите средний расход топлива на 100 км (в литрах): ");
                        double fuelCostLiter = Inputs.InputDouble("Введите  цену топлива за литр (в рублях): ");
                        switch (Menu.MenuSelection(["Машина", "Грузовик", "Мотоцикл"], "Выберите транспорт: "))
                        {
                            case 0:
                                strType = "Машина";
                                break;
                            case 1:
                                strType = "Грузовик";
                                    break;
                            case 2:
                                strType = "Мотоцикл";
                                break;
                        }
                        switch (Menu.MenuSelection(["Лето", "Зима"], "Выберите сезон: "))
                        {
                            case 0:
                                strSeason = "Лето";
                                break;
                            case 1:
                                strSeason = "Зима";
                                break;
                        }
                        TripData trip = new TripData(distance, fuelConsumption, fuelCostLiter, strType, strSeason);
                        trip.PrintInfo();
                        histori.AddTrip(trip);
                        break;
                    case 1:
                        histori.ShowTripHistory();
                        break;
                    case 2:
                        histori.AnalyzeTrips();
                        break;
                    case 3:
                        isRunning = Menu.MenuSelection(["да", "нет"], "Выйти?") == 0;
                        break;
                    }
            }
            catch(InvalidOperationException ex)
            {
               Console.WriteLine(ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Вызвано исключение" + ex);
            }
            
            finally
            {
                if(!isRunning)
                {
                    Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
                    Console.ReadKey();
                }
            }
        }
        Console.WriteLine("Хорошего дня");
    }
}
