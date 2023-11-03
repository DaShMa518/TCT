using TCT.Data;
using TCT.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TCT.Pages.Terminals
{
    public class TerminalSelectPageModel : PageModel
    {
        public SelectList ManufacturerSelectSL { get; set; }

        public void PopulateManufacturersDropDownList(TCTContext _context,
            object selectedManufacturer = null)
        {
            var manufacturersQuery = from m in _context.Manufacturers
                                    orderby m.Name // Sort by Name
                                    select m;

        ManufacturerSelectSL = new SelectList(manufacturersQuery.AsNoTracking(),
                nameof(Manufacturer.Id),
                nameof(Manufacturer.Name),
                selectedManufacturer);
        }

        public SelectList TermClassSelectSL { get; set; }

        public void PopulateTermClassesDropDownList(TCTContext _context,
            object selectedTermClass = null)
        {
            var termClassesQuery = from t in _context.TermClasses
                                     orderby t.Name // Sort by Name
                                     select t;

            TermClassSelectSL = new SelectList(termClassesQuery.AsNoTracking(),
                    nameof(TermClass.Id),
                    nameof(TermClass.Name),
                    selectedTermClass);
        }
    }
}
