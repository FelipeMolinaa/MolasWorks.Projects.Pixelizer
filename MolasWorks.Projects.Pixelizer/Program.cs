using MolasWorks.Projects.Pixelizer.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MolasWorks.Projects.Pixelizer
{
    internal class Program
    {
        //TODO: Refatorar o codigo
        //TODO: Desenvolver um sistema de logs Maneirudo
        //TODO: Desenvolver um meio de prever o tempo que a operação ira durar
        //TODO: Desenvolver um metodo para permitir o usuario escolher entre gerar a imagem proceduralmente ou aleatoriamente
        //TODO: Dar mais controle dos parametros para o usuario
        //TODO: Desenvolver uma interface mais bonita

        static void Main(string[] args)
        {
            var printer = new Printer()
            {
                Height = 2,
                Width = 2,
                Colors = new List<Color>() {
                    Color.Red,
                    Color.Blue,
                },
            };

            var printerManagement = new PrinterManagement(printer);

            printerManagement.StartPrinter();

            //printer.PrintImage();

        }
    }
}
