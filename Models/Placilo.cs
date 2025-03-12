namespace OdpeljiMe.Models
{
    public class Placilo
    {
        public int Id { get; set; }
        public int RezervacijaId { get; set; }
        public decimal Znesek { get; set; }
        public string NacinPlacila { get; set; } // Kartica, PayPal, Gotovina
        public string Status { get; set; } // Plačano, Neplačano

        public Rezervacija Rezervacija { get; set; }
    }
}
