namespace GroundTruthing
{
    partial class SplitAnnotationScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplitAnnotationScreen));
            this.cameraThumbnailStrip = new System.Windows.Forms.FlowLayoutPanel();
            this.displayAndControlSplitter = new System.Windows.Forms.SplitContainer();
            this.controlAnnotationSplitter = new System.Windows.Forms.SplitContainer();
            this.importPGRResouceButton = new System.Windows.Forms.Button();
            this.controlGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayAndControlSplitter)).BeginInit();
            this.displayAndControlSplitter.Panel2.SuspendLayout();
            this.displayAndControlSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlAnnotationSplitter)).BeginInit();
            this.controlAnnotationSplitter.Panel2.SuspendLayout();
            this.controlAnnotationSplitter.SuspendLayout();
            this.controlGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraThumbnailStrip
            // 
            this.cameraThumbnailStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cameraThumbnailStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.cameraThumbnailStrip.Location = new System.Drawing.Point(0, 0);
            this.cameraThumbnailStrip.Name = "cameraThumbnailStrip";
            this.cameraThumbnailStrip.Size = new System.Drawing.Size(1362, 79);
            this.cameraThumbnailStrip.TabIndex = 0;
            // 
            // displayAndControlSplitter
            // 
            this.displayAndControlSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayAndControlSplitter.Location = new System.Drawing.Point(0, 79);
            this.displayAndControlSplitter.Name = "displayAndControlSplitter";
            this.displayAndControlSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // displayAndControlSplitter.Panel1
            // 
            this.displayAndControlSplitter.Panel1.BackColor = System.Drawing.SystemColors.Highlight;
            // 
            // displayAndControlSplitter.Panel2
            // 
            this.displayAndControlSplitter.Panel2.BackColor = System.Drawing.Color.Maroon;
            this.displayAndControlSplitter.Panel2.Controls.Add(this.controlAnnotationSplitter);
            this.displayAndControlSplitter.Size = new System.Drawing.Size(1362, 466);
            this.displayAndControlSplitter.SplitterDistance = 319;
            this.displayAndControlSplitter.TabIndex = 1;
            // 
            // controlAnnotationSplitter
            // 
            this.controlAnnotationSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlAnnotationSplitter.Location = new System.Drawing.Point(0, 0);
            this.controlAnnotationSplitter.Name = "controlAnnotationSplitter";
            // 
            // controlAnnotationSplitter.Panel1
            // 
            this.controlAnnotationSplitter.Panel1.BackColor = System.Drawing.Color.BurlyWood;
            // 
            // controlAnnotationSplitter.Panel2
            // 
            this.controlAnnotationSplitter.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.controlAnnotationSplitter.Panel2.Controls.Add(this.controlGroupBox);
            this.controlAnnotationSplitter.Size = new System.Drawing.Size(1362, 143);
            this.controlAnnotationSplitter.SplitterDistance = 664;
            this.controlAnnotationSplitter.TabIndex = 0;
            // 
            // importPGRResouceButton
            // 
            this.importPGRResouceButton.Location = new System.Drawing.Point(6, 19);
            this.importPGRResouceButton.Name = "importPGRResouceButton";
            this.importPGRResouceButton.Size = new System.Drawing.Size(150, 23);
            this.importPGRResouceButton.TabIndex = 0;
            this.importPGRResouceButton.Text = "Import PGR Resource";
            this.importPGRResouceButton.UseVisualStyleBackColor = true;
            this.importPGRResouceButton.Click += new System.EventHandler(this.importPGRResouceButton_Click);
            // 
            // controlGroupBox
            // 
            this.controlGroupBox.Controls.Add(this.importPGRResouceButton);
            this.controlGroupBox.Location = new System.Drawing.Point(3, 3);
            this.controlGroupBox.Name = "controlGroupBox";
            this.controlGroupBox.Size = new System.Drawing.Size(160, 100);
            this.controlGroupBox.TabIndex = 1;
            this.controlGroupBox.TabStop = false;
            this.controlGroupBox.Text = "Image Control";
            // 
            // SplitAnnotationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 545);
            this.Controls.Add(this.displayAndControlSplitter);
            this.Controls.Add(this.cameraThumbnailStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplitAnnotationScreen";
            this.Text = "Ground Truthing Toolkit";
            this.displayAndControlSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.displayAndControlSplitter)).EndInit();
            this.displayAndControlSplitter.ResumeLayout(false);
            this.controlAnnotationSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.controlAnnotationSplitter)).EndInit();
            this.controlAnnotationSplitter.ResumeLayout(false);
            this.controlGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel cameraThumbnailStrip;
        private System.Windows.Forms.SplitContainer displayAndControlSplitter;
        private System.Windows.Forms.SplitContainer controlAnnotationSplitter;
        private System.Windows.Forms.Button importPGRResouceButton;
        private System.Windows.Forms.GroupBox controlGroupBox;
    }
}