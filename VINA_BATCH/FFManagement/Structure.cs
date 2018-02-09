using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINA_BATCH.FFManagement
{
    class Structure
    {
        private string path = "";

        public Structure(string path)
        {
            this.path = path;
        }

        public string GetPath()
        {
            return path;
        }

        public string GetName()
        {
            return "";
        }
    }
}
