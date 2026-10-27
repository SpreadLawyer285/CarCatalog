using CarCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Pages.Brands;

public class EditModel(AppDbContext db) : PageModel
{
    [BindProperty] public Brand Item { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var b = await db.Brands.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (b == null) return NotFound();
        Item = b;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        var b = await db.Brands.FindAsync(Item.Id);
        if (b == null) return NotFound();
        b.Name = Item.Name;
        b.Country = Item.Country;
        await db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
