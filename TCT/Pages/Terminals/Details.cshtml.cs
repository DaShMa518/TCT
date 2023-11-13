using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;
using TCT.Models.TCTViewModels; // Add VM

namespace TCT.Pages.Terminals
{
    public class DetailsModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DetailsModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public Terminal Terminal { get; set; }

        //public TermToolCrimpVM TermToolCrimp { get; set; }
        //public int TerminalID { get; set; }
        //public int ToolID { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Terminal = await _context.Terminals
            //    .Include(c => c.Manufacturer)
            //    .Include(c => c.TermClass)
            //    .Include(c => c.Crimps)
            //        .ThenInclude(e => e.Tool)
            //    //.ThenInclude(x => x.EquipType)
            //    .Distinct()
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(m => m.Id == id);

            Terminal = _context.Terminals
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
