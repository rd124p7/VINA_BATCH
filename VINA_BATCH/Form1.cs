using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VINA_BATCH
{
    public partial class frmMain : Form
    {

        FFManagement.FolderContentManager fcm = new FFManagement.FolderContentManager();
        FFManagement.FileContentManager ficm = new FFManagement.FileContentManager();

        //Default Textbox Values
        public const int EXHAUST_DEFAULT = 512;
        public const int NUMMODE_DEFAULT = 20;

        //Insure that we are not trying to use to many cores
        public int CPU_DEFAULT = (int)(Environment.ProcessorCount / 1.5);   

        public frmMain()
        {
            InitializeComponent();
        }

        //On Form Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            //create the folders if they don't exist
            Startup.FirstTime firstRun = new Startup.FirstTime();

            //Set tooltips
            helpToolTips(btnRefresh);
            helpToolTips(btnRun);

            //Populate lstStructures
            populateStructureList();

            //Set textbox defaults
            txtExhaust.Text = EXHAUST_DEFAULT.ToString();
            txtNumModes.Text = NUMMODE_DEFAULT.ToString();
            txtCPU.Text = CPU_DEFAULT.ToString();

            //Worker reports progress
            groundVina.WorkerReportsProgress = true;
        }

        private void helpToolTips(Control ctr)
        {
            if(ctr == btnRefresh)
            {
                ToolTip refreshTip = new ToolTip();
                refreshTip.ToolTipTitle = "Refresh";
                refreshTip.UseFading = true;
                refreshTip.UseAnimation = true;
                refreshTip.IsBalloon = true;
                refreshTip.ShowAlways = true;
                refreshTip.AutoPopDelay = 5000;
                refreshTip.InitialDelay = 1000;
                refreshTip.ReshowDelay = 500;

                //Attach the tooltip with Control(button)
                refreshTip.SetToolTip(btnRefresh, "Pressing refresh will update the list.");
            }

            if(ctr == btnRun)
            {
                ToolTip refreshTip = new ToolTip();
                refreshTip.ToolTipTitle = "Run";
                refreshTip.UseFading = true;
                refreshTip.UseAnimation = true;
                refreshTip.IsBalloon = true;
                refreshTip.ShowAlways = true;
                refreshTip.AutoPopDelay = 5000;
                refreshTip.InitialDelay = 1000;
                refreshTip.ReshowDelay = 500;

                //Attach the tooltip with Control(button)
                refreshTip.SetToolTip(btnRun, "Pressing run will start the running a vina process.");
            }
        }
        
        private void populateStructureList()
        {
           //Populate the listbox with the structures in the folder
            for (int i = 0; i < fcm.GetStructureNames().Length; i++)
                lstStructures.Items.Add(fcm.GetStructureNames()[i]);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to continue?", "Run Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Start background work
                groundVina.RunWorkerAsync();
                this.WindowState = FormWindowState.Minimized;

            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            nVinaBatch.BalloonTipTitle = "Processing";
            nVinaBatch.BalloonTipText = "Vina Batch has started processing.";

            if(FormWindowState.Minimized == this.WindowState)
            {
                nVinaBatch.Visible = true;
                if (!groundVina.IsBusy)
                {
                    nVinaBatch.ShowBalloonTip(500);
                }
                this.Hide();
            }
            else if(FormWindowState.Normal == this.WindowState)
            {
                nVinaBatch.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Force the program to repopulate the list
            lstStructures.Items.Clear();
            populateStructureList();
        }

        private void txtCPU_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (int.Parse(txtCPU.Text) > Environment.ProcessorCount)
                {
                    txtCPU.ForeColor = Color.Red;
                    btnRun.Enabled = false; 
                }
                else
                {
                    txtCPU.ForeColor = Color.Black;
                    btnRun.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //DO NOTHING
            }
            
        }

        private void groundVina_DoWork(object sender, DoWorkEventArgs e)
        {

            VinaProcess.VMain vm = new VinaProcess.VMain(
                Int32.Parse(txtCPU.Text),
                Int32.Parse(txtExhaust.Text),
                Int32.Parse(txtNumModes.Text)
                );

            if (vm.Start(lstStructures))
            {
                nVinaBatch.Visible = true;
                nVinaBatch.BalloonTipTitle = "Done!";
                nVinaBatch.BalloonTipText = "All files have been processed.";
                nVinaBatch.ShowBalloonTip(500);
            }
            else
            {
                nVinaBatch.Visible = false;
            }
           
        }
    }
}
