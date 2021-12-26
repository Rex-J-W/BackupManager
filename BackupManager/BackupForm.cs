using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupManager
{
    public partial class BackupForm : Form
    {

        public readonly static string backupSrc = @"R:\Users";
        public readonly static string backupDest = @"F:\NewRUsersBackup";

        private bool canceled = false;
        private string selectedSrc = string.Empty;
        public static string statusMsg = "Un-Initialized";
        public static int itemCount = 0;
        public static int operatedCount = 0;
        public static int threadCount = 0;
        public static string currentDir = string.Empty;

        public BackupForm() => InitializeComponent();

        private void Timer_Tick(object sender, EventArgs e)
        {
            string displayDir = currentDir;
            if (displayDir.Length > 75) displayDir = "..." + displayDir.Substring(displayDir.Length - 75);
            directoryLabel.Text = displayDir;
            statusText.Text = statusMsg + "...";
            title.Text = "Found " + string.Format("{0:n0}", operatedCount) + " out of " + string.Format("{0:n0}", itemCount);
            threadLabel.Text = "Threads : " + threadCount;
        }

        private async void BackupButton_Click(object sender, EventArgs e)
        {
            selectedSrc = backupSrc;
            Initialize();
            try { await Task.Run(StartCopying); }
            catch (TaskCanceledException) { }
            Finish();
        }

        private async void BackupFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowser.ShowDialog(this);
            if ((result == DialogResult.OK) &&
                !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath) &&
                folderBrowser.SelectedPath.Contains(backupSrc))
            {
                selectedSrc = folderBrowser.SelectedPath;
                Initialize();
                try { await Task.Run(StartCopying); }
                catch (TaskCanceledException) { }
                Finish();
            }
            else statusMsg = "Folder Unavailable";
        }

        private async void CleanButton_Click(object sender, EventArgs e)
        {
            selectedSrc = backupSrc;
            Initialize();
            try { await Task.Run(StartClean); }
            catch (TaskCanceledException) { }
            Finish();
        }

        private async void CleanFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowser.ShowDialog(this);
            if ((result == DialogResult.OK) &&
                !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath) &&
                folderBrowser.SelectedPath.Contains(backupSrc))
            {
                selectedSrc = folderBrowser.SelectedPath.Replace(backupSrc, backupDest);
                Initialize();
                try { await Task.Run(StartClean); }
                catch (TaskCanceledException) { }
                Finish();
            }
            else statusMsg = "Folder Unavailable";
        }

        private void StopButton_Click(object sender, EventArgs e) => canceled = true;

        private void DirectoryLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentDir.Contains(":")) Process.Start(currentDir);
            else if (Directory.Exists(backupSrc + "\\" + currentDir)) Process.Start(backupSrc + "\\" + currentDir);
        }

        private void Initialize()
        {
            canceled = false;
            backupButton.Enabled = false;
            cleanButton.Enabled = false;
            backupFolder.Enabled = false;
            cleanFolder.Enabled = false;
            statusMsg = "Starting Main Thread";
            currentDir = backupDest;
            itemCount = 0;
            operatedCount = 0;
        }

        private void Finish()
        {
            selectedSrc = string.Empty;
            backupButton.Enabled = true;
            cleanButton.Enabled = true;
            backupFolder.Enabled = true;
            cleanFolder.Enabled = true;
            statusMsg = "Finished Main Thread";
            currentDir = backupDest;
        }

        private void StartCopying()
        {
            statusMsg = "Searching";
            foreach (string file in Directory.EnumerateFiles(selectedSrc, "*", SearchOption.TopDirectoryOnly))
            {
                if (canceled) return;
                itemCount++;
                if (!file.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)) CheckFile(file);
            }

            foreach (string dir in Directory.EnumerateDirectories(selectedSrc, "*", SearchOption.AllDirectories))
            {
                itemCount++;
                statusMsg = "Searching Directories";
                bool createdDir = false;
                string createDir = dir.Replace(backupSrc, backupDest);
                if (!Directory.Exists(createDir))
                {
                    statusMsg = "Creating Directory";
                    try
                    {
                        _ = Directory.CreateDirectory(createDir);
                        createdDir = true;
                        operatedCount++;
                    }
                    catch (Exception e) { Debug.WriteLine("Create Directory | " + dir + "\n\t" + e.Message); }
                }
                currentDir = dir.Replace(backupSrc, string.Empty).Remove(0, 1);

                if (createdDir)
                {
                    statusMsg = "Copying All Directory Files";
                    foreach (string file in Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly))
                    {
                        if (canceled) return;
                        itemCount++;
                        if (!file.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                        {
                            threadCount++;
                            Task.Run(() =>
                            {
                                if (canceled)
                                {
                                    threadCount--;
                                    return;
                                }
                                try
                                {
                                    string destFile = file.Replace(backupSrc, backupDest);
                                    File.Copy(file, destFile, true);
                                }
                                catch (Exception e) { Debug.WriteLine("Copy File | " + file + "\n\t" + e.Message); }
                                threadCount--;
                                operatedCount++;
                            });
                        }
                    }
                }
                else
                {
                    statusMsg = "Searching";
                    foreach (string file in Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly))
                    {
                        if (canceled) return;
                        itemCount++;
                        if (!file.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)) CheckFile(file);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckFile(string file)
        {
            string destFile = file.Replace(backupSrc, backupDest);
            FileStream srcStream = File.OpenRead(file);
            if (!File.Exists(destFile) || new FileInfo(destFile).Length != srcStream.Length)
            {
                threadCount++;
                Task.Run(() =>
                {
                    if (canceled)
                    {
                        threadCount--;
                        return;
                    }
                    try
                    {
                        File.Copy(file, destFile, true);
                    }
                    catch (Exception e) { Debug.WriteLine("Copy File | " + file + "\n\t" + e.Message); }
                    threadCount--;
                    operatedCount++;
                });
            }
            srcStream.Dispose();
        }

        private void StartClean()
        {
            foreach (string file in Directory.EnumerateFiles(selectedSrc, "*", SearchOption.TopDirectoryOnly))
            {
                itemCount++;
                statusMsg = "Searching";
                if (canceled) return;
                else if (!File.Exists(file.Replace(backupDest, backupSrc)))
                {
                    try
                    {
                        statusMsg = "Cleaning";
                        operatedCount++;
                        File.Delete(file);
                    }
                    catch (Exception e) { Debug.WriteLine("Delete File | " + file + "\n\t" + e.Message); }
                }
            }

            foreach (string dir in Directory.EnumerateDirectories(selectedSrc, "*", SearchOption.AllDirectories))
            {
                statusMsg = "Searching";
                currentDir = dir.Replace(backupDest, string.Empty).Remove(0, 1);
                itemCount++;

                if (!Directory.Exists(dir.Replace(backupDest, backupSrc)))
                {
                    statusMsg = "Cleaning";
                    if (canceled) return;
                    try 
                    {
                        int entries = Directory.GetFileSystemEntries(dir, "*", SearchOption.AllDirectories).Length;
                        operatedCount += entries;
                        itemCount += entries;
                        Directory.Delete(dir, true);
                    }
                    catch (Exception e) { Debug.WriteLine("Delete Directory | " + dir + "\n\t" + e.Message); }
                    operatedCount++;
                }
                else
                {
                    foreach (string file in Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly))
                    {
                        itemCount++;
                        statusMsg = "Searching";
                        if (canceled) return;
                        else if (!File.Exists(file.Replace(backupDest, backupSrc)))
                        {
                            try 
                            {
                                statusMsg = "Cleaning";
                                operatedCount++;
                                File.Delete(file);
                            }
                            catch (Exception e) { Debug.WriteLine("Delete File | " + file + "\n\t" + e.Message); }
                        }
                    }
                }
            }
            return;
        }
    }
}
