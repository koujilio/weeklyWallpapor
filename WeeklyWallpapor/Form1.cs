
using System.Drawing.Imaging;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace WeeklyWallpapor
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void ChangeWallpaper(string filePath)
        {
           SystemParametersInfo(20, 0, filePath, 0);
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void WallpaporSelectionDialouge_p(object sender, EventArgs e)
        {
            PictureBox WallpaporSelectionDialouge_p = (PictureBox)sender;
            OpenFileDialog MyOpenFileDialog = new OpenFileDialog();
            MyOpenFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.webp;*.jfif;*.tiff)|*.png;*.jpg;*.jpeg;*.webp;*.jfif;*.tiff|All files (*.*)|*.*";
            //MessageBox.Show(this, WallpaporSelectionDialouge_p.Name);
            
            DialogResult MyDialogResult = MyOpenFileDialog.ShowDialog();
            if (MyDialogResult == DialogResult.OK) {
                int DayOfWeek = int.Parse(WallpaporSelectionDialouge_p.Tag.ToString());
                switch (DayOfWeek)
                {
                    case 1: Properties.Settings.Default.SaturdayPath = MyOpenFileDialog.FileName; WallpaporSelectionDialouge_p.Image = Image.FromFile(MyOpenFileDialog.FileName); break;
                    case 2: Properties.Settings.Default.SundayPath = MyOpenFileDialog.FileName; WallpaporSelectionDialouge_p.Image = Image.FromFile(MyOpenFileDialog.FileName); break;
                    case 3: Properties.Settings.Default.MondayPath = MyOpenFileDialog.FileName; WallpaporSelectionDialouge_p.Image = Image.FromFile(Properties.Settings.Default.MondayPath); Properties.Settings.Default.Save(); break;
                    case 4: Properties.Settings.Default.TuesdayPath = MyOpenFileDialog.FileName; WallpaporSelectionDialouge_p.Image = Image.FromFile(MyOpenFileDialog.FileName); break;
                    case 5: Properties.Settings.Default.WednesdayPath = MyOpenFileDialog.FileName; WallpaporSelectionDialouge_p.Image = Image.FromFile(MyOpenFileDialog.FileName); break;
                    case 6: Properties.Settings.Default.ThursdayPath = MyOpenFileDialog.FileName; WallpaporSelectionDialouge_p.Image = Image.FromFile(MyOpenFileDialog.FileName); break;
                    case 7: Properties.Settings.Default.FridayPath = MyOpenFileDialog.FileName; WallpaporSelectionDialouge_p.Image = Image.FromFile(MyOpenFileDialog.FileName); break;                        
                }

                Properties.Settings.Default.Save();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (System.IO.File.Exists(Properties.Settings.Default.SaturdayPath))
            {
                pictureBox1.Image = Image.FromFile(Properties.Settings.Default.SaturdayPath);
            }
            else
            {
                if (Properties.Settings.Default.SaturdayPath != "")
                {
                    pictureBox1.Image = Properties.Resources.Idkfile;
                }
            }

            if (System.IO.File.Exists(Properties.Settings.Default.SundayPath))
            {
                pictureBox2.Image = Image.FromFile(Properties.Settings.Default.SundayPath);
            }
            else
            {
                if (Properties.Settings.Default.SundayPath != "")
                {
                    pictureBox2.Image = Properties.Resources.Idkfile;
                }
            }

            if (System.IO.File.Exists(Properties.Settings.Default.MondayPath))
            {
                pictureBox3.Image = Image.FromFile(Properties.Settings.Default.MondayPath);
            }
            else
            {
                if (Properties.Settings.Default.MondayPath != "")
                {
                    pictureBox3.Image = Properties.Resources.Idkfile;
                }
            }

            if (System.IO.File.Exists(Properties.Settings.Default.TuesdayPath))
            {
                pictureBox4.Image = Image.FromFile(Properties.Settings.Default.TuesdayPath);
            }
            else
            {
                if (Properties.Settings.Default.TuesdayPath != "")
                {
                    pictureBox4.Image = Properties.Resources.Idkfile;
                }
            }

            if (System.IO.File.Exists(Properties.Settings.Default.WednesdayPath))
            {
                pictureBox5.Image = Image.FromFile(Properties.Settings.Default.WednesdayPath);
            }
            else
            {
                if (Properties.Settings.Default.WednesdayPath != "")
                {
                    pictureBox5.Image = Properties.Resources.Idkfile;
                }
            }

            if (System.IO.File.Exists(Properties.Settings.Default.ThursdayPath))
            {
                pictureBox6.Image = Image.FromFile(Properties.Settings.Default.ThursdayPath);
            }
            else
            {
                if (Properties.Settings.Default.ThursdayPath != "")
                {
                    pictureBox6.Image = Properties.Resources.Idkfile;
                }
            }

            if (System.IO.File.Exists(Properties.Settings.Default.FridayPath))
            {
                pictureBox7.Image = Image.FromFile(Properties.Settings.Default.FridayPath);
            }
            else
            {
                if (Properties.Settings.Default.FridayPath != "")
                {
                    pictureBox7.Image = Properties.Resources.Idkfile;
                }
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PictureBox[] pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7 };

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;
                pictureBox.Dispose();
            }

        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }

}
