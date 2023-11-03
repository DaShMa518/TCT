using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.EquipTypes
{
    public class DeleteModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DeleteModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EquipType EquipType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EquipTypes == null)
            {
                return NotFound();
            }

            var equiptype = await _context.EquipTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (equiptype == null)
            {
                return NotFound();
            }
            else 
            {
                EquipType = equiptype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EquipTypes == null)
            {
                return NotFound();
            }
            var equiptype = await _context.EquipTypes.FindAsync(id);

            if (equiptype != null)
            {
                EquipType = equiptype;
                _context.EquipTypes.Remove(EquipType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
