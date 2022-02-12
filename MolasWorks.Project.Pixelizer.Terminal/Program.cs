using MolasWorks.Projects.Pixelizer.Interfaces;
using MolasWorks.Projects.Pixelizer.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace MolasWorks.Projects.Pixelizer.Terminal
{
    public class Program
    {

        //TODO: Adicionar controle de cores
        //TODO: Ignorar todos os arquivos com prefixo "_"
        //TODO: Refatorar o codigo
        //TODO: Desenvolver um sistema de logs Maneirudo
        //TODO: Desenvolver um meio de prever o tempo que a operação ira durar
        //TODO: Desenvolver um metodo para permitir o usuario escolher entre gerar a imagem proceduralmente ou aleatoriamente
        //TODO: Dar mais controle dos parametros para o usuario
        //TODO: Desenvolver uma interface mais bonita

        public static void Main(string[] args)
        {
            var Plans = GetInputPlans();


            foreach (var plan in Plans) {
                var printer = new Printer();

                try {
                    var print = printer.PrintImage(plan);
                    print.Save($"output/{plan.FileName}.png", ImageFormat.Png);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static List<IPrintModel> GetInputPlans()
        {
            var files = Directory.GetFiles("input/");

            var printPlans = new List<IPrintModel>();
            foreach (var file in files) {

                var FullText = File.ReadAllText($"{file}");

                var lines = FullText.Split("\r\n");

                var colorLines = lines[0];

                var colorsList = colorLines.Split(',');
                var colors = new List<Color>();

                foreach (var color in colorsList) {
                    colors.Add(Color.FromName(color));
                }

                var fileName = file.Substring(file.IndexOf('/') + 1).Replace(".txt", ".png");

                var printModel = new PrintModel(fileName, lines.Skip(1).ToArray(), colors);

                printPlans.Add(printModel);
            }

            return printPlans;
        }
    }
}
