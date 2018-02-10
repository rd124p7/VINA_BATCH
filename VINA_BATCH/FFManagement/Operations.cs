using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VINA_BATCH.FFManagement
{
    class Operations
    {
        private string structuresPath = Path.Combine(Directory.GetCurrentDirectory(), "structures");
        private static string workingPath = Path.Combine(Directory.GetCurrentDirectory(), "working");
        private string structureExt = ".pdbqt";

        public Operations()
        {

        }

        public string FindProteinPath()
        {
            string[] workingFiles = Directory.GetFiles(workingPath, structureExt);
            return workingFiles[0];
        }

        public string[] FindStructuresPath()
        {
            return Directory.GetFiles(structuresPath, structureExt);
        }

    }
}
