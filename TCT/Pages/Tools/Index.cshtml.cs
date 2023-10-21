using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Tools
{
    public class IndexModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public IndexModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public string InternalIdSort { get; set; }
        public string ModelNoSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Tool> Tools { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            InternalIdSort = String.IsNullOrEmpty(sortOrder) ? "internalId_desc" : "";
            ModelNoSort = sortOrder == "modelNo" ? "modelNo_desc" : "modelNo";

            CurrentFilter = searchString;

            IQueryable<Tool> toolsIQ = from s in _context.Tools
                                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                toolsIQ = toolsIQ.Where(s => s.InternalId.Contains(searchString)
                                        || s.ModelNo.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "internalId_desc":
                    toolsIQ = toolsIQ.OrderByDescending(s => s.InternalId);
                    break;
                case "modelNo":
                    toolsIQ = toolsIQ.OrderBy(s => s.ModelNo);
                    break;
                case "modelNo_desc":
                    toolsIQ = toolsIQ.OrderByDescending(s => s.ModelNo);
                    break;
                default:
                    toolsIQ = toolsIQ.OrderBy(s => s.InternalId);
                    break;
            }

            Tools = await toolsIQ.AsNoTracking().ToListAsync();
        }
    }
}
