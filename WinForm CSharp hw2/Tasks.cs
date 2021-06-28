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
    public partial class Tasks : Form
    {
        Task1 task1;
        Task2 task2;
        Task3 task3;
        Task4 task4;
        public Tasks()
        {
            InitializeComponent();
        }

        public void Show_Visible()
        {
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task1 = new Task1(this);
            this.Visible = false;
            task1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            task2 = new Task2();
            this.Visible = false;
            task2.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            task3 = new Task3();
            this.Visible = false;
            task3.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            task4 = new Task4();
            this.Visible = false;
            task4.ShowDialog();
            this.Visible = true;
        }
    }
}
