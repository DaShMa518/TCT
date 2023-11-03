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
    public class IndexModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public IndexModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public string PartNoSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Terminal> Terminals { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            PartNoSort = String.IsNullOrEmpty(sortOrder) ? "partNo_desc" : "";
            CurrentFilter = searchString;

            IQueryable<Terminal> terminalsIQ = from s in _context.Terminals
                                               .Include(c => c.Manufacturer)
                                                   .Include(c => c.TermClass)
                                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                terminalsIQ = terminalsIQ.Where(s => s.PartNo.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "partNo_desc":
                    terminalsIQ = terminalsIQ.OrderByDescending(s => s.PartNo);
                    break;
                default:
                    terminalsIQ = terminalsIQ.OrderBy(s => s.PartNo);
                    break;
            }

            Terminals = await terminalsIQ.AsNoTracking().ToListAsync();
        }
    }
}
