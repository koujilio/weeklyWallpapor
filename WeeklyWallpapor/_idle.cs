using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeeklyWallpapor
{
    public partial class _idle : Form
    {
        public _idle()
        {
            InitializeComponent();
        }

        private void _idle_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        public static string DayOfWeekSettingsToPath()
        {
            string StrDayOfWeek = DayOfWeekChecker.GetDayOfWeek();
            return (string)Properties.Settings.Default[StrDayOfWeek+"Path"];
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //string Path = ;
            WallpaperChanger dawallpaperChanger = new WallpaperChanger();
            //MessageBox.Show(Path,"shit");
            dawallpaperChanger.ChangeWallpaper(DayOfWeekSettingsToPath());
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            DialogResult result = form1.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Cancel)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                int generation = GC.GetGeneration(form1);
                GC.Collect();
                form1 = null;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(disableToolStripMenuItem.Text == "enable")
            {
                timer1.Start();
                disableToolStripMenuItem.Text = "disable";
                notifyIcon1.Text = "WeeklyWallpapor (Active)";
                notifyIcon1.Icon = app_res.wallpapor_synced;
            }
            else
            {
                notifyIcon1.Icon = app_res.wallpapor_disabled;
                notifyIcon1.Text = "WeeklyWallpapor (disabled)";
                timer1.Stop();
                disableToolStripMenuItem.Text = "enable";
            }
            
        }
    }
}
