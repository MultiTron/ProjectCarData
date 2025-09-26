namespace PCD.Infrastructure.DTOs.Trips;
public class TripViewModel : BaseViewModel
{
    required public TimeOnly Duration { get; set; }
    required public double Distance { get; set; }
    required public double FuelConsumption { get; set; }
    required public Guid CarId { get; set; }
}
