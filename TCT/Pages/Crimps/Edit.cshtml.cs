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

namespace TCT.Pages.Crimps
{
    public class EditModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public EditModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Crimp Crimp { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimp =  await _context.Crimps.FirstOrDefaultAsync(m => m.Id == id);
            if (crimp == null)
            {
                return NotFound();
            }
            Crimp = crimp;
           ViewData["TerminalId"] = new SelectList(_context.Terminals, "Id", "Id");
           ViewData["ToolId"] = new SelectList(_context.Tools, "Id", "Id");
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

            var crimpToUpdate = await _context.Crimps.FindAsync(id);

            if (crimpToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Crimp>(
                crimpToUpdate,
                "Crimp", // Prefix for form value.
                s => s.TerminalId,
                s => s.ToolId,
                s => s.WireAWG,
                s => s.CrimpHeight,
                s => s.PullForce))
            {
                await _context.SaveChangesAsync();

                //    _context.Attach(Crimp).State = EntityState.Modified;

                //try
                //{
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!CrimpExists(Crimp.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}

                return RedirectToPage("./Index");
            }
            return Page();
        }

            private bool CrimpExists(int id)
        {
          return _context.Crimps.Any(e => e.Id == id);
        }
    }
}
