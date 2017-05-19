/*
    The first time this application is run on a new computer it will create the necassary folders in this applicatons folder
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VINA_BATCH.Startup
{
    class FirstTime
    {

        //Current directory where folders will be created
        private string currDir = Directory.GetCurrentDirectory();

        public FirstTime()
        {
            //Define target folders
            string[] targetDirs = { Path.Combine(currDir, "structures"),
                Path.Combine(currDir, "working"), Path.Combine(currDir, "out") };

            //Create folders
            for(int i = 0; i < targetDirs.Length; i++)
            {
               if(!Directory.Exists(targetDirs[i]))             
                    Directory.CreateDirectory(targetDirs[i]);            
            }
        }
    }
}
