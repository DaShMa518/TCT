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
    public class DetailsModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DetailsModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

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
    }
}
