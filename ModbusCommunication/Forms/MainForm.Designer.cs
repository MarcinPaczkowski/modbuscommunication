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
            this.uxComConnect = new System.Windows.Forms.Button();
            this.uxComDisconnect = new System.Windows.Forms.Button();
            this.uxReloadAvailableSerialPorts = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.uxConnectionTest = new System.Windows.Forms.Label();
            this.uxConnectionToSerialPortGroup.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxConnectionTest);
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxReloadAvailableSerialPorts);
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxComDisconnect);
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxComConnect);
            this.uxConnectionToSerialPortGroup.Controls.Add(this.uxAvailableSerialPorts);
            this.uxConnectionToSerialPortGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxConnectionToSerialPortGroup.Location = new System.Drawing.Point(3, 3);
            this.uxConnectionToSerialPortGroup.Name = "uxConnectionToSerialPortGroup";
            this.uxConnectionToSerialPortGroup.Size = new System.Drawing.Size(239, 149);
            this.uxConnectionToSerialPortGroup.TabIndex = 2;
            this.uxConnectionToSerialPortGroup.TabStop = false;
            this.uxConnectionToSerialPortGroup.Text = "Połączenie z portem COM";
            // 
            // uxComConnect
            // 
            this.uxComConnect.Location = new System.Drawing.Point(6, 106);
            this.uxComConnect.Name = "uxComConnect";
            this.uxComConnect.Size = new System.Drawing.Size(110, 37);
            this.uxComConnect.TabIndex = 1;
            this.uxComConnect.Text = "Połącz";
            this.uxComConnect.UseVisualStyleBackColor = true;
            this.uxComConnect.Click += new System.EventHandler(this.uxComConnect_Click);
            // 
            // uxComDisconnect
            // 
            this.uxComDisconnect.Enabled = false;
            this.uxComDisconnect.Location = new System.Drawing.Point(122, 106);
            this.uxComDisconnect.Name = "uxComDisconnect";
            this.uxComDisconnect.Size = new System.Drawing.Size(110, 37);
            this.uxComDisconnect.TabIndex = 2;
            this.uxComDisconnect.Text = "Rozłącz";
            this.uxComDisconnect.UseVisualStyleBackColor = true;
            this.uxComDisconnect.Click += new System.EventHandler(this.uxComDisconnect_Click);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.uxConnectionToSerialPortGroup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1181, 594);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // uxConnectionTest
            // 
            this.uxConnectionTest.AutoSize = true;
            this.uxConnectionTest.ForeColor = System.Drawing.Color.Red;
            this.uxConnectionTest.Location = new System.Drawing.Point(3, 85);
            this.uxConnectionTest.Name = "uxConnectionTest";
            this.uxConnectionTest.Size = new System.Drawing.Size(217, 18);
            this.uxConnectionTest.TabIndex = 4;
            this.uxConnectionTest.Text = "Brak połączenie z portem COM";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 594);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brak połączenia z gateway...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.uxConnectionToSerialPortGroup.ResumeLayout(false);
            this.uxConnectionToSerialPortGroup.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox uxAvailableSerialPorts;
        private System.Windows.Forms.GroupBox uxConnectionToSerialPortGroup;
        private System.Windows.Forms.Button uxComDisconnect;
        private System.Windows.Forms.Button uxComConnect;
        private System.Windows.Forms.Button uxReloadAvailableSerialPorts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label uxConnectionTest;
    }
}

