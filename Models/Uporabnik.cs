namespace OdpeljiMe.Models
{
    public class Uporabnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Email { get; set; }
        public string Geslo { get; set; }
        public string Vloga { get; set; } // Najemnik, Administrator

        public List<Rezervacija> Rezervacije { get; set; }
        public List<Mnenje> Mnenja { get; set; }
    }
}
