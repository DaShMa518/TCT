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

namespace TCT.Pages.Terminals
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DetailsModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public Terminal Terminal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            Terminal = _context.Terminals
                .Include(t => t.Manufacturer)
                .Include(t => t.TermClass)
                .Include(t => t.Crimps)
                    .ThenInclude(c => c.Tool)
                        .ThenInclude(tool => tool.EquipType)
                .Include(t => t.Crimps)
                    .ThenInclude(c => c.Tool)
                        .ThenInclude(tool => tool.Manufacturer)
=======
            Terminal = await _context.Terminals
                .Include(c => c.Manufacturer)
                .Include(c => c.TermClass)
                .Include(s => s.TermToolXrefs)
                    .ThenInclude(e => e.Tool)
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);

            if (Terminal == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
