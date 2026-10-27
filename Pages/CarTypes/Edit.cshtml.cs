using CarCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Pages.CarTypes;

public class EditModel(AppDbContext db) : PageModel
{
    [BindProperty] public CarType Item { get; set; } = new();
    public SelectList Brands { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var t = await db.CarTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (t == null) return NotFound();
        Item = t;
        await LoadBrands();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) { await LoadBrands(); return Page(); }
        var t = await db.CarTypes.FindAsync(Item.Id);
        if (t == null) return NotFound();
        t.Name = Item.Name;
        t.Year = Item.Year;
        t.BrandId = Item.BrandId;
        await db.SaveChangesAsync();
        return RedirectToPage("Index");
    }

    private async Task LoadBrands() =>
        Brands = new SelectList(await db.Brands.OrderBy(b => b.Name).ToListAsync(), "Id", "Name", Item.BrandId);
}
