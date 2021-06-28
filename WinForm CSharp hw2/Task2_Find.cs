using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_CSharp_hw2
{
    public partial class Task2_Find : Form
    {
        string filename;
        Task2 task2;
        public Task2_Find(Task2 _task2)
        {
            InitializeComponent();
            task2 = _task2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                filename = folderBrowserDialog.SelectedPath;
                textBox1.Text = filename;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && textBox2.Text != String.Empty)
            {
                Find(textBox1.Text);
            }
        }
        private void Find(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (var item in directoryInfo.GetFiles(textBox2.Text))
            {
                task2.AddtoList(item.FullName);
            }
            foreach (var item in directoryInfo.GetDirectories())
            {
                Find(path + $@"\{item}");
            }
        }
    }
}
