namespace VINA_BATCH
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lstStructures = new System.Windows.Forms.ListBox();
            this.lblStructures = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.nVinaBatch = new System.Windows.Forms.NotifyIcon(this.components);
            this.grpMiscSettings = new System.Windows.Forms.GroupBox();
            this.txtCPU = new System.Windows.Forms.TextBox();
            this.txtNumModes = new System.Windows.Forms.TextBox();
            this.txtExhaust = new System.Windows.Forms.TextBox();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblNumModes = new System.Windows.Forms.Label();
            this.lblExaustiveness = new System.Windows.Forms.Label();
            this.groundVina = new System.ComponentModel.BackgroundWorker();
            this.grpMiscSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstStructures
            // 
            this.lstStructures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstStructures.Enabled = false;
            this.lstStructures.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStructures.FormattingEnabled = true;
            this.lstStructures.ItemHeight = 15;
            this.lstStructures.Location = new System.Drawing.Point(12, 48);
            this.lstStructures.Name = "lstStructures";
            this.lstStructures.Size = new System.Drawing.Size(178, 227);
            this.lstStructures.TabIndex = 0;
            // 
            // lblStructures
            // 
            this.lblStructures.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStructures.Location = new System.Drawing.Point(12, 14);
            this.lblStructures.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.lblStructures.Name = "lblStructures";
            this.lblStructures.Padding = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.lblStructures.Size = new System.Drawing.Size(176, 23);
            this.lblStructures.TabIndex = 1;
            this.lblStructures.Text = "Structure Queue";
            this.lblStructures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(237, 242);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 33);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRun
            // 
            this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(318, 242);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 33);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // nVinaBatch
            // 
            this.nVinaBatch.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nVinaBatch.Icon = ((System.Drawing.Icon)(resources.GetObject("nVinaBatch.Icon")));
            this.nVinaBatch.Text = "Vina Batch";
            this.nVinaBatch.Visible = true;
            this.nVinaBatch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // grpMiscSettings
            // 
            this.grpMiscSettings.Controls.Add(this.txtCPU);
            this.grpMiscSettings.Controls.Add(this.txtNumModes);
            this.grpMiscSettings.Controls.Add(this.txtExhaust);
            this.grpMiscSettings.Controls.Add(this.lblCPU);
            this.grpMiscSettings.Controls.Add(this.lblNumModes);
            this.grpMiscSettings.Controls.Add(this.lblExaustiveness);
            this.grpMiscSettings.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMiscSettings.Location = new System.Drawing.Point(196, 48);
            this.grpMiscSettings.Name = "grpMiscSettings";
            this.grpMiscSettings.Size = new System.Drawing.Size(200, 183);
            this.grpMiscSettings.TabIndex = 4;
            this.grpMiscSettings.TabStop = false;
            this.grpMiscSettings.Text = "Misc Settings";
            // 
            // txtCPU
            // 
            this.txtCPU.Location = new System.Drawing.Point(10, 146);
            this.txtCPU.Name = "txtCPU";
            this.txtCPU.Size = new System.Drawing.Size(184, 22);
            this.txtCPU.TabIndex = 5;
            this.txtCPU.TextChanged += new System.EventHandler(this.txtCPU_TextChanged);
            // 
            // txtNumModes
            // 
            this.txtNumModes.Location = new System.Drawing.Point(10, 93);
            this.txtNumModes.Name = "txtNumModes";
            this.txtNumModes.Size = new System.Drawing.Size(184, 22);
            this.txtNumModes.TabIndex = 4;
            // 
            // txtExhaust
            // 
            this.txtExhaust.Location = new System.Drawing.Point(10, 41);
            this.txtExhaust.Name = "txtExhaust";
            this.txtExhaust.Size = new System.Drawing.Size(184, 22);
            this.txtExhaust.TabIndex = 3;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(7, 128);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(29, 15);
            this.lblCPU.TabIndex = 2;
            this.lblCPU.Text = "CPU";
            // 
            // lblNumModes
            // 
            this.lblNumModes.AutoSize = true;
            this.lblNumModes.Location = new System.Drawing.Point(7, 75);
            this.lblNumModes.Name = "lblNumModes";
            this.lblNumModes.Size = new System.Drawing.Size(80, 15);
            this.lblNumModes.TabIndex = 1;
            this.lblNumModes.Text = "Num_Modes";
            // 
            // lblExaustiveness
            // 
            this.lblExaustiveness.AutoSize = true;
            this.lblExaustiveness.Location = new System.Drawing.Point(7, 22);
            this.lblExaustiveness.Name = "lblExaustiveness";
            this.lblExaustiveness.Size = new System.Drawing.Size(95, 15);
            this.lblExaustiveness.TabIndex = 0;
            this.lblExaustiveness.Text = "Exhaustiveness";
            // 
            // groundVina
            // 
            this.groundVina.DoWork += new System.ComponentModel.DoWorkEventHandler(this.groundVina_DoWork);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 288);
            this.Controls.Add(this.grpMiscSettings);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblStructures);
            this.Controls.Add(this.lstStructures);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Vina Batch";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.grpMiscSettings.ResumeLayout(false);
            this.grpMiscSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstStructures;
        private System.Windows.Forms.Label lblStructures;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.NotifyIcon nVinaBatch;
        private System.Windows.Forms.GroupBox grpMiscSettings;
        private System.Windows.Forms.TextBox txtCPU;
        private System.Windows.Forms.TextBox txtNumModes;
        private System.Windows.Forms.TextBox txtExhaust;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label lblNumModes;
        private System.Windows.Forms.Label lblExaustiveness;
        private System.ComponentModel.BackgroundWorker groundVina;
    }
}

