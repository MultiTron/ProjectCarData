using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCD.Data.Entities;

public abstract class BaseEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Column("created_at")]
    required public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
