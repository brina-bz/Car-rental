using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdpeljiMe.Models;
using Odpelji_me.Data;

namespace Odpelji_me.Pages.Rezerviraj
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string PickupLocation { get; set; }

        [BindProperty]
        public string DropoffLocation { get; set; }

        [BindProperty]
        public DateTime PickupDate { get; set; }

        [BindProperty]
        public TimeSpan PickupTime { get; set; }

        [BindProperty]
        public DateTime DropoffDate { get; set; }

        [BindProperty]
        public TimeSpan DropoffTime { get; set; }

        public void OnGet()
        {
            PickupDate = DateTime.Today.AddDays(1); // Default date
            PickupTime = new TimeSpan(11, 0, 0); // Default time
            DropoffDate = DateTime.Today.AddDays(4);
            DropoffTime = new TimeSpan(11, 0, 0);
        }

        public IActionResult OnPost()
        {
            if (DropoffDate < PickupDate || (DropoffDate == PickupDate && DropoffTime < PickupTime))
            {
                ModelState.AddModelError("", "Čas vračila mora biti po času prevzema.");
                return Page();
            }

            // Process the data (e.g., save to database, redirect to another page)
            return RedirectToPage("Success");
        }
    }
}