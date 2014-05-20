namespace SignalPlotter
{
    partial class SignalView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbSSID = new System.Windows.Forms.Label();
            this.lbRSSI = new System.Windows.Forms.Label();
            this.lbDistance = new System.Windows.Forms.Label();
            this.lbRSSIResult = new System.Windows.Forms.Label();
            this.lbDistanceResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbSSID
            // 
            this.lbSSID.AutoSize = true;
            this.lbSSID.Font = new System.Drawing.Font("Moire ExtraBold", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSSID.Location = new System.Drawing.Point(29, 27);
            this.lbSSID.Name = "lbSSID";
            this.lbSSID.Size = new System.Drawing.Size(75, 27);
            this.lbSSID.TabIndex = 0;
            this.lbSSID.Text = "SSID";
            // 
            // lbRSSI
            // 
            this.lbRSSI.AutoSize = true;
            this.lbRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbRSSI.Location = new System.Drawing.Point(69, 73);
            this.lbRSSI.Name = "lbRSSI";
            this.lbRSSI.Size = new System.Drawing.Size(48, 20);
            this.lbRSSI.TabIndex = 1;
            this.lbRSSI.Text = "RSSI";
            // 
            // lbDistance
            // 
            this.lbDistance.AutoSize = true;
            this.lbDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDistance.Location = new System.Drawing.Point(45, 93);
            this.lbDistance.Name = "lbDistance";
            this.lbDistance.Size = new System.Drawing.Size(72, 20);
            this.lbDistance.TabIndex = 2;
            this.lbDistance.Text = "Distance";
            // 
            // lbRSSIResult
            // 
            this.lbRSSIResult.AutoSize = true;
            this.lbRSSIResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbRSSIResult.Location = new System.Drawing.Point(123, 73);
            this.lbRSSIResult.Name = "lbRSSIResult";
            this.lbRSSIResult.Size = new System.Drawing.Size(40, 20);
            this.lbRSSIResult.TabIndex = 3;
            this.lbRSSIResult.Text = "0 db";
            // 
            // lbDistanceResult
            // 
            this.lbDistanceResult.AutoSize = true;
            this.lbDistanceResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbDistanceResult.Location = new System.Drawing.Point(123, 93);
            this.lbDistanceResult.Name = "lbDistanceResult";
            this.lbDistanceResult.Size = new System.Drawing.Size(35, 20);
            this.lbDistanceResult.TabIndex = 4;
            this.lbDistanceResult.Text = "0 m";
            // 
            // SignalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.Controls.Add(this.lbDistanceResult);
            this.Controls.Add(this.lbRSSIResult);
            this.Controls.Add(this.lbDistance);
            this.Controls.Add(this.lbRSSI);
            this.Controls.Add(this.lbSSID);
            this.Name = "SignalView";
            this.Size = new System.Drawing.Size(291, 153);
            this.Load += new System.EventHandler(this.SignalView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSSID;
        private System.Windows.Forms.Label lbRSSI;
        private System.Windows.Forms.Label lbDistance;
        private System.Windows.Forms.Label lbRSSIResult;
        private System.Windows.Forms.Label lbDistanceResult;
    }
}
