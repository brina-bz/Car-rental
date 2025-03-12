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
    public class DetailsModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public DetailsModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

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
    }
}
