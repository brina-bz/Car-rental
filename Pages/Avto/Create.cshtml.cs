using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Odpelji_me.Data;
using OpremiSe.Models;

namespace Odpelji_me.Pages.Avto
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
            return Page();
        }

        [BindProperty]
        public Avtomobil Avtomobil { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Avtomobil.Add(Avtomobil);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
