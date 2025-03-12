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

namespace Odpelji_me.Pages.Ocena
{
    public class EditModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public EditModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mnenje Mnenje { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mnenje =  await _context.Mnenje.FirstOrDefaultAsync(m => m.Id == id);
            if (mnenje == null)
            {
                return NotFound();
            }
            Mnenje = mnenje;
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

            _context.Attach(Mnenje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MnenjeExists(Mnenje.Id))
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

        private bool MnenjeExists(int id)
        {
            return _context.Mnenje.Any(e => e.Id == id);
        }
    }
}
