using System.ComponentModel.DataAnnotations;

namespace TheoryProtocol.Models;

public class CreateCanvasModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
}