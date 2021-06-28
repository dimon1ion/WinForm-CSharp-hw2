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
    public partial class Task3 : Form
    {
        Task3_Add task3_Add;
        public Device selectedDevice;
        public Task3()
        {
            InitializeComponent();
            List<Device> devices = new List<Device>()
            {
                new Device("Yasper(Apple)", "2,2ggz", "Good microphone", "30"),
                new Device("Video card(Nvidia)", "16gb", "Good", "200"),
                new Device("Intel core i3", "1.6ggz", "Not bad", "100")
            };
            foreach (var device in devices)
            {
                devicesComboBox.Items.Add(device);
            }
        }

        private void devicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Device device in devicesComboBox.Items)
            {
                if (devicesComboBox.Text == device.Name)
                {
                    textBox1.Text = device.Cost;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (devicesComboBox.SelectedItem is Device)
            {
                selectedDevice = (devicesComboBox.SelectedItem as Device);
                selectedDevice.Added = true;
                task3_Add = new Task3_Add(this);
                devicesComboBox.Items.Remove(devicesComboBox.SelectedItem);
                task3_Add.ShowDialog();
                listBox1.Items.Add(selectedDevice);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sum = 0;
            foreach (Device device in listBox1.Items)
            {
                sum += Double.Parse(device.Cost);
            }
            MessageBox.Show($"Total Cost: {sum}$");
        }
    }
}
