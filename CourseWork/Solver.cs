using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    class Solver
    {
        public static double Function1(double x, double q)
        {
            return Math.Sqrt(Math.Cos(q * x));
        }
        public static double Function2(double x, double q, double a)
        {
            return q / (Math.Log(a - x));
        }
        public static void Calculate(Label label1, Label label2, TextBox textBox1, TextBox textBox2, double x_min, double x_max, double dx, double a)
        {
            if(x_max < x_min)
            {
                MessageBox.Show("x_max < x_min", "Error");
                return;
            }
            Random rnd = new Random();
            int tbcount1 = 0;
            int tbcount2 = 0;
            for (double i = x_min; i <= x_max; i = Math.Round(i += dx, 15))
            {
                double q = Convert.ToDouble(rnd.Next(-100, 0) / (-100.0));
                if (q <= 0.35)
                {
                    tbcount1++;
                    if (Math.Cos(q * i) < 0)
                    {
                        textBox1.Text += String.Concat("x = ", i, "\tq = ", q, "\tError\tsqrt(-|n|)") + Environment.NewLine;
                    }
                    else
                    {
                        double y = Function1(i, q);
                        textBox1.Text += String.Concat("x = ", i, "\tq = ", q, $"\ty = {y:0.00000000}") + Environment.NewLine;
                    }
                }
                else
                {
                    tbcount2++;
                    if (a - i < 0)
                    {
                        textBox2.Text += String.Concat("x = ", i, "\tq = ", q, "\tError\tln(-|n|)") + Environment.NewLine;
                    }
                    else if (a - i == 0)
                    {
                        textBox2.Text += String.Concat("x = ", i, "\tq = ", q, "\tError\tln(0)") + Environment.NewLine;
                    }
                    else if (Math.Log(a - i) == 0)
                    {
                        textBox2.Text += String.Concat("x = ", i, "\tq = ", q, "\tError\tDivision by zero") + Environment.NewLine;
                    }
                    else
                    {
                        double y = Function2(i, q, a);
                        textBox2.Text += String.Concat("x = ", i, "\tq = ",q, $"\ty = {y:0.00000000}") + Environment.NewLine;
                    }
                }
            }
            label1.Text = Convert.ToString(tbcount1);
            label2.Text = Convert.ToString(tbcount2);
        }
    }
}
