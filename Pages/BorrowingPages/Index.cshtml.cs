using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vonica_Alexandru_Lab2.Models;
using Vonica_Alexandru_Lab2.Data;

namespace Vonica_Alexandru_Lab2.Pages.BorrowingPages;

public class IndexModel : PageModel
{
    private readonly Vonica_Alexandru_Lab2Context _context;

    public IndexModel(Vonica_Alexandru_Lab2Context context)
    {
        _context = context;
    }

    public IList<Borrowing> Borrowing { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Borrowing = await _context.Borrowing
            .Include(b => b.Book)
                .ThenInclude(b => b.Author)
            .Include(b => b.Member)
            .ToListAsync();
    }
}