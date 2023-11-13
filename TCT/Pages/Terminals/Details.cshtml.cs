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

        public Terminal Terminal { get; set; }

        //public TermToolCrimpVM TermToolCrimp { get; set; }
        //public int TerminalID { get; set; }
        //public int ToolID { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //TermToolCrimp = new TermToolCrimpVM();
            //TermToolCrimp.Terminals = await _context.Terminals
            //    .Include(i => i.Manufacturer)
            //    .Include(i => i.TermClass)
            //    .Include(i => i.TermToolXrefs)
            //        .ThenInclude(j => j.Tool)
            //    .ToListAsync();

            //if(id != null)
            //{
            //    TerminalID = id.Value;
            //    Terminal terminal = TermToolCrimp.Terminals
            //        .Where(i => i.Id == TerminalID).Single();
            //    //TermToolCrimp.Crimps = terminal.Crimps;

            //}




            if (id == null)
            {
                return NotFound();
            }

            Terminal = await _context.Terminals
                .Include(c => c.Manufacturer)
                .Include(c => c.TermClass)
                .Include(c => c.Crimps)
                    .ThenInclude(e => e.Tool)
                //.ThenInclude(x => x.EquipType)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Terminal == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
