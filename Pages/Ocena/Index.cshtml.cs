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
    public class IndexModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public IndexModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

        public IList<Mnenje> Mnenje { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Mnenje = await _context.Mnenje
                .Include(m => m.Avtomobil)
                .Include(m => m.Uporabnik).ToListAsync();
        }
    }
}
