using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdpeljiMe.Models;
using Odpelji_me.Data;

namespace Odpelji_me.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public DeleteModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Uporabnik Uporabnik { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabnik.FirstOrDefaultAsync(m => m.Id == id);

            if (uporabnik == null)
            {
                return NotFound();
            }
            else
            {
                Uporabnik = uporabnik;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabnik.FindAsync(id);
            if (uporabnik != null)
            {
                Uporabnik = uporabnik;
                _context.Uporabnik.Remove(Uporabnik);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
