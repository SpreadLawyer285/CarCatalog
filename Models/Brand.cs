using System.ComponentModel.DataAnnotations;

namespace CarCatalog.Models;

public class Brand
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A név megadása kötelező"), StringLength(100)]
    [Display(Name = "Márka")]
    public string Name { get; set; } = "";

    [StringLength(100)]
    [Display(Name = "Származási ország")]
    public string? Country { get; set; }

    public List<CarType> CarTypes { get; set; } = new();
}
