﻿using System.Collections.Generic;
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
                    bool zuklein)
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
        }

        public void CalculateFields()
        {

            Alter = (DateTime.Today - Geburtsdatum).Days + 1;

            var vollmondInfo = default((DateTime Datum, bool IstExakterVollmond));
            if (ZuKlein == true)
            {
                vollmondInfo = Util.NextFullMoon(Geburtsdatum.AddDays(84));
                Abspanndatum = vollmondInfo.Datum;
            }
            else
            {
                vollmondInfo = Util.NextFullMoon(Geburtsdatum.AddDays(56));
                Abspanndatum = vollmondInfo.Datum;
            }

            IstExakterVollmond = vollmondInfo.IstExakterVollmond;

            double maxAlter = (Abspanndatum - Geburtsdatum).TotalDays;
           

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
                    case <= 84: Milch = "2L"; break;
                    case <= 110: Milch = "1L"; break;
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
                    case <= 84: Milch = "2L"; break;
                    case <= 110: Milch = "1L"; break;
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
                    case <= 84: Milch = "2L"; break;
                    case <= 110: Milch = "1L"; break;
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
