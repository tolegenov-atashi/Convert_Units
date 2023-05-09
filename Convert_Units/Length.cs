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
    public partial class Length : Form
    {










        private void UpdateLength()
        {
            double inputLength;
            if(double.TryParse(guna2TextBox1.Text, out inputLength))
            {
                string inputUnit=guna2ComboBox1.Text;
                string outputUnit = guna2ComboBox2.Text;
                double ConvertedLength = ConvertLength(inputLength, inputUnit,  outputUnit);

                guna2TextBox2.Text=ConvertedLength.ToString();
            }
        }

        private double ConvertLength(double inputLength,string inputUnit,string outputUnit)
        {
            double KilometrLength;
            switch (inputUnit)
            {
                case "Kilometr": KilometrLength = inputLength; break;
                case "Metr": KilometrLength=inputLength/1000; break;
                case "Decimetr": KilometrLength = inputLength/10000; break;
                case "Cantimetr": KilometrLength = inputLength/100000; break;
                default: KilometrLength = 0; break;
            }

            double outputLength;

            switch(outputUnit)
            {
                case "Kilometr": outputLength=KilometrLength; break;
                case "Metr": outputLength = KilometrLength*1000; break;
                case "Decimetr": outputLength = KilometrLength * 10000; ; break;
                case "Cantimetr": outputLength = KilometrLength * 100000; ; break;
                default: outputLength = 0; break;
            }
            return outputLength;
        }





        public Length()
        {
            InitializeComponent();
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

        private void Length_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLength();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLength();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                guna2TextBox2.Text = " ";
            }

            UpdateLength();
        }

        
        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if((ch==46 && guna2TextBox1.Text.IndexOf(".")!=-1) ||
                (ch==45 && guna2TextBox1.Text.IndexOf("-")!=-1) ||
               (ch==45 && guna2TextBox1.Text.IndexOf(".")!=-1) ||
                (!char.IsDigit(ch)) && ch!=8 && ch!=46 && ch != 45){

                e.Handled = true;
            }
        }
    }
}
