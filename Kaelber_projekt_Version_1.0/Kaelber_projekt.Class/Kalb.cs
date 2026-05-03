using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

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
        [DisplayName("Milchmast")]
        public bool Milchmast { get; set; }

        // Errechnete Felder
        public string Milch {  get; set; }

        // Krankheiten INFO
        [DisplayName("Durchfall + Datum")]
        public string Krankheiten {  get; set; }
        // Info Alter Stall
        [DisplayName("Alter Stall")]
        public bool AlterStall { get; set; }
        

        // Errechnete Felder
        [DisplayName("Kälberstarter")]
        public bool Kaelberstarter {  get; set; }
        public bool Heu {  get; set; }
        public bool Wasser { get; set; }
        public bool Silofutter {  get; set; }
        [DisplayName("Alter in Tagen (Wochen)")]
        public int Alter {  get; set; }
        [DisplayName("Abspanndatum Vollmond")]
        public DateTime Abspanndatum { get; set; }
        // Info wenn ein Kalb zu klein ist um nach 2 Moante 
        [DisplayName("zu klein zum Abspannen")]
        public bool ZuKlein { get; set; }
        public string Notiz {  get; set; }
        public bool IstExakterVollmond { get; private set; }




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
                    string krankheiten,
                    bool alterStall,
                    bool zuklein,
                    bool milchmast)
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
            AlterStall = alterStall;
            ZuKlein = zuklein;
            Milchmast = milchmast;
        }

        public void CalculateFields(
            // Klein
            double KleinMilch1 = 0, double KleinMilch2 = 0, double KleinMilch3 = 0, double KleinMilch4 = 0, double KleinMilch5 = 0,
            double KleinMilch6 = 0, double KleinMilch7 = 0, double KleinMilch8 = 0, double KleinMilch9 = 0, double KleinMilch10 = 0,
            double KleinMilch11 = 0, double KleinMilch12 = 0, double KleinMilch13 = 0, double KleinMilch14 = 0, double KleinMilch15 = 0,
            double KleinKaelberstarter = 0, double KleinHeu = 0, double KleinWasser = 0, double KleinSilofutter = 0,
            // Mittel
            double MittelMilch1 = 0, double MittelMilch2 = 0, double MittelMilch3 = 0, double MittelMilch4 = 0, double MittelMilch5 = 0,
            double MittelMilch6 = 0, double MittelMilch7 = 0, double MittelMilch8 = 0, double MittelMilch9 = 0, double MittelMilch10 = 0,
            double MittelMilch11 = 0, double MittelMilch12 = 0, double MittelMilch13 = 0, double MittelMilch14 = 0, double MittelMilch15 = 0,
            double MittelKaelberstarter = 0, double MittelHeu = 0, double MittelWasser = 0, double MittelSilofutter = 0,
            // Groß
            double GrossMilch1 = 0, double GrossMilch2 = 0, double GrossMilch3 = 0, double GrossMilch4 = 0, double GrossMilch5 = 0,
            double GrossMilch6 = 0, double GrossMilch7 = 0, double GrossMilch8 = 0, double GrossMilch9 = 0, double GrossMilch10 = 0,
            double GrossMilch11 = 0, double GrossMilch12 = 0, double GrossMilch13 = 0, double GrossMilch14 = 0, double GrossMilch15 = 0,
            double GrossKaelberstarter = 0, double GrossHeu = 0, double GrossWasser = 0, double GrossSilofutter = 0,
            // Milchmast
            double Milchmast1 = 3, double Milchmast2 = 4, double Milchmast3 = 5, double Milchmast4 = 6, double Milchmast5 = 6, double Milchmast6 = 6,
            double Milchmast7 = 7, double Milchmast8 = 7, double Milchmast9 = 7, double Milchmast10 = 8, double Milchmast11 = 8, double Milchmast12 = 8)
        {
            Alter = (DateTime.Today - Geburtsdatum).Days + 1;

            var vollmondInfo = default((DateTime Datum, bool IstExakterVollmond));
            if (ZuKlein == true && Milchmast == false)
            {
                vollmondInfo = Util.NextFullMoon(Geburtsdatum.AddDays(84));
                Abspanndatum = vollmondInfo.Datum;
            }
            else if (Milchmast == true)
            {
                if (ZuKlein == true || Groeße == "Klein 35kg" || Groeße == "Mittel 40kg")
                    Abspanndatum = Geburtsdatum.AddDays(84);
                else
                    Abspanndatum = Geburtsdatum.AddDays(56);
            }
            else
            {
                vollmondInfo = Util.NextFullMoon(Geburtsdatum.AddDays(56));
                Abspanndatum = vollmondInfo.Datum;
            }

            IstExakterVollmond = vollmondInfo.IstExakterVollmond;

            double maxAlter = (Abspanndatum - Geburtsdatum).TotalDays;

            if (Groeße == "Klein 35kg" && Milchmast == false)
            {
                switch (Alter)
                {
                    case <= 7: Milch = $"{KleinMilch1}L; {MutterNr}"; break;
                    case <= 14: Milch = $"{KleinMilch2}L"; break;
                    case <= 21: Milch = $"{KleinMilch3}L"; break;
                    case <= 28: Milch = $"{KleinMilch4}L"; break;
                    case <= 35: Milch = $"{KleinMilch5}L"; break;
                    case <= 42: Milch = $"{KleinMilch6}L"; break;
                    case <= 49: Milch = $"{KleinMilch7}L"; break;
                    case <= 56: Milch = $"{KleinMilch8}L"; break;
                    case <= 63: Milch = $"{KleinMilch9}L"; break;
                    case <= 70: Milch = $"{KleinMilch10}L"; break;
                    case <= 77: Milch = $"{KleinMilch11}L"; break;
                    case <= 84: Milch = $"{KleinMilch12}L"; break;
                    case <= 91: Milch = $"{KleinMilch13}L"; break;
                    case <= 98: Milch = $"{KleinMilch14}L"; break;
                    case <= 105: Milch = $"{KleinMilch15}L"; break;
                    default: Milch = "Fehler Abgespannt?"; break;
                }
                if (Alter > maxAlter)
                    Milch = "Abgespannt";
                else if (Krankheiten != string.Empty && Krankheiten != " " && Krankheiten != null)
                    Milch = "-";
                Kaelberstarter = Alter > KleinKaelberstarter;
                Heu = Alter > KleinHeu;
                Wasser = Alter > KleinWasser;
                Silofutter = Alter > KleinSilofutter;
            }
            else if (Groeße == "Mittel 40kg" && Milchmast == false)
            {
                switch (Alter)
                {
                    case <= 7: Milch = $"{MittelMilch1}L; {MutterNr}"; break;
                    case <= 14: Milch = $"{MittelMilch2}L"; break;
                    case <= 21: Milch = $"{MittelMilch3}L"; break;
                    case <= 28: Milch = $"{MittelMilch4}L"; break;
                    case <= 35: Milch = $"{MittelMilch5}L"; break;
                    case <= 42: Milch = $"{MittelMilch6}L"; break;
                    case <= 49: Milch = $"{MittelMilch7}L"; break;
                    case <= 56: Milch = $"{MittelMilch8}L"; break;
                    case <= 63: Milch = $"{MittelMilch9}L"; break;
                    case <= 70: Milch = $"{MittelMilch10}L"; break;
                    case <= 77: Milch = $"{MittelMilch11}L"; break;
                    case <= 84: Milch = $"{MittelMilch12}L"; break;
                    case <= 91: Milch = $"{MittelMilch13}L"; break;
                    case <= 98: Milch = $"{MittelMilch14}L"; break;
                    case <= 105: Milch = $"{MittelMilch15}L"; break;
                    default: Milch = "Fehler Abgespannt?"; break;
                }
                if (Alter > maxAlter)
                    Milch = "Abgespannt";
                else if (Krankheiten != string.Empty && Krankheiten != " " && Krankheiten != null)
                    Milch = "-";
                Kaelberstarter = Alter > MittelKaelberstarter;
                Heu = Alter > MittelHeu;
                Wasser = Alter > MittelWasser;
                Silofutter = Alter > MittelSilofutter;
            }
            else if (Groeße == "Groß 45kg" && Milchmast == false)
            {
                switch (Alter)
                {
                    case <= 7: Milch = $"{GrossMilch1}L; {MutterNr}"; break;
                    case <= 14: Milch = $"{GrossMilch2}L"; break;
                    case <= 21: Milch = $"{GrossMilch3}L"; break;
                    case <= 28: Milch = $"{GrossMilch4}L"; break;
                    case <= 35: Milch = $"{GrossMilch5}L"; break;
                    case <= 42: Milch = $"{GrossMilch6}L"; break;
                    case <= 49: Milch = $"{GrossMilch7}L"; break;
                    case <= 56: Milch = $"{GrossMilch8}L"; break;
                    case <= 63: Milch = $"{GrossMilch9}L"; break;
                    case <= 70: Milch = $"{GrossMilch10}L"; break;
                    case <= 77: Milch = $"{GrossMilch11}L"; break;
                    case <= 84: Milch = $"{GrossMilch12}L"; break;
                    case <= 91: Milch = $"{GrossMilch13}L"; break;
                    case <= 98: Milch = $"{GrossMilch14}L"; break;
                    case <= 105: Milch = $"{GrossMilch15}L"; break;
                    default: Milch = "Fehler Abgespannt?"; break;
                }
                if (Alter > maxAlter)
                    Milch = "Abgespannt";
                else if (Krankheiten != string.Empty && Krankheiten != " " && Krankheiten != null)
                    Milch = "-";
                Kaelberstarter = Alter > GrossKaelberstarter;
                Heu = Alter > GrossHeu;
                Wasser = Alter > GrossWasser;
                Silofutter = Alter > GrossSilofutter;
            }
            else if (Milchmast == true)
            {
                switch (Alter)
                {
                    case <= 7: Milch = $"{Milchmast1}L; {MutterNr}"; break;
                    case <= 14: Milch = $"{Milchmast2}L"; break;
                    case <= 21: Milch = $"{Milchmast3}L"; break;
                    case <= 28: Milch = $"{Milchmast4}L"; break;
                    case <= 35: Milch = $"{Milchmast5}L"; break;
                    case <= 42: Milch = $"{Milchmast6}L"; break;
                    case <= 49: Milch = $"{Milchmast7}L"; break;
                    case <= 56: Milch = $"{Milchmast8}L"; break;
                    case <= 63: Milch = $"{Milchmast9}L"; break;
                    case <= 70: Milch = $"{Milchmast10}L"; break;
                    case <= 77: Milch = $"{Milchmast11}L"; break;
                    case <= 84: Milch = $"{Milchmast12}L"; break;
                    default: Milch = "Fehler Abgespannt?"; break;
                }
                if (Alter > 84)
                    Milch = "Milchmast fertig";
                else if (Krankheiten != string.Empty && Krankheiten != " " && Krankheiten != null)
                    Milch = "-";
                Kaelberstarter = false;
                Heu = false;
                Wasser = false;
                Silofutter = false;
            }
            else
                Milch = "Fehler Größe";

        }

        public override string ToString()
        {
            return $"{Lebensnummer} - {MutterNr} - {Eisen} - {Geburtsdatum}";
        }
    }
}
