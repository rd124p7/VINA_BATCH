using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace VINA_BATCH.FFManagement
{
    class FileContentManager
    {

        private static string workingPath = Path.Combine(Directory.GetCurrentDirectory(), "working");
        private static string confPath = Path.Combine(workingPath, "conf.txt");
        private static string logPath = Path.Combine(workingPath, "log.txt");


        public FileContentManager() { }

        public string findProtein()
        {
            string proteinExt = "*.pdbqt";
            string[] workingFiles = Directory.GetFiles(workingPath, proteinExt);

            return Path.GetFileName(workingFiles[0]);
        }

        public string findProteinPath()
        {
            string proteinExt = "*.pdbqt";
            string[] workingFiles = Directory.GetFiles(workingPath, proteinExt);

            return workingFiles[0];
        }

        public string GetWorkingPath()
        {
            return workingPath;
        }

        public string GetConfPath()
        {
            return confPath;
        }

        public string GetLogPath()
        {
            return logPath;
        }


        public bool isRewriteConf(FolderContentManager fcm, int exhaust, int num_modes)
        {
            try
            {
                if (doesConfExisit())
                {

                    //Content list of conf.txt
                    List<string> contents = new List<string>();

                    //Create reading and writing objects
                    using (StreamReader sr = new StreamReader(confPath))
                    {
                        string currentLine;

                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            //Add each line to the contents list
                            if (currentLine != String.Empty)
                                contents.Add(currentLine);
                        }

                       
                        //Parse the contents list and change ligand 
                        for (int i = 0; i < contents.Count; i++)
                        {
                            if (i == 0)
                            {
                                contents[0] = String.Format("receptor = {0}", findProtein());
                            }

                            if (i == 1)
                            {
                                contents[1] = String.Format("ligand = {0}", fcm.GetCurrentStructureName());
                            }

                            if(i == 9)
                            {
                                
                                contents[9] = String.Format("exhaustiveness = {0}", exhaust);
                            }

                            if(i == 10)
                            {
                                
                                contents[10] = String.Format("num_modes = {0}", num_modes);
                            }
                            Console.WriteLine(contents[i].ToString());
                        }
                        

                    }


                    using (StreamWriter sw = new StreamWriter(confPath))
                    {
                        //Write changes to the conf.txt file
                        for (int i = 0; i < contents.Count; i++)
                        {
                            sw.WriteLine(contents[i]);
                        }

                    }

                    return true;                 
                }
                else { return false; }
            }
            catch(IOException e)
            {
                MessageBox.Show("File can not be accessed.\n\n" + e);
            }

            return false;
        }

        public bool doesLogExist()
        {
            return File.Exists(Path.Combine(workingPath, "log.txt"));
        }

        public bool doesConfExisit()
        {
            return File.Exists(Path.Combine(workingPath, "conf.txt"));
        }

    }
}
