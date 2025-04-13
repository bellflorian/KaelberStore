using Kaelber_projekt.Class;

namespace Oberflaeche_kaelber.Forms
{
    public class KaelberboxVertikal : Kaelberbox
    {
        public KaelberboxVertikal()
        {
            this.Size = new Size(100, 150); // Hochformat
            this.BackgroundImage = Properties.Resources.KaelberBoxPlusV3; // Optional: gedrehtes Plus-Bild
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.BackColor = Color.Beige;
        }

        public override void SetKalb(Kalb kalb)
        {
            aktuellesKalb = kalb;
            this.Controls.Clear();

            if (kalb == null)
            {
                this.BackgroundImage = Properties.Resources.KaelberBoxPlusV3;
                this.BackColor = Color.Beige;
                return;
            }

            this.BackgroundImage = null;

            var lebensnummerLabel = new RotatedLabel
            {
                RotatedText = kalb.Lebensnummer.ToString(),
                RotatedFont = new Font("Segoe UI", 13, FontStyle.Bold),
                Size = new Size(25, 100), // ⬅️ umgedreht!
                Location = new Point(25, 20),
                Cursor = Cursors.Hand
            };

            var milchLabel = new RotatedLabel
            {
                RotatedText = $"Milch: {kalb.Milch}",
                RotatedFont = new Font("Segoe UI", 13, FontStyle.Regular),
                Size = new Size(25, 100),
                Location = new Point(46, 20),
                Cursor = Cursors.Hand
            };

            // Klick & Hover übernehmen
            lebensnummerLabel.Click += (s, e) => ÖffneKalbAuswahl();
            milchLabel.Click += (s, e) => ÖffneKalbAuswahl();
            lebensnummerLabel.MouseEnter += Kaelberbox_MouseEnter;
            lebensnummerLabel.MouseLeave += Kaelberbox_MouseLeave;
            milchLabel.MouseEnter += Kaelberbox_MouseEnter;
            milchLabel.MouseLeave += Kaelberbox_MouseLeave;

            this.Controls.Add(lebensnummerLabel);
            this.Controls.Add(milchLabel);
        }
    }
}
