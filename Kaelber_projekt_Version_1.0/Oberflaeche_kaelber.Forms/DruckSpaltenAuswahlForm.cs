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
    public partial class DruckSpaltenAuswahlForm : Form
    {
        public List<string> AusgewaehlteFelder = new();
        public DruckSpaltenAuswahlForm()
        {
            InitializeComponent();

            var props = typeof(Kalb).GetProperties()
           .Where(p => p.CanRead && p.GetMethod.IsPublic)
           .Select(p => p.Name)
           .ToList();

            foreach (var name in props)
            {
                clbColumnsSelect.Items.Add(name, false); // standardmäßig alles ausgewählt
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (var item in clbColumnsSelect.CheckedItems)
            {
                AusgewaehlteFelder.Add(item.ToString());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
