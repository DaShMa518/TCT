using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.TermToolXrefs
{
    public class CreateModel : TermToolSelectPageModel
    //public class CreateModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public CreateModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["TerminalId"] = new SelectList(_context.Terminals, "Id", "Id");
            //ViewData["ToolId"] = new SelectList(_context.Tools, "Id", "Id");
            PopulateTerminalsDropDownList(_context);
            PopulateToolsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public TermToolXref TermToolXref { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid)
          //  {
          //      return Page();
          //  }

          //  _context.TermToolXrefs.Add(TermToolXref);
          //  await _context.SaveChangesAsync();

          //  return RedirectToPage("./Index");

            var emptyTermToolXref = new TermToolXref();

            if (await TryUpdateModelAsync<TermToolXref>(
                 emptyTermToolXref,
                 "termtoolxref",   // Prefix for form value.
                 s => s.TerminalId, s => s.ToolId))
            {
                _context.TermToolXrefs.Add(emptyTermToolXref);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select TerminalId if TryUpdateModelAsync fails.
            PopulateTerminalsDropDownList(_context, emptyTermToolXref.TerminalId);
            // Select ToollId if TryUpdateModelAsync fails.
            PopulateToolsDropDownList(_context, emptyTermToolXref.ToolId);
            return Page();
        }
    }
}
