using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot_Set
{
    class Mandelbrot
    {
        Complex z = 0;
        double a, b;

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
            Bitmap bmp = new Bitmap(width, height);

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
    }
}
