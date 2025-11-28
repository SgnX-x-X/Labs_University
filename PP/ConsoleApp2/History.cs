 class History
    {
        private (double distance, string vehicle, string season, double cost)[] trips =
            new (double, string, string, double)[10];

        int tripCount = 0;

        public void SaveTripToHistory(double distance, string vehicle, string season, double totalCost)
        {
            int index = tripCount % 10;

            trips[index] = (distance, vehicle, season, totalCost);

            tripCount++;
        }

        private int GetRealIndex(int historyIndex)
        {
            return (tripCount - historyIndex - 1) % 10;
        }

        void ShowTrip(int arrayIndex, string text = "")
        {
            var trip = trips[arrayIndex];

            Console.WriteLine($"{text} {trip.distance:F2} км. {trip.season} {trip.vehicle} итоговая стоимость: {trip.cost:F2}");
        }

        public void ShowTripHistory()
        {
            for (int i = 0; i < 10 && i < tripCount; i++)
            {
                ShowTrip(GetRealIndex(i), $"{i+1}:");
            }
        }

        private int GetMaximumIndex()
        {
            int limit = Math.Min(10, tripCount);
            if (limit == 0) return 0;

            return Enumerable.Range(0, limit)
                .Aggregate((maxIndex, nextIndex) => trips[nextIndex].cost > trips[maxIndex].cost ? nextIndex : maxIndex);
        }

        private int GetMinimumIndex()
        {
            int limit = Math.Min(10, tripCount);
            if (limit == 0) return 0;

            return Enumerable.Range(0, limit)
                .Aggregate((minIndex, nextIndex) => trips[nextIndex].cost < trips[minIndex].cost ? nextIndex : minIndex);
        }

        public void AnalyzeTrips()
        {
            switch (Menu.MenuSelection(["Самая дорогая поездка", "Самая дешёвая поездка", "Расчёт стоимости 1 км", "Поиск поездок по типу транспорта"], "=== Анализ поездок ==="))
            {
                case 0:
                    ShowTrip(GetMaximumIndex(), "Самая дорогая поездка:");
                    break;
                case 1:
                    ShowTrip(GetMinimumIndex(), "Самая дешёвая поездка:");
                    break;
                case 2:
                    Console.WriteLine($"Средняя стоимость 1 км: {GetAverageKmCost():F2}");
                    break;
                case 3:
                    string strType="";
                    int vehicle = Menu.MenuSelection(["Легковой", "Грузовик", "Мотоцикл"], "Выберите транспорт: ");
                    switch (vehicle)
                    {
                        case 0:
                            strType = "Легковой";
                            break;
                        case 1:
                            strType = "Грузовик";
                            break;
                        case 2:
                            strType = "Мотоцикл";
                            break;
                    }
                    int[] indices = FindTripsPerVehicles(strType);
                    if (indices.Length > 0)
                    {
                        Console.WriteLine($"Все поездки на {strType}");
                        for (int i = 0; i < indices.Length; i++)
                        {
                            ShowTrip(indices[i], $"{i + 1}:");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"поездки на {vehicle} отсутствуют");
                    }

                    break;

            }
        }

        private double GetAverageKmCost()
        {
            double totalCost = trips.Take(10).Sum(t => t.cost);
            double totalDistance = trips.Take(10).Sum(t => t.distance);

            if (totalDistance == 0)
            {
                return -1;
            }

            return totalCost / totalDistance;
        }

        private int[] FindTripsPerVehicles(string vehicle)
        {
            int limit = Math.Min(10, tripCount);

            return Enumerable.Range(0, limit)
                .Where(i => trips[i].vehicle == vehicle)
                .ToArray();
        }
    }