namespace Kaelber_projekt.Class
{
    public class Kaelberbox
    {
        public string BoxId {  get; }
        public int? Lebensnummer {  get; }
        public Kaelberbox(string boxId, int? lebensnummer)
        {
            BoxId = boxId;
            Lebensnummer = lebensnummer;
        }
    }
}
