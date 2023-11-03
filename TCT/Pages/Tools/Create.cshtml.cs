using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Tools
{
    public class CreateModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public CreateModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Tool = new Tool
            {
                InternalId = "WP5-075",
                ModelNo = "2266140-1",
                SerialNo = "740357",
                ManufacturerId = 1,
                EquipTypeId = 1
            };
            return Page();
        }

        [BindProperty]
        public Tool Tool { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTool = new Tool();

            if (await TryUpdateModelAsync<Tool>(
                emptyTool,
                "Tool", // Prefix for form value.
                s => s.InternalId,
                s => s.ModelNo,
                s => s.SerialNo,
                s => s.ManufacturerId,
                s => s.EquipTypeId))
            {
                _context.Tools.Add(emptyTool);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
