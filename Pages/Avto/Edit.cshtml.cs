using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Odpelji_me.Data;
using OpremiSe.Models;

namespace Odpelji_me.Pages.Avto
{
    public class EditModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public EditModel(Odpelji_me.Data.Odpelji_meContext context)
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

            var avtomobil =  await _context.Avtomobil.FirstOrDefaultAsync(m => m.Id == id);
            if (avtomobil == null)
            {
                return NotFound();
            }
            Avtomobil = avtomobil;
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

            _context.Attach(Avtomobil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvtomobilExists(Avtomobil.Id))
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

        private bool AvtomobilExists(int id)
        {
            return _context.Avtomobil.Any(e => e.Id == id);
        }
    }
}
