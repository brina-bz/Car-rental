using OdpeljiMe.Models;

namespace OpremiSe.Models
{
    public class Avtomobil
    {
        public int Id { get; set; }
        public string Znamka { get; set; }
        public string Model { get; set; }
        public int Leto { get; set; }
        public decimal CenaNaDan { get; set; }
        public string RegistrskaStevilka { get; set; }
        public string Status { get; set; } // Na voljo, Rezerviran, V uporabi

        public List<Rezervacija> Rezervacije { get; set; }
        public List<Mnenje> Mnenja { get; set; }
    }
}
