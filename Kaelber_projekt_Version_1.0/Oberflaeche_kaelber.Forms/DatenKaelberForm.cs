using Kaelber_projekt.Class;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO.Ports;
namespace Oberflaeche_kaelber.Forms
{
    public partial class DatenKaelberForm : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private TxtFileStore fileStore = new TxtFileStore();
        private IKalbStore store;
        private IKaelberboxStore boxStore;
        private List<Kalb> kaelber;
        private BindingSource bindingSourceAlleKaelber = new BindingSource();
        private IKalbStore alleStore = new AlleKaelberStore();

        public DatenKaelberForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            fileStore = new TxtFileStore();
            store = fileStore;
            boxStore = fileStore;
            arduinoTimer = new System.Windows.Forms.Timer();
            arduinoTimer.Interval = 2000; // alle 2 Sekunden
            arduinoTimer.Tick += ArduinoTimer_Tick;
            arduinoTimer.Start();
            LoadData();
            dgvDatenKaelber.DataError += DgvDatenKaelber_DataError;
            dgvDatenKaelber2.DataError += DgvDatenKaelber_DataError;
            StyleDataGridView(dgvDatenKaelber);
            StyleDataGridView(dgvDatenKaelber2);
            dgvAlleKaelber.CellClick += DgvAlleKaelber_CellClick;
        }

        private void LoadData()
        {
            bindingSource1.ListChanged += BindingSource1_ListChanged;

            kaelber = store.GetAllKaelber();
            RecalculateKaelber();
            var sortierbareListe = new SortableBindingList<Kalb>(kaelber);
            bindingSource1.DataSource = sortierbareListe;
            dgvDatenKaelber.DataSource = bindingSource1;
            dgvDatenKaelber2.DataSource = bindingSource1;
            // Spalte "IstExakterVollmond" ausblenden
            if (dgvDatenKaelber.Columns.Contains("IstExakterVollmond"))
            {
                dgvDatenKaelber.Columns["IstExakterVollmond"].Visible = false;
            }

            if (dgvDatenKaelber2.Columns.Contains("IstExakterVollmond"))
            {
                dgvDatenKaelber2.Columns["IstExakterVollmond"].Visible = false;
            }

            dgvDatenKaelber.AllowDrop = true;

            LoadKaelberBoxes();
            LoadAlleKaelber();
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
            if (!dgvDatenKaelber.Columns.Contains("Verschieben"))
            {
                DataGridViewTextBoxColumn transferColumn = new DataGridViewTextBoxColumn();
                transferColumn.Name = "Verschieben";
                transferColumn.HeaderText = "";
                transferColumn.Width = 40;
                transferColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                transferColumn.DefaultCellStyle.NullValue = "➥"; // Das hier zeigt das Emoji an
                dgvDatenKaelber.Columns.Add(transferColumn);
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

                if (dgvDatenKaelber2.Columns[i].HeaderText == "Durchfall + Datum" || dgvDatenKaelber2.Columns[i].HeaderText == "Notiz" || dgvDatenKaelber2.Columns[i].HeaderText == "Alter Stall" || dgvDatenKaelber2.Columns[i].HeaderText == "zu klein zum Abspannen")
                    dgvDatenKaelber2.Columns[i].ReadOnly = false;
            }
        }

        private void LoadAlleKaelber()
        {
            var alleKaelberListe = alleStore.GetAllKaelber();
            // Berechnete Felder für jedes Kalb aktualisieren
            foreach (var kalb in alleKaelberListe)
            {
                kalb.CalculateFields();
            }

            var sortierbareListe = new SortableBindingList<Kalb>(alleKaelberListe);
            bindingSourceAlleKaelber.DataSource = sortierbareListe;
            dgvAlleKaelber.DataSource = bindingSourceAlleKaelber;

            StyleDataGridView(dgvAlleKaelber);

            // "Löschen"-Button-Spalte nur einmal hinzufügen
            if (!dgvAlleKaelber.Columns.Contains("Loeschen"))
            {
                DataGridViewTextBoxColumn deleteColumn = new DataGridViewTextBoxColumn();
                deleteColumn.Name = "Loeschen";
                deleteColumn.HeaderText = "";
                deleteColumn.Width = 40;
                deleteColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                deleteColumn.DefaultCellStyle.NullValue = "🗑️";
                dgvAlleKaelber.Columns.Add(deleteColumn);
            }
            // "Zurück"-Button-Spalte nur einmal hinzufügen

            if (!dgvAlleKaelber.Columns.Contains("Zurueck"))
            {
                DataGridViewTextBoxColumn backColumn = new DataGridViewTextBoxColumn();
                backColumn.Name = "Zurueck";
                backColumn.HeaderText = "";
                backColumn.Width = 40;
                backColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                backColumn.DefaultCellStyle.NullValue = "⮌"; // Symbol für zurück
                dgvAlleKaelber.Columns.Add(backColumn);
            }

            // Alle Spalten auf ReadOnly, außer "Loeschen" und "Zurueck"
            foreach (DataGridViewColumn col in dgvAlleKaelber.Columns)
            {
                if (col.Name != "Loeschen" && col.Name != "Zurueck")
                    col.ReadOnly = true;
                else
                    col.ReadOnly = false;
            }

            StyleDataGridView(dgvAlleKaelber);
            if (dgvAlleKaelber.Columns.Contains("IstExakterVollmond"))
                dgvAlleKaelber.Columns["IstExakterVollmond"].Visible = false;
            if (dgvAlleKaelber.Columns.Contains("Milch"))
                dgvAlleKaelber.Columns["Milch"].Visible = false;
            if (dgvAlleKaelber.Columns.Contains("Krankheiten"))
                dgvAlleKaelber.Columns["Krankheiten"].Visible = false;
            if (dgvAlleKaelber.Columns.Contains("AlterStall"))
                dgvAlleKaelber.Columns["AlterStall"].Visible = false;
            if (dgvAlleKaelber.Columns.Contains("Kaelberstarter"))
                dgvAlleKaelber.Columns["Kaelberstarter"].Visible = false;
            if (dgvAlleKaelber.Columns.Contains("Heu"))
                dgvAlleKaelber.Columns["Heu"].Visible = false;
            if (dgvAlleKaelber.Columns.Contains("Wasser"))
                dgvAlleKaelber.Columns["Wasser"].Visible = false;
            if (dgvAlleKaelber.Columns.Contains("Silofutter"))
                dgvAlleKaelber.Columns["Silofutter"].Visible = false;
            if (dgvAlleKaelber.Columns.Contains("Alter"))
                dgvAlleKaelber.Columns["Alter"].Visible = false;
        }

        private void LoadKaelberBoxes()
        {
            List<string> names = new List<string>();
            foreach (var ctrl in AlleControls(this))
            {
                if (ctrl is Kaelberbox box)
                {
                    names.Add(box.Name);
                    box.KalbZugewiesen += Box_KalbZugewiesen;
                }

                else if (ctrl is KaelberboxVertikal boxVertical)
                {
                    names.Add(boxVertical.Name);
                    boxVertical.KalbZugewiesen += Box_KalbZugewiesen;
                }
            }

            if (!System.IO.File.Exists("Boxes.txt"))
                boxStore.GenerateBoxTxtFile(names);

            foreach (var ctrl in AlleControls(this))
            {
                if (ctrl is Kaelberbox box)
                {
                    Kaelber_projekt.Class.Kaelberbox tempBox = boxStore.GetKaelberBoxById(box.Name);

                    if (tempBox.Lebensnummer == null)
                        continue;

                    box.AktuellerKalb = store.GetKalb(tempBox.Lebensnummer.Value);
                }

                else if (ctrl is KaelberboxVertikal boxVertical)
                {
                    Kaelber_projekt.Class.Kaelberbox tempBox = boxStore.GetKaelberBoxById(boxVertical.Name);

                    if (tempBox.Lebensnummer == null)
                        continue;

                    boxVertical.AktuellerKalb = store.GetKalb(tempBox.Lebensnummer.Value);
                }
            }
        }

        private IEnumerable<Control> AlleControls(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                yield return child;

                foreach (var subChild in AlleControls(child))
                    yield return subChild;
            }
        }

        private void Box_KalbZugewiesen(object sender, Kalb kalb)
        {
            if (kalb == null)
            {
                if (sender is Kaelberbox box11)
                {
                    var box = sender as Kaelberbox;
                    var daten = new Kaelber_projekt.Class.Kaelberbox(box.Name, null);
                    boxStore.SetBox(daten);
                }
                else if (sender is KaelberboxVertikal box22)
                {
                    var box = sender as KaelberboxVertikal;
                    var daten = new Kaelber_projekt.Class.Kaelberbox(box.Name, null);
                    boxStore.SetBox(daten);
                }
                return;
            }
            // Prüfen, ob das Kalb schon in einer anderen Box ist
            foreach (var ctrl in AlleControls(this))
            {
                if (ctrl is Kaelberbox box)
                {
                    var tempBox = boxStore.GetKaelberBoxById(box.Name);
                    if (tempBox.Lebensnummer == kalb.Lebensnummer)
                    {
                        if (sender == box) continue;

                        MessageBox.Show("Dieses Kalb ist bereits einer anderen Box zugewiesen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Event-Handler temporär abmelden, damit keine Endlosschleife entsteht
                        if (sender is Kaelberbox b)
                        {
                            b.KalbZugewiesen -= Box_KalbZugewiesen;
                            b.AktuellerKalb = null;
                            b.KalbZugewiesen += Box_KalbZugewiesen;
                        }
                        if (sender is KaelberboxVertikal bv)
                        {
                            bv.KalbZugewiesen -= Box_KalbZugewiesen;
                            bv.AktuellerKalb = null;
                            bv.KalbZugewiesen += Box_KalbZugewiesen;
                        }
                        return;
                    }
                }
                else if (ctrl is KaelberboxVertikal boxVertical)
                {
                    var tempBox = boxStore.GetKaelberBoxById(boxVertical.Name);
                    if (tempBox.Lebensnummer == kalb.Lebensnummer)
                    {
                        if (sender == boxVertical) continue;

                        MessageBox.Show("Dieses Kalb ist bereits einer anderen Box zugewiesen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (sender is Kaelberbox b)
                        {
                            b.KalbZugewiesen -= Box_KalbZugewiesen;
                            b.AktuellerKalb = null;
                            b.KalbZugewiesen += Box_KalbZugewiesen;
                        }
                        if (sender is KaelberboxVertikal bv)
                        {
                            bv.KalbZugewiesen -= Box_KalbZugewiesen;
                            bv.AktuellerKalb = null;
                            bv.KalbZugewiesen += Box_KalbZugewiesen;
                        }
                        return;
                    }
                }
            }

            if (sender is Kaelberbox box1)
            {
                var box = sender as Kaelberbox;
                var daten = new Kaelber_projekt.Class.Kaelberbox(box.Name, kalb?.Lebensnummer);
                boxStore.SetBox(daten);
            }
            else if (sender is KaelberboxVertikal box2)
            {
                var box = sender as KaelberboxVertikal;
                var daten = new Kaelber_projekt.Class.Kaelberbox(box.Name, kalb?.Lebensnummer);
                boxStore.SetBox(daten);
            }
        }

        private void EntferneKalbAusAllenBoxen(int lebensnummer)
        {
            foreach (var ctrl in AlleControls(this))
            {
                if (ctrl is Kaelberbox box)
                {
                    var tempBox = boxStore.GetKaelberBoxById(box.Name);
                    if (tempBox.Lebensnummer == lebensnummer)
                    {
                        box.AktuellerKalb = null;
                        boxStore.SetBox(new Kaelber_projekt.Class.Kaelberbox(box.Name, null));
                        MessageBox.Show(System.IO.Path.GetFullPath("Boxes.txt"));
                    }
                }
                else if (ctrl is KaelberboxVertikal boxVertical)
                {
                    var tempBox = boxStore.GetKaelberBoxById(boxVertical.Name);
                    if (tempBox.Lebensnummer == lebensnummer)
                    {
                        boxVertical.AktuellerKalb = null;
                        boxStore.SetBox(new Kaelber_projekt.Class.Kaelberbox(boxVertical.Name, null));
                    }
                }
            }
        }

        private void btnAddKealber_Click(object sender, EventArgs e)
        {
            using (AddKalbForm addKalbForm = new AddKalbForm())
            {
                if (addKalbForm.ShowDialog() == DialogResult.OK)
                {
                    Kalb kalb = new Kalb(addKalbForm.Lebensnummer, addKalbForm.Name, addKalbForm.Geschlecht, addKalbForm.Groeße, addKalbForm.MutterNummer, addKalbForm.Geburtsdatum, addKalbForm.Eisen, addKalbForm.Selene, addKalbForm.Impfungen, addKalbForm.Hornlos, addKalbForm.Krankheiten, addKalbForm.AlterStall, addKalbForm.zuKlein, addKalbForm.Milchmast);
                    store.AddKalb(kalb);
                    (bindingSource1.List as IList<Kalb>)?.Add(kalb);
                }
            }
            bindingSource1.ResetBindings(false);
        }

        private void dgvDatenKaelber_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            RecalculateKaelber();
            store.SetKaelber((bindingSource1.List as IEnumerable<Kalb>).ToList());
            LoadKaelberBoxes();
            bindingSource1.ResetBindings(false);
        }

        private void dgvDatenKaelber2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RecalculateKaelber();
            store.SetKaelber((bindingSource1.List as IEnumerable<Kalb>).ToList());
            LoadKaelberBoxes();
            bindingSource1.ResetBindings(false);
        }

        private void RecalculateKaelber()
        {
            double KleinMilch1 = Properties.Settings.Default.PKleinMilch1;
            double KleinMilch2 = Properties.Settings.Default.PKleinMilch2;
            double KleinMilch3 = Properties.Settings.Default.PKleinMilch3;
            double KleinMilch4 = Properties.Settings.Default.PKleinMilch4;
            double KleinMilch5 = Properties.Settings.Default.PKleinMilch5;
            double KleinMilch6 = Properties.Settings.Default.PKleinMilch6;
            double KleinMilch7 = Properties.Settings.Default.PKleinMilch7;
            double KleinMilch8 = Properties.Settings.Default.PKleinMilch8;
            double KleinMilch9 = Properties.Settings.Default.PKleinMilch9;
            double KleinMilch10 = Properties.Settings.Default.PKleinMilch10;
            double KleinMilch11 = Properties.Settings.Default.PKleinMilch11;
            double KleinMilch12 = Properties.Settings.Default.PKleinMilch12;
            double KleinMilch13 = Properties.Settings.Default.PKleinMilch13;
            double KleinMilch14 = Properties.Settings.Default.PKleinMilch14;
            double KleinMilch15 = Properties.Settings.Default.PKleinMilch15;
            double KleinKaelberStarter = Properties.Settings.Default.PKleinKaelberstarter;
            double KleinHeu = Properties.Settings.Default.PKleinHeu;
            double KleinWasser = Properties.Settings.Default.PKleinWasser;
            double KleinSilofutter = Properties.Settings.Default.PKleinSilofutter;
            foreach (Kalb k in kaelber)
            {
                k.CalculateFields(KleinMilch1,
                                    KleinMilch2,
                                    KleinMilch3,
                                    KleinMilch4,
                                    KleinMilch5,
                                    KleinMilch6,
                                    KleinMilch7,
                                    KleinMilch8,
                                    KleinMilch9,
                                    KleinMilch10,
                                    KleinMilch11,
                                    KleinMilch12,
                                    KleinMilch13,
                                    KleinMilch14,
                                    KleinMilch15,
                                    KleinKaelberStarter,
                                    KleinHeu,
                                    KleinWasser,
                                    KleinSilofutter);
            }
        }

        private void dgvDatenKaelber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var kalb = dgvDatenKaelber.Rows[e.RowIndex].DataBoundItem as Kalb;
            if (kalb == null)
                return;

            // 🗑️ Löschen
            if (dgvDatenKaelber.Columns[e.ColumnIndex].Name == "Löschen")
            {
                var result = MessageBox.Show("Dieses Kalb wirklich löschen?", "Bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    EntferneKalbAusAllenBoxen(kalb.Lebensnummer);
                    bindingSource1.Remove(kalb);
                    store.SetKaelber((bindingSource1.List as IEnumerable<Kalb>).ToList());

                    MessageBox.Show("Kalb wurde gelöscht.");
                }
            }

            // ➡️ Verschieben
            else if (dgvDatenKaelber.Columns[e.ColumnIndex].Name == "Verschieben")
            {
                var result = MessageBox.Show("Kalb in 'AlleKälber' verschieben?", "Verschieben bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    EntferneKalbAusAllenBoxen(kalb.Lebensnummer);
                    // 👉 hier ist dein UI-Code!
                    IKalbStore alleStore = new AlleKaelberStore();
                    alleStore.AddKalb(kalb);

                    // Entferne aus aktueller Liste
                    bindingSource1.Remove(kalb);
                    store.SetKaelber((bindingSource1.List as IEnumerable<Kalb>).ToList());

                    LoadAlleKaelber();

                    MessageBox.Show("Kalb wurde verschoben.");
                }
            }
        }

        private void DgvAlleKaelber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var kalb = dgvAlleKaelber.Rows[e.RowIndex].DataBoundItem as Kalb;
            if (kalb == null)
                return;

            if (dgvAlleKaelber.Columns[e.ColumnIndex].Name == "Zurueck")
            {
                var result = MessageBox.Show("Kalb zurück in die normale Liste verschieben?", "Verschieben bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var alleListe = alleStore.GetAllKaelber();
                    alleListe.RemoveAll(k => k.Lebensnummer == kalb.Lebensnummer);
                    alleStore.SetKaelber(alleListe);

                    var normaleListe = store.GetAllKaelber();
                    normaleListe.Add(kalb);
                    store.SetKaelber(normaleListe);

                    LoadAlleKaelber();
                    LoadData();

                    MessageBox.Show("Kalb wurde zurückverschoben.");
                }
            }
            else if (dgvAlleKaelber.Columns[e.ColumnIndex].Name == "Loeschen")
            {
                var result = MessageBox.Show("Dieses Kalb wirklich löschen?", "Löschen bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var alleListe = alleStore.GetAllKaelber();
                    alleListe.RemoveAll(k => k.Lebensnummer == kalb.Lebensnummer);
                    alleStore.SetKaelber(alleListe);

                    LoadAlleKaelber();

                    MessageBox.Show("Kalb wurde gelöscht.");
                }
            }
        }

        private void dgvDatenKaelber_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDatenKaelber.Rows.Count - (dgvDatenKaelber.AllowUserToAddRows ? 1 : 0))
            {
                return;
            }
            // Prüfen, ob die aktuelle Spalte die "Alter"-Spalte ist
            if (e.ColumnIndex == 20)
            {
                var kalb = dgvDatenKaelber.Rows[e.RowIndex].DataBoundItem as Kalb;

                if (kalb != null)
                {
                    double wochenBisAbspannen = (kalb.Abspanndatum - DateTime.Now).Days / 7.0;
                    if (wochenBisAbspannen < 0)
                    {
                        e.Value = kalb.IstExakterVollmond
                            ? $"{kalb.Abspanndatum:dd.MM.yyyy}🌕"
                            : $"{kalb.Abspanndatum:dd.MM.yyyy}";
                    }
                    else
                    {
                        e.Value = kalb.IstExakterVollmond
                            ? $"{kalb.Abspanndatum:dd.MM.yyyy}🌕 (in {wochenBisAbspannen:F1} Wochen)"
                            : $"{kalb.Abspanndatum:dd.MM.yyyy} (in {wochenBisAbspannen:F1} Wochen)";
                    }
                    e.FormattingApplied = true; // verhindert Rückwandlung ins Modell
                }
            }


            if (e.ColumnIndex == 19)
            {
                // Hole das zugrunde liegende Kalb-Objekt
                var kalb = dgvDatenKaelber.Rows[e.RowIndex].DataBoundItem as Kalb;

                if (kalb != null)
                {
                    // Verwende die Alter-Eigenschaft des Kalb-Objekts
                    int alterInTagen = kalb.Alter;
                    double alterInWochen = alterInTagen / 7.0;

                    // Formatieren: Alter in Tagen (Alter in Wochen)
                    e.Value = $"{alterInTagen} ({alterInWochen:F1} Wochen)";
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex == 0)
            {
                var kalb = dgvDatenKaelber.Rows[e.RowIndex].DataBoundItem as Kalb;
                if (kalb != null)
                {
                    if (kalb.Milchmast)
                        e.Value = $"{kalb.Lebensnummer} Milchmast";
                    else
                        e.Value = kalb.Lebensnummer.ToString();
                    e.FormattingApplied = true;
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

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            var auswahlForm = new DruckSpaltenAuswahlForm();
            if (auswahlForm.ShowDialog() == DialogResult.OK)
            {
                StarteDruckMitFeldAuswahl(auswahlForm.AusgewaehlteFelder);
            }
        }

        private void StarteDruckMitFeldAuswahl(List<string> feldNamen)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true; // Querformat aktivieren

            doc.PrintPage += (s, e) =>
            {
                float seitenrandLinks = 50f;
                float seitenrandOben = 80f;
                float seitenbreite = e.MarginBounds.Width;
                float zeilenHoehe = 25f;

                float y = seitenrandOben;
                float x = seitenrandLinks;

                var list = (bindingSource1.List as IEnumerable<Kalb>)?.ToList();

                // Hole nur ausgewählte Properties der Klasse Kalb
                var props = typeof(Kalb).GetProperties()
                    .Where(p => feldNamen.Contains(p.Name))
                    .ToList();

                int spaltenAnzahl = props.Count;
                float spaltenBreite = seitenbreite / spaltenAnzahl;

                Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
                Font cellFont = new Font("Segoe UI", 9);
                Pen zellenRahmen = Pens.Black;

                // 🔹 Kopfzeile (Feldnamen)
                foreach (var prop in props)
                {
                    var headerRect = new RectangleF(x, y, spaltenBreite, zeilenHoehe);

                    e.Graphics.DrawString(prop.Name, headerFont, Brushes.Black, headerRect);
                    e.Graphics.DrawRectangle(zellenRahmen, headerRect.X, headerRect.Y, headerRect.Width, headerRect.Height);

                    x += spaltenBreite;
                }

                y += zeilenHoehe;

                // 🔹 Datenzeilen
                foreach (var kalb in list)
                {
                    x = seitenrandLinks;

                    foreach (var prop in props)
                    {
                        object propValue = prop.GetValue(kalb);
                        string value;

                        if (propValue is DateTime dt)
                            value = dt.ToShortDateString(); // nur Datum
                        else if (propValue is bool b)
                            value = b ? "Ja" : "Nein"; // ✔️ boolean zu Ja/Nein
                        else
                            value = propValue?.ToString() ?? "";

                        var cellRect = new RectangleF(x, y, spaltenBreite, zeilenHoehe);

                        e.Graphics.DrawString(value, cellFont, Brushes.Black, cellRect);
                        e.Graphics.DrawRectangle(zellenRahmen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                        x += spaltenBreite;
                    }

                    y += zeilenHoehe;
                }
            };

            using (PrintDialog dialog = new PrintDialog())
            {
                dialog.Document = doc;
                if (dialog.ShowDialog() == DialogResult.OK)
                    doc.Print();
            }
        }

        // Sorting the List

        private int dragRowIndex = -1;
        private bool dragging = false;
        // Explicitly specify the namespace for Timer to resolve ambiguity
        private System.Windows.Forms.Timer arduinoTimer;

        private void dgvDatenKaelber_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = dgvDatenKaelber.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
            {
                dragRowIndex = hit.RowIndex;
                dragging = true;
            }
        }

        private void dgvDatenKaelber_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && e.Button == MouseButtons.Left)
            {
                dgvDatenKaelber.DoDragDrop(dgvDatenKaelber.Rows[dragRowIndex], DragDropEffects.Move);
            }
        }

        private void dgvDatenKaelber_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvDatenKaelber_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dgvDatenKaelber.PointToClient(new Point(e.X, e.Y));
            var hit = dgvDatenKaelber.HitTest(clientPoint.X, clientPoint.Y);
            int dropRowIndex = hit.RowIndex;

            if (dropRowIndex >= 0 && dragRowIndex != dropRowIndex)
            {
                var list = (SortableBindingList<Kalb>)bindingSource1.List;

                var item = list[dragRowIndex];
                list.RemoveAt(dragRowIndex);
                list.Insert(dropRowIndex, item);

                bindingSource1.ResetBindings(false); // wichtig für visuelles Update
                dgvDatenKaelber.Rows[dropRowIndex].Selected = true;

                store.SetKaelber((bindingSource1.List as IEnumerable<Kalb>).ToList());
            }

            dragging = false;
        }

        private void BindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                store.SetKaelber((bindingSource1.List as IEnumerable<Kalb>).ToList());
            }
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
            // Manuelle Breite für eine bestimmte Spalte festlegen
            var column = dgv.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.HeaderText == "zu klein zum Abspannen");
            if (column != null)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Width = 110;
            }

            var column1 = dgv.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.HeaderText == "Alter in Tagen (Wochen)");
            if (column1 != null)
            {
                column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column1.Width = 140;
            }

            var column2 = dgv.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.HeaderText == "Abspanndatum Vollmond");
            if (column2 != null)
            {
                column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column2.Width = 230;
            }

            var column3 = dgv.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.HeaderText == "Alter Stall");
            if (column3 != null)
            {
                column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column3.Width = 60;
            }

            var column4 = dgv.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.HeaderText == "Lebensnummer");
            if (column4 != null)
            {
                column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column4.Width = 150;
            }
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
        private void DgvDatenKaelber_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Verhindert Absturz durch Formatierungsfehler
            e.ThrowException = false;
            e.Cancel = true;
        }

        //Einstellungen speichern ect

        private void MainForm_Load(object sender, EventArgs e)
        {
            txbKleinMilk1.Text = Properties.Settings.Default.PKleinMilch1.ToString();
            txbKleinMilk2.Text = Properties.Settings.Default.PKleinMilch2.ToString();
            txbKleinMilk3.Text = Properties.Settings.Default.PKleinMilch3.ToString();
            txbKleinMilk4.Text = Properties.Settings.Default.PKleinMilch4.ToString();
            txbKleinMilk5.Text = Properties.Settings.Default.PKleinMilch5.ToString();
            txbKleinMilk6.Text = Properties.Settings.Default.PKleinMilch6.ToString();
            txbKleinMilk7.Text = Properties.Settings.Default.PKleinMilch7.ToString();
            txbKleinMilk8.Text = Properties.Settings.Default.PKleinMilch8.ToString();
            txbKleinMilk9.Text = Properties.Settings.Default.PKleinMilch9.ToString();
            txbKleinMilk10.Text = Properties.Settings.Default.PKleinMilch10.ToString();
            txbKleinMilk11.Text = Properties.Settings.Default.PKleinMilch11.ToString();
            txbKleinMilk12.Text = Properties.Settings.Default.PKleinMilch12.ToString();
            txbKleinMilk13.Text = Properties.Settings.Default.PKleinMilch13.ToString();
            txbKleinMilk14.Text = Properties.Settings.Default.PKleinMilch14.ToString();
            txbKleinMilk15.Text = Properties.Settings.Default.PKleinMilch15.ToString();
            txbKleinKaelberstarter.Text = Properties.Settings.Default.PKleinKaelberstarter.ToString();
            txbKleinHeu.Text = Properties.Settings.Default.PKleinHeu.ToString();
            txbKleinWasser.Text = Properties.Settings.Default.PKleinWasser.ToString();
            txbKleinSilofutter.Text = Properties.Settings.Default.PKleinSilofutter.ToString();

        }


        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            // Liste von (TextBox, Setting-Name) Paaren
            var doubleSettings = new (TextBox TextBox, string SettingName)[]
            {
                (txbKleinMilk1, nameof(Properties.Settings.Default.PKleinMilch1)),
                (txbKleinMilk2, nameof(Properties.Settings.Default.PKleinMilch2)),
                (txbKleinMilk3, nameof(Properties.Settings.Default.PKleinMilch3)),
                (txbKleinMilk4, nameof(Properties.Settings.Default.PKleinMilch4)),
                (txbKleinMilk5, nameof(Properties.Settings.Default.PKleinMilch5)),
                (txbKleinMilk6, nameof(Properties.Settings.Default.PKleinMilch6)),
                (txbKleinMilk7, nameof(Properties.Settings.Default.PKleinMilch7)),
                (txbKleinMilk8, nameof(Properties.Settings.Default.PKleinMilch8)),
                (txbKleinMilk9, nameof(Properties.Settings.Default.PKleinMilch9)),
                (txbKleinMilk10, nameof(Properties.Settings.Default.PKleinMilch10)),
                (txbKleinMilk11, nameof(Properties.Settings.Default.PKleinMilch11)),
                (txbKleinMilk12, nameof(Properties.Settings.Default.PKleinMilch12)),
                (txbKleinMilk13, nameof(Properties.Settings.Default.PKleinMilch13)),
                (txbKleinMilk14, nameof(Properties.Settings.Default.PKleinMilch14)),
                (txbKleinMilk15, nameof(Properties.Settings.Default.PKleinMilch15)),
                (txbKleinKaelberstarter, nameof(Properties.Settings.Default.PKleinKaelberstarter)),
                (txbKleinHeu, nameof(Properties.Settings.Default.PKleinHeu)),
                (txbKleinWasser, nameof(Properties.Settings.Default.PKleinWasser)),
                (txbKleinSilofutter, nameof(Properties.Settings.Default.PKleinSilofutter))

                // Füge hier weitere Paare hinzu, z.B. (txbKleinMilk3, nameof(Properties.Settings.Default.PKleinMilch3))
            };

            foreach (var (textBox, settingName) in doubleSettings)
            {
                if (double.TryParse(textBox.Text, out double value))
                {
                    Properties.Settings.Default[settingName] = value;
                }
                else
                {
                    MessageBox.Show($"Bitte geben Sie für '{settingName}' nur eine Zahl ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Properties.Settings.Default.Save();
            RecalculateKaelber();
            bindingSource1.ResetBindings(false);

            MessageBox.Show("Einstellung gespeichert!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        //Arduino

        private bool zeigeAlternativeAnzeige = false;
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            zeigeAlternativeAnzeige = !zeigeAlternativeAnzeige;
        }
        private void ArduinoTimer_Tick(object sender, EventArgs e)
        {
            // Beispiel: Box mit Name "kaelberbox1"
            var box = boxStore.GetKaelberBoxById("kaelberbox1");
            if (box == null || box.Lebensnummer == null)
            {
                // Box ist leer → "Leer" anzeigen
                string text = "Leer";
                try
                {
                    using (SerialPort port = new SerialPort("COM3", 9600))
                    {
                        port.Open();
                        port.WriteLine(text);
                        port.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Fehlerbehandlung
                }
                return;
            }

            // Hole das Kalb, das in dieser Box ist
            var kalb = store.GetKalb(box.Lebensnummer.Value);
            if (kalb == null)
                return;

            string fullText;
            if (zeigeAlternativeAnzeige)
            {
                string zeile1 = $"Absp:{kalb.Abspanndatum:dd.MM.yyyy}";
                string zeile2 = $" {kalb.Geschlecht}  " +
                                (kalb.Enthornt ? "Enthornt" : "") +
                                (kalb.Hornlos ? "Hornlos" : "") +
                                (!kalb.Enthornt && !kalb.Hornlos ? "Hoerner" : "");

                fullText = zeile1 + "|" + zeile2;
            }
            else
            {
                double alterInWochen = Math.Round(kalb.Alter / 7.0, 1);
                string zeile1 = $"{kalb.Lebensnummer}  {kalb.Milch}  {alterInWochen}W";
                string zeile2 =
                    (kalb.Wasser ? "W " : "") +
                    (kalb.Heu ? "H " : "") +
                    (kalb.Kaelberstarter ? "K " : "") +
                    (kalb.Silofutter ? "S" : "");
                fullText = zeile1 + "|" + zeile2;
            }

            try
            {
                using (SerialPort port = new SerialPort("COM3", 9600))
                {
                    port.Open();
                    port.WriteLine(fullText);
                    port.Close();
                }
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung
            }
        }

    }
}
