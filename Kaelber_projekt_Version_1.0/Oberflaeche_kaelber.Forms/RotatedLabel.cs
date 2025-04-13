using System.Drawing.Text;

namespace Oberflaeche_kaelber.Forms
{
    public class RotatedLabel : Control
    {
        public string RotatedText = "";

        public Font RotatedFont = new Font("Segoe UI", 13, FontStyle.Regular);
        public Brush RotatedBrush = Brushes.Black;

        public RotatedLabel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Ursprung verschieben nach links unten
            e.Graphics.TranslateTransform(0, this.Height);
            e.Graphics.RotateTransform(-90); // 90° gegen Uhrzeigersinn

            e.Graphics.DrawString(RotatedText, RotatedFont, RotatedBrush, 0, 0);

            // Rücksetzen, um zukünftige Zeichnungen nicht zu beeinflussen
            e.Graphics.ResetTransform();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Neu zeichnen bei Größenänderung
        }
    }

}
