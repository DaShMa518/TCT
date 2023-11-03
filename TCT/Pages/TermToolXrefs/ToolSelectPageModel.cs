using TCT.Data;
using TCT.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TCT.Pages.TermToolXrefs
{
    public class ToolSelectPageModel : PageModel
    {
        public SelectList ToolNameSL { get; set; }

        public void PopulateToolsDropDownList(TCTContext _context,
            object selectedTool = null)
        {
            var toolsQuery = from t in _context.Tools
                             orderby t.InternalId // Sort by InternalId
                             select t;

            ToolNameSL = new SelectList(toolsQuery.AsNoTracking(),
                    nameof(Tool.Id),
                    nameof(Tool.InternalId),
                    selectedTool);
        }
    }
}