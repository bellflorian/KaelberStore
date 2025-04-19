using Kaelber_projekt.Class;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace Oberflaeche_kaelber.Forms
{
    public partial class DatenKaelberForm : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private IKalbStore store = new TxtFileStore();
        private IKaelberboxStore boxStore = new TxtFileStore();
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
            bindingSource1.ListChanged += BindingSource1_ListChanged;

            kaelber = store.GetAllKaelber();
            RecalculateKaelber();
            var sortierbareListe = new SortableBindingList<Kalb>(kaelber);
            bindingSource1.DataSource = sortierbareListe;
            dgvDatenKaelber.DataSource = bindingSource1;
            dgvDatenKaelber2.DataSource = bindingSource1;

            dgvDatenKaelber.AllowDrop = true;

            LoadKaelberBoxes();

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

                if (dgvDatenKaelber2.Columns[i].HeaderText == "Durchfall + Datum" || dgvDatenKaelber2.Columns[i].HeaderText == "Notiz" || dgvDatenKaelber2.Columns[i].HeaderText == "Alter Stall" || dgvDatenKaelber2.Columns[i].HeaderText == "zu klein zum Abspannen")
                    dgvDatenKaelber2.Columns[i].ReadOnly = false;
            }
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

        private void btnAddKealber_Click(object sender, EventArgs e)
        {
            using (AddKalbForm addKalbForm = new AddKalbForm())
            {
                if (addKalbForm.ShowDialog() == DialogResult.OK)
                {
                    Kalb kalb = new Kalb(addKalbForm.Lebensnummer, addKalbForm.Name, addKalbForm.Geschlecht, addKalbForm.Groeße, addKalbForm.MutterNummer, addKalbForm.Geburtsdatum, addKalbForm.Eisen, addKalbForm.Selene, addKalbForm.Impfungen, addKalbForm.Hornlos, addKalbForm.Krankheiten, addKalbForm.AlterStall, addKalbForm.zuKlein);
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
        }

        private void dgvDatenKaelber2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RecalculateKaelber();
            store.SetKaelber((bindingSource1.List as IEnumerable<Kalb>).ToList());
            LoadKaelberBoxes();
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
                        store.SetKaelber((bindingSource1.List as IEnumerable<Kalb>).ToList());
                    }
                }
            }
        }
        private void dgvDatenKaelber_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Prüfen, ob die aktuelle Spalte die "Alter"-Spalte ist
            if (dgvDatenKaelber.Columns[e.ColumnIndex].Name == "Alter")
            {
                var kalb = dgvDatenKaelber.Rows[e.RowIndex].DataBoundItem as Kalb;

                if (kalb != null)
                {
                    double wochenBisAbspannen = (kalb.Abspanndatum - DateTime.Now).Days / 7.0;
                    if (wochenBisAbspannen < 0)
                    {
                        e.Value = $"{kalb.Abspanndatum.ToShortDateString()}";
                    }
                    else
                    {
                        // Formatieren: Abspanndatum (in Wochen)
                        e.Value = $"{kalb.Abspanndatum.ToShortDateString()} (in {wochenBisAbspannen:F1} Wochen)";
                    }
                }
            }

            if (dgvDatenKaelber.Columns[e.ColumnIndex].Name == "Silofutter")
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
                column2.Width = 200;
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
                column4.Width = 120;
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
    }
}
