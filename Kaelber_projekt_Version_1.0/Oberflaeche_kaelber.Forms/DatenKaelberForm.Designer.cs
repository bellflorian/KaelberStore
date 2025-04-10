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
            tcStalluebersicht = new TabPage();
            kaelberbox1 = new Kaelberbox();
            panel5 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            tcPageKaelber1 = new TabPage();
            btnAddKealber = new Button();
            dgvDatenKaelber = new DataGridView();
            tcPageKaelber2 = new TabPage();
            dgvDatenKaelber2 = new DataGridView();
            btnMilchmenge = new Button();
            btnPrint = new Button();
            tcTabs.SuspendLayout();
            tcStalluebersicht.SuspendLayout();
            tcPageKaelber1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber).BeginInit();
            tcPageKaelber2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber2).BeginInit();
            SuspendLayout();
            // 
            // tcTabs
            // 
            tcTabs.Controls.Add(tcStalluebersicht);
            tcTabs.Controls.Add(tcPageKaelber1);
            tcTabs.Controls.Add(tcPageKaelber2);
            tcTabs.Dock = DockStyle.Fill;
            tcTabs.Location = new Point(0, 0);
            tcTabs.Name = "tcTabs";
            tcTabs.SelectedIndex = 0;
            tcTabs.Size = new Size(1370, 685);
            tcTabs.TabIndex = 3;
            // 
            // tcStalluebersicht
            // 
            tcStalluebersicht.BackColor = SystemColors.Control;
            tcStalluebersicht.Controls.Add(kaelberbox1);
            tcStalluebersicht.Controls.Add(panel5);
            tcStalluebersicht.Controls.Add(panel4);
            tcStalluebersicht.Controls.Add(panel3);
            tcStalluebersicht.Controls.Add(panel2);
            tcStalluebersicht.Controls.Add(panel1);
            tcStalluebersicht.Location = new Point(4, 24);
            tcStalluebersicht.Name = "tcStalluebersicht";
            tcStalluebersicht.Size = new Size(1362, 657);
            tcStalluebersicht.TabIndex = 2;
            tcStalluebersicht.Text = "Stallübersicht";
            // 
            // kaelberbox1
            // 
            kaelberbox1.BackColor = SystemColors.Control;
            kaelberbox1.BackgroundImage = (Image)resources.GetObject("kaelberbox1.BackgroundImage");
            kaelberbox1.BackgroundImageLayout = ImageLayout.Zoom;
            kaelberbox1.BorderStyle = BorderStyle.FixedSingle;
            kaelberbox1.Location = new Point(76, 43);
            kaelberbox1.Name = "kaelberbox1";
            kaelberbox1.Size = new Size(150, 100);
            kaelberbox1.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.AppWorkspace;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.ForeColor = SystemColors.ControlText;
            panel5.Location = new Point(23, 617);
            panel5.Name = "panel5";
            panel5.Size = new Size(520, 10);
            panel5.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.AppWorkspace;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.ForeColor = SystemColors.ControlText;
            panel4.Location = new Point(769, 17);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 610);
            panel4.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.ForeColor = SystemColors.ControlText;
            panel3.Location = new Point(479, 17);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 10);
            panel3.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(23, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 10);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(22, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 610);
            panel1.TabIndex = 0;
            // 
            // tcPageKaelber1
            // 
            tcPageKaelber1.BackColor = SystemColors.Control;
            tcPageKaelber1.Controls.Add(btnPrint);
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
            btnAddKealber.Size = new Size(1164, 34);
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
            // 
            // tcPageKaelber2
            // 
            tcPageKaelber2.BackColor = SystemColors.Control;
            tcPageKaelber2.Controls.Add(dgvDatenKaelber2);
            tcPageKaelber2.Controls.Add(btnMilchmenge);
            tcPageKaelber2.Location = new Point(4, 24);
            tcPageKaelber2.Name = "tcPageKaelber2";
            tcPageKaelber2.Padding = new Padding(3);
            tcPageKaelber2.Size = new Size(1362, 657);
            tcPageKaelber2.TabIndex = 1;
            tcPageKaelber2.Text = "Übersicht Kälber";
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
            btnMilchmenge.Size = new Size(1356, 34);
            btnMilchmenge.TabIndex = 3;
            btnMilchmenge.Text = "Berechne Milchmenge";
            btnMilchmenge.UseVisualStyleBackColor = true;
            btnMilchmenge.Click += btnMilchmenge_Click_1;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(1173, 615);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(181, 34);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "Drucken";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
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
            tcStalluebersicht.ResumeLayout(false);
            tcPageKaelber1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber).EndInit();
            tcPageKaelber2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber2).EndInit();
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
        private TabPage tcStalluebersicht;
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
        private Kaelberbox kaelberbox1;
        private Button btnPrint;
    }
}
