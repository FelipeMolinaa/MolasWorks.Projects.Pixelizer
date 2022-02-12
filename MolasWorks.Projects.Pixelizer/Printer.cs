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
        public Bitmap PrintImage(IPrintModel printModel) {
            var image = new Bitmap(printModel.Width, printModel.Height);
            for (int y = 0; y < printModel.Height; y++)
            {
                for (int x = 0; x < printModel.Width; x++)
                {
                    var pixel = printModel.PrintPlan[y][x];
                    var color = printModel.Colors[pixel];
                    image.SetPixel(x, y, color);
                }
            }

            return image;
        }
    }
}
