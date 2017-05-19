using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINA_BATCH_CONSOLE
{
    public class Program
    {
        public GetOutStream gos = new GetOutStream();

        public static void Main(string[] args)
        {
           
        }

        public void Start()
        {
            for (int i = 0; i < gos.getStream().Count; i++)
                Console.WriteLine(gos.getStream()[i]);

            Console.ReadLine();
        }
    }
}
