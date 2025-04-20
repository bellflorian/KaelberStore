using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kaelber_projekt.Class
{
    public static class Util
    {
        public static (DateTime Datum, bool IstExakterVollmond) NextFullMoon(DateTime datum)
        {
            // Referenzvollmond: 25.03.2024, 08:00 UTC
            DateTime referenzVollmond = new DateTime(2024, 3, 25, 8, 0, 0, DateTimeKind.Utc);
            double mondzyklusTage = 29.530588853;

            // Datum in UTC zum Rechnen
            DateTime datumUtc = datum.ToUniversalTime();

            // Berechne, wie viele Mondzyklen seit dem Referenzvollmond vergangen sind
            double tageSeitReferenz = (datumUtc - referenzVollmond).TotalDays;
            double vergangeneZyklen = Math.Floor(tageSeitReferenz / mondzyklusTage);

            // Letzter & nächster Vollmond bestimmen
            DateTime letzterVollmondUtc = referenzVollmond.AddDays(vergangeneZyklen * mondzyklusTage);
            DateTime naechsterVollmondUtc = referenzVollmond.AddDays((vergangeneZyklen + 1) * mondzyklusTage);

            double stundenDifferenz = Math.Abs((datumUtc - letzterVollmondUtc).TotalHours);
            double tageSeitLetztemVollmond = (datumUtc - letzterVollmondUtc).TotalDays;

            // 1. Genau ±12h beim Vollmond => gib das Datum zurück und markiere es als exakter Vollmond
            if (stundenDifferenz <= 12)
                return (datum, true);

            // 2. Letzter Vollmond liegt in den letzten 7 Tagen => gib das Datum zurück und markiere es als nicht exakter Vollmond
            if (tageSeitLetztemVollmond > 0 && tageSeitLetztemVollmond <= 7)
                return (datum, false);

            // 3. Andernfalls gib den nächsten Vollmond zurück und markiere es als exakter Vollmond
            return (naechsterVollmondUtc.ToLocalTime(), true);
        }
    }
}
