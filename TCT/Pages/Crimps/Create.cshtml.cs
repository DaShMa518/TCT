using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
=======
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Crimps
{
<<<<<<< HEAD
    [Authorize]
=======
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
    public class CreateModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public CreateModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Crimp = new Crimp
            {
                TerminalId = 3,
                ToolId = 5,
                WireAWG = 18,
                CrimpHeight = .085f,
                PullForce = 30
            };
            return Page();
        }

        [BindProperty]
        public Crimp Crimp { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCrimp = new Crimp();

            if (await TryUpdateModelAsync<Crimp>(
                emptyCrimp,
                "Crimp", // Prefix for form value.
                s => s.TerminalId,
                s => s.ToolId,
                s => s.WireAWG,
                s => s.CrimpHeight,
                s => s.PullForce))
            {
                _context.Crimps.Add(emptyCrimp);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
