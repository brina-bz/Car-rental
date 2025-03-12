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
    public class DetailsModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public DetailsModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

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
    }
}
