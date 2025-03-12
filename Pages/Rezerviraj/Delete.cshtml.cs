using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdpeljiMe.Models;
using Odpelji_me.Data;

namespace Odpelji_me.Pages.Rezerviraj
{
    public class DeleteModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public DeleteModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervacija Rezervacija { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FirstOrDefaultAsync(m => m.Id == id);

            if (rezervacija == null)
            {
                return NotFound();
            }
            else
            {
                Rezervacija = rezervacija;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija != null)
            {
                Rezervacija = rezervacija;
                _context.Rezervacija.Remove(Rezervacija);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
