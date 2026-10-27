using CarCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Pages.CarTypes;

public class CreateModel(AppDbContext db) : PageModel
{
    [BindProperty] public CarType Item { get; set; } = new();
    public SelectList Brands { get; set; } = default!;

    public async Task OnGetAsync() => await LoadBrands();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) { await LoadBrands(); return Page(); }
        db.CarTypes.Add(Item);
        await db.SaveChangesAsync();
        return RedirectToPage("Index");
    }

    private async Task LoadBrands() =>
        Brands = new SelectList(await db.Brands.OrderBy(b => b.Name).ToListAsync(), "Id", "Name");
}
