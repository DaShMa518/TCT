using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Terminals
{

    public class CreateModel : TermOptionsSelectPageModel
    //public class CreateModel : PageModel

    //public class CreateModel : TerminalSelectPageModel
    //public class CreateModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public CreateModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            PopulateManufacturerDropDownList(_context);
            PopulateTermClassDropDownList(_context);

            //PopulateToolsDropDownList(_context);

            Terminal = new Terminal
            {
                PartNo = "2-520181-2",
                ManufacturerId = 1,
                TermClassId = 1,
                MaxAWG = 18,
                MidMaxAWG = 20,
                MidMinAWG = 21,
                MinAWG = 22,
                MaxInsulDiam = .135f,
                StripLength = .280f,
                DimFront = .20f,
                DimRear = .20f,
            };
            
            return Page();
        }

        [BindProperty]
        public Terminal Terminal { get; set; }         

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTerminal = new Terminal();

            if (await TryUpdateModelAsync<Terminal>(
                emptyTerminal,
                "Terminal", // Prefix for form value.
                s => s.PartNo,
                s => s.ManufacturerId,
                s => s.TermClassId,
                s => s.MaxAWG,
                s => s.MidMaxAWG,
                s => s.MidMinAWG,
                s => s.MinAWG,
                s => s.MaxInsulDiam,
                s => s.StripLength,
                s => s.DimFront,
                s => s.DimRear))
            {
                _context.Terminals.Add(emptyTerminal);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            // Select ManufacturerId if TryUpdateModelAsync fails.
            PopulateManufacturerDropDownList(_context, emptyTerminal.ManufacturerId);
            // Select TermClassId if TryUpdateModelAsync fails.
            PopulateTermClassDropDownList(_context, emptyTerminal.TermClassId);



            return Page();
        }
    }
}
