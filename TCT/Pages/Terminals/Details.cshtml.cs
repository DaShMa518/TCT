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

            Terminal = _context.Terminals
                .Include(t => t.Manufacturer)
                .Include(t => t.TermClass)
                .Include(t => t.Crimps)
                    .ThenInclude(c => c.Tool)
                        .ThenInclude(tool => tool.EquipType)
                .Include(t => t.Crimps)
                    .ThenInclude(c => c.Tool)
                        .ThenInclude(tool => tool.Manufacturer)
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
