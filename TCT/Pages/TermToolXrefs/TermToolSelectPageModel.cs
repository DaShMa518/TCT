using TCT.Data;
using TCT.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TCT.Pages.TermToolXrefs
{
    public class TermToolSelectPageModel : PageModel
    {
        public SelectList TerminalSelectionSL { get; set; }

        public void PopulateTerminalsDropDownList(TCTContext _context,
            object selectedTerminal = null)
        {
            var terminalsQuery = from t in _context.Terminals
                                 orderby t.PartNo // Sort by PartNo
                                 select t;

            TerminalSelectionSL = new SelectList(terminalsQuery.AsNoTracking(),
                    nameof(Terminal.Id),
                    nameof(Terminal.PartNo),
                    selectedTerminal);
        }

        public SelectList ToolSelectionSL { get; set; }

        public void PopulateToolsDropDownList(TCTContext _context,
            object selectedTool = null)
        {
            var toolsQuery = from t in _context.Tools
                             orderby t.InternalId // Sort by InternalId
                             select t;

            ToolSelectionSL = new SelectList(toolsQuery.AsNoTracking(),
                    nameof(Tool.Id),
                    nameof(Tool.InternalId),
                    selectedTool);
        }
    }
}