namespace ModbusCommunication
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
            this.uxAvailableSerialPorts = new System.Windows.Forms.ComboBox();
            this.uxConnectionToSerialPortGroup = new System.Windows.Forms.GroupBox();
            this.uxConnectionSerialPortTest = new System.Windows.Forms.Label();
            this.uxReloadAvailableSerialPorts = new System.Windows.Forms.Button();
            this.uxDisconnectSerialPort = new System.Windows.Forms.Button();
            this.uxConnectionSerialPort = new System.Windows.Forms.Button();
            this.uxConnectionToGatewayGroup = new System.Windows.Forms.GroupBox();
            this.uxConnectionGatewayTest = new System.Windows.Forms.Label();
            this.uxConnectionToGateway = new System.Windows.Forms.Button();
            this.uxConsoleLog = new System.Windows.Forms.TreeView();
            this.uxConsoleGroupBox = new System.Windows.Forms.GroupBox();
            this.uxRefreshConsole = new System.Windows.Forms.Button();
            this.uxGetAllRegistersValue = new System.Windows.Forms.Button();
            this.uxGetEMValue = new System.Windows.Forms.Button();
            this.uxGetStateOfSensor = new System.Windows.Forms.Button();
            this.uxActivityStateOfDevices = new System.Windows.Forms.Button();
            this.uxConnectionToSerialPortGroup.SuspendLayout();
            this.uxConnectionToGatewayGroup.SuspendLayout();
            this.uxConsoleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxAvailableSerialPorts
            // 
            this.uxAvailableSerialPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxAvailableSerialPorts.FormattingEnabled = true;
            this.uxAvailableSerialPorts.Location = new System.Drawing.Point(6, 23);
            this.uxAvailableSerialPorts.Name = "uxAvailableSerialPorts";
            this.uxAvailableSerialPorts.Size = new System.Drawing.Size(226, 26);
            this.uxAvailableSerialPorts.TabIndex = 0;
            this.uxAvailableSerialPorts.Text = "Brak dostępnych portów COM";
            // 
            // uxConnectionToSerialPortGroup
            // 
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxConnectionSerialPortTest);
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxReloadAvailableSerialPorts);
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxDisconnectSerialPort);
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxConnectionSerialPort);
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxAvailableSerialPorts);
            this.uxConnectionToSerialPortGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxConnectionToSerialPortGroup.Location = new System.Drawing.Point(12, 12);
            this.uxConnectionToSerialPortGroup.Name = "uxConnectionToSerialPortGroup";
            this.uxConnectionToSerialPortGroup.Size = new System.Drawing.Size(239, 149);
            this.uxConnectionToSerialPortGroup.TabIndex = 2;
            this.uxConnectionToSerialPortGroup.TabStop = false;
            this.uxConnectionToSerialPortGroup.Text = "Połączenie z portem COM";
            // 
            // uxConnectionSerialPortTest
            // 
            this.uxConnectionSerialPortTest.AutoSize = true;
            this.uxConnectionSerialPortTest.ForeColor = System.Drawing.Color.Red;
            this.uxConnectionSerialPortTest.Location = new System.Drawing.Point(3, 85);
            this.uxConnectionSerialPortTest.Name = "uxConnectionSerialPortTest";
            this.uxConnectionSerialPortTest.Size = new System.Drawing.Size(217, 18);
            this.uxConnectionSerialPortTest.TabIndex = 4;
            this.uxConnectionSerialPortTest.Text = "Brak połączenie z portem COM";
            // 
            // uxReloadAvailableSerialPorts
            // 
            this.uxReloadAvailableSerialPorts.Location = new System.Drawing.Point(6, 55);
            this.uxReloadAvailableSerialPorts.Name = "uxReloadAvailableSerialPorts";
            this.uxReloadAvailableSerialPorts.Size = new System.Drawing.Size(226, 27);
            this.uxReloadAvailableSerialPorts.TabIndex = 3;
            this.uxReloadAvailableSerialPorts.Text = "Odśwież";
            this.uxReloadAvailableSerialPorts.UseVisualStyleBackColor = true;
            this.uxReloadAvailableSerialPorts.Click += new System.EventHandler(this.uxReloadAvailableSerialPorts_Click);
            // 
            // uxDisconnectSerialPort
            // 
            this.uxDisconnectSerialPort.Enabled = false;
            this.uxDisconnectSerialPort.Location = new System.Drawing.Point(122, 106);
            this.uxDisconnectSerialPort.Name = "uxDisconnectSerialPort";
            this.uxDisconnectSerialPort.Size = new System.Drawing.Size(110, 37);
            this.uxDisconnectSerialPort.TabIndex = 2;
            this.uxDisconnectSerialPort.Text = "Rozłącz";
            this.uxDisconnectSerialPort.UseVisualStyleBackColor = true;
            this.uxDisconnectSerialPort.Click += new System.EventHandler(this.uxComDisconnect_Click);
            // 
            // uxConnectionSerialPort
            // 
            this.uxConnectionSerialPort.Location = new System.Drawing.Point(6, 106);
            this.uxConnectionSerialPort.Name = "uxConnectionSerialPort";
            this.uxConnectionSerialPort.Size = new System.Drawing.Size(110, 37);
            this.uxConnectionSerialPort.TabIndex = 1;
            this.uxConnectionSerialPort.Text = "Połącz";
            this.uxConnectionSerialPort.UseVisualStyleBackColor = true;
            this.uxConnectionSerialPort.Click += new System.EventHandler(this.uxComConnect_Click);
            // 
            // uxConnectionToGatewayGroup
            // 
            this.uxConnectionToGatewayGroup.Controls.Add(this.uxConnectionGatewayTest);
            this.uxConnectionToGatewayGroup.Controls.Add(this.uxConnectionToGateway);
            this.uxConnectionToGatewayGroup.Enabled = false;
            this.uxConnectionToGatewayGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxConnectionToGatewayGroup.Location = new System.Drawing.Point(12, 167);
            this.uxConnectionToGatewayGroup.Name = "uxConnectionToGatewayGroup";
            this.uxConnectionToGatewayGroup.Size = new System.Drawing.Size(239, 90);
            this.uxConnectionToGatewayGroup.TabIndex = 3;
            this.uxConnectionToGatewayGroup.TabStop = false;
            this.uxConnectionToGatewayGroup.Text = "Połączenie z Gateway";
            // 
            // uxConnectionGatewayTest
            // 
            this.uxConnectionGatewayTest.AutoSize = true;
            this.uxConnectionGatewayTest.ForeColor = System.Drawing.Color.Red;
            this.uxConnectionGatewayTest.Location = new System.Drawing.Point(3, 63);
            this.uxConnectionGatewayTest.Name = "uxConnectionGatewayTest";
            this.uxConnectionGatewayTest.Size = new System.Drawing.Size(184, 18);
            this.uxConnectionGatewayTest.TabIndex = 5;
            this.uxConnectionGatewayTest.Text = "Brak połączenie z gateway";
            // 
            // uxConnectionToGateway
            // 
            this.uxConnectionToGateway.Location = new System.Drawing.Point(6, 23);
            this.uxConnectionToGateway.Name = "uxConnectionToGateway";
            this.uxConnectionToGateway.Size = new System.Drawing.Size(226, 37);
            this.uxConnectionToGateway.TabIndex = 1;
            this.uxConnectionToGateway.Text = "Połącz";
            this.uxConnectionToGateway.UseVisualStyleBackColor = true;
            this.uxConnectionToGateway.Click += new System.EventHandler(this.uxConnectionToGateway_Click);
            // 
            // uxConsoleLog
            // 
            this.uxConsoleLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxConsoleLog.Location = new System.Drawing.Point(6, 23);
            this.uxConsoleLog.Name = "uxConsoleLog";
            this.uxConsoleLog.Size = new System.Drawing.Size(465, 503);
            this.uxConsoleLog.TabIndex = 1;
            // 
            // uxConsoleGroupBox
            // 
            this.uxConsoleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxConsoleGroupBox.Controls.Add(this.uxRefreshConsole);
            this.uxConsoleGroupBox.Controls.Add(this.uxConsoleLog);
            this.uxConsoleGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxConsoleGroupBox.Location = new System.Drawing.Point(692, 12);
            this.uxConsoleGroupBox.Name = "uxConsoleGroupBox";
            this.uxConsoleGroupBox.Size = new System.Drawing.Size(477, 570);
            this.uxConsoleGroupBox.TabIndex = 4;
            this.uxConsoleGroupBox.TabStop = false;
            this.uxConsoleGroupBox.Text = "Konsola";
            // 
            // uxRefreshConsole
            // 
            this.uxRefreshConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxRefreshConsole.Location = new System.Drawing.Point(6, 532);
            this.uxRefreshConsole.Name = "uxRefreshConsole";
            this.uxRefreshConsole.Size = new System.Drawing.Size(123, 32);
            this.uxRefreshConsole.TabIndex = 2;
            this.uxRefreshConsole.Text = "Wyczyść";
            this.uxRefreshConsole.UseVisualStyleBackColor = true;
            this.uxRefreshConsole.Click += new System.EventHandler(this.uxRefreshConsole_Click);
            // 
            // uxGetAllRegistersValue
            // 
            this.uxGetAllRegistersValue.Location = new System.Drawing.Point(12, 263);
            this.uxGetAllRegistersValue.Name = "uxGetAllRegistersValue";
            this.uxGetAllRegistersValue.Size = new System.Drawing.Size(239, 60);
            this.uxGetAllRegistersValue.TabIndex = 5;
            this.uxGetAllRegistersValue.Text = "Podaj wartość wszystkich rejestrów";
            this.uxGetAllRegistersValue.UseVisualStyleBackColor = true;
            this.uxGetAllRegistersValue.Click += new System.EventHandler(this.uxGetAllRegistersValue_Click);
            // 
            // uxGetEMValue
            // 
            this.uxGetEMValue.Location = new System.Drawing.Point(12, 329);
            this.uxGetEMValue.Name = "uxGetEMValue";
            this.uxGetEMValue.Size = new System.Drawing.Size(239, 60);
            this.uxGetEMValue.TabIndex = 6;
            this.uxGetEMValue.Text = "Sprawdź wartośc pola EM";
            this.uxGetEMValue.UseVisualStyleBackColor = true;
            this.uxGetEMValue.Click += new System.EventHandler(this.uxGetEMValue_Click);
            // 
            // uxGetStateOfSensor
            // 
            this.uxGetStateOfSensor.Location = new System.Drawing.Point(12, 395);
            this.uxGetStateOfSensor.Name = "uxGetStateOfSensor";
            this.uxGetStateOfSensor.Size = new System.Drawing.Size(239, 60);
            this.uxGetStateOfSensor.TabIndex = 7;
            this.uxGetStateOfSensor.Text = "Sprawdź stan czujnika";
            this.uxGetStateOfSensor.UseVisualStyleBackColor = true;
            // 
            // uxActivityStateOfDevices
            // 
            this.uxActivityStateOfDevices.Location = new System.Drawing.Point(12, 461);
            this.uxActivityStateOfDevices.Name = "uxActivityStateOfDevices";
            this.uxActivityStateOfDevices.Size = new System.Drawing.Size(239, 60);
            this.uxActivityStateOfDevices.TabIndex = 8;
            this.uxActivityStateOfDevices.Text = "Sprawdz które czujniki są aktywne";
            this.uxActivityStateOfDevices.UseVisualStyleBackColor = true;
            this.uxActivityStateOfDevices.Click += new System.EventHandler(this.uxActivityStateOfDevices_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 594);
            this.Controls.Add(this.uxActivityStateOfDevices);
            this.Controls.Add(this.uxGetStateOfSensor);
            this.Controls.Add(this.uxGetEMValue);
            this.Controls.Add(this.uxGetAllRegistersValue);
            this.Controls.Add(this.uxConsoleGroupBox);
            this.Controls.Add(this.uxConnectionToGatewayGroup);
            this.Controls.Add(this.uxConnectionToSerialPortGroup);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modbus Communication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.uxConnectionToSerialPortGroup.ResumeLayout(false);
            this.uxConnectionToSerialPortGroup.PerformLayout();
            this.uxConnectionToGatewayGroup.ResumeLayout(false);
            this.uxConnectionToGatewayGroup.PerformLayout();
            this.uxConsoleGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox uxAvailableSerialPorts;
        private System.Windows.Forms.GroupBox uxConnectionToSerialPortGroup;
        private System.Windows.Forms.Button uxDisconnectSerialPort;
        private System.Windows.Forms.Button uxConnectionSerialPort;
        private System.Windows.Forms.Button uxReloadAvailableSerialPorts;
        private System.Windows.Forms.Label uxConnectionSerialPortTest;
        private System.Windows.Forms.GroupBox uxConnectionToGatewayGroup;
        private System.Windows.Forms.TreeView uxConsoleLog;
        private System.Windows.Forms.GroupBox uxConsoleGroupBox;
        private System.Windows.Forms.Button uxRefreshConsole;
        private System.Windows.Forms.Button uxConnectionToGateway;
        private System.Windows.Forms.Label uxConnectionGatewayTest;
        private System.Windows.Forms.Button uxGetAllRegistersValue;
        private System.Windows.Forms.Button uxGetEMValue;
        private System.Windows.Forms.Button uxGetStateOfSensor;
        private System.Windows.Forms.Button uxActivityStateOfDevices;
    }
}

