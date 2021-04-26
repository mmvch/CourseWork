using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.label9.Text = "0";
            this.label10.Text = "0";
            try
            {
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                this.textBox1.Text = this.textBox1.Text.Replace(",", ".");
                this.textBox2.Text = this.textBox2.Text.Replace(",", ".");
                this.textBox3.Text = this.textBox3.Text.Replace(",", ".");
                this.textBox4.Text = this.textBox4.Text.Replace(",", ".");
                double x_min = Convert.ToDouble(this.textBox1.Text, formatter);
                double x_max = Convert.ToDouble(this.textBox2.Text, formatter);
                double dx = Convert.ToDouble(this.textBox3.Text, formatter);
                double a = Convert.ToDouble(this.textBox4.Text, formatter);
                Solver.Calculate(this.label9, this.label10, this.textBox5, this.textBox6, x_min, x_max, dx, a);
            }
            catch (InvalidProgramException exc)
            {
                MessageBox.Show(exc.Message, "Error");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
            }
        }
    }
}
