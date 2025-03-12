using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdpeljiMe.Models;
using Odpelji_me.Data;

namespace Odpelji_me.Pages.Rezerviraj
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
        ViewData["AvtomobilId"] = new SelectList(_context.Avtomobil, "Id", "Id");
        ViewData["UporabnikId"] = new SelectList(_context.Set<Uporabnik>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Rezervacija Rezervacija { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rezervacija.Add(Rezervacija);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
