using CarCatalog.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Pages.Brands;

public class IndexModel(AppDbContext db) : PageModel
{
    public List<Brand> Items { get; set; } = new();
    public async Task OnGetAsync() =>
        Items = await db.Brands.Include(b => b.CarTypes).OrderBy(b => b.Name).ToListAsync();
}
