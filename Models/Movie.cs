using System.ComponentModel.DataAnnotations;

namespace Mission06.Models;

/// <summary>
/// A movie in Joel Hilton's film collection.
/// </summary>
public class Movie
{
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(200)]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Director is required.")]
    [MaxLength(200)]
    public required string Director { get; set; }

    [Required(ErrorMessage = "Rating is required.")]
    [MaxLength(5)]
    public required string Rating { get; set; }

    /// <summary>
    /// Whether the version in the collection is edited (e.g., for content).
    /// </summary>
    public bool Edited { get; set; }

    [MaxLength(100)]
    public string? LentTo { get; set; }

    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}
