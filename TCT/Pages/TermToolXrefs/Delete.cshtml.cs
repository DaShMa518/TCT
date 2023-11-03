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
    public class DeleteModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DeleteModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TermToolXref TermToolXref { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TermToolXrefs == null)
            {
                return NotFound();
            }

            var termToolXref = await _context.TermToolXrefs.FirstOrDefaultAsync(m => m.Id == id);

            if (termToolXref == null)
            {
                return NotFound();
            }
            else 
            {
                TermToolXref = termToolXref;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TermToolXrefs == null)
            {
                return NotFound();
            }
            var termtoolxref = await _context.TermToolXrefs.FindAsync(id);

            if (termtoolxref != null)
            {
                TermToolXref = termtoolxref;
                _context.TermToolXrefs.Remove(TermToolXref);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
