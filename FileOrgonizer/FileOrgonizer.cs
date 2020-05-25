using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        private void Button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                button2.Focus();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                button4.Focus();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("<YY>	Year (20)\r<YYYY>	Year (2020)\r<M>	Month (2)\r<MM>	Month (02)\r<D>	Day (1)\r<DD>	Day (01)\r<h>	Hour (8)\r<hh>	Hour (08)\r<m>	Minute (9)\r<mm>	Minute (09)\r<s>	Second (5)\r<ss>	Second (05)\r<ex>	jpg\r<EX>	JPG\n<TITLE>	Title");
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("Source path is not exist.");
                return;
            }
            if (!System.IO.Directory.Exists(textBox2.Text))
            {
                MessageBox.Show("Destination path is not exist.");
                return;
            }

            textBox4.Clear();
            List<string> MP4_filesList = new List<string>(Directory.GetFiles(textBox1.Text,
                "*.mp4", SearchOption.AllDirectories));
            List<string> JPG_filesList = new List<string>(Directory.GetFiles(textBox1.Text,
                "*.jpg", SearchOption.AllDirectories));
            List<string> EML_filesList = new List<string>(Directory.GetFiles(textBox1.Text,
                "*.eml", SearchOption.AllDirectories));

            textBox4.AppendText("Find " + MP4_filesList.Count + " MP4\r\n");
            textBox4.AppendText("Find " + JPG_filesList.Count + " JPG\r\n");
            textBox4.AppendText("Find " + EML_filesList.Count + " EML\r\n");


            // MP4
            progressBar1.Value = 0;
            progressBar1.Maximum = MP4_filesList.Count;
            foreach (string file in MP4_filesList)
            {
                progressBar1.Value += 1;
                DateTime fileDate = (DateTime)PhotoLibaryToolkit.Framework.VideoInfo.GetVideoFileTakenDate(file);
                string destPath = StringGenerator(fileDate, Properties.Settings.Default.PatternMP4, "mp4",null);
                string[] fileParts = destPath.Split('/', '\\');
                for (int i = 0; i < fileParts.Length - 1; i++)
                {
                    string directory = textBox2.Text;
                    for (int j = 0; j <= i; j++)
                    {
                        directory += "\\" + fileParts[j];
                    }
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                }
                string d = textBox2.Text + "\\" + destPath;
                File.Move(file, d);
            }



            // JPG
            progressBar1.Value = 0;
            progressBar1.Maximum = JPG_filesList.Count;
            foreach (string file in JPG_filesList)
            {
                progressBar1.Value += 1;
                DateTime fileDate = (DateTime)PFP.Imaging.ImageInfo.GetTakenDate(file);
                string destPath = StringGenerator(fileDate, Properties.Settings.Default.PatternJPG, "jpg",null);
                string[] fileParts = destPath.Split('/', '\\');
                for (int i = 0; i < fileParts.Length - 1; i++)
                {
                    string directory = textBox2.Text;
                    for (int j = 0; j <= i; j++)
                    {
                        directory += "\\" + fileParts[j];
                    }
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                }
                string d = textBox2.Text + "\\" + destPath;
                File.Move(file, d);
            }

            // EML
            progressBar1.Value = 0;
            progressBar1.Maximum = EML_filesList.Count;
            foreach (string file in EML_filesList)
            {
                progressBar1.Value += 1;
                DateTime fileDate = GetDateTimeFromEML(file);
                string fileTitle = GetTitleFromEML(file);
                string destPath = StringGenerator(fileDate, Properties.Settings.Default.PatternEML, "eml", fileTitle);
                string[] fileParts = destPath.Split('/', '\\');
                for (int i = 0; i < fileParts.Length - 1; i++)
                {
                    string directory = textBox2.Text;
                    for (int j = 0; j <= i; j++)
                    {
                        directory += "\\" + fileParts[j];
                    }
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                }
                string d = textBox2.Text + "\\" + destPath;
                File.Move(file, d);
            }


        }

        public static string StringGenerator(DateTime date, string format, string ext, string title)
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
                .Replace("<TITLE>", title.Replace(':', '_').Replace('/', '_').Replace('\\', '_'));
        }

        private void FileOrgonizer_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = Properties.Settings.Default.SourcePath;
            textBox2.Text = Properties.Settings.Default.DestinationPath;
        }

        private void FileOrgonizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SourcePath = textBox1.Text;
            Properties.Settings.Default.DestinationPath = textBox2.Text;
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
                    break;
                case 1:
                    it = Properties.Settings.Default.PatternJPG;
                    break;
                case 2:
                    it = Properties.Settings.Default.PatternEML;
                    break;
            }
            textBox3.Text = it;
        }
    }
}
