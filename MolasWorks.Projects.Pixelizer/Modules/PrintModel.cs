﻿using MolasWorks.Projects.Pixelizer.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolasWorks.Projects.Pixelizer.Modules
{
    public class PrintModel : IPrintModel
    {

        public PrintModel(IList<IList<int>> printPlan, List<Color> colors)
        {
            Colors = colors;
            PrintPlan = printPlan;
        }

        public int Height { get => PrintPlan.Count; }
        public int Width { get => PrintPlan[0].Count; }
        public int Area { get => (Height * Width); }
        public List<Color> Colors { get; set; }
        public IList<IList<int>> PrintPlan { get; set; }
    }
}