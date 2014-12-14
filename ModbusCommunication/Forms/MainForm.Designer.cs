namespace ModbusCommunication.Forms
{
    partial class MainForm
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
            this.uxConsoleLog = new System.Windows.Forms.TreeView();
            this.uxConsoleGroupBox = new System.Windows.Forms.GroupBox();
            this.uxRefreshConsole = new System.Windows.Forms.Button();
            this.uxOperationGroupBox = new System.Windows.Forms.GroupBox();
            this.uxStart = new System.Windows.Forms.Button();
            this.uxStop = new System.Windows.Forms.Button();
            this.uxSerialPortStatus = new System.Windows.Forms.ListBox();
            this.uxSerialPortList = new System.Windows.Forms.ListBox();
            this.uxSettings = new System.Windows.Forms.Button();
            this.uxIsDead24 = new System.Windows.Forms.CheckBox();
            this.uxIsDb = new System.Windows.Forms.CheckBox();
            this.uxIsCOM = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxSerialPortTimer = new System.Windows.Forms.Timer(this.components);
            this.uxAvailableGatewayBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.uxGatewayOperationTimer = new System.Windows.Forms.Timer(this.components);
            this.uxConsoleGroupBox.SuspendLayout();
            this.uxOperationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxConsoleLog
            // 
            this.uxConsoleLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxConsoleLog.BackColor = System.Drawing.Color.Black;
            this.uxConsoleLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxConsoleLog.ForeColor = System.Drawing.Color.LawnGreen;
            this.uxConsoleLog.Location = new System.Drawing.Point(6, 23);
            this.uxConsoleLog.Name = "uxConsoleLog";
            this.uxConsoleLog.Size = new System.Drawing.Size(484, 425);
            this.uxConsoleLog.TabIndex = 1;
            // 
            // uxConsoleGroupBox
            // 
            this.uxConsoleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxConsoleGroupBox.Controls.Add(this.uxRefreshConsole);
            this.uxConsoleGroupBox.Controls.Add(this.uxConsoleLog);
            this.uxConsoleGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxConsoleGroupBox.Location = new System.Drawing.Point(14, 12);
            this.uxConsoleGroupBox.Name = "uxConsoleGroupBox";
            this.uxConsoleGroupBox.Size = new System.Drawing.Size(496, 537);
            this.uxConsoleGroupBox.TabIndex = 4;
            this.uxConsoleGroupBox.TabStop = false;
            this.uxConsoleGroupBox.Text = "Konsola";
            // 
            // uxRefreshConsole
            // 
            this.uxRefreshConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxRefreshConsole.Location = new System.Drawing.Point(6, 454);
            this.uxRefreshConsole.Name = "uxRefreshConsole";
            this.uxRefreshConsole.Size = new System.Drawing.Size(212, 77);
            this.uxRefreshConsole.TabIndex = 2;
            this.uxRefreshConsole.Text = "Wyczyść";
            this.uxRefreshConsole.UseVisualStyleBackColor = true;
            this.uxRefreshConsole.Click += new System.EventHandler(this.uxRefreshConsole_Click);
            // 
            // uxOperationGroupBox
            // 
            this.uxOperationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxOperationGroupBox.Controls.Add(this.uxStart);
            this.uxOperationGroupBox.Controls.Add(this.uxStop);
            this.uxOperationGroupBox.Controls.Add(this.uxSerialPortStatus);
            this.uxOperationGroupBox.Controls.Add(this.uxSerialPortList);
            this.uxOperationGroupBox.Controls.Add(this.uxSettings);
            this.uxOperationGroupBox.Controls.Add(this.uxIsDead24);
            this.uxOperationGroupBox.Controls.Add(this.uxIsDb);
            this.uxOperationGroupBox.Controls.Add(this.uxIsCOM);
            this.uxOperationGroupBox.Controls.Add(this.label1);
            this.uxOperationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxOperationGroupBox.Location = new System.Drawing.Point(521, 12);
            this.uxOperationGroupBox.Name = "uxOperationGroupBox";
            this.uxOperationGroupBox.Size = new System.Drawing.Size(356, 537);
            this.uxOperationGroupBox.TabIndex = 5;
            this.uxOperationGroupBox.TabStop = false;
            this.uxOperationGroupBox.Text = "Operacje";
            // 
            // uxStart
            // 
            this.uxStart.Location = new System.Drawing.Point(6, 23);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(344, 46);
            this.uxStart.TabIndex = 9;
            this.uxStart.Text = "Start aplikacji";
            this.uxStart.UseVisualStyleBackColor = true;
            this.uxStart.Click += new System.EventHandler(this.uxStart_Click);
            // 
            // uxStop
            // 
            this.uxStop.Location = new System.Drawing.Point(6, 75);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(344, 46);
            this.uxStop.TabIndex = 8;
            this.uxStop.Text = "Stop aplikacji";
            this.uxStop.UseVisualStyleBackColor = true;
            // 
            // uxSerialPortStatus
            // 
            this.uxSerialPortStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uxSerialPortStatus.FormattingEnabled = true;
            this.uxSerialPortStatus.ItemHeight = 18;
            this.uxSerialPortStatus.Location = new System.Drawing.Point(124, 156);
            this.uxSerialPortStatus.Name = "uxSerialPortStatus";
            this.uxSerialPortStatus.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.uxSerialPortStatus.Size = new System.Drawing.Size(226, 292);
            this.uxSerialPortStatus.TabIndex = 6;
            // 
            // uxSerialPortList
            // 
            this.uxSerialPortList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uxSerialPortList.FormattingEnabled = true;
            this.uxSerialPortList.ItemHeight = 18;
            this.uxSerialPortList.Location = new System.Drawing.Point(6, 156);
            this.uxSerialPortList.Name = "uxSerialPortList";
            this.uxSerialPortList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.uxSerialPortList.Size = new System.Drawing.Size(115, 292);
            this.uxSerialPortList.TabIndex = 1;
            // 
            // uxSettings
            // 
            this.uxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxSettings.Location = new System.Drawing.Point(124, 454);
            this.uxSettings.Name = "uxSettings";
            this.uxSettings.Size = new System.Drawing.Size(226, 77);
            this.uxSettings.TabIndex = 7;
            this.uxSettings.Text = "Wprowadź zmiany";
            this.uxSettings.UseVisualStyleBackColor = true;
            // 
            // uxIsDead24
            // 
            this.uxIsDead24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxIsDead24.AutoSize = true;
            this.uxIsDead24.Location = new System.Drawing.Point(6, 481);
            this.uxIsDead24.Name = "uxIsDead24";
            this.uxIsDead24.Size = new System.Drawing.Size(78, 22);
            this.uxIsDead24.TabIndex = 5;
            this.uxIsDead24.Text = "Dead24";
            this.uxIsDead24.UseVisualStyleBackColor = true;
            // 
            // uxIsDb
            // 
            this.uxIsDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxIsDb.AutoSize = true;
            this.uxIsDb.Location = new System.Drawing.Point(6, 509);
            this.uxIsDb.Name = "uxIsDb";
            this.uxIsDb.Size = new System.Drawing.Size(112, 22);
            this.uxIsDb.TabIndex = 4;
            this.uxIsDb.Text = "Baza danych";
            this.uxIsDb.UseVisualStyleBackColor = true;
            // 
            // uxIsCOM
            // 
            this.uxIsCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxIsCOM.AutoSize = true;
            this.uxIsCOM.Location = new System.Drawing.Point(6, 453);
            this.uxIsCOM.Name = "uxIsCOM";
            this.uxIsCOM.Size = new System.Drawing.Size(63, 22);
            this.uxIsCOM.TabIndex = 3;
            this.uxIsCOM.Text = "COM";
            this.uxIsCOM.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista dostępnych portów COM";
            // 
            // uxSerialPortTimer
            // 
            this.uxSerialPortTimer.Interval = 5000;
            this.uxSerialPortTimer.Tick += new System.EventHandler(this.uxSerialPortTimer_Tick);
            // 
            // uxAvailableGatewayBackgroundWorker
            // 
            this.uxAvailableGatewayBackgroundWorker.WorkerReportsProgress = true;
            this.uxAvailableGatewayBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uxAvailableGatewayBackgroundWorker_DoWork);
            this.uxAvailableGatewayBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.uxAvailableGatewayBackgroundWorker_ProgressChanged);
            // 
            // uxGatewayOperationTimer
            // 
            this.uxGatewayOperationTimer.Interval = 5000;
            this.uxGatewayOperationTimer.Tick += new System.EventHandler(this.uxGatewayOperationTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.uxOperationGroupBox);
            this.Controls.Add(this.uxConsoleGroupBox);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modbus Communication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.uxConsoleGroupBox.ResumeLayout(false);
            this.uxOperationGroupBox.ResumeLayout(false);
            this.uxOperationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView uxConsoleLog;
        private System.Windows.Forms.GroupBox uxConsoleGroupBox;
        private System.Windows.Forms.Button uxRefreshConsole;
        private System.Windows.Forms.GroupBox uxOperationGroupBox;
        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxSettings;
        private System.Windows.Forms.ListBox uxSerialPortStatus;
        private System.Windows.Forms.CheckBox uxIsDead24;
        private System.Windows.Forms.CheckBox uxIsDb;
        private System.Windows.Forms.CheckBox uxIsCOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox uxSerialPortList;
        private System.Windows.Forms.Timer uxSerialPortTimer;
        private System.ComponentModel.BackgroundWorker uxAvailableGatewayBackgroundWorker;
        private System.Windows.Forms.Timer uxGatewayOperationTimer;
    }
}

