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

namespace TCT.Pages.Terminals
{
    [Authorize]
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

<<<<<<< HEAD
            PopulateManufacturerDropDownList(_context);
            PopulateTermClassDropDownList(_context);

=======
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
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
<<<<<<< HEAD
                s => s.MinWireAWG,
                s => s.MaxWireAWG,
                s => s.MinInsulDiam,
=======
                s => s.MaxAWG,
                s => s.MidMaxAWG,
                s => s.MidMinAWG,
                s => s.MinAWG,
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
                s => s.MaxInsulDiam,
                s => s.StripLength,
                s => s.DimFront,
                s => s.DimRear))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

<<<<<<< HEAD
            // Select ManufacturerId if TryUpdateModelAsync fails.
            PopulateManufacturerDropDownList(_context, terminalToUpdate.ManufacturerId);
            // Select TermClassId if TryUpdateModelAsync fails.
            PopulateTermClassDropDownList(_context, terminalToUpdate.TermClassId);
=======
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
            return Page();
        }

        private bool TerminalExists(int id)
        {
          return (_context.Terminals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
