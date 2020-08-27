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
            System.IO.File.AppendAllText(@"C:\FoodManager\FoodDate.txt", Convert.ToDateTime(textBox2.Text) + Environment.NewLine);
            System.IO.File.AppendAllText(@"C:\FoodManager\FoodName.txt", textBox1.Text + Environment.NewLine);
            label3.Text = "Registered: " + textBox1.Text + " " + Convert.ToDateTime(textBox2.Text).ToShortDateString();
        }
    }
}
