using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCLuster.Program.use.only.files
{
    internal class FilesForProgramUse
    {
        public static void CreatingRequiredFiles()
        {
            Directory.CreateDirectory("/Program Files/BetterCLuster"); //Creates Directory to store all the files
        }
    }
}
