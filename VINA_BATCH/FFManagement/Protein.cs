using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINA_BATCH.FFManagement
{
    class Protein : Structure
    {
        private string path = "";

        public Protein(string path) : base(path)
        {
            this.path = path;
        }
    }
}
