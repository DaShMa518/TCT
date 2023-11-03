﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCT.Data;
using TCT.Models;

namespace TCT.Pages.Manufacturers
{
    public class DeleteModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DeleteModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);

            if (manufacturer == null)
            {
                return NotFound();
            }
            else 
            {
                Manufacturer = manufacturer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer != null)
            {
                Manufacturer = manufacturer;
                _context.Manufacturers.Remove(Manufacturer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}