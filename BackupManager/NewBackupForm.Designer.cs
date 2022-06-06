
namespace BackupManager
{
    partial class NewBackupForm
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
            this.directoryList = new System.Windows.Forms.CheckedListBox();
            this.optionsBox = new System.Windows.Forms.GroupBox();
            this.viewExceptions = new System.Windows.Forms.Button();
            this.clearExceptions = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.manualBackupButton = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.backupButton = new System.Windows.Forms.Button();
            this.excludeLabel = new System.Windows.Forms.Label();
            this.dirLabel = new System.Windows.Forms.LinkLabel();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.exceptionLabel = new System.Windows.Forms.Label();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.optionsBox.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoryList
            // 
            this.directoryList.CheckOnClick = true;
            this.directoryList.FormattingEnabled = true;
            this.directoryList.Location = new System.Drawing.Point(12, 25);
            this.directoryList.Name = "directoryList";
            this.directoryList.Size = new System.Drawing.Size(168, 364);
            this.directoryList.TabIndex = 0;
            // 
            // optionsBox
            // 
            this.optionsBox.Controls.Add(this.viewExceptions);
            this.optionsBox.Controls.Add(this.clearExceptions);
            this.optionsBox.Controls.Add(this.stopButton);
            this.optionsBox.Controls.Add(this.pauseButton);
            this.optionsBox.Controls.Add(this.manualBackupButton);
            this.optionsBox.Controls.Add(this.cleanButton);
            this.optionsBox.Controls.Add(this.backupButton);
            this.optionsBox.Location = new System.Drawing.Point(188, 13);
            this.optionsBox.Name = "optionsBox";
            this.optionsBox.Size = new System.Drawing.Size(200, 376);
            this.optionsBox.TabIndex = 1;
            this.optionsBox.TabStop = false;
            this.optionsBox.Text = "Options";
            // 
            // viewExceptions
            // 
            this.viewExceptions.BackColor = System.Drawing.Color.SeaShell;
            this.viewExceptions.Location = new System.Drawing.Point(6, 193);
            this.viewExceptions.Name = "viewExceptions";
            this.viewExceptions.Size = new System.Drawing.Size(188, 23);
            this.viewExceptions.TabIndex = 8;
            this.viewExceptions.Text = "View Exceptions";
            this.viewExceptions.UseVisualStyleBackColor = false;
            this.viewExceptions.Click += new System.EventHandler(this.ViewExceptions_Click);
            // 
            // clearExceptions
            // 
            this.clearExceptions.BackColor = System.Drawing.Color.SaddleBrown;
            this.clearExceptions.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.clearExceptions.Location = new System.Drawing.Point(6, 164);
            this.clearExceptions.Name = "clearExceptions";
            this.clearExceptions.Size = new System.Drawing.Size(188, 23);
            this.clearExceptions.TabIndex = 7;
            this.clearExceptions.Text = "Clear Exceptions";
            this.clearExceptions.UseVisualStyleBackColor = false;
            this.clearExceptions.Click += new System.EventHandler(this.ClearExceptions_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.LightSalmon;
            this.stopButton.Location = new System.Drawing.Point(6, 135);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(188, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pauseButton.Location = new System.Drawing.Point(6, 106);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(188, 23);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // manualBackupButton
            // 
            this.manualBackupButton.BackColor = System.Drawing.Color.Honeydew;
            this.manualBackupButton.Location = new System.Drawing.Point(6, 48);
            this.manualBackupButton.Name = "manualBackupButton";
            this.manualBackupButton.Size = new System.Drawing.Size(188, 23);
            this.manualBackupButton.TabIndex = 2;
            this.manualBackupButton.Text = "Manual Backup";
            this.manualBackupButton.UseVisualStyleBackColor = false;
            this.manualBackupButton.Click += new System.EventHandler(this.ManualBackupButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.BackColor = System.Drawing.Color.PowderBlue;
            this.cleanButton.Location = new System.Drawing.Point(6, 77);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(188, 23);
            this.cleanButton.TabIndex = 1;
            this.cleanButton.Text = "Clean";
            this.cleanButton.UseVisualStyleBackColor = false;
            this.cleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // backupButton
            // 
            this.backupButton.BackColor = System.Drawing.Color.PaleGreen;
            this.backupButton.Location = new System.Drawing.Point(6, 19);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(188, 23);
            this.backupButton.TabIndex = 0;
            this.backupButton.Text = "Backup";
            this.backupButton.UseVisualStyleBackColor = false;
            this.backupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // excludeLabel
            // 
            this.excludeLabel.AutoSize = true;
            this.excludeLabel.Location = new System.Drawing.Point(9, 9);
            this.excludeLabel.Name = "excludeLabel";
            this.excludeLabel.Size = new System.Drawing.Size(98, 13);
            this.excludeLabel.TabIndex = 2;
            this.excludeLabel.Text = "Exclude Directories";
            // 
            // dirLabel
            // 
            this.dirLabel.Location = new System.Drawing.Point(12, 399);
            this.dirLabel.Name = "dirLabel";
            this.dirLabel.Size = new System.Drawing.Size(583, 13);
            this.dirLabel.TabIndex = 4;
            this.dirLabel.TabStop = true;
            this.dirLabel.Text = "Current Directory";
            this.dirLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DirLabel_LinkClicked);
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.speedLabel);
            this.infoBox.Controls.Add(this.exceptionLabel);
            this.infoBox.Controls.Add(this.itemsLabel);
            this.infoBox.Controls.Add(this.statusLabel);
            this.infoBox.Location = new System.Drawing.Point(395, 13);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(200, 376);
            this.infoBox.TabIndex = 5;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Info";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(6, 45);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(44, 13);
            this.speedLabel.TabIndex = 3;
            this.speedLabel.Text = "Speed: ";
            // 
            // exceptionLabel
            // 
            this.exceptionLabel.AutoSize = true;
            this.exceptionLabel.Location = new System.Drawing.Point(6, 58);
            this.exceptionLabel.Name = "exceptionLabel";
            this.exceptionLabel.Size = new System.Drawing.Size(62, 13);
            this.exceptionLabel.TabIndex = 2;
            this.exceptionLabel.Text = "Exceptions:";
            // 
            // itemsLabel
            // 
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Location = new System.Drawing.Point(6, 32);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(67, 13);
            this.itemsLabel.TabIndex = 1;
            this.itemsLabel.Text = "Found 0 of 0";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(6, 19);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(84, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status: Cleaning";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // folderDialog
            // 
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderDialog.SelectedPath = "D:\\";
            // 
            // NewBackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 421);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.dirLabel);
            this.Controls.Add(this.excludeLabel);
            this.Controls.Add(this.optionsBox);
            this.Controls.Add(this.directoryList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewBackupForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "Backup Assistant";
            this.optionsBox.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox directoryList;
        private System.Windows.Forms.GroupBox optionsBox;
        private System.Windows.Forms.Button manualBackupButton;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.Label excludeLabel;
        private System.Windows.Forms.LinkLabel dirLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Label exceptionLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Button clearExceptions;
        private System.Windows.Forms.Button viewExceptions;
    }
}