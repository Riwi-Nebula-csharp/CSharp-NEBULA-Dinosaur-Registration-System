using System.ComponentModel.DataAnnotations;

namespace Dinosaur_Registration_System.Models;

public class Dinosaur
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int? Age { get; set; }

    public DinosaurType? Type { get; set; }

    public DinosaurZone? Zone { get; set; }

    public DinosaurSector? Sector { get; set; }

    [MaxLength(200)]
    public string? Address { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}