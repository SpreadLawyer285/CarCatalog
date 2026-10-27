using CarCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCatalog.Pages.Brands;

public class CreateModel(AppDbContext db) : PageModel
{
    [BindProperty] public Brand Item { get; set; } = new();
    public void OnGet() { }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        db.Brands.Add(Item);
        await db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
