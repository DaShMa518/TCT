﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly TCT.Data.TCTContext _context;

        public DetailsModel(TCT.Data.TCTContext context)
        {
            _context = context;
        }

      public Crimp Crimp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

            return Page();
        }
    }
}
