using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Evaluation;
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Crimps
{
<<<<<<< HEAD
    [Authorize]
=======
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
    public class IndexModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public IndexModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        public string TerminalSort { get; set; }
        public string ToolSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Crimp> Crimps { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            TerminalSort = String.IsNullOrEmpty(sortOrder) ? "terminal.partno_desc" : "";
            ToolSort = sortOrder == "tool.internalid" ? "tool.internalid_desc" : "tool.internalid";

            CurrentFilter = searchString;

            IQueryable<Crimp> crimpsIQ = from s in _context.Crimps
                                           .Include(c => c.Terminal)
                                           .Include(c => c.Tool)
                                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                crimpsIQ = crimpsIQ.Where(s => s.Terminal.PartNo.Contains(searchString)
                                        || s.Tool.InternalId.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "terminal.partno_desc":
                    crimpsIQ = crimpsIQ.OrderByDescending(s => s.Terminal.PartNo);
                    break;
                case "tool.internalid":
                    crimpsIQ = crimpsIQ.OrderBy(s => s.Tool.InternalId);
                    break;
                case "tool.internalid_desc":
                    crimpsIQ = crimpsIQ.OrderByDescending(s => s.Tool.InternalId);
                    break;
                default:
                    crimpsIQ = crimpsIQ.OrderBy(s => s.Terminal.PartNo);
                    break;
            }

            Crimps = await crimpsIQ
            .AsNoTracking()
            .ToListAsync();
=======
        public IList<Crimp> Crimp { get;set; }

        public async Task OnGetAsync()
        {
            Crimp = await _context.Crimps
            .Include(c => c.Terminal)
            .Include(c => c.Tool).ToListAsync();
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
        }
    }
}
