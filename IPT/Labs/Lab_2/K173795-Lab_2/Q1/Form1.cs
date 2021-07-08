using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void multiply_Click(object sender, EventArgs e)
        {
            int first_num, second_num;

            first_num = Int32.Parse(input_1.Text);
            second_num = Int32.Parse(input_2.Text);

            input_result.Text = (first_num * second_num).ToString();
        }

        private void divide_Click(object sender, EventArgs e)
        {
            double first_num, second_num;

            first_num = Double.Parse(input_1.Text);
            second_num = Double.Parse(input_2.Text);
            try
            {
                input_result.Text = (first_num / second_num).ToString("F6");
            }
            catch (DivideByZeroException)
            {
                input_result.Text = "Inf";
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            int first_num, second_num;

            first_num = Int32.Parse(input_1.Text);
            second_num = Int32.Parse(input_2.Text);

            input_result.Text = (first_num + second_num).ToString();

        }

        private void input_1_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(input_1.Text, "[^0-9]"))
            {
                MessageBox.Show("Input Must be numeric");
                input_1.Text = "";
            }
        }

        private void input_2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(input_2.Text, "[^0-9]"))
            {
                MessageBox.Show("Input Must be numeric");
                input_2.Text = "";
            }
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            int first_num, second_num;

            first_num = Int32.Parse(input_1.Text);
            second_num = Int32.Parse(input_2.Text);

            input_result.Text = (first_num - second_num).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
