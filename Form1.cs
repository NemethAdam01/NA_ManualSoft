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

namespace NA_ManualSoft
{
    public partial class Form1 : Form
    {
        FileInfo[] filesNames;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\NemethAdam\Desktop\NA_ManualSoft\NA_ManualSoft\bin\Debug\manuals"); 

            filesNames = d.GetFiles("*.pdf"); 
            string str = "";

            foreach (FileInfo file in filesNames)
            {
                str = str + ", " + file.Name;
            }
            foreach (FileInfo file in filesNames)
            {
                cb_selector.Items.Add(file.Name);
            }
            pdfReader.LoadFile("manual_monitor.pdf");


        }

        private void cb_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            pdfReader.LoadFile(filesNames[cb_selector.SelectedIndex].FullName);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string saveDirectory = @"C:\Users\NemethAdam\Desktop\NA_ManualSoft\NA_ManualSoft\bin\Debug\manuals";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(saveDirectory))
                    {
                        Directory.CreateDirectory(saveDirectory);
                    }

                    string fileName = Path.GetFileName(openFileDialog1.FileName);
                    string fileSavePath = Path.Combine(saveDirectory, fileName);
                    File.Copy(openFileDialog1.FileName, fileSavePath, true);
                    cb_selector.Items.Add(fileName);
                }
            }
        }
    }
}
