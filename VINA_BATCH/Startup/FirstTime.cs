/*
MIT License

Copyright (c) 2017 rd124p7

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

/**
    Class Name: FirstTime
    Constructor: FirstTime
    Inherits: None

    Description:
        If the folders that are required don't exist then create the folders in the same directory as
        VINA_BATCH.exe
**/

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

        /**
            Constructor: FirstTime
            Description:
                If the folders that are required don't exist then create the folders in the same directory as
                VINA_BATCH.exe
            
            Params: None
            Returns: None
        **/
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
