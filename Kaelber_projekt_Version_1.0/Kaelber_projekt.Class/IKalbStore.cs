using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaelber_projekt.Class
{
    public interface IKalbStore
    {
        public void AddKalb (Kalb kalb);
        public List<Kalb> GetAllKaelber();
        public void SaveToFile();
        public void SetKaelber(List<Kalb> newList);
        public Kalb GetKalb(int lebensnummer);
    }
}
