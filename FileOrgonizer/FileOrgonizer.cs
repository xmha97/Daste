using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PFP.Imaging;

namespace FileOrgonizer
{
    public partial class FileOrgonizer : Form
    {
        public FileOrgonizer()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox4.AppendText("--Help--\r\n<YY>	Year (20)\r\n<YYYY>	Year (2020)\r\n<M>	Month (2)\r\n<MM>	Month (02)\r\n<D>	Day (1)\r\n<DD>	Day (01)\r\n<h>	Hour (8)\r\n<hh>	Hour (08)\r\n<m>	Minute (9)\r\n<mm>	Minute (09)\r\n<s>	Second (5)\r\n<ss>	Second (05)\r\n<ex>	jpg\r\n<EX>	JPG\r\n<TITLE>	Title\r\n\r\n");
            textBox4.Focus();
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        private void Button4_Click(object sender, EventArgs e)
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
            string dPath = string.Empty;
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
            dPath = Properties.Settings.Default.DestPathMP4;
            foreach (string file in MP4_filesList)
            {
                progressBar1.Value += 1;
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
                if (copy)
                {
                    File.Copy(file, d);
                }
                else
                {
                    File.Move(file, d);
                }
            }

            // JPG
            dPath = Properties.Settings.Default.DestPathJPG;
            foreach (string file in JPG_filesList)
            {
                progressBar1.Value += 1;
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
                if (copy)
                {
                    File.Copy(file, d);
                }
                else
                {
                    File.Move(file, d);
                }
            }

            // EML
            dPath = Properties.Settings.Default.DestPathEML;
            foreach (string file in EML_filesList)
            {
                progressBar1.Value += 1;
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
                if (copy)
                {
                    File.Copy(file, d);
                }
                else
                {
                    File.Move(file, d);
                }
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
        public string StringGenerator(DateTime date, string format, string ext, string title)
        {
            return format
                .Replace("<YYYY>", date.Year.ToString())
                .Replace("<YY>", date.Year.ToString().Substring(2, 2))
                .Replace("<M>", date.Month.ToString())
                .Replace("<MM>", date.Month.ToString("00"))
                .Replace("<D>", date.Day.ToString())
                .Replace("<DD>", date.Day.ToString("00"))
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

        private void FileOrgonizer_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = Properties.Settings.Default.SourcePath;
        }

        private void FileOrgonizer_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
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

        private void scanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scan(false);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scan(true);
        }
    }
}