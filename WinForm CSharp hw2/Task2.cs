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
    public partial class Task2 : Form
    {
        Task2_Find task2_find;
        public Task2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task2_find = new Task2_Find(this);
            task2_find.Show();
        }
        public void AddtoList(string FullName)
        {
            listBox1.Items.Add(FullName);
        }
    }
}
