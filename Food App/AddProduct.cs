using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_App
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateFromatValid())
            {
                DateTime dateTime = GetDateFromatChange();
                System.IO.File.AppendAllText(@"C:\FoodManager\FoodDate.txt",
                    dateTime + Environment.NewLine);

                System.IO.File.AppendAllText(@"C:\FoodManager\FoodName.txt",
                    textBox1.Text + Environment.NewLine);

                label3.Text = "Registered: " + textBox1.Text + " " + textBox2.Text;
            }
            else
                label3.Text = "Failed to register check Date format";
        }
        private bool DateFromatValid()
        {
            return DateTime.TryParse(textBox2.Text, out DateTime result);
        }
        public DateTime GetDateFromatChange()
        {
            char separator = Convert.ToChar(textBox2.Text[textBox2.Text.Length - 5]);
            string[] date = textBox2.Text.Split(separator);
            DateTime dateTime = new DateTime(Convert.ToInt32(date[2]),
                Convert.ToInt32(date[1]),
                Convert.ToInt32(date[0]));
            return dateTime;
        }
    }
}
