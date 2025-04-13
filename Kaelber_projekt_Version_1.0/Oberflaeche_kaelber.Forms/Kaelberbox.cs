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
        public Kalb aktuellesKalb;

        public Kaelberbox()
        {
            InitializeComponent();

            this.Size = new Size(150, 100);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
            this.BackgroundImage = Properties.Resources.KaelberBoxPlusV3;
            this.BackgroundImageLayout = ImageLayout.Zoom;

            // Klick auf ganze Box
            this.Click += (s, e) => ÖffneKalbAuswahl();
            this.MouseEnter += Kaelberbox_MouseEnter;
            this.MouseLeave += Kaelberbox_MouseLeave;
        }

        public void ÖffneKalbAuswahl()
        {
            var auswahlFenster = new SelectKalbForm();
            if (auswahlFenster.ShowDialog() == DialogResult.OK)
            {
                SetKalb(auswahlFenster.ausgewaehltesKalb); // auch bei null resetten
            }
        }

        public virtual void SetKalb(Kalb kalb)
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

            var lebensnummerLabel = new Label
            {
                Text = kalb.Lebensnummer.ToString(),
                AutoSize = true,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(20, 25),
                Cursor = Cursors.Hand
            };

            var milchLabel = new Label
            {
                Text = $"Milch: {kalb.Milch}",
                AutoSize = true,
                Font = new Font("Segoe UI", 13),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(20, 46),
                Cursor = Cursors.Hand
            };

            // Events für Labels
            lebensnummerLabel.Click += (s, e) => ÖffneKalbAuswahl();
            milchLabel.Click += (s, e) => ÖffneKalbAuswahl();
            lebensnummerLabel.MouseEnter += Kaelberbox_MouseEnter;
            lebensnummerLabel.MouseLeave += Kaelberbox_MouseLeave;
            milchLabel.MouseEnter += Kaelberbox_MouseEnter;
            milchLabel.MouseLeave += Kaelberbox_MouseLeave;

            this.Controls.Add(lebensnummerLabel);
            this.Controls.Add(milchLabel);
        }

        public void Kaelberbox_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Gainsboro;
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        public void Kaelberbox_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Beige;
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
