using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINA_BATCH_CONSOLE
{
    public class GetOutStream
    {

        List<string> output = new List<string>();

        public void setStream(string stream)
        {
            output.Add(stream);
        }

        public List<string> getStream()
        {
            return output;
        }

    }
}
