using OpremiSe.Models;

namespace OdpeljiMe.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public int UporabnikId { get; set; }
        public int AvtomobilId { get; set; }
        public DateTime DatumZacetka { get; set; }
        public DateTime DatumKonca { get; set; }
        public string Status { get; set; } // Čaka, Potrjena, Zavrnjena, Zaključena

        public Uporabnik Uporabnik { get; set; }
        public Avtomobil Avtomobil { get; set; }
        public Placilo Placilo { get; set; }
    }
}
