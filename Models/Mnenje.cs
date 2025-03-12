using OpremiSe.Models;

namespace OdpeljiMe.Models
{
    public class Mnenje
    {
        public int Id { get; set; }
        public int UporabnikId { get; set; }
        public int AvtomobilId { get; set; }
        public int Ocena { get; set; } // 1 - 5
        public string Komentar { get; set; }
        public DateTime Datum { get; set; }

        public Uporabnik Uporabnik { get; set; }
        public Avtomobil Avtomobil { get; set; }
    }
}
