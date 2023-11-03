using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.TermClasses
{
    public class DeleteModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DeleteModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TermClass TermClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TermClasses == null)
            {
                return NotFound();
            }

            var termclass = await _context.TermClasses.FirstOrDefaultAsync(m => m.Id == id);

            if (termclass == null)
            {
                return NotFound();
            }
            else 
            {
                TermClass = termclass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TermClasses == null)
            {
                return NotFound();
            }
            var termclass = await _context.TermClasses.FindAsync(id);

            if (termclass != null)
            {
                TermClass = termclass;
                _context.TermClasses.Remove(TermClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
