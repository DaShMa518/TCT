using TCT.Data;
using TCT.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TCT.Pages.Terminals
{
    public class TermOptionsSelectPageModel : PageModel
    {
        public SelectList ManufacturerSelectionSL { get; set; }

        public void PopulateManufacturerDropDownList(TCTContext _context,
            object selectedManufacturer = null)
        {
            var manufacturersQuery = from m in _context.Manufacturers
                                   orderby m.Name // Sort by name.
                                   select m;

            ManufacturerSelectionSL = new SelectList(manufacturersQuery.AsNoTracking(),
                nameof(Manufacturer.Id),
                nameof(Manufacturer.Name),
                selectedManufacturer);
        }

        public SelectList TermClassSelectionSL { get; set; }

        public void PopulateTermClassDropDownList(TCTContext _context,
            object selectedTermClass = null)
        {
            var termClassesQuery = from m in _context.TermClasses
                                     orderby m.Name // Sort by name.
                                     select m;

            TermClassSelectionSL = new SelectList(termClassesQuery.AsNoTracking(),
                nameof(TermClass.Id),
                nameof(TermClass.Name),
                selectedTermClass);
        }
    }
}
