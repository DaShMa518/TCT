using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Terminals
{
    public class DetailsModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DetailsModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

      public Terminal Terminal { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Terminals == null)
            {
                return NotFound();
            }

            //var terminal = await _context.Terminals.FirstOrDefaultAsync(m => m.Id == id);
            Terminal = await _context.Terminals
                .Include(s => s.TermToolXrefs)
                .ThenInclude(e => e.Tool)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Terminal == null)
            {
                return NotFound();
            }
            //else 
            //{
            //    Terminal = terminal;
            //}
            return Page();
        }
    }
}
