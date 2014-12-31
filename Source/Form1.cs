using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace MC_World_To_Server
{
    public partial class Form1 : Form
    {
        public string world;
        public string plugins;
        public int os;
        
        public Form1()
        {
            InitializeComponent();
        }

        public string Fpath;
        
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.RootFolder = Environment.SpecialFolder.ApplicationData;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Fpath = fbd.SelectedPath;
                try
                {
                    textBox1.Text = Fpath;
                }
                catch
                {
                    MessageBox.Show("ERROR: Can't load folder!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Fpath + "\\region"))
            {
                MessageBox.Show("Can't find " + Fpath + "\\region,  is this folder a minecraft world?", "ERROR: Doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            else
            {
                try
                {
                    Directory.Delete(world, true);
                }
                catch
                {

                }
                string current = Directory.GetCurrentDirectory();
                DirectoryCopy(Fpath, world, true);
                if (os == 0)
                {
                    try
                    {
                        this.Hide();
                        Process p = new Process();
                        p.StartInfo.FileName = "start.sh";
                        p.Start();
                        p.WaitForExit();
                        this.Show();
                    }
                    catch
                    {
                        this.Hide();
                        Process p = new Process();
                        p.StartInfo.FileName = "/bin/bash";
                        p.StartInfo.Arguments = "start";
                        p.Start();
                        p.WaitForExit();
                        this.Show();
                    }                    
                }
                else
                {
                    try
                    {
                        this.Hide();
                        Process p = new Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.Arguments = "/c start.bat";
                        p.Start();
                        p.WaitForExit();
                        this.Show();
                    }
                    catch (InvalidProgramException)
                    {
                        MessageBox.Show("ERROR: Can't start server, Try again!!", "ERROR: Can't Start", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if ((MessageBox.Show("Do you want to save the changes?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    Directory.Delete(Fpath, true);
                    DirectoryCopy(world, Fpath, true);
                }
            }
                          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((MessageBox.Show("When you close form, all loaded data will erase (your minecraft world too)\n Are you sure to close?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }
            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "http://www.glowstone.net";
            proc.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int p = (int)Environment.OSVersion.Platform;
            if ((p == 4) || (p == 128))
            {
                os = 0;
            }
            else
            {
                os = 1;
            }
            string[] line = File.ReadAllLines("mc.props");
            world = line[3];
            plugins = line[6];
            try
            {
                File.Delete("temp.version");
            }
            catch
            {
            }           
        }
    }
}
