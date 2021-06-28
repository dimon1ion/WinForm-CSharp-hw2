using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_CSharp_hw2
{
    public partial class Task3_Add : Form
    {
        Task3 task3;
        public Task3_Add(Task3 _task3)
        {
            InitializeComponent();
            task3 = _task3;
        }

        private void Task3_Add_Load(object sender, EventArgs e)
        {
            textBox1.Text = task3.selectedDevice.Name;
            textBox2.Text = task3.selectedDevice.Characteristics;
            textBox3.Text = task3.selectedDevice.Comment;
            textBox4.Text = task3.selectedDevice.Cost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task3.selectedDevice.Name = textBox1.Text;
            task3.selectedDevice.Characteristics = textBox2.Text;
            task3.selectedDevice.Comment = textBox3.Text;
            task3.selectedDevice.Cost = textBox4.Text;
        }
    }
}
