using MolasWorks.Projects.Pixelizer.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

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
                    try {
                        var pixelLine = printModel.PrintPlan[y];
                        if (pixelLine == "") continue;
                        var pixel = pixelLine.ToCharArray();

                        var teste = Convert.ToInt32(pixel[x].ToString());
                        var color = printModel.Colors[teste];
                        image.SetPixel(x, y, color);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        throw new Exception("Ocorreu um erro ao imprimir a imagem, revise o input");
                    }
                }
            }

            return image;
        }
    }
}
