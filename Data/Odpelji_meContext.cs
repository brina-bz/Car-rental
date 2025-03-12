using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpremiSe.Models;
using OdpeljiMe.Models;

namespace Odpelji_me.Data
{
    public class Odpelji_meContext : DbContext
    {
        public Odpelji_meContext (DbContextOptions<Odpelji_meContext> options)
            : base(options)
        {
        }

        public DbSet<OpremiSe.Models.Avtomobil> Avtomobil { get; set; } = default!;
        public DbSet<OdpeljiMe.Models.Mnenje> Mnenje { get; set; } = default!;
        public DbSet<OdpeljiMe.Models.Placilo> Placilo { get; set; } = default!;
        public DbSet<OdpeljiMe.Models.Rezervacija> Rezervacija { get; set; } = default!;
        public DbSet<OdpeljiMe.Models.Uporabnik> Uporabnik { get; set; } = default!;
    }
}
