using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Globalization;

namespace FileOrganizer
{
    public partial class FileOrganizer : Form
    {
        public FileOrganizer()
        {
            InitializeComponent();
            int useImmersiveDarkMode = 1;
            DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useImmersiveDarkMode, sizeof(int));
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        private void HelpButton_Click(object sender, EventArgs e)
        {
            textBox4.AppendText("\r\n::::::::::::::::::::::::::::::::::: Help ::::::::::::::::::::::::::::::::::::\r\n" +
                                "::                                                                         ::\r\n" +
                                "::  <YYYY>\t\tLonger Gregorian Taken Year\t\t2020       ::\r\n" +
                                "::  <YY>\t\tShorter Gregorian Taken Year\t\t20         ::\r\n" +
                                "::  <MM>\t\tLonger Gregorian Taken Month\t\t02         ::\r\n" +
                                "::  <M>\t\t\tShorter Gregorian Taken Month\t\t2          ::\r\n" +
                                "::  <DD>\t\tLonger Gregorian Taken Day\t\t05         ::\r\n" +
                                "::  <D>\t\t\tShorter Gregorian Taken Day\t\t5          ::\r\n" +
                                "::                                                                         ::\r\n" +
                                "::  <YYYYper>\t\tLonger Persian Taken Year\t\t1398       ::\r\n" +
                                "::  <YYper>\t\tShorter Persian Taken Year\t\t98         ::\r\n" +
                                "::  <MMper>\t\tLonger Persian Taken Month\t\t09         ::\r\n" +
                                "::  <Mper>\t\tShorter Persian Taken Month\t\t9          ::\r\n" +
                                "::  <DDper>\t\tLonger Persian Taken Day\t\t03         ::\r\n" +
                                "::  <Dper>\t\tShorter Persian Taken Day\t\t3          ::\r\n" +
                                "::                                                                         ::\r\n" +
                                "::  <hh>\t\tLonger Local Taken Hour\t\t\t08         ::\r\n" +
                                "::  <h>\t\t\tShorter Local Taken Hour\t\t8          ::\r\n" +
                                "::  <mm>\t\tLonger Local Taken Minute\t\t09         ::\r\n" +
                                "::  <m>\t\t\tShorter Local Taken Minute\t\t9          ::\r\n" +
                                "::  <ss>\t\tLonger Local Taken Second\t\t05         ::\r\n" +
                                "::  <s>\t\t\tShorter Local Taken Second\t\t5          ::\r\n" +
                                "::                                                                         ::\r\n" +
                                "::  <ex>\t\tUppercase File Extension\t\tjpg        ::\r\n" +
                                "::  <EX>\t\tLowercase File Extension\t\tJPG        ::\r\n" +
                                "::  <TITLE>\t\tFile Title\t\t\t\tHalloween  ::\r\n" +
                                "::                                                                         ::\r\n" +
                                ":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\r\n");
            textBox4.Focus();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void Scan(bool copy)
        {
            progressBar1.Value = 0;
            SendMessage(progressBar1.Handle, 1040, (IntPtr)1, IntPtr.Zero);
            if (!System.IO.Directory.Exists(textBox1.Text))
            {
                textBox4.AppendText("Source path is not exist.\r\n");
                progressBar1.Value = progressBar1.Maximum;
                SendMessage(progressBar1.Handle, 1040, (IntPtr)2, IntPtr.Zero);
                SystemSounds.Hand.Play();
                return;
            }

            progressBar1.Style = ProgressBarStyle.Marquee;
            textBox4.Clear();
            List<string> MP4_filesList = new List<string>(Directory.GetFiles(textBox1.Text,
                "*.mp4", SearchOption.AllDirectories));
            List<string> JPG_filesList = new List<string>(Directory.GetFiles(textBox1.Text,
                "*.jpg", SearchOption.AllDirectories));
            List<string> EML_filesList = new List<string>(Directory.GetFiles(textBox1.Text,
                "*.eml", SearchOption.AllDirectories));

            progressBar1.Style = ProgressBarStyle.Blocks;

            textBox4.AppendText("Find " + MP4_filesList.Count + " MP4\r\n");
            textBox4.AppendText("Find " + JPG_filesList.Count + " JPG\r\n");
            textBox4.AppendText("Find " + EML_filesList.Count + " EML\r\n");

            progressBar1.Maximum = MP4_filesList.Count + JPG_filesList.Count + EML_filesList.Count;

            // MP4
            string dPath = Properties.Settings.Default.DestPathMP4;
            foreach (string file in MP4_filesList)
            {
                progressBar1.Value += 1;
                Application.DoEvents();
                try
                {
                    DateTime fileDate = (DateTime)PhotoLibaryToolkit.Framework.VideoInfo.GetVideoFileTakenDate(file);
                    string destPath = StringGenerator(fileDate, Properties.Settings.Default.PatternMP4, "mp4", null);
                    string[] fileParts = destPath.Split('/', '\\');
                    for (int i = 0; i < fileParts.Length - 1; i++)
                    {
                        string directory = dPath;
                        for (int j = 0; j <= i; j++)
                        {
                            directory += "\\" + fileParts[j];
                        }

                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);
                    }

                    string d = dPath + "\\" + destPath;
                    if (File.Exists(d))
                    {
                        File.Delete(d);
                        textBox4.AppendText("Error: Exist -> Delete: " + d + "\r\n");
                    }
                    if (copy)
                    {
                        File.Copy(file, d);
                    }
                    else
                    {
                        File.Move(file, d);
                    }
                }
                catch (Exception ex)
                {
                    textBox4.AppendText("Error " + file + " MSG: " + ex.Message + "\r\n");
                }
            }

            // JPG
            dPath = Properties.Settings.Default.DestPathJPG;
            foreach (string file in JPG_filesList)
            {
                progressBar1.Value += 1;
                Application.DoEvents();
                try
                {
                    DateTime fileDate = (DateTime)PFP.Imaging.ImageInfo.GetTakenDate(file);
                    string destPath = StringGenerator(fileDate, Properties.Settings.Default.PatternJPG, "jpg", null);
                    string[] fileParts = destPath.Split('/', '\\');
                    for (int i = 0; i < fileParts.Length - 1; i++)
                    {
                        string directory = dPath;
                        for (int j = 0; j <= i; j++)
                        {
                            directory += "\\" + fileParts[j];
                        }

                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);
                    }

                    string d = dPath + "\\" + destPath;
                    if (File.Exists(d))
                    {
                        File.Delete(d);
                        textBox4.AppendText("Error: Exist -> Delete: " + d + "\r\n");
                    }
                    if (copy)
                    {
                        File.Copy(file, d);
                    }
                    else
                    {
                        File.Move(file, d);
                    }
                }
                catch (Exception ex)
                {
                    textBox4.AppendText("Error " + file + " MSG: " + ex.Message + "\r\n");
                }
            }

