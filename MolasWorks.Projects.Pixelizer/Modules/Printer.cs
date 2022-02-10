using MolasWorks.Projects.Pixelizer.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MolasWorks.Projects.Pixelizer.Modules
{
    public class Printer : IPrinter
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Area { get => (Height * Width); }
        public List<Color> Colors { get; set; }

        public Bitmap PrintImage(string printPlan) {
            var image = new Bitmap(Width, Height);
            for (int x = 1; x <= Height; x++)
            {
                for (int y = 1; y <= Height; y++)
                {
                    var nextPixel = printPlan[(x * Width) - (Width - y) - 1];
                    var color = Colors[Convert.ToInt32(Convert.ToString(nextPixel))];
                    image.SetPixel(x - 1, y - 1, color);
                }
            }

            return image;
        }
    }
}
