using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaelber_projekt.Class
{
    public class StaticKaelberStore : IKalbStore
    {
        public List<Kalb> Kaelber {  get; set; }
        public void AddKalb(Kalb kalb)
        {
            Kaelber.Add(kalb);
        }

        public List<Kalb> GetAllKaelber()
        {
            return Kaelber;
        }

        public void SaveToFile()
        {

        }

        public void SetKaelber(List<Kalb> newList)
        {
            
        }

        public Kalb GetKalb(int lebensnummer)
        {
            return null;
        }

        public StaticKaelberStore()
        {
            Kaelber = new List<Kalb>();
        }
    }
}
