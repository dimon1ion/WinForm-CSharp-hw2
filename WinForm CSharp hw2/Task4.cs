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
    public partial class Task4 : Form
    {
        Task4_Edit task4_Edit;
        public string Name { get; set; }
        public Task4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt files(*.txt) |*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                button2.Enabled = true;
                StreamReader streamReader = File.OpenText(openFileDialog.FileName);
                Name = openFileDialog.FileName;
                textBox1.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            task4_Edit = new Task4_Edit(this);
            task4_Edit.Show();
        }

        public void Edit_Textbox(string text)
        {
            textBox1.Text = text;
        }
    }
}
