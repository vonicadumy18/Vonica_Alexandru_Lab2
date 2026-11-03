using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vonica_Alexandru_Lab2.Models;
using Vonica_Alexandru_Lab2.Data;

namespace Vonica_Alexandru_Lab2.Pages.MemberPages;

public class IndexModel : PageModel
{
    private readonly Vonica_Alexandru_Lab2Context _context;

    public IndexModel(Vonica_Alexandru_Lab2Context context)
    {
        _context = context;
    }

    public IList<Member> Member { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Member = await _context.Member.ToListAsync();
    }
}
