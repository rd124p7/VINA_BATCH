using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;


namespace VINA_BATCH.VinaProcess
{
    class VProcess
    {
        private static string vinaPath = Path.Combine(Directory.GetCurrentDirectory(), "vina");
        private static string vinaExe = Path.Combine(vinaPath, "vina.exe");
        public bool isReady = true;

        public VProcess()
        {
        }

        public void newProc(int cpu)
        {
            try
            {

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "vina\\vina.exe";
                psi.Arguments = String.Format("--config conf.txt --log log.txt --cpu {0}", cpu);
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.WorkingDirectory = vinaPath;
                psi.RedirectStandardOutput = true;

                var proc = Process.Start(psi);
                
                proc.WaitForExit();

                string output = proc.StandardOutput.ReadToEnd();
                Console.WriteLine(output);

                proc.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Something went terribly wrong.\n\n" + e);
            }
        }

        public string GetVinaPath()
        {
            return vinaPath;
        }

        public void checkID(Process pr)
        {
            MessageBox.Show(pr.Id.ToString());
        }

        public bool isFinished()
        {
            Process[] procName = Process.GetProcessesByName("vina.exe");
            if (procName.Length == 0)
                return true;
            else
                return false;
        }
        

    }
}
