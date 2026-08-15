using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Booking.Core.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Booking.Core.Entities;

[Table("Events")]
public class Event : BaseModel
{ 
    [Required] public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime EventDate { get; set; }
    
    [Required] public List<Seat> TotalSeats { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
}