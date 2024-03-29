﻿namespace Daste
{
    partial class Daste
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Daste));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.KeepFilesCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.KeepSourceCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ScanButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.HelpButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.FTypeCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KeepFilesCheck,
            this.KeepSourceCheck,
            this.toolStripMenuItem2,
            this.scanToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 76);
            // 
            // KeepFilesCheck
            // 
            this.KeepFilesCheck.Checked = true;
            this.KeepFilesCheck.CheckOnClick = true;
            this.KeepFilesCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KeepFilesCheck.ForeColor = System.Drawing.Color.White;
            this.KeepFilesCheck.Image = global::Daste.Properties.Resources.Rename;
            this.KeepFilesCheck.Name = "KeepFilesCheck";
            this.KeepFilesCheck.Size = new System.Drawing.Size(143, 22);
            this.KeepFilesCheck.Text = "Keep All Files";
            this.KeepFilesCheck.ToolTipText = "Automatically rename duplicate files.";
            // 
            // KeepSourceCheck
            // 
            this.KeepSourceCheck.Checked = true;
            this.KeepSourceCheck.CheckOnClick = true;
            this.KeepSourceCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KeepSourceCheck.ForeColor = System.Drawing.Color.White;
            this.KeepSourceCheck.Image = global::Daste.Properties.Resources.Copy;
            this.KeepSourceCheck.Name = "KeepSourceCheck";
            this.KeepSourceCheck.Size = new System.Drawing.Size(143, 22);
            this.KeepSourceCheck.Text = "Keep Source";
            this.KeepSourceCheck.ToolTipText = "Copy files.";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 6);
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.scanToolStripMenuItem.Image = global::Daste.Properties.Resources.Scan;
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.scanToolStripMenuItem.Text = "Go";
            this.scanToolStripMenuItem.Click += new System.EventHandler(this.ScanToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Controls.Add(this.ScanButton);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(13, 477);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(758, 71);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Process";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(8, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(592, 29);
            this.progressBar1.TabIndex = 16;
            // 
            // ScanButton
            // 
            this.ScanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScanButton.Image = global::Daste.Properties.Resources.Scan;
            this.ScanButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ScanButton.Location = new System.Drawing.Point(607, 30);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(144, 29);
            this.ScanButton.TabIndex = 8;
            this.ScanButton.Text = "Scan";
            this.ScanButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ScanButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(13, 248);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(758, 223);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(3, 25);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox4.Size = new System.Drawing.Size(752, 195);
            this.textBox4.TabIndex = 11;
            this.textBox4.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SettingsButton);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.HelpButton);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.FTypeCombo);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(13, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 152);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "                                     ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Options for";
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.BackColor = System.Drawing.Color.Black;
            this.SettingsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Image = global::Daste.Properties.Resources.Save;
            this.SettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.Location = new System.Drawing.Point(607, 113);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(144, 29);
            this.SettingsButton.TabIndex = 2;
            this.SettingsButton.Text = "Edit All Settings";
            this.SettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SettingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(8, 37);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(743, 29);
            this.textBox2.TabIndex = 4;
            // 
            // HelpButton
            // 
            this.HelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HelpButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Image = global::Daste.Properties.Resources.Help;
            this.HelpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpButton.Location = new System.Drawing.Point(8, 113);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(144, 29);
            this.HelpButton.TabIndex = 7;
            this.HelpButton.Text = "Pattern Help";
            this.HelpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HelpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(8, 76);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(743, 29);
            this.textBox3.TabIndex = 6;
            // 
            // FTypeCombo
            // 
            this.FTypeCombo.BackColor = System.Drawing.Color.Black;
            this.FTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FTypeCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FTypeCombo.ForeColor = System.Drawing.Color.White;
            this.FTypeCombo.FormattingEnabled = true;
            this.FTypeCombo.Items.AddRange(new object[] {
            "MP4",
            "MOV",
            "JPG",
            "EML"});
            this.FTypeCombo.Location = new System.Drawing.Point(95, 0);
            this.FTypeCombo.Name = "FTypeCombo";
            this.FTypeCombo.Size = new System.Drawing.Size(59, 29);
            this.FTypeCombo.TabIndex = 3;
            this.FTypeCombo.SelectedIndexChanged += new System.EventHandler(this.FTypeCombo_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.BrowseButton);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(758, 71);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(7, 30);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(593, 29);
            this.textBox1.TabIndex = 1;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Image = global::Daste.Properties.Resources.Open;
            this.BrowseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BrowseButton.Location = new System.Drawing.Point(607, 30);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(144, 29);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BrowseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // Daste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Daste";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Daste_FormClosing);
            this.Load += new System.EventHandler(this.Daste_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem KeepSourceCheck;
        private System.Windows.Forms.ToolStripMenuItem KeepFilesCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox FTypeCombo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BrowseButton;
    }
}

