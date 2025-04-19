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
            kaelberboxVertikal7 = new KaelberboxVertikal();
            kaelberboxVertikal6 = new KaelberboxVertikal();
            kaelberboxVertikal5 = new KaelberboxVertikal();
            kaelberboxVertikal4 = new KaelberboxVertikal();
            kaelberboxVertikal3 = new KaelberboxVertikal();
            kaelberboxVertikal2 = new KaelberboxVertikal();
            kaelberboxVertikal1 = new KaelberboxVertikal();
            kaelberbox8 = new Kaelberbox();
            kaelberbox7 = new Kaelberbox();
            kaelberbox6 = new Kaelberbox();
            kaelberbox5 = new Kaelberbox();
            kaelberbox4 = new Kaelberbox();
            kaelberbox3 = new Kaelberbox();
            kaelberbox2 = new Kaelberbox();
            kaelberbox1 = new Kaelberbox();
            tcStalluebersichtAlterStall = new TabPage();
            kaelberbox15 = new Kaelberbox();
            kaelberbox14 = new Kaelberbox();
            kaelberbox13 = new Kaelberbox();
            kaelberbox12 = new Kaelberbox();
            kaelberbox11 = new Kaelberbox();
            kaelberbox10 = new Kaelberbox();
            kaelberbox9 = new Kaelberbox();
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
            tcStalluebersichtNeuerStall.Controls.Add(kaelberboxVertikal7);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberboxVertikal6);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberboxVertikal5);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberboxVertikal4);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberboxVertikal3);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberboxVertikal2);
            tcStalluebersichtNeuerStall.Controls.Add(kaelberboxVertikal1);
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
            // kaelberboxVertikal7
            // 
            kaelberboxVertikal7.BackColor = Color.Beige;
            kaelberboxVertikal7.BackgroundImage = (Image)resources.GetObject("kaelberboxVertikal7.BackgroundImage");
            kaelberboxVertikal7.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberboxVertikal7.BorderStyle = BorderStyle.FixedSingle;
            kaelberboxVertikal7.Location = new Point(690, 309);
            kaelberboxVertikal7.Name = "kaelberboxVertikal7";
            kaelberboxVertikal7.Size = new Size(100, 150);
            kaelberboxVertikal7.TabIndex = 21;
            // 
            // kaelberboxVertikal6
            // 
            kaelberboxVertikal6.BackColor = Color.Beige;
            kaelberboxVertikal6.BackgroundImage = (Image)resources.GetObject("kaelberboxVertikal6.BackgroundImage");
            kaelberboxVertikal6.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberboxVertikal6.BorderStyle = BorderStyle.FixedSingle;
            kaelberboxVertikal6.Location = new Point(573, 309);
            kaelberboxVertikal6.Name = "kaelberboxVertikal6";
            kaelberboxVertikal6.Size = new Size(100, 150);
            kaelberboxVertikal6.TabIndex = 20;
            // 
            // kaelberboxVertikal5
            // 
            kaelberboxVertikal5.BackColor = Color.Beige;
            kaelberboxVertikal5.BackgroundImage = (Image)resources.GetObject("kaelberboxVertikal5.BackgroundImage");
            kaelberboxVertikal5.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberboxVertikal5.BorderStyle = BorderStyle.FixedSingle;
            kaelberboxVertikal5.Location = new Point(188, 157);
            kaelberboxVertikal5.Name = "kaelberboxVertikal5";
            kaelberboxVertikal5.Size = new Size(100, 150);
            kaelberboxVertikal5.TabIndex = 19;
            // 
            // kaelberboxVertikal4
            // 
            kaelberboxVertikal4.BackColor = Color.Beige;
            kaelberboxVertikal4.BackgroundImage = (Image)resources.GetObject("kaelberboxVertikal4.BackgroundImage");
            kaelberboxVertikal4.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberboxVertikal4.BorderStyle = BorderStyle.FixedSingle;
            kaelberboxVertikal4.Location = new Point(82, 157);
            kaelberboxVertikal4.Name = "kaelberboxVertikal4";
            kaelberboxVertikal4.Size = new Size(100, 150);
            kaelberboxVertikal4.TabIndex = 18;
            // 
            // kaelberboxVertikal3
            // 
            kaelberboxVertikal3.BackColor = Color.Beige;
            kaelberboxVertikal3.BackgroundImage = (Image)resources.GetObject("kaelberboxVertikal3.BackgroundImage");
            kaelberboxVertikal3.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberboxVertikal3.BorderStyle = BorderStyle.FixedSingle;
            kaelberboxVertikal3.Location = new Point(690, 21);
            kaelberboxVertikal3.Name = "kaelberboxVertikal3";
            kaelberboxVertikal3.Size = new Size(100, 150);
            kaelberboxVertikal3.TabIndex = 17;
            // 
            // kaelberboxVertikal2
            // 
            kaelberboxVertikal2.BackColor = Color.Beige;
            kaelberboxVertikal2.BackgroundImage = (Image)resources.GetObject("kaelberboxVertikal2.BackgroundImage");
            kaelberboxVertikal2.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberboxVertikal2.BorderStyle = BorderStyle.FixedSingle;
            kaelberboxVertikal2.Location = new Point(573, 21);
            kaelberboxVertikal2.Name = "kaelberboxVertikal2";
            kaelberboxVertikal2.Size = new Size(100, 150);
            kaelberboxVertikal2.TabIndex = 16;
            // 
            // kaelberboxVertikal1
            // 
            kaelberboxVertikal1.BackColor = Color.Beige;
            kaelberboxVertikal1.BackgroundImage = (Image)resources.GetObject("kaelberboxVertikal1.BackgroundImage");
            kaelberboxVertikal1.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberboxVertikal1.BorderStyle = BorderStyle.FixedSingle;
            kaelberboxVertikal1.Location = new Point(332, 90);
            kaelberboxVertikal1.Name = "kaelberboxVertikal1";
            kaelberboxVertikal1.Size = new Size(100, 150);
            kaelberboxVertikal1.TabIndex = 15;
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
        private KaelberboxVertikal kaelberboxVertikal5;
        private KaelberboxVertikal kaelberboxVertikal4;
        private KaelberboxVertikal kaelberboxVertikal3;
        private KaelberboxVertikal kaelberboxVertikal2;
        private KaelberboxVertikal kaelberboxVertikal1;
        private KaelberboxVertikal kaelberboxVertikal7;
        private KaelberboxVertikal kaelberboxVertikal6;
    }
}
