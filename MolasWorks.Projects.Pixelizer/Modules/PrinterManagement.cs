using MolasWorks.Projects.Pixelizer.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolasWorks.Projects.Pixelizer.Modules
{
    public class PrinterManagement
    {
        private readonly IPrinter _printer;

        public PrinterManagement(IPrinter printer)
        {
            _printer = printer;
        }

        public void StartPrinter() {
            var pastaIndex = 0;
            var limitePorPasta = 10000;

            var maxQTDImgs = Math.Pow(_printer.Colors.Count, _printer.Area);
            //var maxQTDImgs = 16;

            var pixelMap = new string('0', _printer.Area);

            Console.WriteLine($"Gerando imagens de {_printer.Height}x{_printer.Width} de dimenção");
            Console.WriteLine($"Um total de {_printer.Area} pixels por imagem");
            Console.WriteLine($"Será utilizada {_printer.Colors.Count} cores.");
            Console.WriteLine($"Gerando um total de {maxQTDImgs} imagens");

            Console.Write("Deseja Prosseguir?");
            Console.ReadLine();

            Console.WriteLine($"Reiniciando pastas");
            Directory.Delete("./imgs", true);

            var ApplicationStopWatch = new Stopwatch();
            ApplicationStopWatch.Start();
            Directory.CreateDirectory($"./imgs/{pastaIndex}");

            for (int i = 1; i <= maxQTDImgs; i++)
            {
                Console.Write($"\rimprimindo {i}/{maxQTDImgs}");

                var image = _printer.PrintImage(pixelMap);

                pixelMap = Convert.ToString(Convert.ToInt32(pixelMap, _printer.Colors.Count) + 1, _printer.Colors.Count);
                while (pixelMap.Length < _printer.Area)
                {
                    pixelMap = '0' + pixelMap;
                }

                if (i % limitePorPasta == 0)
                {
                    pastaIndex++;
                    Directory.CreateDirectory($"./imgs/{pastaIndex}");
                }

                image.Save($"imgs/{pastaIndex}/{i}.png", ImageFormat.Png);
            }

            ApplicationStopWatch.Stop();
            Console.WriteLine("\nTempo corrido:");
            Console.WriteLine($"{ApplicationStopWatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"{ApplicationStopWatch.ElapsedMilliseconds / 1000}S");
            Console.WriteLine($"{ApplicationStopWatch.ElapsedMilliseconds / 1000 / 60}M");
        }
    }
}
