namespace PCD.Data.Entities;

public class Trip : BaseEntity
{
    required public TimeOnly Duration { get; set; }
    required public double Distance { get; set; }
    required public double FuelConsumption { get; set; }


}
