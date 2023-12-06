using TCT.Data;
using TCT.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace TCT.Pages.Tools
{
    [Authorize]
    public class ToolOptionsSelectPageModel : PageModel
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

        public SelectList EquipTypeSelectionSL { get; set; }

        public void PopulateEquipTypeDropDownList(TCTContext _context,
            object selectedEquipType = null)
        {
            var equipTypesQuery = from e in _context.EquipTypes
                                  orderby e.Name // Sort by name.
                                  select e;

            EquipTypeSelectionSL = new SelectList(equipTypesQuery.AsNoTracking(),
                nameof(EquipType.Id),
                nameof(EquipType.Name),
                selectedEquipType);
        }
    }
}
