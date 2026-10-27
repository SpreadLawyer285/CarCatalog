using CarCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Pages.CarTypes;

public class DeleteModel(AppDbContext db) : PageModel
{
    public CarType Item { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var t = await db.CarTypes.Include(x => x.Brand).FirstOrDefaultAsync(x => x.Id == id);
        if (t == null) return NotFound();
        Item = t;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var t = await db.CarTypes.FindAsync(id);
        if (t != null) { db.CarTypes.Remove(t); await db.SaveChangesAsync(); }
        return RedirectToPage("Index");
    }
}
