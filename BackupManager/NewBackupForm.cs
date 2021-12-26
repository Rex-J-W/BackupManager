using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupManager
{
    public partial class NewBackupForm : Form
    {

        private enum State
        {
            Running, Paused, Stopped
        }

        public readonly static string backupSrc = @"D:\";
        public readonly static string backupDest = @"R:\RexsPCBackup\";
        public readonly static string settingsFileRel = @"\settings.txt";
        public const int exceptionCount = 10;

        private State state = State.Stopped;
        private string selectedSrc = string.Empty;
        private int exceptionId = 0;
        public static string statusMsg = "Initialized";
        public static string settingsFile = string.Empty;
        public static int itemCount = 0;
        public static int operatedCount = 0;
        public static DateTime startTime;
        public static float progress = 0f;
        public static string currentDir = string.Empty;
        public static List<string> noGoDirs = new List<string>();
        public static List<string> topDirList = new List<string>();
        public static List<string> exceptions = new List<string>();

        public NewBackupForm()
        {
            InitializeComponent();
            settingsFile = Directory.GetCurrentDirectory() + settingsFileRel;
            List<string> savedDirs = new List<string>();
            if (File.Exists(settingsFile))
            {
                string[] lines = File.ReadAllLines(settingsFile);
                for (int i = 0; i < lines.Length; i++)
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                        savedDirs.Add(lines[i]);
            }

            string[] dirs = Directory.GetDirectories(backupSrc);
            for (int i = 0; i < dirs.Length; i++)
            {
                topDirList.Add(dirs[i]);
                directoryList.Items.Add(dirs[i].Replace(backupSrc, string.Empty), savedDirs.Contains(dirs[i]));
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            statusLabel.Text = "Status: " + statusMsg;
            if (state == State.Running)
            {
                itemsLabel.Text = "Found " + operatedCount + " of " + itemCount;
                if (startTime != null)
                    speedLabel.Text = "Speed: " +
                        Math.Round(itemCount / DateTime.Now.Subtract(startTime).TotalSeconds, 1) +
                        " items per second";
                dirLabel.Text = currentDir;
                string exceptionText = "Exceptions:";
                for (int i = 0; i < exceptions.Count; i++)
                    exceptionText += "\n" + exceptions[i];
                exceptionLabel.Text = exceptionText;
            }
            else if (state == State.Stopped)
            {
                noGoDirs.Clear();
                string settings = string.Empty;
                for (int i = 0; i < topDirList.Count; i++)
                {
                    if (directoryList.CheckedIndices.Contains(i))
                    {
                        settings += topDirList[i] + "\n";
                        noGoDirs.Add(topDirList[i]);
                    }
                }
                File.WriteAllText(settingsFile, settings);
            }
        }

        private async void BackupButton_Click(object sender, EventArgs e)
        {
            state = State.Running;
            startTime = DateTime.Now;
            itemCount = 0;
            operatedCount = 0;
            backupButton.Enabled = false;
            manualBackupButton.Enabled = false;
            cleanButton.Enabled = false;

            selectedSrc = backupSrc;
            currentDir = backupSrc;

            string[] subDirs = Directory.GetDirectories(selectedSrc);
            for (int i = 0; i < subDirs.Length; i++)
            {
                if (state == State.Stopped) break;
                while (state == State.Paused) await Task.Delay(1);
                if (!noGoDirs.Contains(subDirs[i]))
                {
                    string subDestDir = subDirs[i].Replace(backupSrc, backupDest);
                    if (!Directory.Exists(subDestDir)) Directory.CreateDirectory(subDestDir);
                    try
                    {
                        foreach (string file in Directory.EnumerateFiles(subDirs[i], "*", SearchOption.TopDirectoryOnly))
                        {
                            if (state == State.Stopped) break;
                            while (state == State.Paused) await Task.Delay(1);
                            statusMsg = "Searching";
                            itemCount++;
                            string destFile = file.Replace(backupSrc, backupDest);
                            if (CanCopyFile(file, destFile))
                            {
                                statusMsg = "Copying";
                                await Task.Delay(1);
                                File.Copy(file, destFile);
                                operatedCount++;
                            }
                        }
                    }
                    catch (Exception ex) { ExceptionHandler(ex); }
                    await Task.Delay(1);

                    foreach (string dir in Directory.EnumerateDirectories(subDirs[i], "*", SearchOption.AllDirectories))
                    {
                        if (state == State.Stopped) break;
                        while (state == State.Paused) await Task.Delay(1);
                        currentDir = dir;
                        statusMsg = "Searching";
                        itemCount++;
                        string destDir = dir.Replace(backupSrc, backupDest);
                        try
                        {
                            if (!Directory.Exists(destDir))
                            {
                                Directory.CreateDirectory(destDir);
                                operatedCount++;
                            }

                            foreach (string file in Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly))
                            {
                                if (state == State.Stopped) break;
                                while (state == State.Paused) await Task.Delay(1);
                                statusMsg = "Searching";
                                itemCount++;
                                string destFile = file.Replace(backupSrc, backupDest);
                                if (CanCopyFile(file, destFile))
                                {
                                    statusMsg = "Copying";
                                    await Task.Delay(1);
                                    File.Copy(file, destFile);
                                    operatedCount++;
                                }
                            }
                        }
                        catch (Exception ex) { ExceptionHandler(ex); }
                        await Task.Delay(1);
                    }
                }
            }

            statusMsg = "Finished";
            cleanButton.Enabled = true;
            manualBackupButton.Enabled = true;
            backupButton.Enabled = true;
            state = State.Stopped;
        }

        private async void ManualBackupButton_Click(object sender, EventArgs e)
        {
            state = State.Running;
            startTime = DateTime.Now;
            itemCount = 0;
            operatedCount = 0;
            backupButton.Enabled = false;
            manualBackupButton.Enabled = false;
            cleanButton.Enabled = false;

            DialogResult folderResult = folderDialog.ShowDialog();
            if (folderResult == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(folderDialog.SelectedPath) &&
                folderDialog.SelectedPath.Contains(backupSrc))
            {
                selectedSrc = folderDialog.SelectedPath + "\\";
                currentDir = folderDialog.SelectedPath + "\\";
                string destDir = selectedSrc.Replace(backupSrc, backupDest);
                if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);

                try
                {
                    foreach (string file in Directory.EnumerateFiles(selectedSrc, "*", SearchOption.TopDirectoryOnly))
                    {
                        if (state == State.Stopped) break;
                        while (state == State.Paused) await Task.Delay(1);
                        statusMsg = "Searching";
                        itemCount++;
                        string destFile = file.Replace(backupSrc, backupDest);
                        if (CanCopyFile(file, destFile))
                        {
                            statusMsg = "Copying";
                            await Task.Delay(1);
                            File.Copy(file, destFile);
                            operatedCount++;
                        }
                    }
                }
                catch (Exception ex) { ExceptionHandler(ex); }

                string[] subDirs = Directory.GetDirectories(selectedSrc);
                Debug.WriteLine(subDirs[0]);
                for (int i = 0; i < subDirs.Length; i++)
                {
                    if (state == State.Stopped) break;
                    while (state == State.Paused) await Task.Delay(1);
                    if (!noGoDirs.Contains(subDirs[i]))
                    {
                        string subDestDir = subDirs[i].Replace(backupSrc, backupDest);
                        if (!Directory.Exists(subDestDir)) Directory.CreateDirectory(subDestDir);
                        try
                        {
                            foreach (string file in Directory.EnumerateFiles(subDirs[i], "*", SearchOption.TopDirectoryOnly))
                            {
                                if (state == State.Stopped) break;
                                while (state == State.Paused) await Task.Delay(1);
                                statusMsg = "Searching";
                                itemCount++;
                                string destFile = file.Replace(backupSrc, backupDest);
                                if (CanCopyFile(file, destFile))
                                {
                                    statusMsg = "Copying";
                                    await Task.Delay(1);
                                    File.Copy(file, destFile);
                                    operatedCount++;
                                }
                            }
                        }
                        catch (Exception ex) { ExceptionHandler(ex); }
                        await Task.Delay(1);

                        foreach (string dir in Directory.EnumerateDirectories(subDirs[i], "*", SearchOption.AllDirectories))
                        {
                            if (state == State.Stopped) break;
                            while (state == State.Paused) await Task.Delay(1);
                            currentDir = dir;
                            statusMsg = "Searching";
                            itemCount++;
                            destDir = dir.Replace(backupSrc, backupDest);
                            try
                            {
                                if (!Directory.Exists(destDir))
                                {
                                    Directory.CreateDirectory(destDir);
                                    operatedCount++;
                                }

                                foreach (string file in Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly))
                                {
                                    if (state == State.Stopped) break;
                                    while (state == State.Paused) await Task.Delay(1);
                                    statusMsg = "Searching";
                                    itemCount++;
                                    string destFile = file.Replace(backupSrc, backupDest);
                                    if (CanCopyFile(file, destFile))
                                    {
                                        statusMsg = "Copying";
                                        await Task.Delay(1);
                                        File.Copy(file, destFile);
                                        operatedCount++;
                                    }
                                }
                            }
                            catch (Exception ex) { ExceptionHandler(ex); }
                            await Task.Delay(1);
                        }
                    }
                }
            }

            statusMsg = "Finished";
            cleanButton.Enabled = true;
            manualBackupButton.Enabled = true;
            backupButton.Enabled = true;
            state = State.Stopped;
        }

        private bool CanCopyFile(string srcFile, string destFile)
        {
            if (Path.GetExtension(srcFile) == ".dll") return false;
            if (File.Exists(destFile))
            {
                FileInfo srcInfo = new FileInfo(srcFile),
                        destInfo = new FileInfo(destFile);
                if (srcInfo.Length != destInfo.Length) return true;
                else return false;
            }
            else return true;
        }

        private async void CleanButton_Click(object sender, EventArgs e)
        {
            state = State.Running;
            startTime = DateTime.Now;
            itemCount = 0;
            operatedCount = 0;
            backupButton.Enabled = false;
            manualBackupButton.Enabled = false;
            cleanButton.Enabled = false;

            selectedSrc = backupDest;
            currentDir = backupDest;

            foreach (string dir in Directory.EnumerateDirectories(selectedSrc, "*", SearchOption.AllDirectories))
            {
                if (state == State.Stopped) break;
                while (state == State.Paused) await Task.Delay(1);
                currentDir = dir;
                statusMsg = "Searching";
                itemCount++;
                string srcDir = dir.Replace(backupDest, backupSrc);
                if (!Directory.Exists(srcDir))
                {
                    statusMsg = "Deleting";
                    foreach (string file in Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories))
                    {
                        if (state == State.Stopped) break;
                        while (state == State.Paused) await Task.Delay(1);
                        itemCount++;
                        operatedCount++;
                        await Task.Delay(1);
                        File.Delete(file);
                    }
                    int subDirs = Directory.GetFileSystemEntries(dir, "*", SearchOption.AllDirectories).Length;
                    operatedCount += subDirs;
                    itemCount += subDirs;
                    operatedCount++;
                    Directory.Delete(dir, true);
                    await Task.Delay(1);
                }
                else
                {
                    foreach (string file in Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly))
                    {
                        if (state == State.Stopped) break;
                        while (state == State.Paused) await Task.Delay(1);
                        statusMsg = "Searching";
                        itemCount++;
                        if (!File.Exists(file.Replace(backupDest, backupSrc)))
                        {
                            statusMsg = "Deleting";
                            operatedCount++;
                            await Task.Delay(1);
                            File.Delete(file);
                        }
                    }
                }
                await Task.Delay(1);
            }

            statusMsg = "Finished";
            cleanButton.Enabled = true;
            manualBackupButton.Enabled = true;
            backupButton.Enabled = true;
            state = State.Stopped;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (state == State.Running)
            {
                state = State.Paused;
                pauseButton.Text = "Play";
            }
            else if (state == State.Paused)
            {
                state = State.Running;
                pauseButton.Text = "Pause";
            }
        }

        private void StopButton_Click(object sender, EventArgs e) => state = State.Stopped;

        private void DirLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(currentDir);

        private void ExceptionHandler(Exception e)
        {
            exceptions.Insert(0, exceptionId + ": " + e.GetType().Name);
            if (exceptions.Count > exceptionCount) exceptions.RemoveAt(exceptions.Count - 1);
            exceptionId++;
        }

    }
}
