using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;


class DayOfWeekChecker
{
    public static string GetDayOfWeek()
    {
        //DateTime today = DateTime.Today;
        
        return DateTime.Now.DayOfWeek.ToString();
    }
}

public class WallpaperChanger
{
    [DllImport("user32.dll")]
    static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    public void ChangeWallpaper(string path)
    {
        if (!string.IsNullOrEmpty(path))
        {
            string CrWlp = WallpaperChecker.GetCurrentWallpaper();
            if (path != CrWlp)
            {
            SystemParametersInfo(20, 0, path, 0x0014);
            }
        }
        else
        {
            Console.WriteLine("Error: Path cannot be null or empty.");
        }
    }
    class WallpaperChecker
    {
        public static string GetCurrentWallpaper()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Wallpapers");
            string wallpaperKey = (string)key.GetValue("BackgroundHistoryPath0");
            Console.WriteLine(wallpaperKey);
            return wallpaperKey;
        }
    }





}