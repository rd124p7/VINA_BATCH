using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace VINA_BATCH.VinaProcess
{
    class VMain : VProcess
    {

        private FFManagement.FolderContentManager fcm = new FFManagement.FolderContentManager();
        private FFManagement.FileContentManager ficm = new FFManagement.FileContentManager();
        public int cpuNum;
        public int exhaust;
        public int num_modes;
        
        public VMain(int cpu, int exhaust, int num_modes)
        {
            cpuNum = cpu;
            this.exhaust = exhaust;
            this.num_modes = num_modes;
            fcm.exhaust = this.exhaust;
            fcm.num_modes = this.num_modes;
        }

        public bool Start(ListBox structList)
        {
            
            int i = 0;
            while(i < structList.Items.Count)
            {
                if(RunSingleProc())
                {
                    i += 1;
                }  
            }

            return true;
        }

        public bool RunSingleProc()
        {
            ficm.isRewriteConf(fcm, exhaust, num_modes);
            fcm.Move_RunRoutine();
            VProcess vp = new VProcess();
            vp.newProc(cpuNum);

            if (vp.isFinished())
            {
                fcm.Move_OutRoutine();
                fcm.e_OnRunEnd();
                return true;
            }

            return false;         
        }
    }
}
