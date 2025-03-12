using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdpeljiMe.Models;
using Odpelji_me.Data;

namespace Odpelji_me.Pages.Ocena
{
    public class DeleteModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public DeleteModel(Odpelji_me.Data.Odpelji_meContext context)
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

            var mnenje = await _context.Mnenje.FirstOrDefaultAsync(m => m.Id == id);

            if (mnenje == null)
            {
                return NotFound();
            }
            else
            {
                Mnenje = mnenje;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mnenje = await _context.Mnenje.FindAsync(id);
            if (mnenje != null)
            {
                Mnenje = mnenje;
                _context.Mnenje.Remove(Mnenje);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
