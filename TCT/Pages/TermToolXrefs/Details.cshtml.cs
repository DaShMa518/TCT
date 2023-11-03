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
    public class DetailsModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DetailsModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

      public TermToolXref TermToolXref { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TermToolXrefs == null)
            {
                return NotFound();
            }

            var termtoolxref = await _context.TermToolXrefs.FirstOrDefaultAsync(m => m.Id == id);
            if (termtoolxref == null)
            {
                return NotFound();
            }
            else 
            {
                TermToolXref = termtoolxref;
            }
            return Page();
        }
    }
}
