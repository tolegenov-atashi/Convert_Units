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
    public partial class Mass : Form
    {
        public Mass()
        {
            InitializeComponent();
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConvertMass();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConvertMass();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                guna2TextBox2.Text = " ";
            }

            UpdateConvertMass();
        }
        private void UpdateConvertMass()
        {
            double inputMass;
            if(double.TryParse(guna2TextBox1.Text, out inputMass))
            {
                string input = guna2ComboBox1.Text;
                string output= guna2ComboBox2.Text;
                double ConvertedMass = ConvertMass(inputMass,input,output);
                guna2TextBox2.Text = ConvertedMass.ToString();
            }
        }
        private double ConvertMass(double inputMass,string inputUnit,string outputUnit)
        {
            double KilogramMass;
            switch (inputUnit)
            {
                case "Kilogramm":
                    KilogramMass = inputMass;
                    break;
                case "Gramm":
                    KilogramMass = inputMass/1000;
                    break;
                case "Decigramm":
                    KilogramMass = inputMass / 10000;
                    break;
                case "Centigramm":
                    KilogramMass = inputMass / 100000;
                    break;
                default:
                    KilogramMass=inputMass; break;  
            }
            double outputMass;
            switch(outputUnit)
            {
                case "Kilogramm": outputMass = KilogramMass; break;
                case "Gramm":  outputMass=KilogramMass * 1000; break;
                case "Decigramm": outputMass = KilogramMass * 10000; break;
                case "Centigramm": outputMass = KilogramMass * 100000; break;
                default : outputMass = 0; break;
            }
            return outputMass;
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
            Form1 ff = new Form1();
            ff.Show();
            this.Hide();
        }

        private void Mass_Load(object sender, EventArgs e)
        {

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
    }
}
