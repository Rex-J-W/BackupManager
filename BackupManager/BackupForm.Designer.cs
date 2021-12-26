namespace BackupManager
{
    partial class BackupForm
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
            this.statusText = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.title = new System.Windows.Forms.Label();
            this.backupButton = new System.Windows.Forms.Button();
            this.dirToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.LinkLabel();
            this.cleanButton = new System.Windows.Forms.Button();
            this.backupFolder = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.cleanFolder = new System.Windows.Forms.Button();
            this.threadLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.Location = new System.Drawing.Point(16, 42);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(38, 14);
            this.statusText.TabIndex = 1;
            this.statusText.Text = "Status";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(225, 33);
            this.title.TabIndex = 3;
            this.title.Text = "Found 0 out of 0";
            // 
            // backupButton
            // 
            this.backupButton.BackColor = System.Drawing.Color.PaleGreen;
            this.backupButton.Location = new System.Drawing.Point(18, 73);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(75, 27);
            this.backupButton.TabIndex = 4;
            this.backupButton.Text = "Backup";
            this.backupButton.UseVisualStyleBackColor = false;
            this.backupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // dirToolTip
            // 
            this.dirToolTip.ToolTipTitle = "Full Directory";
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.LightSalmon;
            this.stopButton.Location = new System.Drawing.Point(420, 73);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 27);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.directoryLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.directoryLabel.Location = new System.Drawing.Point(16, 56);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(59, 14);
            this.directoryLabel.TabIndex = 6;
            this.directoryLabel.TabStop = true;
            this.directoryLabel.Text = "(Directory)";
            this.directoryLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DirectoryLabel_LinkClicked);
            // 
            // cleanButton
            // 
            this.cleanButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cleanButton.Location = new System.Drawing.Point(219, 73);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(75, 27);
            this.cleanButton.TabIndex = 7;
            this.cleanButton.Text = "Clean";
            this.cleanButton.UseVisualStyleBackColor = false;
            this.cleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // backupFolder
            // 
            this.backupFolder.BackColor = System.Drawing.Color.PaleGreen;
            this.backupFolder.Location = new System.Drawing.Point(99, 73);
            this.backupFolder.Name = "backupFolder";
            this.backupFolder.Size = new System.Drawing.Size(114, 27);
            this.backupFolder.TabIndex = 8;
            this.backupFolder.Text = "Backup Folder";
            this.backupFolder.UseVisualStyleBackColor = false;
            this.backupFolder.Click += new System.EventHandler(this.BackupFolder_Click);
            // 
            // folderBrowser
            // 
            this.folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // cleanFolder
            // 
            this.cleanFolder.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cleanFolder.Location = new System.Drawing.Point(300, 73);
            this.cleanFolder.Name = "cleanFolder";
            this.cleanFolder.Size = new System.Drawing.Size(114, 27);
            this.cleanFolder.TabIndex = 9;
            this.cleanFolder.Text = "Clean Folder";
            this.cleanFolder.UseVisualStyleBackColor = false;
            this.cleanFolder.Click += new System.EventHandler(this.CleanFolder_Click);
            // 
            // threadLabel
            // 
            this.threadLabel.AutoSize = true;
            this.threadLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threadLabel.Location = new System.Drawing.Point(16, 103);
            this.threadLabel.Name = "threadLabel";
            this.threadLabel.Size = new System.Drawing.Size(62, 14);
            this.threadLabel.TabIndex = 10;
            this.threadLabel.Text = "Threads : 0";
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 127);
            this.Controls.Add(this.threadLabel);
            this.Controls.Add(this.cleanFolder);
            this.Controls.Add(this.backupFolder);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.backupButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.statusText);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "BackupForm";
            this.Text = "Backup Assistant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.ToolTip dirToolTip;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.LinkLabel directoryLabel;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Button backupFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button cleanFolder;
        private System.Windows.Forms.Label threadLabel;
    }
}

