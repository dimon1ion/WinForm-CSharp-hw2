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
    public partial class Task1_1 : Form
    {
        public Task1_1()
        {
            InitializeComponent();
            RedTrackBar.Value = Task1.red;
            GreenTrackBar.Value = Task1.green;
            BlueTrackBar.Value = Task1.blue;
        }

        private void RedTrackBar_Scroll(object sender, EventArgs e)
        {
            Task1.red = RedTrackBar.Value;
        }

        private void GreenTrackBar_Scroll(object sender, EventArgs e)
        {
            Task1.green = GreenTrackBar.Value;
        }

        private void BlueTrackBar_Scroll(object sender, EventArgs e)
        {
            Task1.blue = BlueTrackBar.Value;
        }
    }
}
