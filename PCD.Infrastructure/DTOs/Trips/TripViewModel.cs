namespace PCD.Infrastructure.DTOs.Trips;
public class TripViewModel : BaseViewModel
{
    required public int Id { get; set; }
    required public TimeOnly Duration { get; set; }
    required public double Distance { get; set; }
    required public double FuelConsumption { get; set; }
    required public int CarId { get; set; }
}
