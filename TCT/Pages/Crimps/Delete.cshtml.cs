using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Crimps
{
    [Authorize]
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
        public Crimp Crimp { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Crimp = await _context.Crimps
            .Include(c => c.Terminal)
            .Include(c => c.Tool)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (Crimp == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {Id} failed. Try again", id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var crimp = await _context.Crimps.FindAsync(id);

            if (crimp == null)
            {
                return NotFound();
            }

            try
            {
                _context.Crimps.Remove(crimp);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }

        }
    }
}
