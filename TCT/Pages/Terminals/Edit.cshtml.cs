using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Terminals
{
    public class EditModel : TermOptionsSelectPageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public EditModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Terminal Terminal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PopulateManufacturerDropDownList(_context);
            PopulateTermClassDropDownList(_context);

            Terminal =  await _context.Terminals
                .Include(c => c.Manufacturer)
                .Include(c => c.TermClass)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Terminal == null)
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

            var terminalToUpdate = await _context.Terminals.FindAsync(id);

            if (terminalToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Terminal>(
                terminalToUpdate,
                "Terminal", // Prefix for form value.
                s => s.PartNo,
                s => s.ManufacturerId,
                s => s.TermClassId,
                s => s.MinWireAWG,
                s => s.MaxWireAWG,
                s => s.MinInsulDiam,
                s => s.MaxInsulDiam,
                s => s.StripLength,
                s => s.DimFront,
                s => s.DimRear))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select ManufacturerId if TryUpdateModelAsync fails.
            PopulateManufacturerDropDownList(_context, terminalToUpdate.ManufacturerId);
            // Select TermClassId if TryUpdateModelAsync fails.
            PopulateTermClassDropDownList(_context, terminalToUpdate.TermClassId);
            return Page();
        }

        private bool TerminalExists(int id)
        {
          return (_context.Terminals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
