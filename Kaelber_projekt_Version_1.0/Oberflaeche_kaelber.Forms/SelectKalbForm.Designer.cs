﻿namespace Oberflaeche_kaelber.Forms
{
    partial class SelectKalbForm
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
            cobxKaelberListe = new ComboBox();
            btnOk = new Button();
            btnRemoveKalb = new Button();
            SuspendLayout();
            // 
            // cobxKaelberListe
            // 
            cobxKaelberListe.FormattingEnabled = true;
            cobxKaelberListe.Location = new Point(12, 12);
            cobxKaelberListe.Name = "cobxKaelberListe";
            cobxKaelberListe.Size = new Size(129, 23);
            cobxKaelberListe.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(12, 48);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(129, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "Bestätigen";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnRemoveKalb
            // 
            btnRemoveKalb.Location = new Point(12, 83);
            btnRemoveKalb.Name = "btnRemoveKalb";
            btnRemoveKalb.Size = new Size(129, 23);
            btnRemoveKalb.TabIndex = 3;
            btnRemoveKalb.Text = "Kalb entfernen";
            btnRemoveKalb.UseVisualStyleBackColor = true;
            btnRemoveKalb.Click += btnRemoveKalb_Click_1;
            // 
            // SelectKalbForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(149, 118);
            Controls.Add(btnRemoveKalb);
            Controls.Add(btnOk);
            Controls.Add(cobxKaelberListe);
            Name = "SelectKalbForm";
            Text = "SelectKalbForm";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cobxKaelberListe;
        private Button btnOk;
        private Button btnRemoveKalb;
    }
}