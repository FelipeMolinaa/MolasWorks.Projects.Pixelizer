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
            var printer = new Printer();

            var printPlan = new List<IList<int>>() {
                new List<int>(){
                    1,0,0,0,0,0,1
                },
                new List<int>(){
                    1,1,0,0,0,1,1
                },
                new List<int>(){
                    0,1,1,0,1,1,0
                },
                new List<int>(){
                    0,0,1,1,1,0,0
                },
            };

            var colors = new List<Color>() {
                Color.Green,
                Color.White
            };

            var printModel = new PrintModel(printPlan, colors);

            var print = printer.PrintImage(printModel);

            print.Save("imgs/imagemBonita.png", ImageFormat.Png);
        }
    }
}
