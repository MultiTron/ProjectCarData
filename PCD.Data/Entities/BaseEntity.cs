using System.ComponentModel.DataAnnotations;

namespace PCD.Data.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    required public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
