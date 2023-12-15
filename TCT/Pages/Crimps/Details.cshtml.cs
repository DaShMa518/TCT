using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
=======
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Crimps
{
<<<<<<< HEAD
    [Authorize]
=======
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
    public class DetailsModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DetailsModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

      public Crimp Crimp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Crimp = await _context.Crimps
            .Include(c => c.Terminal)
            .Include(c => c.Tool)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (Crimp == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
