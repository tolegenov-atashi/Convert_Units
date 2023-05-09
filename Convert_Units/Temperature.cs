using Guna.UI2.WinForms;
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
    public partial class Temperature : Form
    {
        public Temperature()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConvertedTemperature();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConvertedTemperature();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                guna2TextBox2.Text = "";
            }
            UpdateConvertedTemperature();
        }


        private void UpdateConvertedTemperature()
        {
            double inputTemperature;
            if (double.TryParse(guna2TextBox1.Text, out inputTemperature))
            {
                string inputUnit = guna2ComboBox1.Text;
                string outputUnit = guna2ComboBox2.Text;
                double convertedTemperature = ConvertTemperature(inputTemperature, inputUnit, outputUnit);
                guna2TextBox2.Text = convertedTemperature.ToString();
            }
        }

        private double ConvertTemperature(double inputTemperature, string inputUnit, string outputUnit)
        {
            // Convert input temperature to Celsius
            double celsiusTemperature;
            switch (inputUnit)
            {
                case "Celsiy":
                    celsiusTemperature = inputTemperature;
                    break;
                case "Farengeyt":
                    celsiusTemperature = (inputTemperature - 32) * 5 / 9;
                    break;
                case "Kelvin":
                    celsiusTemperature = inputTemperature - 273.15;
                    break;
                case "Rankin":
                    celsiusTemperature = (inputTemperature - 491.67) * 5 / 9;
                    break;
                default: 
                    celsiusTemperature = 0;
                    break;
            }

            // Convert Celsius temperature to output unit
            double outputTemperature;
            switch (outputUnit)
            {
                case "Celsiy":
                    outputTemperature = celsiusTemperature;
                    break;
                case "Farengeyt":
                    outputTemperature = celsiusTemperature * 9 / 5 + 32;
                    break;
                case "Kelvin":
                    outputTemperature = celsiusTemperature + 273.15;
                    break;
                case "Rankin":
                    if (inputUnit == "Rankin")
                    {
                        outputTemperature = inputTemperature;
                    }
                    else
                    {
                        outputTemperature = (celsiusTemperature + 273.15) * 9 / 5;
                    }
                    break;
                default:
                    outputTemperature = 0;
                    break;
            }
            return outputTemperature;
        }
        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.') && (e.KeyChar != '-') ||
            ((e.KeyChar == '.') && ((sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf('.') > -1)) ||
            ((e.KeyChar == '-') && ((sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf('-') > -1)))
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
            this.Hide();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text==" ") 
            { 

            guna2TextBox2.Text= " ";   
            
            }
        }

        private void Temperature_Load(object sender, EventArgs e)
        {

        }
    }
}
