class TripCalcilator
{
    private TripData[] trips = new TripData[10];
    private int tripCount = 0;
    public void AddTrip(TripData trip)
    {
        if(tripCount <= 10 )
        {
            trips[tripCount] = trip; 
            tripCount++;
        }
        else
        {
            for (int i = 0; i < 10 ; i++)
            {
                trips[i] = trips[i + 1];
            }
        }
    }
    public void ShowTripHistory()
    {
        if(tripCount==0 )throw new InvalidOperationException("Ошибка: нет поездок в истории.");
        for (int i = 0; i < trips.Length && i < tripCount; i++)
        {
            Console.Write("========История поездок========");
            Console.WriteLine($"\nПоездка №{i+1}");
            Console.WriteLine($"Дата расчёта: {trips[i].CalculationTime}");
            trips[i].PrintInfo();
        }
    }
    private int GetMaximum()
    {
        int maxIndex=0;
        double max = 0;
        for(int i = 0; i < 10; i++)
        {
            if(trips[i] != null && trips[i].TotalCost  > max) 
            {
                maxIndex = i;
                max = trips[i].TotalCost;
            }
        }
        return maxIndex;
    }
    private int GetMinimum()
    {
        int minIndex = 0;
        double min = trips[0].TotalCost;
        for(int i = 0; i < 10; i++)
        {
            if(trips[i] != null && trips[i].TotalCost  < min) 
            {
                minIndex = i;
                min = trips[i].TotalCost;
            }
        }
        return minIndex;
    }
    private double GetAverageKm()
    {
        double totalCost = 0.0;
        double totalKm = 0.0;
        for(int i = 0; i < 10; i++)
        {
            if(trips[i] != null)
            {
                totalCost += trips[i].TotalCost;
                totalKm += trips[i].Distance;
            }
        }
        return totalCost/totalKm;
    }
    private int[] FindTripsPerVehicles(string vehicle)
    {
        int[] arr = new int[10];
        Array.Fill(arr, 0);
        for(int i = 0; i < 10; i++) 
        {
            if (trips[i] != null && trips[i].Vehicle == vehicle) arr[i] = 1;
        }
        return arr;
    }
    private int GetMaxEfficiencyTrip()
    {
        double max=trips[0].TotalCost/trips[0].Distance;
        int maxIndex = 0;
        for(int i = 0; i < 10; i++)
        {
            if(trips[i] != null && trips[i].TotalCost/trips[i].Distance  > max)
            {
                maxIndex = i; 
                max = trips[i].TotalCost/trips[i].Distance;
            } 
        }
        return maxIndex;
    }
    private int GetMinEfficiencyTrip()
    {
        double min=trips[0].TotalCost/trips[0].Distance;
        int minIndex = 0;
        for(int i = 0; i < 10; i++)
        {
            if(trips[i] != null && trips[i].TotalCost/trips[i].Distance  < min) 
            {
                minIndex = i;
                min = trips[i].TotalCost/trips[i].Distance;
            }
        }
        return minIndex;
    }
    private double GetVehicleEfficiency(string vehicle)
    {
        int[] index = FindTripsPerVehicles(vehicle);
        double totalCost = 0.0;
        double totalDistance = 0.0;
        for(int i = 0; i < 10; i++)
        {
            if(index[i]==1)
            {
                totalCost+=trips[i].TotalCost;
                totalDistance+=trips[i].Distance;
            }
        }
        return totalCost/totalDistance;
    }
    public void AnalyzeTrips()
    {
        string[] avaibleVehicles = Program.vehicles.Keys.ToArray();
        if(tripCount==0 )throw new InvalidOperationException("Ошибка: нет поездок в истории.");
        switch (Menu.MenuSelection(["Самая дорогая поездка", "Самая дешёвая поездка", "Расчёт стоимости 1 км", "Поиск поездок по типу транспорта", "Сравнение эффективности разных видов транспорта", "самая экономичная поездка", "самая затратная поездка"], "======== Анализ поездок ========"))
        {
            case 0:
                int maxIndex = GetMaximum();
                Console.WriteLine("Самая дорогая поездка:");
                trips[GetMaximum()].PrintInfo();
                break;
            case 1:
                Console.WriteLine("Самая дешёвая поездка:");
                int minIndex = GetMinimum();
                trips[minIndex].PrintInfo();
                break;
            case 2:
                double averageKmCost = GetAverageKm();
                Console.WriteLine($"Средняя стоимость 1 км: {averageKmCost:F2}");
                break;
            case 3:
                string vehicle = avaibleVehicles[Menu.MenuSelection(avaibleVehicles, "Выберите транспорт: ")];
                int[] index = FindTripsPerVehicles(vehicle);
                int count = 0;
                Console.Write($"Все поездки на {vehicle}:");
                for (int i = 0; i < index.Length; i++)
                {
                    if (index[i] == 1)
                    {
                        Console.WriteLine($"\nПоездка №{i+1}");
                        trips[i].PrintInfo();
                        count++;
                    }
                }
                if(count==0) Console.WriteLine($"поездки на {vehicle} отсутствуют");
                break;
            case 4:
                Console.WriteLine("=== Сравнение эффективности видов транспорта ===");
                foreach (string v in avaibleVehicles)
                {
                    Console.WriteLine($"{v}: {GetVehicleEfficiency(v):F2} руб/км");
                }
                break;
            case 5:
                Console.WriteLine("Самая эффективная поездка:");
                trips[GetMaxEfficiencyTrip()].PrintInfo();
                break;
            case 6:
                Console.WriteLine("Самая затратная поездка:");
                trips[GetMinEfficiencyTrip()].PrintInfo();
                break;
        }
    }
}