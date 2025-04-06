using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oberflaeche_kaelber.Forms
{
    public partial class AddKalbForm : Form
    {
        public int Lebensnummer = 0;
        public int MutterNummer = 0;
        public string Name = string.Empty;
        public string Groeße = string.Empty;
        public char Geschlecht = ' ';
        public DateTime Geburtsdatum = DateTime.Now;
        public bool Eisen = false;
        public bool Selene = false;
        public bool Impfungen = false;
        public bool Hornlos = false;
        public string Krankheiten = string.Empty;   

        public AddKalbForm()
        {
            InitializeComponent();
            this.Load += AddKalbForm_Load;
            //DesignAddCalfForm()
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //Lebensnummer 4 stellig
            if (!int.TryParse(tbxLebensnummer.Text, out int temp1))
            {
                lblError.Text = "Lebensnummer muss eine Zahl sein!";
                return;
            }
            if (tbxLebensnummer.Text.Length != 4)
            {
                lblError.Text = "Lebensnummer muss 4 Ziffer lang sein!";
                return;
            }
            Lebensnummer = Convert.ToInt32(tbxLebensnummer.Text);

            // Mutternummer
            if (!int.TryParse(tbxMutterNummer.Text, out int temp))
            {
                lblError.Text = "Mutternummer muss eine Zahl sein!";
                return;
            }
            if (tbxMutterNummer.Text.Length != 2)
            {
                lblError.Text = "Mutternummer muss 2 Ziffer lang sein!";
                return;
            }
            MutterNummer = Convert.ToInt32(tbxMutterNummer.Text);

            // Name
            if (tbxName.Text == String.Empty)
            {
                lblError.Text = "Gib einen Namen an!";
                return;
            }
            Name = tbxName.Text;

            // Geschlecht
            if (tbxGeschlecht.Text.Length != 1 || tbxGeschlecht.Text[0] != 'w' && tbxGeschlecht.Text[0] != 'm')
            {
                lblError.Text = "Geschlecht muss entweder 'm' oder 'w' sein!";
                return;
            }
            Geschlecht = tbxGeschlecht.Text[0];

            // Geburtsdatum
            if (dtPDatum.Value > DateTime.Now)
            {
                lblError.Text = "Geburtsdatum darf nicht in der Zukunft sein!";
                return;
            }
            Geburtsdatum = dtPDatum.Value;
            // Combo Box
            if (cbxGroeße.SelectedItem == null)
            {
                lblError.Text = "Bitte eine Größe auswählen!";
                return;
            }
            Groeße = cbxGroeße.SelectedItem.ToString();

            // Checkboxen
            Eisen = cbxEisen.Checked;
            Selene = cbxSelene.Checked;
            Impfungen = cbxImpfungen.Checked;
            Hornlos = cbxHornlos.Checked;


            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void AddKalbForm_Load(object sender, EventArgs e)
        {
            cbxGroeße.Items.Add("Klein 35kg");
            cbxGroeße.Items.Add("Mittel 40kg");
            cbxGroeße.Items.Add("Groß 45kg");

            cbxGroeße.SelectedIndex = 1; // Standardauswahl
        }
        private void cbxGroeße_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
