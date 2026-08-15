using System.ComponentModel.DataAnnotations;

namespace Booking.Core.Models;

public abstract class BaseModel
{
    [Key]
    public int Id { get; set; }
}