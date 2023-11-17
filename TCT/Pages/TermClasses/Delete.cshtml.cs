using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.TermClasses
{
    public class DeleteModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(TCT.Data.TCTContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public TermClass TermClass { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            TermClass = await _context.TermClasses
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (TermClass == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {{ID}} failed. Try again", id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var termclass = await _context.TermClasses.FindAsync(id);

            try
            {
                _context.TermClasses.Remove(termclass);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);
            }

            return RedirectToAction("./Delete", new { id, saveChangesError = true });
        }
    }
}
