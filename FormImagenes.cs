using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainLinkConnect
{
    

    public partial class FormImagenes : Form
    {
        public string SelectedFolderPath { get; private set; }

        public FormImagenes()
        {
            InitializeComponent();

        }

        private void FormImagenes_Load(object sender, EventArgs e)
        {

        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBox1.Items.Clear();
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.RootFolder = Environment.SpecialFolder.Desktop;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                SelectedFolderPath = folder.SelectedPath + "\\";
                string[] fileNames = Directory.GetFiles(SelectedFolderPath, "*.jpg", SearchOption.TopDirectoryOnly)
                        .Union(Directory.GetFiles(SelectedFolderPath, "*.png", SearchOption.TopDirectoryOnly))
                        .Union(Directory.GetFiles(SelectedFolderPath, "*.bmp", SearchOption.TopDirectoryOnly))
                        .ToArray();
                
                //esto es lo que falta en el formConfig
                foreach (string fileName in fileNames)
                {
                    listBox1.Items.Add(Path.GetFileName(fileName));
                }

            }
            if (listBox1.Items.Count > 0)
            {
                pictureBox2.Load(SelectedFolderPath   + listBox1.Items[0]);
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.Load(SelectedFolderPath + listBox1.Items[listBox1.SelectedIndex]);

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
