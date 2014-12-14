namespace ModbusTest.Forms
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
            this.uxConsole = new System.Windows.Forms.TreeView();
            this.uxOpenConnection = new System.Windows.Forms.Button();
            this.uxRefreshAvailableSerialPorts = new System.Windows.Forms.Button();
            this.uxTestConnection = new System.Windows.Forms.Button();
            this.uxAvaibleSerialPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxGetRegisterValues = new System.Windows.Forms.Button();
            this.uxGetEMValue = new System.Windows.Forms.Button();
            this.uxCalibration = new System.Windows.Forms.Button();
            this.uxCloseConnection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uxGet6601Register = new System.Windows.Forms.Button();
            this.uxConsoleClear = new System.Windows.Forms.Button();
            this.uxRegisterNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxRegisterNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // uxConsole
            // 
            this.uxConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxConsole.BackColor = System.Drawing.SystemColors.Desktop;
            this.uxConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxConsole.ForeColor = System.Drawing.Color.LawnGreen;
            this.uxConsole.Location = new System.Drawing.Point(12, 12);
            this.uxConsole.Name = "uxConsole";
            this.uxConsole.Size = new System.Drawing.Size(716, 553);
            this.uxConsole.TabIndex = 0;
            // 
            // uxOpenConnection
            // 
            this.uxOpenConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxOpenConnection.Location = new System.Drawing.Point(133, 34);
            this.uxOpenConnection.Name = "uxOpenConnection";
            this.uxOpenConnection.Size = new System.Drawing.Size(121, 38);
            this.uxOpenConnection.TabIndex = 1;
            this.uxOpenConnection.Text = "Otwórz połączenie";
            this.uxOpenConnection.UseVisualStyleBackColor = true;
            this.uxOpenConnection.Click += new System.EventHandler(this.uxOpenConnection_Click);
            // 
            // uxRefreshAvailableSerialPorts
            // 
            this.uxRefreshAvailableSerialPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxRefreshAvailableSerialPorts.Location = new System.Drawing.Point(6, 61);
            this.uxRefreshAvailableSerialPorts.Name = "uxRefreshAvailableSerialPorts";
            this.uxRefreshAvailableSerialPorts.Size = new System.Drawing.Size(118, 55);
            this.uxRefreshAvailableSerialPorts.TabIndex = 2;
            this.uxRefreshAvailableSerialPorts.Text = "Odśwież";
            this.uxRefreshAvailableSerialPorts.UseVisualStyleBackColor = true;
            this.uxRefreshAvailableSerialPorts.Click += new System.EventHandler(this.uxRefreshAvailableSerialPorts_Click);
            // 
            // uxTestConnection
            // 
            this.uxTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxTestConnection.Location = new System.Drawing.Point(6, 122);
            this.uxTestConnection.Name = "uxTestConnection";
            this.uxTestConnection.Size = new System.Drawing.Size(244, 54);
            this.uxTestConnection.TabIndex = 3;
            this.uxTestConnection.Text = "Test połączenia";
            this.uxTestConnection.UseVisualStyleBackColor = true;
            this.uxTestConnection.Click += new System.EventHandler(this.uxTestConnection_Click);
            // 
            // uxAvaibleSerialPorts
            // 
            this.uxAvaibleSerialPorts.FormattingEnabled = true;
            this.uxAvaibleSerialPorts.Location = new System.Drawing.Point(6, 34);
            this.uxAvaibleSerialPorts.Name = "uxAvaibleSerialPorts";
            this.uxAvaibleSerialPorts.Size = new System.Drawing.Size(121, 21);
            this.uxAvaibleSerialPorts.TabIndex = 5;
            this.uxAvaibleSerialPorts.Text = "Wybierz port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wybierz port COM";
            // 
            // uxGetRegisterValues
            // 
            this.uxGetRegisterValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxGetRegisterValues.Location = new System.Drawing.Point(6, 182);
            this.uxGetRegisterValues.Name = "uxGetRegisterValues";
            this.uxGetRegisterValues.Size = new System.Drawing.Size(244, 54);
            this.uxGetRegisterValues.TabIndex = 7;
            this.uxGetRegisterValues.Text = "Pobierz wartości rejestrów";
            this.uxGetRegisterValues.UseVisualStyleBackColor = true;
            this.uxGetRegisterValues.Click += new System.EventHandler(this.uxGetRegisterValues_Click);
            // 
            // uxGetEMValue
            // 
            this.uxGetEMValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxGetEMValue.Location = new System.Drawing.Point(6, 242);
            this.uxGetEMValue.Name = "uxGetEMValue";
            this.uxGetEMValue.Size = new System.Drawing.Size(244, 54);
            this.uxGetEMValue.TabIndex = 8;
            this.uxGetEMValue.Text = "Pobierz wartość 1 rejestru";
            this.uxGetEMValue.UseVisualStyleBackColor = true;
            this.uxGetEMValue.Click += new System.EventHandler(this.uxGetEMValue_Click);
            // 
            // uxCalibration
            // 
            this.uxCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxCalibration.Location = new System.Drawing.Point(6, 302);
            this.uxCalibration.Name = "uxCalibration";
            this.uxCalibration.Size = new System.Drawing.Size(244, 54);
            this.uxCalibration.TabIndex = 9;
            this.uxCalibration.Text = "Kalibruj czujnik";
            this.uxCalibration.UseVisualStyleBackColor = true;
            this.uxCalibration.Click += new System.EventHandler(this.uxCalibration_Click);
            // 
            // uxCloseConnection
            // 
            this.uxCloseConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxCloseConnection.Location = new System.Drawing.Point(133, 78);
            this.uxCloseConnection.Name = "uxCloseConnection";
            this.uxCloseConnection.Size = new System.Drawing.Size(121, 38);
            this.uxCloseConnection.TabIndex = 10;
            this.uxCloseConnection.Text = "Zamknij połączenie";
            this.uxCloseConnection.UseVisualStyleBackColor = true;
            this.uxCloseConnection.Click += new System.EventHandler(this.uxCloseConnection_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.uxRegisterNumber);
            this.groupBox1.Controls.Add(this.uxGet6601Register);
            this.groupBox1.Controls.Add(this.uxConsoleClear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.uxCloseConnection);
            this.groupBox1.Controls.Add(this.uxOpenConnection);
            this.groupBox1.Controls.Add(this.uxCalibration);
            this.groupBox1.Controls.Add(this.uxRefreshAvailableSerialPorts);
            this.groupBox1.Controls.Add(this.uxGetEMValue);
            this.groupBox1.Controls.Add(this.uxTestConnection);
            this.groupBox1.Controls.Add(this.uxGetRegisterValues);
            this.groupBox1.Controls.Add(this.uxAvaibleSerialPorts);
            this.groupBox1.Location = new System.Drawing.Point(732, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 552);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operacje";
            // 
            // uxGet6601Register
            // 
            this.uxGet6601Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxGet6601Register.Location = new System.Drawing.Point(6, 432);
            this.uxGet6601Register.Name = "uxGet6601Register";
            this.uxGet6601Register.Size = new System.Drawing.Size(244, 54);
            this.uxGet6601Register.TabIndex = 12;
            this.uxGet6601Register.Text = "Pobierz rejestr 6601";
            this.uxGet6601Register.UseVisualStyleBackColor = true;
            this.uxGet6601Register.Click += new System.EventHandler(this.uxGet6601Register_Click);
            // 
            // uxConsoleClear
            // 
            this.uxConsoleClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxConsoleClear.Location = new System.Drawing.Point(6, 492);
            this.uxConsoleClear.Name = "uxConsoleClear";
            this.uxConsoleClear.Size = new System.Drawing.Size(244, 54);
            this.uxConsoleClear.TabIndex = 11;
            this.uxConsoleClear.Text = "Wyczyść konsole";
            this.uxConsoleClear.UseVisualStyleBackColor = true;
            this.uxConsoleClear.Click += new System.EventHandler(this.uxConsoleClear_Click);
            // 
            // uxRegisterNumber
            // 
            this.uxRegisterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxRegisterNumber.Location = new System.Drawing.Point(6, 395);
            this.uxRegisterNumber.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.uxRegisterNumber.Name = "uxRegisterNumber";
            this.uxRegisterNumber.Size = new System.Drawing.Size(244, 31);
            this.uxRegisterNumber.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(2, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Podaj rejestr:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 576);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uxConsole);
            this.MinimumSize = new System.Drawing.Size(938, 569);
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxRegisterNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView uxConsole;
        private System.Windows.Forms.Button uxOpenConnection;
        private System.Windows.Forms.Button uxRefreshAvailableSerialPorts;
        private System.Windows.Forms.Button uxTestConnection;
        private System.Windows.Forms.ComboBox uxAvaibleSerialPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uxGetRegisterValues;
        private System.Windows.Forms.Button uxGetEMValue;
        private System.Windows.Forms.Button uxCalibration;
        private System.Windows.Forms.Button uxCloseConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uxConsoleClear;
        private System.Windows.Forms.Button uxGet6601Register;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown uxRegisterNumber;
    }
}

