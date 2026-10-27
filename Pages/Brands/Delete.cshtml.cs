using CarCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Pages.Brands;

public class DeleteModel(AppDbContext db) : PageModel
{
    public Brand Item { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var b = await db.Brands.Include(x => x.CarTypes).FirstOrDefaultAsync(x => x.Id == id);
        if (b == null) return NotFound();
        Item = b;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var b = await db.Brands.FindAsync(id);
        if (b != null) { db.Brands.Remove(b); await db.SaveChangesAsync(); }
        return RedirectToPage("Index");
    }
}
