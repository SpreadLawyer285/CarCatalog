using System.ComponentModel.DataAnnotations;

namespace CarCatalog.Models;

public class CarType
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A név megadása kötelező"), StringLength(100)]
    [Display(Name = "Típus")]
    public string Name { get; set; } = "";

    [Range(1886, 2100, ErrorMessage = "Érvénytelen évszám")]
    [Display(Name = "Gyártás kezdete")]
    public int Year { get; set; } = DateTime.Now.Year;

    [Display(Name = "Márka")]
    public int BrandId { get; set; }

    public Brand? Brand { get; set; }
}
