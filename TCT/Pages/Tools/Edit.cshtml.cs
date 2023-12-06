using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Tools
{
    [Authorize]
    public class EditModel : ToolOptionsSelectPageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public EditModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tool Tool { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PopulateManufacturerDropDownList(_context);
            PopulateEquipTypeDropDownList(_context);

            Tool = await _context.Tools
                .Include(c => c.Manufacturer)
                .Include(c => c.EquipType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Tool == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var toolToUpdate = await _context.Tools.FindAsync(id);

            if (toolToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Tool>(
                toolToUpdate,
                "Tool", // Prefix for form value.
                s => s.InternalId,
                s => s.ModelNo,
                s => s.SerialNo,
                s => s.ManufacturerId,
                s => s.EquipTypeId))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select ManufacturerId if TryUpdateModelAsync fails.
            PopulateManufacturerDropDownList(_context, toolToUpdate.ManufacturerId);
            // Select TermClassId if TryUpdateModelAsync fails.
            PopulateEquipTypeDropDownList(_context, toolToUpdate.EquipTypeId);
            return Page();
        }

        private bool ToolExists(int id)
        {
          return _context.Tools.Any(e => e.Id == id);
        }
    }
}
