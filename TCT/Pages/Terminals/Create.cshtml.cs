﻿using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Terminals
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
            Terminal = new Terminal
            {
                PartNo = "2-520181-2",
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
            //if (!ModelState.IsValid || _context.Terminals == null || Terminal == null)
            //{
            //    return Page();
            //}
            var emptyTerminal = new Terminal();

            if (await TryUpdateModelAsync<Terminal>(
                emptyTerminal,
                "Terminal", // Prefix for form value.
                s => s.PartNo,
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

            return Page();
        }
    }
}
