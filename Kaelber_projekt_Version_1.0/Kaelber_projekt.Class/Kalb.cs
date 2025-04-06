using System.Collections.Generic;
using System.ComponentModel;

namespace Kaelber_projekt.Class
{
    public class Kalb
    {
        public int Lebensnummer {  get; set; }
        public string Name {  get; set; }
        public char Geschlecht {  get; set; }
        [DisplayName("Größe")]
        public string Groeße { get; set; }
        public int MutterNr {  get; set; }
        public DateTime Geburtsdatum { get; set; }
        public bool Eisen {  get; set; }
        public bool Selene {  get; set; }
        public bool Impfungen {  get; set; }
        public bool Hornlos {  get; set; }
        public bool Enthornt { get; set; } 

        // Errechnete Felder
        public string Milch {  get; set; }

        // Krankheiten INFO
        [DisplayName("Durchfall + Datum")]
        public string Krankheiten {  get; set; }

        // Errechnete Felder
        [DisplayName("Kälberstarter")]
        public bool Kaelberstarter {  get; set; }
        public bool Heu {  get; set; }
        public bool Wasser { get; set; }
        public bool Silofutter {  get; set; }
        [DisplayName("Alter in Tagen")]
        public int Alter {  get; set; }
        [DisplayName("vorauss. Abspanndatum Vollmond")]
        public DateTime Abspanndatum { get; set; }
        //public string WochenUndTageBisAbspanndatum { get; set; }
        public string Notiz {  get; set; }


        public Kalb()
        {
            
        }
        public Kalb(int lebensnummer,
                    string name,
                    char geschlecht,
                    string groeße,
                    int mutternummer,
                    DateTime geburtsdatum,
                    bool eisen, 
                    bool selene,
                    bool impfungen,
                    bool hornlos,
                    string krankheiten)
        {
            Lebensnummer = lebensnummer;
            Name = name;
            Geschlecht = geschlecht;
            Groeße = groeße;
            MutterNr = mutternummer;
            Geburtsdatum = geburtsdatum;
            Eisen = eisen;
            Selene = selene;
            Impfungen = impfungen;
            Hornlos = hornlos;
            Enthornt = false;
            Krankheiten = krankheiten;
            Notiz = "-";
            CalculateFields();
        }

        public void CalculateFields()
        {
            Alter = (DateTime.Today - Geburtsdatum).Days + 1;
            //int totalTageBisAbspanndatum = (int)(Abspanndatum - DateTime.Today).TotalDays;
            Abspanndatum = Util.NextFullMoon(Geburtsdatum.AddDays(56));

            double maxAlter = (Abspanndatum - Geburtsdatum).TotalDays;
            //Wochen und Tage bis Abspanndatum angezeigt

            //WochenUndTageBisAbspanndatum = $"{totalTageBisAbspanndatum / 7} Wochen und {totalTageBisAbspanndatum % 7} Tage";

            if (Groeße == "Klein 35kg")
            {
                switch (Alter)
                {
                    case <= 7: Milch = $"2L; {MutterNr}"; break;
                    case <= 14: Milch = "3L"; break;
                    case <= 21: Milch = "3L"; break;
                    case <= 28: Milch = "3,5L"; break;
                    case <= 56: Milch = "4L"; break;
                    case <= 63: Milch = "3L"; break;
                    case <= 70: Milch = "2L"; break;
                    case <= 92: Milch = "1L"; break;
                    default: Milch = "Fehler Abgespannt?"; break;
                }
                if (Alter > maxAlter)
                    Milch = "Abgespannt";
                else if (Krankheiten != String.Empty && Krankheiten != " " && Krankheiten != null)
                    Milch = "-";
                Kaelberstarter = Alter > 21 ? true : false;
                Heu = Alter > 21 ? true : false;
                Wasser = Alter > 21 ? true : false;
            }

            else if (Groeße == "Mittel 40kg")
            {
                switch (Alter)
                {
                    case <= 7: Milch = $"3L; {MutterNr}"; break;
                    case <= 14: Milch = "3L"; break;
                    case <= 21: Milch = "3,5L"; break;
                    case <= 28: Milch = "3,5L"; break;
                    case <= 56: Milch = "4L"; break;
                    case <= 63: Milch = "3L"; break;
                    case <= 70: Milch = "2L"; break;
                    case <= 92: Milch = "1L"; break;
                    default: Milch = "Fehler Abgespannt?"; break;
                }
                if (Alter > maxAlter)
                    Milch = "Abgespannt"; 
                else if (Krankheiten != String.Empty && Krankheiten != " " && Krankheiten != null)
                    Milch = "-";
                Kaelberstarter = Alter > 17 ? true : false;
                Heu = Alter > 17 ? true : false;
                Wasser = Alter > 17 ? true : false;
            }

            else if (Groeße == "Groß 45kg")
            {
                switch (Alter)
                {
                    case <= 7: Milch = $"3L; {MutterNr}"; break;
                    case <= 14: Milch = "3L"; break;
                    case <= 21: Milch = "3,5L"; break;
                    case <= 28: Milch = "3,5L"; break;
                    case <= 56: Milch = "4L"; break;
                    case <= 63: Milch = "3L"; break;
                    case <= 70: Milch = "2L"; break;
                    case <= 92: Milch = "1L"; break;
                    default: Milch = "Fehler Abgespannt?"; break;
                }
                if (Alter > maxAlter)
                    Milch = "Abgespannt";
                else if (Krankheiten != String.Empty && Krankheiten != " " && Krankheiten != null)
                    Milch = "-";
                Kaelberstarter = Alter > 17 ? true : false;
                Heu = Alter > 17 ? true : false;
                Wasser = Alter > 17 ? true : false;
            }
            else
                Milch = "Fehler Größe";

            Silofutter = Alter > 33 ? true : false;
        }

        public override string ToString()
        {
            return $"{Lebensnummer} - {MutterNr} - {Eisen} - {Geburtsdatum}";
        }
    }
}
