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
        Complex c;
        int iterations, border;
        public Bitmap bmp;
        double a, b;
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
            
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    a = (double)(x - (width / 2)) / (double)(width / 4);
                    b = (double)(y - (height / 2)) / (double)(height / 4);
                    c = inSet(new Complex(a, b), iterations, border);
                    if (c.Magnitude > border) bmp.SetPixel(x, y, Color.Black);
                    else bmp.SetPixel(x, y, Color.White);
                }
            }

            return bmp;
        }
    }
}
