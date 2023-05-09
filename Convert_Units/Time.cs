using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convert_Units
{
    public partial class Time : Form
    {
        public Time()
        {
            InitializeComponent();
        }
        private void UpdateDuration()
        {
            int inputDuration;
            if (int.TryParse(guna2TextBox1.Text, out inputDuration))
            {
                string inputUnit = guna2ComboBox1.Text;
                string outputUnit = guna2ComboBox2.Text;
                int convertedDuration = ConvertDuration(inputDuration, inputUnit, outputUnit);
                guna2TextBox2.Text = convertedDuration.ToString();
            }
        }

        private int ConvertDuration(int inputDuration, string inputUnit, string outputUnit)
        {
            int outputDuration;

            switch (inputUnit)
            {
                case "Jil":
                    outputDuration = inputDuration * 365;
                    break;
                case "Ay":
                    outputDuration = inputDuration * 30;
                    break;
                case "Hápte":
                    outputDuration = inputDuration * 7;
                    break;
                case "Kún":
                    outputDuration = inputDuration;
                    break;
                default:
                    outputDuration = 0;
                    break;
            }

            switch (outputUnit) { 
           
                case "Jil":
                    outputDuration = outputDuration / 365;
                    break;
                case "Ay":
                    outputDuration = outputDuration / 30;
                    break;
                case "Hápte":
                    outputDuration = outputDuration / 7;
                    break;
                case "Kún":
                    break;
                default:
                    outputDuration = 0;
                    break;
            }

            return outputDuration;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 tt = new Form1();
            tt.Show();
            this.Hide();
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Time_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDuration();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDuration();

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateDuration();

        }
    }
}
