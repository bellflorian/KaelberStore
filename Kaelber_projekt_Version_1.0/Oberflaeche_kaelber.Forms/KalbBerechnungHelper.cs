using Kaelber_projekt.Class;
using System.Collections.Generic;

namespace Oberflaeche_kaelber.Forms
{
    internal static class KalbBerechnungHelper
    {
        internal static void Calculate(Kalb kalb)
        {
            kalb.CalculateFields(
                // Klein
                Properties.Settings.Default.PKleinMilch1, Properties.Settings.Default.PKleinMilch2,
                Properties.Settings.Default.PKleinMilch3, Properties.Settings.Default.PKleinMilch4,
                Properties.Settings.Default.PKleinMilch5, Properties.Settings.Default.PKleinMilch6,
                Properties.Settings.Default.PKleinMilch7, Properties.Settings.Default.PKleinMilch8,
                Properties.Settings.Default.PKleinMilch9, Properties.Settings.Default.PKleinMilch10,
                Properties.Settings.Default.PKleinMilch11, Properties.Settings.Default.PKleinMilch12,
                Properties.Settings.Default.PKleinMilch13, Properties.Settings.Default.PKleinMilch14,
                Properties.Settings.Default.PKleinMilch15, Properties.Settings.Default.PKleinKaelberstarter,
                Properties.Settings.Default.PKleinHeu, Properties.Settings.Default.PKleinWasser,
                Properties.Settings.Default.PKleinSilofutter,
                // Mittel
                Properties.Settings.Default.PMittelMilch1, Properties.Settings.Default.PMittelMilch2,
                Properties.Settings.Default.PMittelMilch3, Properties.Settings.Default.PMittelMilch4,
                Properties.Settings.Default.PMittelMilch5, Properties.Settings.Default.PMittelMilch6,
                Properties.Settings.Default.PMittelMilch7, Properties.Settings.Default.PMittelMilch8,
                Properties.Settings.Default.PMittelMilch9, Properties.Settings.Default.PMittelMilch10,
                Properties.Settings.Default.PMittelMilch11, Properties.Settings.Default.PMittelMilch12,
                Properties.Settings.Default.PMittelMilch13, Properties.Settings.Default.PMittelMilch14,
                Properties.Settings.Default.PMittelMilch15, Properties.Settings.Default.PMittelKaelberstarter,
                Properties.Settings.Default.PMittelHeu, Properties.Settings.Default.PMittelWasser,
                Properties.Settings.Default.PMittelSilofutter,
                // Gross
                Properties.Settings.Default.PGrossMilch1, Properties.Settings.Default.PGrossMilch2,
                Properties.Settings.Default.PGrossMilch3, Properties.Settings.Default.PGrossMilch4,
                Properties.Settings.Default.PGrossMilch5, Properties.Settings.Default.PGrossMilch6,
                Properties.Settings.Default.PGrossMilch7, Properties.Settings.Default.PGrossMilch8,
                Properties.Settings.Default.PGrossMilch9, Properties.Settings.Default.PGrossMilch10,
                Properties.Settings.Default.PGrossMilch11, Properties.Settings.Default.PGrossMilch12,
                Properties.Settings.Default.PGrossMilch13, Properties.Settings.Default.PGrossMilch14,
                Properties.Settings.Default.PGrossMilch15, Properties.Settings.Default.PGrossKaelberstarter,
                Properties.Settings.Default.PGrossHeu, Properties.Settings.Default.PGrossWasser,
                Properties.Settings.Default.PGrossSilofutter,
                // Milchmast
                Properties.Settings.Default.PMilchmast1, Properties.Settings.Default.PMilchmast2,
                Properties.Settings.Default.PMilchmast3, Properties.Settings.Default.PMilchmast4,
                Properties.Settings.Default.PMilchmast5, Properties.Settings.Default.PMilchmast6,
                Properties.Settings.Default.PMilchmast7, Properties.Settings.Default.PMilchmast8,
                Properties.Settings.Default.PMilchmast9, Properties.Settings.Default.PMilchmast10,
                Properties.Settings.Default.PMilchmast11, Properties.Settings.Default.PMilchmast12
            );
        }

        internal static void CalculateAll(IEnumerable<Kalb> kaelber)
        {
            foreach (Kalb kalb in kaelber)
                Calculate(kalb);
        }
    }
}
