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
            tcTabs.SuspendLayout();
            tcPageKaelber2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber2).BeginInit();
            tcPageKaelber1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatenKaelber).BeginInit();
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
            tcStalluebersichtNeuerStall.Location = new Point(4, 24);
            tcStalluebersichtNeuerStall.Name = "tcStalluebersichtNeuerStall";
            tcStalluebersichtNeuerStall.Size = new Size(1362, 657);
            tcStalluebersichtNeuerStall.TabIndex = 2;
            tcStalluebersichtNeuerStall.Text = " Stallübersicht Neuer Stall";
            // 
            // tcStalluebersichtAlterStall
            // 
            tcStalluebersichtAlterStall.BackColor = SystemColors.Control;
            tcStalluebersichtAlterStall.Location = new Point(4, 24);
            tcStalluebersichtAlterStall.Name = "tcStalluebersichtAlterStall";
            tcStalluebersichtAlterStall.Size = new Size(1362, 657);
            tcStalluebersichtAlterStall.TabIndex = 3;
            tcStalluebersichtAlterStall.Text = "Stallübersicht Alter Stall";
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
    }
}
