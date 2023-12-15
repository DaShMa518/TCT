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

namespace TCT.Pages.EquipTypes
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public EditModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EquipType EquipType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EquipTypes == null)
            {
                return NotFound();
            }

            var equiptype =  await _context.EquipTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (equiptype == null)
            {
                return NotFound();
            }
            EquipType = equiptype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EquipType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipTypeExists(EquipType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EquipTypeExists(int id)
        {
          return _context.EquipTypes.Any(e => e.Id == id);
        }
    }
}
