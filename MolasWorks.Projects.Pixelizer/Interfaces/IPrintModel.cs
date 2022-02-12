using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolasWorks.Projects.Pixelizer.Interfaces
{
    public interface IPrintModel
    {
        public int Height { get; }
        public int Width { get; }
        public int Area { get; }
        public List<Color> Colors { get; set; }
        public IList<string> PrintPlan { get; set; }
        public string FileName { get; set; }
    }
}
