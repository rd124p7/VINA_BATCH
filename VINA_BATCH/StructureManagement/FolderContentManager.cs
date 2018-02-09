using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VINA_BATCH.FFManagement
{   
    class FolderContentManager : FileContentManager
    {
        public int currIndex = 0;
        public bool filesReady = false;

        public int exhaust;
        public int num_modes;

        private VinaProcess.VProcess vproc = new VinaProcess.VProcess();
        private string structurePath = Path.Combine(Directory.GetCurrentDirectory(), "structures");
        private string structureExt = "*.pdbqt";
        private string vinaSource = Path.Combine(Directory.GetCurrentDirectory(), "vina");


        public FolderContentManager() { }

        //Returns list of structures
        public string[] GetStructuresPath()
        {
            return Directory.GetFiles(structurePath, structureExt);
        }

        
        public string[] GetStructureNames()
        {
            string[] structs = Directory.GetFiles(structurePath, structureExt);

            for(int i = 0; i < structs.Length; i++)
            {
                structs[i] = Path.GetFileName(structs[i]);
            }

            return structs;
        }

        public string GetCurrentStructureName()
        {
            string currStructPath = GetCurrentStructurePath();
            return Path.GetFileName(currStructPath);
        }

        public string GetCurrentStructurePath()
        {
            string currPath = "";
            string[] paths = Directory.GetFiles(structurePath, structureExt);
            for (int i = 0; i < paths.Length; i++)
            {
                if (i == currIndex)
                    currPath = paths[i];
            }

            return currPath;
        }

        public string GetNextStructurePath(int index)
        {
            string[] names = GetStructureNames();
            string[] paths = GetStructuresPath();

            string nextPath = "";

            for (int i = 0; i < names.Length; i++)
            {
                if (i == index)
                    nextPath = paths[index + 1]; 
            }

            return nextPath;
        }

        //Copy current structure to the vina folder
        public void CopyStructure(string dest, bool move)
        {
            string source = GetCurrentStructurePath();
            

            if (move)
            {
                //Move the structure
                File.Move(Path.Combine(vinaSource, GetCurrentStructureName()), Path.Combine(dest, GetCurrentStructureName()));            
            }
            else
            {   
                //Copy the structure    
                File.Copy(source, Path.Combine(dest, GetCurrentStructureName()), true);
            }
        }

        //Copy protein to the vina folder
        public void CopyProtein(string dest, bool move)
        {
            string source = findProteinPath();

            if (move)
            {
                File.Move(Path.Combine(vinaSource, findProtein()), Path.Combine(dest, findProtein()));
            }
            else
            {
                
                File.Copy(source, Path.Combine(dest, findProtein()), true);
            }
        }

        //Copy Changed Conf to the vina folder
        public void CopyConf(string dest, bool move)
        {
            string source = GetConfPath();

            if (move)
            {
                File.Move(Path.Combine(vinaSource, "conf.txt"), Path.Combine(dest, "conf.txt"));
            }
            else
            {
                
                File.Copy(source, Path.Combine(dest, "conf.txt"), true);
            }
        }

        //Copy the blank log file to the vina folder
        public void CopyLog(string dest, bool move)
        {
            string source = GetLogPath();

            if (move)
            {
                File.Move(Path.Combine(vinaSource, "log.txt"), Path.Combine(dest, "log.txt"));
                File.Move(Path.Combine(vinaSource, "out.pdbqt"), Path.Combine(dest, "out.pdbqt"));
            }
            else
            {
                
                File.Copy(source, Path.Combine(dest, "log.txt"), true);
            }
        }

        public bool isREADY()
        {
            return filesReady;
        }
        
        public void Move_RunRoutine()
        {
            /*
                - After conf.txt change copy to vina folder
                - Copy the rest of the working folder file to vina folder
                - Copy the current *.pdbqt file to the vina folder

            --------------------------------------------------------------------------

            */
            string destination = vproc.GetVinaPath();

            if (isRewriteConf(this, this.exhaust, this.num_modes))
            {
                try
                {
                    CopyStructure(destination, false);
                    CopyProtein(destination, false);
                    CopyConf(destination, false);
                    CopyLog(destination, false);
                    filesReady = true;
                }
                catch (IOException e)
                {
                    MessageBox.Show("Some files could not be copied.\n\n" + e);
                }

               
            }
            else
            {
                filesReady = false;
            }

            
        }

        public void Move_OutRoutine()
        {
            /*
                - Once an iteration is done move the contents of the vina folder to out folder with the name of the *.pdbqt file 
            */

            string destination = Path.Combine(Directory.GetCurrentDirectory(), "out");
            string[] structOutFolder = GetCurrentStructureName().Split('.');
            Directory.CreateDirectory(Path.Combine(destination, structOutFolder[0]));

            string finalDestination = Path.Combine(destination, structOutFolder[0]);


            try
            {
                CopyStructure(finalDestination, true);
                CopyProtein(finalDestination, true);
                CopyConf(finalDestination, true);
                CopyLog(finalDestination, true);
            }
            catch(IOException e)
            {
                MessageBox.Show("Some files could not be moved.\n\n" + e);
            }
        }
        

        /*------------------------------        EVENTS      ---------------------------------------*/

        //After the a structure is run increment the currIndex by one
        public void e_OnRunEnd()
        {
            if (currIndex < GetStructureNames().Length)
            {
                try
                {
                    currIndex += 1;
                }
                catch (IndexOutOfRangeException e)
                {
                    //When outside of bounds
                    MessageBox.Show("Reached end of queue.");
                }
            }
        }
    }
}