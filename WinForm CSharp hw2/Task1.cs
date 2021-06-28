using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm_CSharp_hw2
{
    public partial class Task1 : Form
    {
        float[] arrCostCafeFood;
        Timer timerEnd = new Timer();
        Timer timerTime = new Timer();
        Task1_1 task1_1 = new Task1_1();
        DateTime dateTime;
        double TodayWork;
        public static int green;
        public static int red;
        public static int blue;
        string language;
        int timeHour, timeMinute, timeDay, timeMonth, timeYear;
        public Task1()
        {
            InitializeComponent();
            arrCostCafeFood = new float[4];
            for (int i = 0; i < arrCostCafeFood.Length; i++)
            {
                arrCostCafeFood[i] = 0f;
            }
            timeHour = DateTime.Now.Hour; //Попеременное отображение
            timeMinute = DateTime.Now.Minute;
            timeDay = DateTime.Now.Day;
            timeMonth = DateTime.Now.Month;
            timeYear = DateTime.Now.Year;
            dateTime = DateTime.Now;
            dayOfWeakToolStripMenuItem.Text = dateTime.DayOfWeek.ToString();

            Change_TimeStripStatus();

            timerTime.Interval = 60000;
            timerTime.Tick += TimerTime_Tick;
            timerTime.Start();

            timerEnd.Interval = 10000;
            timerEnd.Tick += Timer_Tick;
            TodayWork = 0;

            groupBox1.ForeColor = this.ForeColor;
            groupBox3.ForeColor = this.ForeColor;
            groupBox4.ForeColor = this.ForeColor;
            groupBox5.ForeColor = this.ForeColor;
            groupBox6.ForeColor = this.ForeColor;
            language = "ru";
            SetLocalization("RU");
        }

        private void SetLocalization(string loc)
        {
            loc = loc.ToLower();
            настройкиToolStripMenuItem.Text = lang.ResourceManager.GetString(loc + "_settings");
            цветФормыToolStripMenuItem.Text = lang .ResourceManager.GetString(loc + "_colorform");
            groupBox1.Text = lang.ResourceManager.GetString(loc + "_gasstation");
            label1.Text = lang.ResourceManager.GetString(loc + "_oil");
            label2.Text = lang.ResourceManager.GetString(loc + "_cost");
            label3.Text = lang.ResourceManager.GetString(loc + "_rub");
            radioButton1.Text = lang.ResourceManager.GetString(loc + "_num");
            label4.Text = lang.ResourceManager.GetString(loc + "_litres");
            radioButton2.Text = lang.ResourceManager.GetString(loc + "_amount");
            label5.Text = lang.ResourceManager.GetString(loc + "_rub");
            if (radioButton1.Checked)
            {
                groupBox3.Text = lang.ResourceManager.GetString(loc + "_topay");
            }
            else
            {
                groupBox3.Text = lang.ResourceManager.GetString(loc + "_toissue");
            }
            rubSumOilLabel.Text = lang.ResourceManager.GetString(loc + "_rub");
            groupBox4.Text = lang.ResourceManager.GetString(loc + "_cafe");
            label8.Text = lang.ResourceManager.GetString(loc + "_cost");
            label9.Text = lang.ResourceManager.GetString(loc + "_num");
            Hot_DogCheckBox.Text = lang.ResourceManager.GetString(loc + "_hot_dog");
            HamburgerCheckBox.Text = lang.ResourceManager.GetString(loc + "_hamburger");
            PotatoCheckBox.Text = lang.ResourceManager.GetString(loc + "_potato");
            CocaCheckBox.Text = lang.ResourceManager.GetString(loc + "_coca");
            groupBox5.Text = lang.ResourceManager.GetString(loc + "_topay");
            label10.Text = lang.ResourceManager.GetString(loc + "_rub");
            groupBox6.Text = lang.ResourceManager.GetString(loc + "_totalpay");
            label12.Text = lang.ResourceManager.GetString(loc + "_rub");
            button1.Text = lang.ResourceManager.GetString(loc + "_calculate");
        }

        private void Change_TimeStripStatus()
        {
            TimetoolStripStatusLabel.Text = $"{timeHour}:{timeMinute}  {timeDay}.{timeMonth}.{timeYear}"; // Попеременное отображение
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            timeMinute++;
            if (timeMinute == 60)
            {
                timeMinute = 0;
                timeHour++;
                if (timeHour == 24)
                {
                    timeHour = 0;
                    timeDay++;
                    dateTime = dateTime.AddDays(1);
                    dayOfWeakToolStripMenuItem.Text = dateTime.DayOfWeek.ToString();
                    if (DateTime.DaysInMonth(timeYear, timeMonth) + 1 == timeDay)
                    {
                        timeDay = 1;
                        timeMonth++;
                        if (timeMonth == 13)
                        {
                            timeMonth = 1;
                            timeYear++;
                        }
                    }
                }
            }
            Change_TimeStripStatus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "АИ-98")
            {
                CostOilTextBox.Text = "4,44";
            }
            else if (comboBox1.Text == "Diesel")
            {
                CostOilTextBox.Text = "2,22";
            }
            else if (comboBox1.Text == "АИ-95")
            {
                CostOilTextBox.Text = "6,66";
            }
            if (radioButton1.Checked)
            {
                radioButton1_CheckedChanged(sender, e);
            }
            else
            {
                radioButton2_CheckedChanged(sender, e);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                textBox2.Enabled = !textBox2.Enabled;
            }
            if (radioButton1.Checked)
            {
                groupBox3.Text = lang.ResourceManager.GetString(language + "_topay");
                rubSumOilLabel.Text = lang.ResourceManager.GetString(language + "_rub");
                if (CostOilTextBox.Text != String.Empty)
                {
                    float liters;
                    if (Single.TryParse(textBox2.Text, out liters))
                    {
                        SumOil.Text = (liters * Single.Parse(CostOilTextBox.Text)).ToString();
                    }
                }
            }
            else
            {
                SumOil.Text = "0";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                textBox3.Enabled = !textBox3.Enabled;
            }
            if (radioButton2.Checked)
            {
                groupBox3.Text = lang.ResourceManager.GetString(language + "_toissue");
                rubSumOilLabel.Text = lang.ResourceManager.GetString(language + "_litres");
                if (CostOilTextBox.Text != String.Empty)
                {
                    float cost;
                    if (Single.TryParse(textBox3.Text, out cost))
                    {
                        SumOil.Text = (cost / Single.Parse(CostOilTextBox.Text)).ToString();
                    }
                }
            }
            else
            {
                SumOil.Text = "0";
            }
        }

        private void Change_SumFoodTextBox()
        {
            SumFoodTextBox.Text = arrCostCafeFood.Sum().ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CountHot_DogTextBox.Enabled = !CountHot_DogTextBox.Enabled;
            }
            if (CountHot_DogTextBox.Enabled)
            {
                float count;
                if (Single.TryParse(CountHot_DogTextBox.Text, out count))
                {
                    arrCostCafeFood[0] = count * Single.Parse(CostHot_DogTextBox.Text);
                }
            }
            else
            {
                arrCostCafeFood[0] = 0f;
            }
            Change_SumFoodTextBox();
        }

        private void HamburgerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CountHamburgerTextBox.Enabled = !CountHamburgerTextBox.Enabled;
            }
            if (CountHamburgerTextBox.Enabled)
            {
                float count;
                if (Single.TryParse(CountHamburgerTextBox.Text, out count))
                {
                    arrCostCafeFood[1] = count * Single.Parse(CostHamburgerTextBox.Text);
                }
            }
            else
            {
                arrCostCafeFood[1] = 0f;
            }
            Change_SumFoodTextBox();
        }

        private void PotatoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CountPotatoTextBox.Enabled = !CountPotatoTextBox.Enabled;
            }
            if (CountPotatoTextBox.Enabled)
            {
                float count;
                if (Single.TryParse(CountPotatoTextBox.Text, out count))
                {
                    arrCostCafeFood[2] = count * Single.Parse(CostPotatoTextBox.Text);
                }
            }
            else
            {
                arrCostCafeFood[2] = 0f;
            }
            Change_SumFoodTextBox();
        }

        private void цветФормыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            task1_1.ShowDialog();
            ChangeForeColor();
        }

        private void ChangeForeColor()
        {
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(red)))), ((int)(((byte)(green)))), ((int)(((byte)(blue)))));
            groupBox1.ForeColor = this.ForeColor;
            groupBox3.ForeColor = this.ForeColor;
            groupBox4.ForeColor = this.ForeColor;
            groupBox5.ForeColor = this.ForeColor;
            groupBox6.ForeColor = this.ForeColor;
        }

        private void Task1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Программа была спрятана";
                notifyIcon1.BalloonTipText = "Нажмите 2 раза по иконке чтобы открыть";
                notifyIcon1.ShowBalloonTip(5000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            language = "ru";
            SetLocalization("RU");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            language = "en";
            SetLocalization("EN");
        }

        private void CocaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CountCocaTextBox.Enabled = !CountCocaTextBox.Enabled;
            }
            if (CountCocaTextBox.Enabled)
            {
                float count;
                if (Single.TryParse(CountCocaTextBox.Text, out count))
                {
                    arrCostCafeFood[3] = count * Single.Parse(CostCocaTextBox.Text);
                }
            }
            else
            {
                arrCostCafeFood[3] = 0f;
            }
            Change_SumFoodTextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                SumAllTextBox.Text = (Single.Parse(textBox3.Text) + Single.Parse(SumFoodTextBox.Text)).ToString();
            }
            else
            {
                SumAllTextBox.Text = (Single.Parse(SumOil.Text) + Single.Parse(SumFoodTextBox.Text)).ToString();
            }
            TodayWork += Double.Parse(SumAllTextBox.Text);
            timerEnd.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            (sender as Timer).Stop();
            DialogResult dialogResult = MessageBox.Show("Появился следующий покупатель?", "Запрос на очистку", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                comboBox1.SelectedItem = null;
                CostOilTextBox.Text = String.Empty;

                radioButton1.Checked = true;
                textBox2.Text = String.Empty;
                textBox2.Enabled = true;

                radioButton2.Checked = false;
                textBox3.Text = String.Empty;
                textBox3.Enabled = false;

                groupBox3.Text = "К оплате";
                SumOil.Text = "0";
                rubSumOilLabel.Text = "руб.";

                Hot_DogCheckBox.Checked = false;
                HamburgerCheckBox.Checked = false;
                PotatoCheckBox.Checked = false;
                CocaCheckBox.Checked = false;

                CountHot_DogTextBox.Text = String.Empty;
                CountHamburgerTextBox.Text = String.Empty;
                CountPotatoTextBox.Text = String.Empty;
                CountCocaTextBox.Text = String.Empty;

                CountHot_DogTextBox.Enabled = false;
                CountHamburgerTextBox.Enabled = false;
                CountPotatoTextBox.Enabled = false;
                CountCocaTextBox.Enabled = false;

                SumFoodTextBox.Text = "0";

                SumAllTextBox.Text = "0";
            }
            else
            {
                (sender as Timer).Start();
            }
        }

        private void Task8_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show($"Общая сумма выручки: {TodayWork} рублей");
        }
    }
}
