using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Odpelji_me.Data;
using OpremiSe.Models;

namespace Odpelji_me.Pages.Avto
{
    public class DeleteModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public DeleteModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Avtomobil Avtomobil { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avtomobil = await _context.Avtomobil.FirstOrDefaultAsync(m => m.Id == id);

            if (avtomobil == null)
            {
                return NotFound();
            }
            else
            {
                Avtomobil = avtomobil;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avtomobil = await _context.Avtomobil.FindAsync(id);
            if (avtomobil != null)
            {
                Avtomobil = avtomobil;
                _context.Avtomobil.Remove(Avtomobil);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
