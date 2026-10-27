using CarCatalog.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Pages.CarTypes;

public class IndexModel(AppDbContext db) : PageModel
{
    public List<CarType> Items { get; set; } = new();
    public async Task OnGetAsync() =>
        Items = await db.CarTypes.Include(t => t.Brand).OrderBy(t => t.Brand!.Name).ThenBy(t => t.Name).ToListAsync();
}
