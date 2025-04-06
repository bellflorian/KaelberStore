namespace Oberflaeche_kaelber.Forms
{
    partial class AddKalbForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLebensnummer = new Label();
            label2 = new Label();
            lblMutterNummer = new Label();
            tbxLebensnummer = new TextBox();
            tbxMutterNummer = new TextBox();
            cbxEisen = new CheckBox();
            btnSave = new Button();
            lblName = new Label();
            tbxName = new TextBox();
            lblGeburtsdatum = new Label();
            cbxSelene = new CheckBox();
            cbxImpfungen = new CheckBox();
            cbxHornlos = new CheckBox();
            tbxGeschlecht = new TextBox();
            lblGesclecht = new Label();
            dtPDatum = new DateTimePicker();
            lblError = new Label();
            lblGroeße = new Label();
            cbxGroeße = new ComboBox();
            SuspendLayout();
            // 
            // lblLebensnummer
            // 
            lblLebensnummer.AutoSize = true;
            lblLebensnummer.Location = new Point(3, 57);
            lblLebensnummer.Name = "lblLebensnummer";
            lblLebensnummer.Size = new Size(93, 15);
            lblLebensnummer.TabIndex = 0;
            lblLebensnummer.Text = "Lebensnummer:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 309);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            // 
            // lblMutterNummer
            // 
            lblMutterNummer.AutoSize = true;
            lblMutterNummer.Location = new Point(-1, 134);
            lblMutterNummer.Name = "lblMutterNummer";
            lblMutterNummer.Size = new Size(97, 15);
            lblMutterNummer.TabIndex = 3;
            lblMutterNummer.Text = "Mutter Nummer:";
            // 
            // tbxLebensnummer
            // 
            tbxLebensnummer.Location = new Point(97, 54);
            tbxLebensnummer.Name = "tbxLebensnummer";
            tbxLebensnummer.Size = new Size(100, 23);
            tbxLebensnummer.TabIndex = 4;
            // 
            // tbxMutterNummer
            // 
            tbxMutterNummer.Location = new Point(97, 130);
            tbxMutterNummer.Name = "tbxMutterNummer";
            tbxMutterNummer.Size = new Size(100, 23);
            tbxMutterNummer.TabIndex = 5;
            // 
            // cbxEisen
            // 
            cbxEisen.AutoSize = true;
            cbxEisen.Location = new Point(248, 71);
            cbxEisen.Name = "cbxEisen";
            cbxEisen.Size = new Size(53, 19);
            cbxEisen.TabIndex = 6;
            cbxEisen.Text = "Eisen";
            cbxEisen.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(237, 133);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Speichern";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(52, 31);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 8;
            lblName.Text = "Name:";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(97, 28);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(100, 23);
            tbxName.TabIndex = 9;
            // 
            // lblGeburtsdatum
            // 
            lblGeburtsdatum.AutoSize = true;
            lblGeburtsdatum.Location = new Point(292, 11);
            lblGeburtsdatum.Name = "lblGeburtsdatum";
            lblGeburtsdatum.Size = new Size(83, 15);
            lblGeburtsdatum.TabIndex = 12;
            lblGeburtsdatum.Text = "Geburtsdatum";
            // 
            // cbxSelene
            // 
            cbxSelene.AutoSize = true;
            cbxSelene.Location = new Point(248, 96);
            cbxSelene.Name = "cbxSelene";
            cbxSelene.Size = new Size(60, 19);
            cbxSelene.TabIndex = 14;
            cbxSelene.Text = "Selene";
            cbxSelene.UseVisualStyleBackColor = true;
            // 
            // cbxImpfungen
            // 
            cbxImpfungen.AutoSize = true;
            cbxImpfungen.Location = new Point(333, 71);
            cbxImpfungen.Name = "cbxImpfungen";
            cbxImpfungen.Size = new Size(85, 19);
            cbxImpfungen.TabIndex = 15;
            cbxImpfungen.Text = "Impfungen";
            cbxImpfungen.UseVisualStyleBackColor = true;
            // 
            // cbxHornlos
            // 
            cbxHornlos.AutoSize = true;
            cbxHornlos.Location = new Point(333, 96);
            cbxHornlos.Name = "cbxHornlos";
            cbxHornlos.Size = new Size(68, 19);
            cbxHornlos.TabIndex = 16;
            cbxHornlos.Text = "Hornlos";
            cbxHornlos.UseVisualStyleBackColor = true;
            // 
            // tbxGeschlecht
            // 
            tbxGeschlecht.Location = new Point(97, 79);
            tbxGeschlecht.Name = "tbxGeschlecht";
            tbxGeschlecht.Size = new Size(100, 23);
            tbxGeschlecht.TabIndex = 17;
            // 
            // lblGesclecht
            // 
            lblGesclecht.AutoSize = true;
            lblGesclecht.Location = new Point(27, 81);
            lblGesclecht.Name = "lblGesclecht";
            lblGesclecht.Size = new Size(68, 15);
            lblGesclecht.TabIndex = 18;
            lblGesclecht.Text = "Geschlecht:";
            // 
            // dtPDatum
            // 
            dtPDatum.Location = new Point(237, 29);
            dtPDatum.Name = "dtPDatum";
            dtPDatum.Size = new Size(200, 23);
            dtPDatum.TabIndex = 19;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.FromArgb(192, 0, 0);
            lblError.Location = new Point(12, 166);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 15);
            lblError.TabIndex = 20;
            // 
            // lblGroeße
            // 
            lblGroeße.AutoSize = true;
            lblGroeße.Location = new Point(52, 107);
            lblGroeße.Name = "lblGroeße";
            lblGroeße.Size = new Size(42, 15);
            lblGroeße.TabIndex = 21;
            lblGroeße.Text = "Größe:";
            // 
            // cbxGroeße
            // 
            cbxGroeße.FormattingEnabled = true;
            cbxGroeße.Location = new Point(97, 104);
            cbxGroeße.Name = "cbxGroeße";
            cbxGroeße.Size = new Size(100, 23);
            cbxGroeße.TabIndex = 23;
            cbxGroeße.SelectedIndexChanged += cbxGroeße_SelectedIndexChanged;
            // 
            // AddKalbForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 190);
            Controls.Add(cbxGroeße);
            Controls.Add(lblGroeße);
            Controls.Add(lblError);
            Controls.Add(dtPDatum);
            Controls.Add(lblGesclecht);
            Controls.Add(tbxGeschlecht);
            Controls.Add(cbxHornlos);
            Controls.Add(cbxImpfungen);
            Controls.Add(cbxSelene);
            Controls.Add(lblGeburtsdatum);
            Controls.Add(tbxName);
            Controls.Add(lblName);
            Controls.Add(btnSave);
            Controls.Add(cbxEisen);
            Controls.Add(tbxMutterNummer);
            Controls.Add(tbxLebensnummer);
            Controls.Add(lblMutterNummer);
            Controls.Add(label2);
            Controls.Add(lblLebensnummer);
            Name = "AddKalbForm";
            Text = "Neues Kalb hinzufügen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLebensnummer;
        private Label label2;
        private Label lblMutterNummer;
        private TextBox tbxLebensnummer;
        private TextBox tbxMutterNummer;
        private CheckBox cbxEisen;
        private Button btnSave;
        private Label lblName;
        private TextBox tbxName;
        private Label lblGeburtsdatum;
        private CheckBox cbxSelene;
        private CheckBox cbxImpfungen;
        private CheckBox cbxHornlos;
        private TextBox tbxGeschlecht;
        private Label lblGesclecht;
        private DateTimePicker dtPDatum;
        private Label lblError;
        private Label lblGroeße;
        private ComboBox cbxGroeße;
    }
}