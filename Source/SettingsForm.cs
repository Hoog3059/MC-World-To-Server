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

namespace MC_World_To_Server
{
    public partial class SettingsForm : Form
    {

        public string txt1;
        public string txt2;
        
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string[] line1 = File.ReadAllLines("mc.wts");
            txt1 = line1[3];
            txt2 = line1[6];
            string[] plugins = Directory.GetFiles(txt2, "*.jar");
            DirectoryInfo dir = new DirectoryInfo(txt2);
            int count = dir.GetFiles("*.jar").Length;
            for (int i = 0; i < count; i++)
            {
                richTextBox1.Text += plugins[i] + "\n";
            }
            try
            {
                string[] line = File.ReadAllLines("mc.wts");
                txt1 = line[3];
                txt2 = line[6];
                textBox1.Text = txt1;
                textBox2.Text = txt2;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("ERROR: Can't find settings file " + Directory.GetCurrentDirectory() + "\\mc.wts", "ERROR: NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Create("mc.wts");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txt1 = textBox1.Text;
            File.Delete("mc.wts");
            StreamWriter sw1 = new StreamWriter("mc.wts");
            sw1.WriteLine("#SETTINGS FILE - DONT EDIT");
            sw1.WriteLine("");
            sw1.WriteLine("OVERWORLD:");
            sw1.WriteLine(txt1);
            sw1.WriteLine("");
            sw1.WriteLine("PLUGINS:");
            sw1.WriteLine(txt2);
            sw1.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            txt2 = textBox2.Text;
            File.Delete("mc.wts");
            StreamWriter sw1 = new StreamWriter("mc.wts");
            sw1.WriteLine("#SETTINGS FILE - DONT EDIT");
            sw1.WriteLine("");
            sw1.WriteLine("OVERWORLD:");
            sw1.WriteLine(txt1);
            sw1.WriteLine("");
            sw1.WriteLine("PLUGINS:");
            sw1.WriteLine(txt2);
            sw1.Close();
        }                
    }
}
