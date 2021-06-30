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
    public partial class Task4_Edit : Form
    {
        Task4 task4;
        public Task4_Edit(Task4 _task4)
        {
            InitializeComponent();
            task4 = _task4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(task4.Name, FileMode.Create);
            StreamWriter sW = new StreamWriter(fileStream, Encoding.Unicode);
            sW.Write(textBox1.Text);
            sW.Close();
            fileStream.Close();

            task4.Edit_Textbox(textBox1.Text);
        }
    }
}
