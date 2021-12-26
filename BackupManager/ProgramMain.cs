using System;
using System.Windows.Forms;

namespace BackupManager
{
    public static class ProgramMain
    {

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NewBackupForm form = new NewBackupForm();
            Application.Run(form);
        }

    }
}
