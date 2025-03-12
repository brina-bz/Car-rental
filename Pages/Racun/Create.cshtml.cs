using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdpeljiMe.Models;
using Odpelji_me.Data;

namespace Odpelji_me.Pages.Racun
{
    public class CreateModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public CreateModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RezervacijaId"] = new SelectList(_context.Set<Rezervacija>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Placilo Placilo { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Placilo.Add(Placilo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
