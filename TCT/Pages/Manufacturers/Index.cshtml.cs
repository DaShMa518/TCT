using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public IndexModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public IList<Manufacturer> Manufacturer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Manufacturers != null)
            {
                Manufacturer = await _context.Manufacturers.ToListAsync();
            }
        }
    }
}
