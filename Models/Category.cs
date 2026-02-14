using System.ComponentModel.DataAnnotations;

namespace Mission06.Models;

/// <summary>
/// Category for a movie (e.g., Comedy, Drama, Action/Adventure).
/// Normalized to avoid repeating category names.
/// </summary>
public class Category
{
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
