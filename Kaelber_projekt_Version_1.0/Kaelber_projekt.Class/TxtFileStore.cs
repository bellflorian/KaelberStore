using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaelber_projekt.Class
{
    public class TxtFileStore: IKalbStore
    {
        public List<Kalb> Kaelber { get; set; }
        public TxtFileStore()
        {
            Kaelber = new List<Kalb>();
        }
        public void AddKalb(Kalb kalb)
        {
            Kaelber.Add(kalb);
            SaveToFile();
        }

        public void SetKaelber(List<Kalb> newList)
        {
            Kaelber = newList;
            SaveToFile();
        }

        public List<Kalb> GetAllKaelber()
        {
            Kaelber.Clear();

            if (!File.Exists("Kaelber.txt"))
            {
                File.Create("Kaelber.txt").Close();
                return Kaelber;
            }

            string[] lines = File.ReadAllLines("Kaelber.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 15)
                {
                    Kaelber.Add(new Kalb
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
                        ZuKlein = bool.Parse(parts[14])
                    });
                }
            }

            return Kaelber;
        }

        public void SaveToFile()
        {
            List<string> output = new List<string>();
            foreach (Kalb kalb in Kaelber)
            {
                string line = $"{kalb.Lebensnummer};{kalb.Name};{kalb.Geschlecht};{kalb.Groeße};{kalb.MutterNr};{kalb.Geburtsdatum};{kalb.Eisen};{kalb.Selene};{kalb.Impfungen};{kalb.Hornlos};{kalb.Enthornt};{kalb.AlterStall};{kalb.Krankheiten};{kalb.Notiz};{kalb.ZuKlein}";
                output.Add(line);
            }
            File.WriteAllLines("Kaelber.txt", output);
        }
    }
}
