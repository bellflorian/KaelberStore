using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kaelber_projekt.Class
{
    public class AlleKaelberStore : IKalbStore
    {
        private List<Kalb> kaelber = new List<Kalb>();

        public void AddKalb(Kalb kalb)
        {
            kaelber = GetAllKaelber();
            kaelber.Add(kalb);
            SaveToFile();
        }

        public void SetKaelber(List<Kalb> newList)
        {
            kaelber = newList;
            SaveToFile();
        }

        public Kalb GetKalb(int lebensnummer)
        {
            return GetAllKaelber().FirstOrDefault(k => k.Lebensnummer == lebensnummer);
        }

        public List<Kalb> GetAllKaelber()
        {
            kaelber.Clear();

            if (!File.Exists(DataFilePaths.AlleKaelberFile))
            {
                File.Create(DataFilePaths.AlleKaelberFile).Close();
                return kaelber;
            }

            string[] lines = File.ReadAllLines(DataFilePaths.AlleKaelberFile);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 16)
                {
                    kaelber.Add(new Kalb
                    {
                        Lebensnummer = int.Parse(parts[0]),
                        Name = parts[1],
                        Geschlecht = char.Parse(parts[2]),
                        Groeße = parts[3],
                        MutterNr = int.Parse(parts[4]),
                        Geburtsdatum = DateTime.Parse(parts[5]),
                        Eisen = bool.Parse(parts[6]),
                        Selene = bool.Parse(parts[7]),
                        Impfungen = bool.Parse(parts[8]),
                        Hornlos = bool.Parse(parts[9]),
                        Enthornt = bool.Parse(parts[10]),
                        AlterStall = bool.Parse(parts[11]),
                        Krankheiten = parts[12],
                        Notiz = parts[13],
                        ZuKlein = bool.Parse(parts[14]),
                        Milchmast = bool.Parse(parts[15])
                    });
                }
            }

            return kaelber;
        }

        public void SaveToFile() // Changed from private to public
        {
            List<string> output = new List<string>();
            foreach (Kalb kalb in kaelber)
            {
                string line = $"{kalb.Lebensnummer};{kalb.Name};{kalb.Geschlecht};{kalb.Groeße};{kalb.MutterNr};{kalb.Geburtsdatum};{kalb.Eisen};{kalb.Selene};{kalb.Impfungen};{kalb.Hornlos};{kalb.Enthornt};{kalb.AlterStall};{kalb.Krankheiten};{kalb.Notiz};{kalb.ZuKlein};{kalb.Milchmast}";
                output.Add(line);
            }
            File.WriteAllLines(DataFilePaths.AlleKaelberFile, output);
        }
    }
}
