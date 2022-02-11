using MolasWorks.Projects.Pixelizer.Modules;
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
        public Bitmap PrintImage(IPrintModel printModel);
    }
}
