namespace ModbusSynchronisation.Forms
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
            this.uxGateways = new System.Windows.Forms.ListBox();
            this.uxSensors = new System.Windows.Forms.ListBox();
            this.uxSynchronise = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxClose = new System.Windows.Forms.Button();
            this.uxEMFieldValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uxAllSensorRegisters = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uxAllGatewayRegisters = new System.Windows.Forms.TextBox();
            this.uxStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxGateways
            // 
            this.uxGateways.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uxGateways.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxGateways.FormattingEnabled = true;
            this.uxGateways.ItemHeight = 24;
            this.uxGateways.Location = new System.Drawing.Point(17, 39);
            this.uxGateways.Name = "uxGateways";
            this.uxGateways.Size = new System.Drawing.Size(172, 388);
            this.uxGateways.TabIndex = 0;
            this.uxGateways.SelectedIndexChanged += new System.EventHandler(this.uxGateways_SelectedIndexChanged);
            // 
            // uxSensors
            // 
            this.uxSensors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uxSensors.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxSensors.FormattingEnabled = true;
            this.uxSensors.ItemHeight = 24;
            this.uxSensors.Location = new System.Drawing.Point(195, 39);
            this.uxSensors.Name = "uxSensors";
            this.uxSensors.Size = new System.Drawing.Size(172, 388);
            this.uxSensors.TabIndex = 1;
            this.uxSensors.SelectedIndexChanged += new System.EventHandler(this.uxSensors_SelectedIndexChanged);
            // 
            // uxSynchronise
            // 
            this.uxSynchronise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxSynchronise.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxSynchronise.Location = new System.Drawing.Point(377, 287);
            this.uxSynchronise.Name = "uxSynchronise";
            this.uxSynchronise.Size = new System.Drawing.Size(425, 67);
            this.uxSynchronise.TabIndex = 2;
            this.uxSynchronise.Text = "Synchronizuj";
            this.uxSynchronise.UseVisualStyleBackColor = true;
            this.uxSynchronise.Click += new System.EventHandler(this.uxSynchronise_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bramki";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(191, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Czujniki";
            // 
            // uxClose
            // 
            this.uxClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxClose.Location = new System.Drawing.Point(377, 360);
            this.uxClose.Name = "uxClose";
            this.uxClose.Size = new System.Drawing.Size(425, 67);
            this.uxClose.TabIndex = 6;
            this.uxClose.Text = "Zamknij";
            this.uxClose.UseVisualStyleBackColor = true;
            this.uxClose.Click += new System.EventHandler(this.uxClose_Click);
            // 
            // uxEMFieldValue
            // 
            this.uxEMFieldValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxEMFieldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxEMFieldValue.Location = new System.Drawing.Point(377, 39);
            this.uxEMFieldValue.Name = "uxEMFieldValue";
            this.uxEMFieldValue.ReadOnly = true;
            this.uxEMFieldValue.Size = new System.Drawing.Size(421, 29);
            this.uxEMFieldValue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(373, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wartość 1 rejestru czujnika";
            // 
            // uxAllSensorRegisters
            // 
            this.uxAllSensorRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAllSensorRegisters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxAllSensorRegisters.Location = new System.Drawing.Point(377, 98);
            this.uxAllSensorRegisters.Name = "uxAllSensorRegisters";
            this.uxAllSensorRegisters.ReadOnly = true;
            this.uxAllSensorRegisters.Size = new System.Drawing.Size(421, 29);
            this.uxAllSensorRegisters.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(373, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(329, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Wartości wszystkich rejestrów czujnika";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(373, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(317, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Wartości wszystkich rejestrów bramki";
            // 
            // uxAllGatewayRegisters
            // 
            this.uxAllGatewayRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAllGatewayRegisters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxAllGatewayRegisters.Location = new System.Drawing.Point(377, 157);
            this.uxAllGatewayRegisters.Name = "uxAllGatewayRegisters";
            this.uxAllGatewayRegisters.ReadOnly = true;
            this.uxAllGatewayRegisters.Size = new System.Drawing.Size(421, 29);
            this.uxAllGatewayRegisters.TabIndex = 11;
            // 
            // uxStart
            // 
            this.uxStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxStart.Location = new System.Drawing.Point(377, 214);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(425, 67);
            this.uxStart.TabIndex = 13;
            this.uxStart.Text = "Start";
            this.uxStart.UseVisualStyleBackColor = true;
            this.uxStart.Click += new System.EventHandler(this.uxStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 438);
            this.Controls.Add(this.uxStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.uxAllGatewayRegisters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uxAllSensorRegisters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxEMFieldValue);
            this.Controls.Add(this.uxClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxSynchronise);
            this.Controls.Add(this.uxSensors);
            this.Controls.Add(this.uxGateways);
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(825, 477);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Synchronizator czujników";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uxGateways;
        private System.Windows.Forms.ListBox uxSensors;
        private System.Windows.Forms.Button uxSynchronise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uxClose;
        private System.Windows.Forms.TextBox uxEMFieldValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uxAllSensorRegisters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uxAllGatewayRegisters;
        private System.Windows.Forms.Button uxStart;

    }
}