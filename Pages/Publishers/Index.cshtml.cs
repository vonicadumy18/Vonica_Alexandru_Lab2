using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vonica_Alexandru_Lab2.Models;

namespace Vonica_Alexandru_Lab2.Pages_Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Vonica_Alexandru_Lab2Context _context;

        public IndexModel(Vonica_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
