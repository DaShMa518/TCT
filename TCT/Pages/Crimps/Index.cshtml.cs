using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Crimps
{
    public class IndexModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public IndexModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public IList<Crimp> Crimp { get;set; }

        public async Task OnGetAsync()
        {
            Crimp = await _context.Crimps
            .Include(c => c.Terminal)
            .Include(c => c.Tool).ToListAsync();
        }
    }
}
