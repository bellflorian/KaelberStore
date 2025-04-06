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
                Location = new Point(70, 8) // <<--- Feinposition (X, Y) anpassen wie du willst
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
                if (ausgewählt != null)
                    SetKalb(ausgewählt);
            }
        }

        public void SetKalb(Kalb kalb)
        {
            aktuellesKalb = kalb;

            // Entferne nur die bestehenden Labels (das Plus wird eh ersetzt)
            this.Controls.Clear();

            // Lebensnummer-Label
            var lebensnummerLabel = new Label
            {
                Text = kalb.Lebensnummer.ToString(),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(60, 30) // <<< Außenbereich, oben
            };

            // Milch-Label
            var milchLabel = new Label
            {
                Text = $"Milch: {kalb.Milch}",
                AutoSize = true,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(60, 45) // <<< Außenbereich, darunter
            };

            this.Controls.Add(lebensnummerLabel);
            this.Controls.Add(milchLabel);
        }
    }
}
