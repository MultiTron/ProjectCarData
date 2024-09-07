using System.ComponentModel.DataAnnotations.Schema;

namespace PCD.Data.Entities;

public class Trip : BaseEntity
{
    required public TimeOnly Duration { get; set; }
    required public double Distance { get; set; }
    required public double FuelConsumption { get; set; }
    [ForeignKey(nameof(Car))]
    required public int CarId { get; set; }
    public virtual Car? Car { get; set; }
}
