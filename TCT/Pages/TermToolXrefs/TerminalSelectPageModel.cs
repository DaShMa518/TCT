using TCT.Data;
using TCT.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TCT.Pages.TermToolXrefs
{
    public class TerminalSelectPageModel : PageModel
    {
        public SelectList TerminalNameSL { get; set; }

        public void PopulateTerminalsDropDownList(TCTContext _context,
            object selectedTerminal = null)
        {
            var terminalsQuery = from t in _context.Terminals
                             orderby t.PartNo // Sort by PartNo
                             select t;

            TerminalNameSL = new SelectList(terminalsQuery.AsNoTracking(),
                    nameof(Terminal.Id),
                    nameof(Terminal.PartNo),
                    selectedTerminal);
        }
    }
}