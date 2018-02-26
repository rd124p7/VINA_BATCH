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
        private string vinaSource = Path.Combine(Directory.GetCurrentDirectory(), "vina");

        private static string confPath = Path.Combine(workingPath, "conf.txt");
        private static string logPath = Path.Combine(workingPath, "log.txt");

        private string structureExt = ".pdbqt";
        private StructureList structList = new StructureList();

        public Operations(StructureList structList)
        {
            this.structList = structList;
        }

        public string findProtein()
        {
            string proteinExt = "*.pdbqt";
            string[] workingFiles = Directory.GetFiles(workingPath, proteinExt);

            return Path.GetFileName(workingFiles[0]);
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

        public void MoveFiles(string path1, string path2)
        {
            try
            {
                File.Move(path1, path2);
            }
            catch (FileNotFoundException e)
            {
                e.ToString();
            }
        }

        public void CopyFiles(string source, string dest)
        {
            try
            {
                File.Copy(source, dest);
            }
            catch(FileNotFoundException e)
            {
                e.ToString();
            }
        }

        public bool SaveSettings(int exhaust, int num_modes)
        {
            try
            {
                if (File.Exists(confPath))
                {
                    List<string> contents = new List<string>();

                    using (StreamReader sr = new StreamReader(confPath))
                    {
                        string curLine;

                        while ((curLine = sr.ReadLine()) != null)
                        {
                            if (curLine != String.Empty)
                                contents.Add(curLine);
                        }

                        for (int i = 0; i < contents.Count; i++)
                        {
                            if (i == 0)
                                contents[0] = String.Format("receptor = {0}", findProtein());

                            if (i == 1)
                                contents[1] = String.Format("ligand = {0}", structList.GetCurrentInfo().Name);

                            if (i == 9)
                                contents[9] = String.Format("exhaustiveness = {0}", exhaust);

                            if (i == 10)
                                contents[10] = String.Format("num_modes = {0}", num_modes);
                        }
                    }

                    using (StreamWriter sw = new StreamWriter(confPath))
                    {
                        for (int i = 0; i < contents.Count; i++)
                            sw.WriteLine(contents[i]);
                    }

                    return true;
                }
            }
            catch (IOException e)
            {
                // Leave blank for now
            }

            return false;
        }
    }
}
