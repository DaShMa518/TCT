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

namespace TCT.Pages.Tools
{
    public class EditModel : PageModel
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

            Tool = await _context.Tools.FindAsync(id);

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
                s => s.SerialNo))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            //    _context.Attach(Terminal).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TerminalExists(Terminal.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");
            return Page();
        }

        private bool ToolExists(int id)
        {
          return _context.Tools.Any(e => e.Id == id);
        }
    }
}
