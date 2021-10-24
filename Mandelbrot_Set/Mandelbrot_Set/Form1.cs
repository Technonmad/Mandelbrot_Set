using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_Set
{
    public partial class Form1 : Form
    {
        Mandelbrot mandelbrot;
        public Form1()
        {
            InitializeComponent();
            mandelbrot = new Mandelbrot();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = mandelbrot.Draw(pictureBox1.Width, pictureBox1.Height,
                Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
