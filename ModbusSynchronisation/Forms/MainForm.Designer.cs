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
            this.uxRefresh = new System.Windows.Forms.Button();
            this.uxClose = new System.Windows.Forms.Button();
            this.uxEMFieldValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxGateways
            // 
            this.uxGateways.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxGateways.FormattingEnabled = true;
            this.uxGateways.ItemHeight = 24;
            this.uxGateways.Location = new System.Drawing.Point(12, 36);
            this.uxGateways.Name = "uxGateways";
            this.uxGateways.Size = new System.Drawing.Size(172, 340);
            this.uxGateways.TabIndex = 0;
            this.uxGateways.SelectedIndexChanged += new System.EventHandler(this.uxGateways_SelectedIndexChanged);
            // 
            // uxSensors
            // 
            this.uxSensors.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxSensors.FormattingEnabled = true;
            this.uxSensors.ItemHeight = 24;
            this.uxSensors.Location = new System.Drawing.Point(190, 36);
            this.uxSensors.Name = "uxSensors";
            this.uxSensors.Size = new System.Drawing.Size(172, 340);
            this.uxSensors.TabIndex = 1;
            this.uxSensors.SelectedIndexChanged += new System.EventHandler(this.uxSensors_SelectedIndexChanged);
            // 
            // uxSynchronise
            // 
            this.uxSynchronise.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxSynchronise.Location = new System.Drawing.Point(368, 164);
            this.uxSynchronise.Name = "uxSynchronise";
            this.uxSynchronise.Size = new System.Drawing.Size(173, 67);
            this.uxSynchronise.TabIndex = 2;
            this.uxSynchronise.Text = "Synchronizuj";
            this.uxSynchronise.UseVisualStyleBackColor = true;
            this.uxSynchronise.Click += new System.EventHandler(this.uxSynchronise_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bramki";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(186, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Czujniki";
            // 
            // uxRefresh
            // 
            this.uxRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxRefresh.Location = new System.Drawing.Point(368, 237);
            this.uxRefresh.Name = "uxRefresh";
            this.uxRefresh.Size = new System.Drawing.Size(173, 67);
            this.uxRefresh.TabIndex = 5;
            this.uxRefresh.Text = "Odśwież";
            this.uxRefresh.UseVisualStyleBackColor = true;
            this.uxRefresh.Click += new System.EventHandler(this.uxRefresh_Click);
            // 
            // uxClose
            // 
            this.uxClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxClose.Location = new System.Drawing.Point(368, 309);
            this.uxClose.Name = "uxClose";
            this.uxClose.Size = new System.Drawing.Size(173, 67);
            this.uxClose.TabIndex = 6;
            this.uxClose.Text = "Zamknij";
            this.uxClose.UseVisualStyleBackColor = true;
            this.uxClose.Click += new System.EventHandler(this.uxClose_Click);
            // 
            // uxEMFieldValue
            // 
            this.uxEMFieldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxEMFieldValue.Location = new System.Drawing.Point(368, 36);
            this.uxEMFieldValue.Name = "uxEMFieldValue";
            this.uxEMFieldValue.ReadOnly = true;
            this.uxEMFieldValue.Size = new System.Drawing.Size(173, 29);
            this.uxEMFieldValue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(364, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wartość rejestru";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 384);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxEMFieldValue);
            this.Controls.Add(this.uxClose);
            this.Controls.Add(this.uxRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxSynchronise);
            this.Controls.Add(this.uxSensors);
            this.Controls.Add(this.uxGateways);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Synchronizator czujników";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uxGateways;
        private System.Windows.Forms.ListBox uxSensors;
        private System.Windows.Forms.Button uxSynchronise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uxRefresh;
        private System.Windows.Forms.Button uxClose;
        private System.Windows.Forms.TextBox uxEMFieldValue;
        private System.Windows.Forms.Label label3;

    }
}