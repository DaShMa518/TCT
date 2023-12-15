using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.TermClasses
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public IndexModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public IList<TermClass> TermClass { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TermClasses != null)
            {
                TermClass = await _context.TermClasses.ToListAsync();
            }
        }
    }
}
