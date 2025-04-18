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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Oberflaeche_kaelber.Forms
{
    public partial class Kaelberbox : UserControl
    {
        private Kalb aktuellesKalb;
        public Kalb AktuellerKalb => aktuellesKalb;
        public string BoxId;

        public Kaelberbox()
        {
            InitializeComponent();

            this.Size = new Size(150, 100);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackgroundImage = Properties.Resources.KaelberboxV1;
            this.BackgroundImageLayout = ImageLayout.Zoom;

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
                Location = new Point(70, 5)
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
                    Location = new Point((this.Width - 60) / 2, (this.Height - 70) / 2)
                };

                plusLabel.Click += (s, e) => ÖffneKalbAuswahl();
                this.Controls.Add(plusLabel);
                return;
            }

            this.BackgroundImage = Properties.Resources.KaelberboxV1;

            var lebensnummerLabel = new Label
            {
                Text = kalb.Lebensnummer.ToString(),
                AutoSize = true,
                Font = new Font("ADLaM Display", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(70, 20),
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
                    ? new Point(56, 50)
                    : new Point(58, 40),
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
