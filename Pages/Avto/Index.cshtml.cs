using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Odpelji_me.Data;
using OpremiSe.Models;

namespace Odpelji_me.Pages.Avto
{
    public class IndexModel : PageModel
    {
        private readonly Odpelji_me.Data.Odpelji_meContext _context;

        public IndexModel(Odpelji_me.Data.Odpelji_meContext context)
        {
            _context = context;
        }

        public IList<Avtomobil> Avtomobil { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Avtomobil = await _context.Avtomobil.ToListAsync();
        }
    }
}
