using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_Set
{
    //распараллелить task ами, они должны считать, но не отрисовывать
    class Mandelbrot
    {
        Complex z = 0;
        double a, b;
        public Bitmap bmp;

        public delegate void Progress(int x);
        public Progress progress;
        public Complex inSet(Complex c, int iterations, int border)
        {
            z = Complex.Zero;

            for(int i = 0; i < iterations; i++)
            {
                z = Complex.Pow(z, 2) + c;
                if (z.Magnitude >= border) break;
            }

            return z;
        }


        public Bitmap Draw(int width, int height, int iterations, int border)
        {
            bmp = new Bitmap(width, height);

            progress(0);
            
            for(int x = 0; x < width; x++)
            {
                progress(x);
                for(int y = 0; y < height; y++)
                {
                    a = (double)(x - (width / 2)) / (double)(width / 4);
                    b = (double)(y - (height / 2)) / (double)(height / 4);
                    Complex c = inSet(new Complex(a, b), iterations, border);
                    if (c.Magnitude > border) bmp.SetPixel(x, y, Color.Black);
                    else bmp.SetPixel(x, y, Color.White);
                }
            }

            progress(999);

            return bmp;
        }

        public Bitmap DrawWithTasks(int width, int height, int iterations, int border)
        {
            bmp = new Bitmap(width, height);
            Task[] tasks = new Task[width - 1];
            //Complex[] complex_array = new Complex[width - 1];

            for(int i = 0; i < width - 1; i++)
            {
                tasks[i] = new Task(new Action(() => { CalculationsTasks(i, width, height, iterations, border); }));
            }
            
            foreach (Task t in tasks)
            {
                t.Start();
                
            }
            
            //foreach (Task t in tasks)
            //{
            //    tb.Text += t;
            //}

            Task.WaitAll(tasks);


            return bmp;
        }

        public void CalculationsTasks(int start, int width, int height, int iterations, int border)
        {
            //for (int x = start; x < end; x++)
            //{
                    for (int y = 0; y < height; y++)
                    {
                        a = (double)(start - (width / 2)) / (double)(width / 4);
                        b = (double)(y - (height / 2)) / (double)(height / 4);
                        Complex c = inSet(new Complex(a, b), iterations, border);
                        if (c.Magnitude > border) bmp.SetPixel(start, y, Color.Black);
                        else bmp.SetPixel(start, y, Color.White);
                //return c;
                        
                    }
            //return 0;
            //}
        }
    }
}
