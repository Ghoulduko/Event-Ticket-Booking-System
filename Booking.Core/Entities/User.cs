using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Booking.Core.Models;

namespace Booking.Core.Entities;

[Table("Users")]
public class User : BaseModel
{
    [Required] public required string Name { get; set; }
    [Required] public required string LastName { get; set; }
    [Required] public required string Email { get; set; }
    [Required] public required string Password { get; set; }
}