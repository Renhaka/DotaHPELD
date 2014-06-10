namespace DotaHPLED
{
    partial class Form1
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
            this.findProcess = new System.Windows.Forms.Button();
            this.labelHooked = new System.Windows.Forms.Label();
            this.labelHookedVariable = new System.Windows.Forms.Label();
            this.labelPID = new System.Windows.Forms.Label();
            this.labelPIDVariable = new System.Windows.Forms.Label();
            this.hookHealth = new System.Windows.Forms.Button();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelDead = new System.Windows.Forms.Label();
            this.labelRespawn = new System.Windows.Forms.Label();
            this.labelCHVar = new System.Windows.Forms.Label();
            this.labelMHVar = new System.Windows.Forms.Label();
            this.labelDeathVar = new System.Windows.Forms.Label();
            this.labelRTVar = new System.Windows.Forms.Label();
            this.buttonBegin = new System.Windows.Forms.Button();
            this.labelComPort = new System.Windows.Forms.Label();
            this.labelArdStatus = new System.Windows.Forms.Label();
            this.labelComRead = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // findProcess
            // 
            this.findProcess.Location = new System.Drawing.Point(12, 12);
            this.findProcess.Name = "findProcess";
            this.findProcess.Size = new System.Drawing.Size(114, 23);
            this.findProcess.TabIndex = 0;
            this.findProcess.Text = "Find Dota 2 Process";
            this.findProcess.UseVisualStyleBackColor = true;
            this.findProcess.Click += new System.EventHandler(this.findProcess_Click);
            // 
            // labelHooked
            // 
            this.labelHooked.AutoSize = true;
            this.labelHooked.Location = new System.Drawing.Point(165, 17);
            this.labelHooked.Name = "labelHooked";
            this.labelHooked.Size = new System.Drawing.Size(48, 13);
            this.labelHooked.TabIndex = 1;
            this.labelHooked.Text = "Hooked:";
            // 
            // labelHookedVariable
            // 
            this.labelHookedVariable.AutoSize = true;
            this.labelHookedVariable.Location = new System.Drawing.Point(219, 17);
            this.labelHookedVariable.Name = "labelHookedVariable";
            this.labelHookedVariable.Size = new System.Drawing.Size(33, 13);
            this.labelHookedVariable.TabIndex = 2;
            this.labelHookedVariable.Text = "Nope";
            // 
            // labelPID
            // 
            this.labelPID.AutoSize = true;
            this.labelPID.Location = new System.Drawing.Point(185, 42);
            this.labelPID.Name = "labelPID";
            this.labelPID.Size = new System.Drawing.Size(28, 13);
            this.labelPID.TabIndex = 3;
            this.labelPID.Text = "PID:";
            // 
            // labelPIDVariable
            // 
            this.labelPIDVariable.AutoSize = true;
            this.labelPIDVariable.Location = new System.Drawing.Point(219, 42);
            this.labelPIDVariable.Name = "labelPIDVariable";
            this.labelPIDVariable.Size = new System.Drawing.Size(33, 13);
            this.labelPIDVariable.TabIndex = 4;
            this.labelPIDVariable.Text = "None";
            // 
            // hookHealth
            // 
            this.hookHealth.Location = new System.Drawing.Point(12, 42);
            this.hookHealth.Name = "hookHealth";
            this.hookHealth.Size = new System.Drawing.Size(114, 23);
            this.hookHealth.TabIndex = 5;
            this.hookHealth.Text = "Sniff Info";
            this.hookHealth.UseVisualStyleBackColor = true;
            this.hookHealth.Click += new System.EventHandler(this.hookHealth_Click);
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(57, 87);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(78, 13);
            this.labelCurrent.TabIndex = 6;
            this.labelCurrent.Text = "Current Health:";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(71, 113);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(64, 13);
            this.labelMax.TabIndex = 7;
            this.labelMax.Text = "Max Health:";
            // 
            // labelDead
            // 
            this.labelDead.AutoSize = true;
            this.labelDead.Location = new System.Drawing.Point(99, 138);
            this.labelDead.Name = "labelDead";
            this.labelDead.Size = new System.Drawing.Size(36, 13);
            this.labelDead.TabIndex = 8;
            this.labelDead.Text = "Dead:";
            // 
            // labelRespawn
            // 
            this.labelRespawn.AutoSize = true;
            this.labelRespawn.Location = new System.Drawing.Point(54, 164);
            this.labelRespawn.Name = "labelRespawn";
            this.labelRespawn.Size = new System.Drawing.Size(81, 13);
            this.labelRespawn.TabIndex = 9;
            this.labelRespawn.Text = "Respawn Time:";
            // 
            // labelCHVar
            // 
            this.labelCHVar.AutoSize = true;
            this.labelCHVar.Location = new System.Drawing.Point(142, 87);
            this.labelCHVar.Name = "labelCHVar";
            this.labelCHVar.Size = new System.Drawing.Size(60, 13);
            this.labelCHVar.TabIndex = 10;
            this.labelCHVar.Text = "Not Sniffed";
            // 
            // labelMHVar
            // 
            this.labelMHVar.AutoSize = true;
            this.labelMHVar.Location = new System.Drawing.Point(142, 113);
            this.labelMHVar.Name = "labelMHVar";
            this.labelMHVar.Size = new System.Drawing.Size(60, 13);
            this.labelMHVar.TabIndex = 11;
            this.labelMHVar.Text = "Not Sniffed";
            // 
            // labelDeathVar
            // 
            this.labelDeathVar.AutoSize = true;
            this.labelDeathVar.Location = new System.Drawing.Point(142, 138);
            this.labelDeathVar.Name = "labelDeathVar";
            this.labelDeathVar.Size = new System.Drawing.Size(60, 13);
            this.labelDeathVar.TabIndex = 12;
            this.labelDeathVar.Text = "Not Sniffed";
            // 
            // labelRTVar
            // 
            this.labelRTVar.AutoSize = true;
            this.labelRTVar.Location = new System.Drawing.Point(142, 164);
            this.labelRTVar.Name = "labelRTVar";
            this.labelRTVar.Size = new System.Drawing.Size(60, 13);
            this.labelRTVar.TabIndex = 13;
            this.labelRTVar.Text = "Not Sniffed";
            // 
            // buttonBegin
            // 
            this.buttonBegin.Location = new System.Drawing.Point(12, 196);
            this.buttonBegin.Name = "buttonBegin";
            this.buttonBegin.Size = new System.Drawing.Size(96, 23);
            this.buttonBegin.TabIndex = 15;
            this.buttonBegin.Text = "Begin Evaluation";
            this.buttonBegin.UseVisualStyleBackColor = true;
            this.buttonBegin.Click += new System.EventHandler(this.buttonBegin_Click);
            // 
            // labelComPort
            // 
            this.labelComPort.AutoSize = true;
            this.labelComPort.Location = new System.Drawing.Point(114, 201);
            this.labelComPort.Name = "labelComPort";
            this.labelComPort.Size = new System.Drawing.Size(73, 13);
            this.labelComPort.TabIndex = 16;
            this.labelComPort.Text = "Arduino COM:";
            // 
            // labelArdStatus
            // 
            this.labelArdStatus.AutoSize = true;
            this.labelArdStatus.ForeColor = System.Drawing.Color.Red;
            this.labelArdStatus.Location = new System.Drawing.Point(193, 201);
            this.labelArdStatus.Name = "labelArdStatus";
            this.labelArdStatus.Size = new System.Drawing.Size(37, 13);
            this.labelArdStatus.TabIndex = 17;
            this.labelArdStatus.Text = "Offline";
            // 
            // labelComRead
            // 
            this.labelComRead.AutoSize = true;
            this.labelComRead.Location = new System.Drawing.Point(9, 138);
            this.labelComRead.Name = "labelComRead";
            this.labelComRead.Size = new System.Drawing.Size(60, 13);
            this.labelComRead.TabIndex = 18;
            this.labelComRead.Text = "NothingYet";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 230);
            this.Controls.Add(this.labelComRead);
            this.Controls.Add(this.labelArdStatus);
            this.Controls.Add(this.labelComPort);
            this.Controls.Add(this.buttonBegin);
            this.Controls.Add(this.labelRTVar);
            this.Controls.Add(this.labelDeathVar);
            this.Controls.Add(this.labelMHVar);
            this.Controls.Add(this.labelCHVar);
            this.Controls.Add(this.labelRespawn);
            this.Controls.Add(this.labelDead);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.hookHealth);
            this.Controls.Add(this.labelPIDVariable);
            this.Controls.Add(this.labelPID);
            this.Controls.Add(this.labelHookedVariable);
            this.Controls.Add(this.labelHooked);
            this.Controls.Add(this.findProcess);
            this.Name = "Form1";
            this.Text = "Dota 2 HP LED Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findProcess;
        private System.Windows.Forms.Label labelHooked;
        private System.Windows.Forms.Label labelHookedVariable;
        private System.Windows.Forms.Label labelPID;
        private System.Windows.Forms.Label labelPIDVariable;
        private System.Windows.Forms.Button hookHealth;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelDead;
        private System.Windows.Forms.Label labelRespawn;
        private System.Windows.Forms.Label labelCHVar;
        private System.Windows.Forms.Label labelMHVar;
        private System.Windows.Forms.Label labelDeathVar;
        private System.Windows.Forms.Label labelRTVar;
        private System.Windows.Forms.Button buttonBegin;
        private System.Windows.Forms.Label labelComPort;
        private System.Windows.Forms.Label labelArdStatus;
        private System.Windows.Forms.Label labelComRead;
    }
}

