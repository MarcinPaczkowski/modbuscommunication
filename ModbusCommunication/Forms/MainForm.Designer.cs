﻿namespace ModbusCommunication.Forms
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
            this.uxConsoleLog = new System.Windows.Forms.TreeView();
            this.uxConsoleGroupBox = new System.Windows.Forms.GroupBox();
            this.uxErrorCounter = new System.Windows.Forms.Button();
            this.uxIsProccesing = new System.Windows.Forms.Label();
            this.uxRefreshConsole = new System.Windows.Forms.Button();
            this.uxOperationGroupBox = new System.Windows.Forms.GroupBox();
            this.uxStart = new System.Windows.Forms.Button();
            this.uxStop = new System.Windows.Forms.Button();
            this.uxSerialPortStatus = new System.Windows.Forms.ListBox();
            this.uxSerialPortList = new System.Windows.Forms.ListBox();
            this.uxSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uxSensorBackgroundWorker = new System.ComponentModel.BackgroundWorker();
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
            this.uxConsoleGroupBox.Controls.Add(this.uxErrorCounter);
            this.uxConsoleGroupBox.Controls.Add(this.uxIsProccesing);
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
            // uxErrorCounter
            // 
            this.uxErrorCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxErrorCounter.BackColor = System.Drawing.Color.LimeGreen;
            this.uxErrorCounter.FlatAppearance.BorderSize = 0;
            this.uxErrorCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxErrorCounter.Location = new System.Drawing.Point(450, 454);
            this.uxErrorCounter.Name = "uxErrorCounter";
            this.uxErrorCounter.Size = new System.Drawing.Size(40, 40);
            this.uxErrorCounter.TabIndex = 4;
            this.uxErrorCounter.Text = "OK";
            this.uxErrorCounter.UseVisualStyleBackColor = false;
            this.uxErrorCounter.Click += new System.EventHandler(this.uxErrorCounter_Click);
            // 
            // uxIsProccesing
            // 
            this.uxIsProccesing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxIsProccesing.AutoSize = true;
            this.uxIsProccesing.ForeColor = System.Drawing.Color.Red;
            this.uxIsProccesing.Location = new System.Drawing.Point(275, 513);
            this.uxIsProccesing.Name = "uxIsProccesing";
            this.uxIsProccesing.Size = new System.Drawing.Size(215, 18);
            this.uxIsProccesing.TabIndex = 3;
            this.uxIsProccesing.Text = "Sprawdzanie stanów czujników";
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
            this.uxStop.Enabled = false;
            this.uxStop.Location = new System.Drawing.Point(6, 75);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(344, 46);
            this.uxStop.TabIndex = 8;
            this.uxStop.Text = "Stop aplikacji";
            this.uxStop.UseVisualStyleBackColor = true;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
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
            this.uxSettings.Click += new System.EventHandler(this.uxSettings_Click);
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
            // uxSensorBackgroundWorker
            // 
            this.uxSensorBackgroundWorker.WorkerReportsProgress = true;
            this.uxSensorBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uxSensorBackgroundWorker_DoWork);
            this.uxSensorBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.uxSensorBackgroundWorker_ProgressChanged);
            this.uxSensorBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.uxSensorBackgroundWorker_RunWorkerCompleted);
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
            this.uxConsoleGroupBox.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox uxSerialPortList;
        private System.ComponentModel.BackgroundWorker uxSensorBackgroundWorker;
        private System.Windows.Forms.Label uxIsProccesing;
        private System.Windows.Forms.Button uxErrorCounter;
    }
}

