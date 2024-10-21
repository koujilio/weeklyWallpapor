using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeeklyWallpapor
{
    internal static class Program
    {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new _idle());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Another instance of application is already running","Weekly Wallpapor",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
