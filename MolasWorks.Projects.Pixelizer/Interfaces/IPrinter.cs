using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolasWorks.Projects.Pixelizer.Interfaces
{
    public interface IPrinter
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Area { get; }
        public List<Color> Colors { get; set; }

        public Bitmap PrintImage(string printPlan);
    }
}
