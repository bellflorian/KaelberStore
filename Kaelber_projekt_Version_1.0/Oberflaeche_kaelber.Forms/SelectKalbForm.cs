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
    public partial class SelectKalbForm : Form
    {
        public IKalbStore store = new TxtFileStore();
        public Kalb ausgewaehltesKalb;
        public List<Kalb> kaelber;
        public SelectKalbForm()
        {
            InitializeComponent();
            kaelber = store.GetAllKaelber();
            foreach(Kalb kalb in kaelber)
                kalb.CalculateFields();
            cobxKaelberListe.DataSource = kaelber;
            cobxKaelberListe.DisplayMember = "Lebensnummer";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ausgewaehltesKalb = cobxKaelberListe.SelectedItem as Kalb;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
