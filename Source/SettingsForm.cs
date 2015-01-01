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
        public string txt3;
        public string txt4;
        
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string[] line1 = File.ReadAllLines("mc.props");
            txt1 = line1[3];
            txt2 = line1[6];
            txt3 = line1[12];
            txt4 = line1[15];
            string[] plugins = Directory.GetFiles(txt2, "*.jar");
            DirectoryInfo dir = new DirectoryInfo(txt2);
            int count = dir.GetFiles("*.jar").Length;
            for (int i = 0; i < count; i++)
            {
                richTextBox1.Text += plugins[i] + "\n";
            }
            try
            {
                string[] line = File.ReadAllLines("mc.props");
                txt1 = line[3];
                txt2 = line[6];
                txt3 = line[12];
                txt4 = line[15];
                textBox1.Text = txt1;
                textBox2.Text = txt2;
                textBox3.Text = txt3;
                textBox4.Text = txt4;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("ERROR: Can't find settings file " + Directory.GetCurrentDirectory() + "\\mc.props", "ERROR: NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Create("mc.props");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txt1 = textBox1.Text;
            File.Delete("mc.props");
            StreamWriter sw1 = new StreamWriter("mc.props");
            sw1.WriteLine("#SETTINGS FILE - DONT EDIT");
            sw1.WriteLine("");
            sw1.WriteLine("OVERWORLD:");
            sw1.WriteLine(txt1);
            sw1.WriteLine("");
            sw1.WriteLine("PLUGINS:");
            sw1.WriteLine(txt2);
            sw1.WriteLine("");
            sw1.WriteLine("FIRST_RUN:");
            sw1.WriteLine("false");
            sw1.WriteLine("");
            sw1.WriteLine("MINECRAFT_NAME:");
            sw1.WriteLine(txt3);
            sw1.WriteLine("");
            sw1.WriteLine("CONFIG:");
            sw1.WriteLine(txt4);
            sw1.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            txt2 = textBox2.Text;
            File.Delete("mc.props");
            StreamWriter sw1 = new StreamWriter("mc.props");
            sw1.WriteLine("#SETTINGS FILE - DONT EDIT");
            sw1.WriteLine("");
            sw1.WriteLine("OVERWORLD:");
            sw1.WriteLine(txt1);
            sw1.WriteLine("");
            sw1.WriteLine("PLUGINS:");
            sw1.WriteLine(txt2);
            sw1.WriteLine("");
            sw1.WriteLine("FIRST_RUN:");
            sw1.WriteLine("false");
            sw1.WriteLine("");
            sw1.WriteLine("MINECRAFT_NAME:");
            sw1.WriteLine(txt3);
            sw1.WriteLine("");
            sw1.WriteLine("CONFIG:");
            sw1.WriteLine(txt4);
            sw1.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            txt3 = textBox3.Text;
            File.Delete("mc.props");
            StreamWriter sw1 = new StreamWriter("mc.props");
            sw1.WriteLine("#SETTINGS FILE - DONT EDIT");
            sw1.WriteLine("");
            sw1.WriteLine("OVERWORLD:");
            sw1.WriteLine(txt1);
            sw1.WriteLine("");
            sw1.WriteLine("PLUGINS:");
            sw1.WriteLine(txt2);
            sw1.WriteLine("");
            sw1.WriteLine("FIRST_RUN:");
            sw1.WriteLine("false");
            sw1.WriteLine("");
            sw1.WriteLine("MINECRAFT_NAME:");
            sw1.WriteLine(txt3);
            sw1.WriteLine("");
            sw1.WriteLine("CONFIG:");
            sw1.WriteLine(txt4);
            sw1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txt1 = textBox1.Text;
                txt2 = textBox2.Text;
                txt3 = textBox3.Text;
                txt4 = textBox4.Text;
                File.Delete("mc.props");
                StreamWriter sw1 = new StreamWriter("mc.props");
                sw1.WriteLine("#SETTINGS FILE - DONT EDIT");
                sw1.WriteLine("");
                sw1.WriteLine("OVERWORLD:");
                sw1.WriteLine(txt1);
                sw1.WriteLine("");
                sw1.WriteLine("PLUGINS:");
                sw1.WriteLine(txt2);
                sw1.WriteLine("");
                sw1.WriteLine("FIRST_RUN:");
                sw1.WriteLine("false");
                sw1.WriteLine("");
                sw1.WriteLine("MINECRAFT_NAME:");
                sw1.WriteLine(txt3);
                sw1.WriteLine("");
                sw1.WriteLine("CONFIG:");
                sw1.WriteLine(txt4);
                sw1.Close();
                this.Hide();
            }
            catch (FileLoadException)
            {
                MessageBox.Show("Can't load file: mc.props, try again", "ERROR: Can't open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }                
    }
}
