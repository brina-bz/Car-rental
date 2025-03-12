using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdpeljiMe.Models;
using Odpelji_me.Data;

namespace Odpelji_me.Pages.Racun
{
    public class DeleteModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public DeleteModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Placilo Placilo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placilo = await _context.Placilo.FirstOrDefaultAsync(m => m.Id == id);

            if (placilo == null)
            {
                return NotFound();
            }
            else
            {
                Placilo = placilo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placilo = await _context.Placilo.FindAsync(id);
            if (placilo != null)
            {
                Placilo = placilo;
                _context.Placilo.Remove(Placilo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
