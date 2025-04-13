namespace Oberflaeche_kaelber.Forms
{
    partial class DatenKaelberForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatenKaelberForm));
            tcTabs = new TabControl();
            tcPageKaelber2 = new TabPage();
            btnPrint = new Button();
            dgvDatenKaelber2 = new DataGridView();
            btnMilchmenge = new Button();
            tcPageKaelber1 = new TabPage();
            btnAddKealber = new Button();
            dgvDatenKaelber = new DataGridView();
            tcStalluebersichtNeuerStall = new TabPage();
            tcStalluebersichtAlterStall = new TabPage();
            kaelberbox1 = new Kaelberbox();
            kaelberbox2 = new Kaelberbox();
            kaelberbox3 = new Kaelberbox();
            kaelberbox4 = new Kaelberbox();
            kaelberbox5 = new Kaelberbox();
            kaelberbox6 = new Kaelberbox();
            kaelberbox7 = new Kaelberbox();
            kaelberbox8 = new Kaelberbox();
            kaelberbox9 = new Kaelberbox();
            kaelberbox10 = new Kaelberbox();
            kaelberbox11 = new Kaelberbox();
            kaelberbox12 = new Kaelberbox();
            kaelberbox13 = new Kaelberbox();
            kaelberbox14 = new Kaelberbox();
            kaelberbox15 = new Kaelberbox();
            kaelberbox16 = new Kaelberbox();
            kaelberbox17 = new Kaelberbox();
            kaelberbox18 = new Kaelberbox();
            kaelberbox19 = new Kaelberbox();
            kaelberbox20 = new Kaelberbox();
            kaelberbox21 = new Kaelberbox();
            kaelberbox22 = new Kaelberbox();
            tcTabs.SuspendLayout();
            tcPageKaelber2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber2).BeginInit();
            tcPageKaelber1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber).BeginInit();
            tcStalluebersichtNeuerStall.SuspendLayout();
            tcStalluebersichtAlterStall.SuspendLayout();
            SuspendLayout();
            // 
            // tcTabs
            // 
            tcTabs.Controls.Add(tcPageKaelber2);
            tcTabs.Controls.Add(tcPageKaelber1);
            tcTabs.Controls.Add(tcStalluebersichtNeuerStall);
            tcTabs.Controls.Add(tcStalluebersichtAlterStall);
            tcTabs.Dock = DockStyle.Fill;
            tcTabs.Location = new Point(0, 0);
            tcTabs.Name = "tcTabs";
            tcTabs.SelectedIndex = 0;
            tcTabs.Size = new Size(1370, 685);
            tcTabs.TabIndex = 3;
            // 
            // tcPageKaelber2
            // 
            tcPageKaelber2.BackColor = SystemColors.Control;
            tcPageKaelber2.Controls.Add(btnPrint);
            tcPageKaelber2.Controls.Add(dgvDatenKaelber2);
            tcPageKaelber2.Controls.Add(btnMilchmenge);
            tcPageKaelber2.Location = new Point(4, 24);
            tcPageKaelber2.Name = "tcPageKaelber2";
            tcPageKaelber2.Padding = new Padding(3);
            tcPageKaelber2.Size = new Size(1362, 657);
            tcPageKaelber2.TabIndex = 1;
            tcPageKaelber2.Text = "Übersicht Kälber";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(1178, 615);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(181, 34);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "Drucken";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click_1;
            // 
            // dgvDatenKaelber2
            // 
            dgvDatenKaelber2.BackgroundColor = SystemColors.Control;
            dgvDatenKaelber2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatenKaelber2.Dock = DockStyle.Top;
            dgvDatenKaelber2.Location = new Point(3, 3);
            dgvDatenKaelber2.Name = "dgvDatenKaelber2";
            dgvDatenKaelber2.Size = new Size(1356, 602);
            dgvDatenKaelber2.TabIndex = 4;
            dgvDatenKaelber2.CellValueChanged += dgvDatenKaelber2_CellValueChanged;
            // 
            // btnMilchmenge
            // 
            btnMilchmenge.Location = new Point(3, 615);
            btnMilchmenge.Name = "btnMilchmenge";
            btnMilchmenge.Size = new Size(1169, 34);
            btnMilchmenge.TabIndex = 3;
            btnMilchmenge.Text = "Berechne Milchmenge";
            btnMilchmenge.UseVisualStyleBackColor = true;
            btnMilchmenge.Click += btnMilchmenge_Click_1;
            // 
            // tcPageKaelber1
            // 
            tcPageKaelber1.BackColor = SystemColors.Control;
            tcPageKaelber1.Controls.Add(btnAddKealber);
            tcPageKaelber1.Controls.Add(dgvDatenKaelber);
            tcPageKaelber1.Location = new Point(4, 24);
            tcPageKaelber1.Name = "tcPageKaelber1";
            tcPageKaelber1.Padding = new Padding(3);
            tcPageKaelber1.Size = new Size(1362, 657);
            tcPageKaelber1.TabIndex = 0;
            tcPageKaelber1.Text = "Daten Kälber";
            // 
            // btnAddKealber
            // 
            btnAddKealber.Location = new Point(3, 615);
            btnAddKealber.Name = "btnAddKealber";
            btnAddKealber.Size = new Size(1356, 34);
            btnAddKealber.TabIndex = 2;
            btnAddKealber.Text = "Neues Kalb hinzufügen";
            btnAddKealber.UseVisualStyleBackColor = true;
            btnAddKealber.Click += btnAddKealber_Click;
            // 
            // dgvDatenKaelber
            // 
            dgvDatenKaelber.BackgroundColor = SystemColors.Control;
            dgvDatenKaelber.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatenKaelber.Dock = DockStyle.Top;
            dgvDatenKaelber.Location = new Point(3, 3);
            dgvDatenKaelber.Name = "dgvDatenKaelber";
            dgvDatenKaelber.Size = new Size(1356, 602);
            dgvDatenKaelber.TabIndex = 1;
            dgvDatenKaelber.CellClick += dgvDatenKaelber_CellClick;
            dgvDatenKaelber.CellValueChanged += dgvDatenKaelber_CellValueChanged_1;
            dgvDatenKaelber.DragDrop += dgvDatenKaelber_DragDrop;
            dgvDatenKaelber.DragOver += dgvDatenKaelber_DragOver;
            dgvDatenKaelber.MouseDown += dgvDatenKaelber_MouseDown;
            dgvDatenKaelber.MouseMove += dgvDatenKaelber_MouseMove;
            // 
            // tcStalluebersichtNeuerStall
            // 
            tcStalluebersichtNeuerStall.BackColor = SystemColors.Control;
            tcStalluebersichtNeuerStall.BackgroundImage = Properties.Resources.neuerstall_zeichnung2;
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox22);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox21);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox20);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox19);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox18);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox17);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox16);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox8);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox7);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox6);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox5);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox4);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox3);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox2);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberbox1);
            tcStalluebersichtNeuerStall.Location = new Point(4, 24);
            tcStalluebersichtNeuerStall.Name = "tcStalluebersichtNeuerStall";
            tcStalluebersichtNeuerStall.Size = new Size(1362, 657);
            tcStalluebersichtNeuerStall.TabIndex = 2;
            tcStalluebersichtNeuerStall.Text = " Stallübersicht Neuer Stall";
            // 
            // tcStalluebersichtAlterStall
            // 
            tcStalluebersichtAlterStall.BackColor = SystemColors.Control;
            tcStalluebersichtAlterStall.BackgroundImage = Properties.Resources.alter_stall_zeichnung;
            tcStalluebersichtAlterStall.Controls.Add(kaelberbox15);
            tcStalluebersichtAlterStall.Controls.Add(kaelberbox14);
            tcStalluebersichtAlterStall.Controls.Add(kaelberbox13);
            tcStalluebersichtAlterStall.Controls.Add(kaelberbox12);
            tcStalluebersichtAlterStall.Controls.Add(kaelberbox11);
            tcStalluebersichtAlterStall.Controls.Add(kaelberbox10);
            tcStalluebersichtAlterStall.Controls.Add(kaelberbox9);
            tcStalluebersichtAlterStall.Location = new Point(4, 24);
            tcStalluebersichtAlterStall.Name = "tcStalluebersichtAlterStall";
            tcStalluebersichtAlterStall.Size = new Size(1362, 657);
            tcStalluebersichtAlterStall.TabIndex = 3;
            tcStalluebersichtAlterStall.Text = "Stallübersicht Alter Stall";
            // 
            // kaelberbox1
            // 
            kaelberbox1.BackColor = SystemColors.Control;
            kaelberbox1.BackgroundImage = (Image)resources.GetObject("kaelberbox1.BackgroundImage");
            kaelberbox1.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox1.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox1.Location = new Point(332, 485);
            kaelberbox1.Name = "kaelberbox1";
            kaelberbox1.Size = new Size(150, 100);
            kaelberbox1.TabIndex = 0;
            // 
            // kaelberbox2
            // 
            kaelberbox2.BackColor = SystemColors.Control;
            kaelberbox2.BackgroundImage = (Image)resources.GetObject("kaelberbox2.BackgroundImage");
            kaelberbox2.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox2.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox2.Location = new Point(332, 368);
            kaelberbox2.Name = "kaelberbox2";
            kaelberbox2.Size = new Size(150, 100);
            kaelberbox2.TabIndex = 1;
            // 
            // kaelberbox3
            // 
            kaelberbox3.BackColor = SystemColors.Control;
            kaelberbox3.BackgroundImage = (Image)resources.GetObject("kaelberbox3.BackgroundImage");
            kaelberbox3.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox3.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox3.Location = new Point(332, 246);
            kaelberbox3.Name = "kaelberbox3";
            kaelberbox3.Size = new Size(150, 100);
            kaelberbox3.TabIndex = 2;
            // 
            // kaelberbox4
            // 
            kaelberbox4.BackColor = SystemColors.Control;
            kaelberbox4.BackgroundImage = (Image)resources.GetObject("kaelberbox4.BackgroundImage");
            kaelberbox4.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox4.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox4.Location = new Point(882, 141);
            kaelberbox4.Name = "kaelberbox4";
            kaelberbox4.Size = new Size(150, 100);
            kaelberbox4.TabIndex = 3;
            // 
            // kaelberbox5
            // 
            kaelberbox5.BackColor = SystemColors.Control;
            kaelberbox5.BackgroundImage = (Image)resources.GetObject("kaelberbox5.BackgroundImage");
            kaelberbox5.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox5.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox5.Location = new Point(882, 256);
            kaelberbox5.Name = "kaelberbox5";
            kaelberbox5.Size = new Size(150, 100);
            kaelberbox5.TabIndex = 4;
            // 
            // kaelberbox6
            // 
            kaelberbox6.BackColor = SystemColors.Control;
            kaelberbox6.BackgroundImage = (Image)resources.GetObject("kaelberbox6.BackgroundImage");
            kaelberbox6.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox6.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox6.Location = new Point(882, 368);
            kaelberbox6.Name = "kaelberbox6";
            kaelberbox6.Size = new Size(150, 100);
            kaelberbox6.TabIndex = 5;
            // 
            // kaelberbox7
            // 
            kaelberbox7.BackColor = SystemColors.Control;
            kaelberbox7.BackgroundImage = (Image)resources.GetObject("kaelberbox7.BackgroundImage");
            kaelberbox7.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox7.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox7.Location = new Point(882, 485);
            kaelberbox7.Name = "kaelberbox7";
            kaelberbox7.Size = new Size(150, 100);
            kaelberbox7.TabIndex = 6;
            // 
            // kaelberbox8
            // 
            kaelberbox8.BackColor = SystemColors.Control;
            kaelberbox8.BackgroundImage = (Image)resources.GetObject("kaelberbox8.BackgroundImage");
            kaelberbox8.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox8.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox8.Location = new Point(882, 21);
            kaelberbox8.Name = "kaelberbox8";
            kaelberbox8.Size = new Size(150, 100);
            kaelberbox8.TabIndex = 7;
            // 
            // kaelberbox9
            // 
            kaelberbox9.BackColor = SystemColors.Control;
            kaelberbox9.BackgroundImage = (Image)resources.GetObject("kaelberbox9.BackgroundImage");
            kaelberbox9.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox9.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox9.Location = new Point(158, 96);
            kaelberbox9.Name = "kaelberbox9";
            kaelberbox9.Size = new Size(150, 100);
            kaelberbox9.TabIndex = 0;
            // 
            // kaelberbox10
            // 
            kaelberbox10.BackColor = SystemColors.Control;
            kaelberbox10.BackgroundImage = (Image)resources.GetObject("kaelberbox10.BackgroundImage");
            kaelberbox10.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox10.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox10.Location = new Point(314, 96);
            kaelberbox10.Name = "kaelberbox10";
            kaelberbox10.Size = new Size(150, 100);
            kaelberbox10.TabIndex = 1;
            // 
            // kaelberbox11
            // 
            kaelberbox11.BackColor = SystemColors.Control;
            kaelberbox11.BackgroundImage = (Image)resources.GetObject("kaelberbox11.BackgroundImage");
            kaelberbox11.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox11.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox11.Location = new Point(470, 96);
            kaelberbox11.Name = "kaelberbox11";
            kaelberbox11.Size = new Size(150, 100);
            kaelberbox11.TabIndex = 2;
            // 
            // kaelberbox12
            // 
            kaelberbox12.BackColor = SystemColors.Control;
            kaelberbox12.BackgroundImage = (Image)resources.GetObject("kaelberbox12.BackgroundImage");
            kaelberbox12.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox12.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox12.Location = new Point(626, 96);
            kaelberbox12.Name = "kaelberbox12";
            kaelberbox12.Size = new Size(150, 100);
            kaelberbox12.TabIndex = 3;
            // 
            // kaelberbox13
            // 
            kaelberbox13.BackColor = SystemColors.Control;
            kaelberbox13.BackgroundImage = (Image)resources.GetObject("kaelberbox13.BackgroundImage");
            kaelberbox13.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox13.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox13.Location = new Point(792, 96);
            kaelberbox13.Name = "kaelberbox13";
            kaelberbox13.Size = new Size(150, 100);
            kaelberbox13.TabIndex = 4;
            // 
            // kaelberbox14
            // 
            kaelberbox14.BackColor = SystemColors.Control;
            kaelberbox14.BackgroundImage = (Image)resources.GetObject("kaelberbox14.BackgroundImage");
            kaelberbox14.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox14.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox14.Location = new Point(959, 96);
            kaelberbox14.Name = "kaelberbox14";
            kaelberbox14.Size = new Size(150, 100);
            kaelberbox14.TabIndex = 5;
            // 
            // kaelberbox15
            // 
            kaelberbox15.BackColor = SystemColors.Control;
            kaelberbox15.BackgroundImage = (Image)resources.GetObject("kaelberbox15.BackgroundImage");
            kaelberbox15.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox15.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox15.Location = new Point(1209, 421);
            kaelberbox15.Name = "kaelberbox15";
            kaelberbox15.Size = new Size(150, 100);
            kaelberbox15.TabIndex = 6;
            // 
            // kaelberbox16
            // 
            kaelberbox16.BackColor = SystemColors.Control;
            kaelberbox16.BackgroundImage = (Image)resources.GetObject("kaelberbox16.BackgroundImage");
            kaelberbox16.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox16.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox16.Location = new Point(332, 119);
            kaelberbox16.Name = "kaelberbox16";
            kaelberbox16.Size = new Size(150, 100);
            kaelberbox16.TabIndex = 8;
            // 
            // kaelberbox17
            // 
            kaelberbox17.BackColor = SystemColors.Control;
            kaelberbox17.BackgroundImage = (Image)resources.GetObject("kaelberbox17.BackgroundImage");
            kaelberbox17.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox17.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox17.Location = new Point(679, 21);
            kaelberbox17.Name = "kaelberbox17";
            kaelberbox17.Size = new Size(150, 100);
            kaelberbox17.TabIndex = 9;
            // 
            // kaelberbox18
            // 
            kaelberbox18.BackColor = SystemColors.Control;
            kaelberbox18.BackgroundImage = (Image)resources.GetObject("kaelberbox18.BackgroundImage");
            kaelberbox18.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox18.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox18.Location = new Point(523, 21);
            kaelberbox18.Name = "kaelberbox18";
            kaelberbox18.Size = new Size(150, 100);
            kaelberbox18.TabIndex = 10;
            // 
            // kaelberbox19
            // 
            kaelberbox19.BackColor = SystemColors.Control;
            kaelberbox19.BackgroundImage = (Image)resources.GetObject("kaelberbox19.BackgroundImage");
            kaelberbox19.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox19.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox19.Location = new Point(679, 273);
            kaelberbox19.Name = "kaelberbox19";
            kaelberbox19.Size = new Size(150, 100);
            kaelberbox19.TabIndex = 11;
            // 
            // kaelberbox20
            // 
            kaelberbox20.BackColor = SystemColors.Control;
            kaelberbox20.BackgroundImage = (Image)resources.GetObject("kaelberbox20.BackgroundImage");
            kaelberbox20.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox20.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox20.Location = new Point(523, 273);
            kaelberbox20.Name = "kaelberbox20";
            kaelberbox20.Size = new Size(150, 100);
            kaelberbox20.TabIndex = 12;
            // 
            // kaelberbox21
            // 
            kaelberbox21.BackColor = SystemColors.Control;
            kaelberbox21.BackgroundImage = (Image)resources.GetObject("kaelberbox21.BackgroundImage");
            kaelberbox21.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox21.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox21.Location = new Point(104, 153);
            kaelberbox21.Name = "kaelberbox21";
            kaelberbox21.Size = new Size(150, 100);
            kaelberbox21.TabIndex = 13;
            // 
            // kaelberbox22
            // 
            kaelberbox22.BackColor = SystemColors.Control;
            kaelberbox22.BackgroundImage = (Image)resources.GetObject("kaelberbox22.BackgroundImage");
            kaelberbox22.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox22.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox22.Location = new Point(104, 273);
            kaelberbox22.Name = "kaelberbox22";
            kaelberbox22.Size = new Size(150, 100);
            kaelberbox22.TabIndex = 14;
            // 
            // DatenKaelberForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 685);
            Controls.Add(tcTabs);
            Name = "DatenKaelberForm";
            Text = "Kälber Daten";
            tcTabs.ResumeLayout(false);
            tcPageKaelber2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber2).EndInit();
            tcPageKaelber1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber).EndInit();
            tcStalluebersichtNeuerStall.ResumeLayout(false);
            tcStalluebersichtAlterStall.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tcTabs;
        private TabPage tcPageKaelber1;
        private TabPage tcPageKaelber2;
        private DataGridView dgvDatenKaelber;
        private Button btnAddKealber;
        private DataGridView dgvDatenKaelber2;
        private Button btnMilchmenge;
        private TabPage tcStalluebersichtAlterStall;
        private TabPage tcStalluebersichtNeuerStall;
        private Button btnPrint;
        private Kaelberbox kaelberbox8;
        private Kaelberbox kaelberbox7;
        private Kaelberbox kaelberbox6;
        private Kaelberbox kaelberbox5;
        private Kaelberbox kaelberbox4;
        private Kaelberbox kaelberbox3;
        private Kaelberbox kaelberbox2;
        private Kaelberbox kaelberbox1;
        private Kaelberbox kaelberbox15;
        private Kaelberbox kaelberbox14;
        private Kaelberbox kaelberbox13;
        private Kaelberbox kaelberbox12;
        private Kaelberbox kaelberbox11;
        private Kaelberbox kaelberbox10;
        private Kaelberbox kaelberbox9;
        private Kaelberbox kaelberbox22;
        private Kaelberbox kaelberbox21;
        private Kaelberbox kaelberbox20;
        private Kaelberbox kaelberbox19;
        private Kaelberbox kaelberbox18;
        private Kaelberbox kaelberbox17;
        private Kaelberbox kaelberbox16;
    }
}
