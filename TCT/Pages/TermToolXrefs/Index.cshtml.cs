using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.TermToolXrefs
{
    public class IndexModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public IndexModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public IList<TermToolXref> TermToolXref { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TermToolXrefs != null)
            {
                TermToolXref = await _context.TermToolXrefs
                .Include(t => t.Terminal)
                .Include(t => t.Tool).ToListAsync();
            }
        }
    }
}
