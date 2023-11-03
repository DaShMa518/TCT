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

namespace TCT.Pages.TermToolXrefs
{
    public class EditModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public EditModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TermToolXref TermToolXref { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TermToolXrefs == null)
            {
                return NotFound();
            }

            var termtoolxref =  await _context.TermToolXrefs.FirstOrDefaultAsync(m => m.Id == id);
            if (termtoolxref == null)
            {
                return NotFound();
            }
            TermToolXref = termtoolxref;
           ViewData["TerminalId"] = new SelectList(_context.Terminals, "Id", "Id");
           ViewData["ToolId"] = new SelectList(_context.Tools, "Id", "Id");
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

            _context.Attach(TermToolXref).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermToolXrefExists(TermToolXref.Id))
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

        private bool TermToolXrefExists(int id)
        {
          return _context.TermToolXrefs.Any(e => e.Id == id);
        }
    }
}
