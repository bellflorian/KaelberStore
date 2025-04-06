using Kaelber_projekt.Class;
using System.Windows.Forms;
namespace Oberflaeche_kaelber.Forms
{
    public partial class DatenKaelberForm : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private IKalbStore store = new TxtFileStore();
        private List<Kalb> kaelber;

        public DatenKaelberForm()
        {
            InitializeComponent();
            LoadData();
            StyleDataGridView(dgvDatenKaelber);
            StyleDataGridView(dgvDatenKaelber2);
        }

        private void LoadData()
        {
            //store.AddKalb(new Kalb(2345, "Kritzi", 'm', "Mittel 40kg", 32, DateTime.Now.AddDays(-10), false, false, false, false, " "));
            //store.AddKalb(new Kalb(3456, "Erwin", 'm', "Mittel 40kg", 34, DateTime.Now.AddDays(-30), false, false, false, false, " "));
            //store.AddKalb(new Kalb(3245, "Kira", 'w', "Mittel 40kg", 54, DateTime.Now, false, false, false, false, " "));


            kaelber = store.GetAllKaelber();
            RecalculateKaelber();
            bindingSource1.DataSource = kaelber;
            dgvDatenKaelber.DataSource = bindingSource1;
            dgvDatenKaelber2.DataSource = bindingSource1;


            // Ausblenden auf dem ersten Tab
            bool temp = false;
            for (int i = 0; i < dgvDatenKaelber.ColumnCount; i++)
            {
                if (dgvDatenKaelber.Columns[i].HeaderText == "Milch")
                    temp = true;

                if (temp)
                    dgvDatenKaelber.Columns[i].Visible = false;
            }
            if (!dgvDatenKaelber.Columns.Contains("Löschen"))
            {
                DataGridViewTextBoxColumn deleteColumn = new DataGridViewTextBoxColumn();
                deleteColumn.Name = "Löschen";
                deleteColumn.HeaderText = "";
                deleteColumn.Width = 40;
                deleteColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                deleteColumn.DefaultCellStyle.NullValue = "🗑️"; // Das hier zeigt das Emoji an
                dgvDatenKaelber.Columns.Add(deleteColumn);
            }

            // Ausblenden auf dem zweiten Tab
            for (int i = 0; i < dgvDatenKaelber2.ColumnCount; i++)
            {
                if (dgvDatenKaelber2.Columns[i].HeaderText == "Milch")
                    temp = false;

                if (temp)
                    dgvDatenKaelber2.Columns[i].Visible = false;

                else
                    dgvDatenKaelber2.Columns[i].ReadOnly = true;

                if (dgvDatenKaelber2.Columns[i].HeaderText == "Lebensnummer")
                {
                    dgvDatenKaelber2.Columns[i].Visible = true;
                    dgvDatenKaelber2.Columns[i].ReadOnly = true;
                }

                if (dgvDatenKaelber2.Columns[i].HeaderText == "Durchfall + Datum" || dgvDatenKaelber2.Columns[i].HeaderText == "Notiz")
                    dgvDatenKaelber2.Columns[i].ReadOnly = false;
            }
        }

        private void btnAddKealber_Click(object sender, EventArgs e)
        {
            using (AddKalbForm addKalbForm = new AddKalbForm())
            {
                if (addKalbForm.ShowDialog() == DialogResult.OK)
                {
                    store.AddKalb(new Kalb(addKalbForm.Lebensnummer, addKalbForm.Name, addKalbForm.Geschlecht, addKalbForm.Groeße, addKalbForm.MutterNummer, addKalbForm.Geburtsdatum, addKalbForm.Eisen, addKalbForm.Selene, addKalbForm.Impfungen, addKalbForm.Hornlos, addKalbForm.Krankheiten));
                }
            }
            bindingSource1.ResetBindings(false);
        }

        private void dgvDatenKaelber_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            RecalculateKaelber();
            store.SaveToFile();
        }

        private void dgvDatenKaelber2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RecalculateKaelber();
            store.SaveToFile(); 
        }

        private void RecalculateKaelber()
        {
            foreach (Kalb k in kaelber)
            {
                k.CalculateFields();
            }
        }

        private void dgvDatenKaelber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Prüfen, ob die Klickposition gültig ist
            if (e.RowIndex >= 0 && dgvDatenKaelber.Columns[e.ColumnIndex].Name == "Löschen")
            {
                // Sicherheitsabfrage (optional)
                var result = MessageBox.Show("Dieses Kalb wirklich löschen?", "Bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Datensatz aus der Datenquelle entfernen
                    var kalb = dgvDatenKaelber.Rows[e.RowIndex].DataBoundItem as Kalb;
                    if (kalb != null)
                    {
                        bindingSource1.Remove(kalb);
                        store.SaveToFile();
                    }
                }
            }
        }

        private void btnMilchmenge_Click_1(object sender, EventArgs e)
        {
            List<string> milchmenge = kaelber.Select(k => k.Milch).ToList();
            double milchmengeSum = 0;
            for (int i = 0; i < milchmenge.Count; i++)
            {
                string currentmilchmenge = milchmenge[i];
                if (currentmilchmenge.Contains(';'))
                    continue;
                if (currentmilchmenge == "Abgespannt" || currentmilchmenge == "Fehler Abgespannt?" || currentmilchmenge == "-")
                    continue;

                milchmengeSum += Convert.ToDouble(currentmilchmenge.Split('L')[0]);
            }
            MessageBox.Show($"Die gesamte Milchmenge beträgt: {milchmengeSum}L", "Berechnung Milchmenge", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.Black; // Dünne schwarze Linien um Zellen

            // Header-Design
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Verhindern, dass der Header blau markiert wird
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.DarkGray;  // Header bleibt in der normalen Hintergrundfarbe

            // Zellen-Design
            dgv.DefaultCellStyle.BackColor = Color.LightGray;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Padding = new Padding(5);

            // Zellengröße & Layout
            dgv.RowTemplate.Height = 35;
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns["Geburtsdatum"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgv.Columns["Abspanndatum"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgv.MultiSelect = false;

            // **Schwarze Rahmen um Zellen**
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.RowHeadersVisible = false;

            dgv.AllowUserToAddRows = false;
        }
    }
}
