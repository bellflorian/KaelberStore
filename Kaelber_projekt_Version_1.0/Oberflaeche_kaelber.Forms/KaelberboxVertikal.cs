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
        public event EventHandler<Kalb> KalbZugewiesen;
        private Kalb aktuellesKalb;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Kalb AktuellerKalb
        {
            get => aktuellesKalb;
            set => SetKalb(value);
        }

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
                    Location = new Point(20, 50)
                };

                plusLabel.Click += (s, e) => ÖffneKalbAuswahl();
                this.Controls.Add(plusLabel);
                KalbZugewiesen?.Invoke(this, kalb);
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

            var AlterLabel = new Label
            {
                Text = (kalb.Alter / 7.0).ToString("F1"),
                AutoSize = true,
                Font = new Font("ADLaM Display", 8, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(65, 10),
                Cursor = Cursors.Hand
            };
            this.Controls.Add(AlterLabel);
            // "W" direkt unter der Wochenzahl
            var wochenEinheitLabel = new Label
            {
                Text = "W",
                AutoSize = true,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                // X-Position: mittig unter der Zahl
                Location = new Point(
                  AlterLabel.Location.X + AlterLabel.PreferredWidth / 2 - 4, // -4 für optische Zentrierung
                     AlterLabel.Location.Y + AlterLabel.Height + 2
                ),
                Cursor = Cursors.Hand
            };
            this.Controls.Add(wochenEinheitLabel);

            var milchLabel = new Label
            {
                Text = kalb.Milch == "Milchmast fertig"
                    ? "Milchmast\nfertig"
                    : kalb.Milch,
                AutoSize = false,
                Size = new Size(80, 30), // ggf. anpassen
                Font = (kalb.Milch == "Abgespannt" || kalb.Milch == "Milchmast fertig")
                    ? new Font("ADLaM Display", 8, FontStyle.Bold)
                    : kalb.Milch.Contains(";")
                        ? new Font("ADLaM Display", 18, FontStyle.Bold)
                        : new Font("ADLaM Display", 25, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = (kalb.Milch == "Abgespannt" || kalb.Milch == "Milchmast fertig")
                    ? new Point(7, 100)
                    : new Point(6, 90),
                TextAlign = ContentAlignment.TopCenter,
                Cursor = Cursors.Hand
            };

            // Events hinzufügen, damit auch Labels klickbar bleiben
            lebensnummerLabel.Click += (s, e) => ÖffneKalbAuswahl();
            milchLabel.Click += (s, e) => ÖffneKalbAuswahl();

            // Falls das UserControl selbst nicht mehr reagiert, nochmal sichern:
            this.Click += (s, e) => ÖffneKalbAuswahl();

            this.Controls.Add(lebensnummerLabel);
            this.Controls.Add(milchLabel);

            if (kalb.Wasser)
            {
                var wasserLabel = new Label
                {
                    Text = "W",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.DodgerBlue,
                    BackColor = Color.Transparent,
                    Location = new Point(10, 27), // Position nach Wunsch anpassen
                    Cursor = Cursors.Hand
                };
                wasserLabel.Click += (s, e) => ÖffneKalbAuswahl();
                this.Controls.Add(wasserLabel);
            }
            if (kalb.Silofutter)
            {
                var wasserLabel = new Label
                {
                    Text = "S",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Brown,
                    BackColor = Color.Transparent,
                    Location = new Point(32, 27), // Position nach Wunsch anpassen
                    Cursor = Cursors.Hand
                };
                wasserLabel.Click += (s, e) => ÖffneKalbAuswahl();
                this.Controls.Add(wasserLabel);
            }
            if (kalb.Heu)
            {
                var wasserLabel = new Label
                {
                    Text = "H",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Green,
                    BackColor = Color.Transparent,
                    Location = new Point(10, 7), // Position nach Wunsch anpassen
                    Cursor = Cursors.Hand
                };
                wasserLabel.Click += (s, e) => ÖffneKalbAuswahl();
                this.Controls.Add(wasserLabel);
            }
            if (kalb.Kaelberstarter)
            {
                var wasserLabel = new Label
                {
                    Text = "K",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Location = new Point(32, 7), // Position nach Wunsch anpassen
                    Cursor = Cursors.Hand
                };
                wasserLabel.Click += (s, e) => ÖffneKalbAuswahl();
                this.Controls.Add(wasserLabel);
            }
            KalbZugewiesen?.Invoke(this, kalb);
        }
    }
}

