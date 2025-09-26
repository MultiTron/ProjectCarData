using System.ComponentModel.DataAnnotations.Schema;

namespace PCD.Data.Entities;

public class Trip : BaseEntity
{
    [Column("duration")]
    required public TimeOnly Duration { get; set; }
    [Column("distance")]
    required public double Distance { get; set; }
    [Column("fuel_consumption")]
    required public double FuelConsumption { get; set; }
    [Column("car_id")]
    [ForeignKey(nameof(Car))]
    required public Guid CarId { get; set; }
    public virtual Car? Car { get; set; }
}
