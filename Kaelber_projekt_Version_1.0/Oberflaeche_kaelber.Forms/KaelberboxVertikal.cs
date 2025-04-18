using Kaelber_projekt.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oberflaeche_kaelber.Forms
{
    public partial class KaelberboxVertikal : UserControl
    {
        private Kalb aktuellesKalb;
        public Kalb AktuellerKalb => aktuellesKalb;
        public string BoxId;

        public KaelberboxVertikal()
        {
            InitializeComponent();

            this.Size = new Size(100, 150);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackgroundImage = Properties.Resources.KaelberBoxVertikal2;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.BackColor = Color.Beige;

            // ➕-Label
            var plusLabel = new Label
            {
                Text = "+",
                Size = new Size(60, 70),
                Font = new Font("Segoe UI", 45, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                Location = new Point(20, 50)
            };

            plusLabel.Click += (s, e) => ÖffneKalbAuswahl();
            this.Controls.Add(plusLabel);
        }

        private void ÖffneKalbAuswahl()
        {
            var auswahlFenster = new SelectKalbForm();
            if (auswahlFenster.ShowDialog() == DialogResult.OK)
            {
                Kalb ausgewählt = auswahlFenster.ausgewaehltesKalb;
                SetKalb(ausgewählt);
            }
        }

        public void SetKalb(Kalb kalb)
        {
            aktuellesKalb = kalb;
            this.Controls.Clear();

            if (kalb == null)
            {
                var plusLabel = new Label
                {
                    Text = "+",
                    Size = new Size(60, 70),
                    Font = new Font("Segoe UI", 45, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    Location = new Point(35, 20)
                };

                plusLabel.Click += (s, e) => ÖffneKalbAuswahl();
                this.Controls.Add(plusLabel);
                return;
            }

            this.BackgroundImage = Properties.Resources.KaelberBoxVertikal2;

            var lebensnummerLabel = new Label
            {
                Text = kalb.Lebensnummer.ToString(),
                AutoSize = true,
                Font = new Font("ADLaM Display", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(20, 65),
                Cursor = Cursors.Hand
            };

            var milchLabel = new Label
            {
                Text = kalb.Milch,
                AutoSize = true,
                Font = kalb.Milch == "Abgespannt"
                    ? new Font("ADLaM Display", 9, FontStyle.Bold)
                    : new Font("ADLaM Display", 25, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = kalb.Milch == "Abgespannt"
                    ? new Point(7, 100)
                    : new Point(6, 90),
                Cursor = Cursors.Hand
            };

            // Events hinzufügen, damit auch Labels klickbar bleiben
            lebensnummerLabel.Click += (s, e) => ÖffneKalbAuswahl();
            milchLabel.Click += (s, e) => ÖffneKalbAuswahl();

            // Falls das UserControl selbst nicht mehr reagiert, nochmal sichern:
            this.Click += (s, e) => ÖffneKalbAuswahl();

            this.Controls.Add(lebensnummerLabel);
            this.Controls.Add(milchLabel);
        }
    }
}

