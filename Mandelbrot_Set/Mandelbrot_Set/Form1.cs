using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Stopwatch stopwatch = new Stopwatch();
        TimeSpan ts;
        string elapsedTime;
        
        public Form1()
        {
            InitializeComponent();
            mandelbrot = new Mandelbrot();
            mandelbrot.progress = ProgressBar;
            Graphics gr = panel1.CreateGraphics();
        }

        public void ProgressBar(int x)
        {
            Mandelbrot.Progress progress = ProgressBar;
            progressBar1.Value = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*pictureBox1.Image = null;
            stopwatch.Start();
            pictureBox1.Image = mandelbrot.Draw(pictureBox1.Width, pictureBox1.Height,
                Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}", ts.Seconds, ts.Milliseconds);
            label6.Text = elapsedTime;*/

            
            stopwatch.Reset();
            stopwatch.Start();
            mandelbrot.DrawWithTasks(panel1.Width, panel1.Height,
                Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}", ts.Seconds, ts.Milliseconds);
            label7.Text = elapsedTime;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (mandelbrot != null) e.Graphics.DrawImage(mandelbrot.bmp, 0, 0);
        }
    }
}
