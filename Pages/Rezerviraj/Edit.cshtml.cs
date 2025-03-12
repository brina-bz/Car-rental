using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdpeljiMe.Models;
using Odpelji_me.Data;

namespace Odpelji_me.Pages.Rezerviraj
{
    public class EditModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public EditModel(Odpelji_me.Data.Odpelji_meContext context)
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

            var rezervacija =  await _context.Rezervacija.FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            Rezervacija = rezervacija;
           ViewData["AvtomobilId"] = new SelectList(_context.Avtomobil, "Id", "Id");
           ViewData["UporabnikId"] = new SelectList(_context.Set<Uporabnik>(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rezervacija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervacijaExists(Rezervacija.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.Id == id);
        }
    }
}