            // EML
            dPath = Properties.Settings.Default.DestPathEML;
            foreach (string file in EML_filesList)
            {
                progressBar1.Value += 1;
                Application.DoEvents();
                try
                {
                    DateTime fileDate = GetDateTimeFromEML(file);
                    string fileTitle = GetTitleFromEML(file);
                    string destPath = StringGenerator(fileDate, Properties.Settings.Default.PatternEML, "eml",
                        fileTitle);
                    string[] fileParts = destPath.Split('/', '\\');
                    for (int i = 0; i < fileParts.Length - 1; i++)
                    {
                        string directory = dPath;
                        for (int j = 0; j <= i; j++)
                        {
                            directory += "\\" + fileParts[j];
                        }

                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);
                    }

                    string d = dPath + "\\" + destPath;
                    if (File.Exists(d))
                    {
                        File.Delete(d);
                        textBox4.AppendText("Error: Exist -> Delete: " + d + "\r\n");
                    }
                    if (copy)
                    {
                        File.Copy(file, d);
                    }
                    else
                    {
                        File.Move(file, d);
                    }
                }
                catch (Exception ex)
                {
                    textBox4.AppendText("Error " + file + " MSG: " + ex.Message + "\r\n");
                }

                if (progressBar1.Maximum != 0)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Maximum = 1;
                    progressBar1.Value = 1;
                }
                SystemSounds.Beep.Play();
            }
            MessageBox.Show("Done!");
        }

        public string StringGenerator(DateTime date, string format, string ext, string title)
        {
            return format
                .Replace("<YYYY>", date.Year.ToString())
                .Replace("<YY>", date.Year.ToString().Substring(2, 2))
                .Replace("<M>", date.Month.ToString())
                .Replace("<MM>", date.Month.ToString("00"))
                .Replace("<D>", date.Day.ToString())
                .Replace("<DD>", date.Day.ToString("00"))

                .Replace("<YYYYper>", new PersianCalendar().GetYear(date).ToString())
                .Replace("<YYper>", new PersianCalendar().GetYear(date).ToString().Substring(2, 2))
                .Replace("<Mper>", new PersianCalendar().GetMonth(date).ToString())
                .Replace("<MMper>", new PersianCalendar().GetMonth(date).ToString("00"))
                .Replace("<Dper>", new PersianCalendar().GetDayOfMonth(date).ToString())
                .Replace("<DDper>", new PersianCalendar().GetDayOfMonth(date).ToString("00"))

                .Replace("<h>", date.Hour.ToString())
                .Replace("<hh>", date.Hour.ToString("00"))
                .Replace("<m>", date.Minute.ToString())
                .Replace("<mm>", date.Minute.ToString("00"))
                .Replace("<s>", date.Second.ToString())
                .Replace("<ss>", date.Second.ToString("00"))
                .Replace("<ex>", ext.ToLower())
                .Replace("<EX>", ext.ToUpper())
                .Replace("<TITLE>", RemoveIC(title));
        }

        public string RemoveIC(string text)
        {
            if (text == null)
            {
                return null;
            }
            return text.Replace('\\', '_')
                .Replace('/', '_')
                .Replace(':', '_')
                .Replace('*', '_')
                .Replace('?', '_')
                .Replace('\"', '_')
                .Replace('<', '_')
                .Replace('>', '_')
                .Replace('|', '_');
        }

        private void FileOrganizer_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = Properties.Settings.Default.SourcePath;
        }

        private void FileOrganizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SourcePath = textBox1.Text;
            Properties.Settings.Default.Save();
        }


        private string GetTitleFromEML(string file)
        {
            return YML_GetValue(file, "Subject");
        }

        private DateTime GetDateTimeFromEML(string file)
        {
            return Convert.ToDateTime(YML_GetValue(file, "Date"));
        }

        private string YML_GetValue(string file, string tag)
        {
            string ou = null;
            foreach (string line in System.IO.File.ReadAllLines(file))
            {
                if (line.Split(':')[0].Trim().ToLower() == tag.ToLower().Trim())
                {
                    ou = YML_LineValue(line, tag);
                    break;
                }
            }
            return ou;
        }

        private string YML_LineValue(string Data, string tag)
        {
            string ou = null;
            string trm = Data.Trim();
            string[] tmp = trm.Split(':');
            string tit = tmp[0].ToLower().Trim();
            if (tit.Trim() == tag.ToLower())
            {
                ou = trm.Substring(tit.Length + 1, trm.Length - tit.Length - 1).Trim();
            }

            return ou;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string it = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    it = Properties.Settings.Default.PatternMP4;
                    textBox2.Text = Properties.Settings.Default.DestPathMP4;
                    break;
                case 1:
                    it = Properties.Settings.Default.PatternJPG;
                    textBox2.Text = Properties.Settings.Default.DestPathJPG;
                    break;
                case 2:
                    it = Properties.Settings.Default.PatternEML;
                    textBox2.Text = Properties.Settings.Default.DestPathEML;
                    break;
            }
            textBox3.Text = it;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog
            {
                SelectedPath = textBox1.Text
            };
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = f.SelectedPath;
            }
        }

        private void ScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scan(false);
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scan(true);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.Process proc = process;
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "FileOrganizer.exe.config";
            proc.Start();
        }
    }
}