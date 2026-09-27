using System.Reflection.Metadata.Ecma335;

class TripData
{
    private double distance;
    private string vehicle;
    private string season;
    private double fuelCostLiter;
    private double totalCost;
    private double fuelConsumed;
    private double fuelConsumption;
    private DateTime calculationTime;
    public double Distance
    {
        get { return distance; }
        protected set { distance = value; }
    }
    public string Vehicle
    {
        get { return vehicle; }
        protected set { vehicle = value; }
    }
    public string Season
    {
        get { return season; }
        protected set { season = value; }
    }
    public double FuelCostLiter
    {
            get { return fuelCostLiter; }
        protected set { fuelCostLiter = value; }
    }
    public double TotalCost
    {
        get { return totalCost; }
        protected set { totalCost = value; }
    }
    public double FuelConsumed
    {
        get { return fuelConsumed; }
        protected set { fuelConsumed = value; }
    }
    public double FuelConsumption
    {
        get { return fuelConsumption; }
        protected set { fuelConsumption = value;  }
    }
    public DateTime CalculationTime
    {
        get { return calculationTime; }
        protected set { calculationTime = value;  }
    }
    public TripData(double distance, double fuelConsumption, double fuelCostLiter,string vehicle, string season)
    {
        Distance = distance;
        Vehicle = vehicle;
        FuelConsumption = fuelConsumption;
        FuelCostLiter = fuelCostLiter;
        Season = season;
        CalculateCost();
    } 
    public double CalculateFuelConsumption()
    { 
        return FuelConsumption * (Distance / 100) *  Program.vehicles[Vehicle];
    }
    public double CalculateFuelCost()
    {
        return CalculateFuelConsumption() * FuelCostLiter;
    }
    public double ApplySeasonalCoefficient(double cost)
    {
        return cost * Program.seasons[Season];
    }
    public double CalculateCost()
    {
        TotalCost = ApplySeasonalCoefficient(CalculateFuelCost());
        CalculationTime = DateTime.Now;
        return TotalCost;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Длинна поездки: {Distance:F2}км.");
        Console.WriteLine($"Сезон: {Season}");
        Console.WriteLine($"Транспорт: {Vehicle}");
        Console.WriteLine($"Итоговая стоимость поездки: {TotalCost:F2}");
    }
}