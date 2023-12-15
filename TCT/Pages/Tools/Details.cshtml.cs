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

namespace TCT.Pages.Tools
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DetailsModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public Tool Tool { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tool = await _context.Tools
                .Include(c => c.Manufacturer)
                .Include(c => c.EquipType)
<<<<<<< HEAD
                .Include(s => s.Crimps)
                    .ThenInclude(e => e.Terminal)
                        .ThenInclude(term => term.TermClass)
                .Include(s => s.Crimps)
                    .ThenInclude(e => e.Terminal)
                        .ThenInclude(term => term.Manufacturer)
=======
                .Include(s => s.TermToolXrefs)
                    .ThenInclude(e => e.Terminal)
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Tool == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
