namespace GroundTruthing
{
    partial class AnnotationScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnotationScreen));
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainImageDisplayPanel = new System.Windows.Forms.Panel();
            this.mainImageDisplay = new Emgu.CV.UI.ImageBox();
            this.frameDetailsPanle = new System.Windows.Forms.Panel();
            this.mainFrameDisplayGroupBox = new System.Windows.Forms.GroupBox();
            this.frameInformationTreeView = new System.Windows.Forms.TreeView();
            this.annotationPannel = new System.Windows.Forms.Panel();
            this.annotationObjectsLable = new System.Windows.Forms.Label();
            this.addAnnotationButton = new System.Windows.Forms.Button();
            this.annotationObjectListBox = new System.Windows.Forms.ListBox();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearSingleAnnotationButton = new System.Windows.Forms.Button();
            this.zoomedPanel = new System.Windows.Forms.Panel();
            this.IOGroupBox = new System.Windows.Forms.GroupBox();
            this.autoAnnotateButton = new System.Windows.Forms.Button();
            this.exportImagesButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.mainNavigationControlPanel = new System.Windows.Forms.GroupBox();
            this.previouseImageButton = new System.Windows.Forms.Button();
            this.setDirectoryButton = new System.Windows.Forms.Button();
            this.nextImageButton = new System.Windows.Forms.Button();
            this.mainLayoutPanel.SuspendLayout();
            this.mainImageDisplayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImageDisplay)).BeginInit();
            this.frameDetailsPanle.SuspendLayout();
            this.mainFrameDisplayGroupBox.SuspendLayout();
            this.annotationPannel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.IOGroupBox.SuspendLayout();
            this.mainNavigationControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.Controls.Add(this.mainImageDisplayPanel, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.frameDetailsPanle, 1, 1);
            this.mainLayoutPanel.Controls.Add(this.annotationPannel, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.navigationPanel, 1, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(1493, 538);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // mainImageDisplayPanel
            // 
            this.mainImageDisplayPanel.AutoScroll = true;
            this.mainImageDisplayPanel.Controls.Add(this.mainImageDisplay);
            this.mainImageDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainImageDisplayPanel.Location = new System.Drawing.Point(3, 3);
            this.mainImageDisplayPanel.Name = "mainImageDisplayPanel";
            this.mainImageDisplayPanel.Size = new System.Drawing.Size(740, 263);
            this.mainImageDisplayPanel.TabIndex = 11;
            // 
            // mainImageDisplay
            // 
            this.mainImageDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainImageDisplay.Location = new System.Drawing.Point(0, 0);
            this.mainImageDisplay.Name = "mainImageDisplay";
            this.mainImageDisplay.Size = new System.Drawing.Size(740, 263);
            this.mainImageDisplay.TabIndex = 2;
            this.mainImageDisplay.TabStop = false;
            this.mainImageDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainImageDisplay_MouseClick);
            // 
            // frameDetailsPanle
            // 
            this.frameDetailsPanle.Controls.Add(this.mainFrameDisplayGroupBox);
            this.frameDetailsPanle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frameDetailsPanle.Location = new System.Drawing.Point(749, 272);
            this.frameDetailsPanle.Name = "frameDetailsPanle";
            this.frameDetailsPanle.Size = new System.Drawing.Size(741, 263);
            this.frameDetailsPanle.TabIndex = 1;
            // 
            // mainFrameDisplayGroupBox
            // 
            this.mainFrameDisplayGroupBox.Controls.Add(this.frameInformationTreeView);
            this.mainFrameDisplayGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFrameDisplayGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mainFrameDisplayGroupBox.Name = "mainFrameDisplayGroupBox";
            this.mainFrameDisplayGroupBox.Size = new System.Drawing.Size(741, 263);
            this.mainFrameDisplayGroupBox.TabIndex = 5;
            this.mainFrameDisplayGroupBox.TabStop = false;
            this.mainFrameDisplayGroupBox.Text = "Frame Details";
            // 
            // frameInformationTreeView
            // 
            this.frameInformationTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frameInformationTreeView.Location = new System.Drawing.Point(3, 16);
            this.frameInformationTreeView.Name = "frameInformationTreeView";
            this.frameInformationTreeView.Size = new System.Drawing.Size(738, 212);
            this.frameInformationTreeView.TabIndex = 0;
            // 
            // annotationPannel
            // 
            this.annotationPannel.Controls.Add(this.annotationObjectsLable);
            this.annotationPannel.Controls.Add(this.addAnnotationButton);
            this.annotationPannel.Controls.Add(this.annotationObjectListBox);
            this.annotationPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationPannel.Location = new System.Drawing.Point(3, 272);
            this.annotationPannel.Name = "annotationPannel";
            this.annotationPannel.Size = new System.Drawing.Size(740, 263);
            this.annotationPannel.TabIndex = 3;
            // 
            // annotationObjectsLable
            // 
            this.annotationObjectsLable.AutoSize = true;
            this.annotationObjectsLable.Location = new System.Drawing.Point(1, 1);
            this.annotationObjectsLable.Name = "annotationObjectsLable";
            this.annotationObjectsLable.Size = new System.Drawing.Size(97, 13);
            this.annotationObjectsLable.TabIndex = 2;
            this.annotationObjectsLable.Text = "Annotation Objects";
            // 
            // addAnnotationButton
            // 
            this.addAnnotationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAnnotationButton.Location = new System.Drawing.Point(3, 234);
            this.addAnnotationButton.Name = "addAnnotationButton";
            this.addAnnotationButton.Size = new System.Drawing.Size(103, 23);
            this.addAnnotationButton.TabIndex = 1;
            this.addAnnotationButton.Text = "Add Annotation";
            this.addAnnotationButton.UseVisualStyleBackColor = true;
            this.addAnnotationButton.Click += new System.EventHandler(this.addAnnotationButton_Click);
            // 
            // annotationObjectListBox
            // 
            this.annotationObjectListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annotationObjectListBox.FormattingEnabled = true;
            this.annotationObjectListBox.Location = new System.Drawing.Point(3, 16);
            this.annotationObjectListBox.Name = "annotationObjectListBox";
            this.annotationObjectListBox.Size = new System.Drawing.Size(734, 212);
            this.annotationObjectListBox.TabIndex = 0;
            this.annotationObjectListBox.SelectedIndexChanged += new System.EventHandler(this.annotationObjectListBox_SelectedIndexChanged);
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.zoomOutButton);
            this.navigationPanel.Controls.Add(this.zoomInButton);
            this.navigationPanel.Controls.Add(this.groupBox1);
            this.navigationPanel.Controls.Add(this.zoomedPanel);
            this.navigationPanel.Controls.Add(this.IOGroupBox);
            this.navigationPanel.Controls.Add(this.mainNavigationControlPanel);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(749, 3);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(741, 263);
            this.navigationPanel.TabIndex = 4;
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Location = new System.Drawing.Point(134, 215);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(75, 23);
            this.zoomOutButton.TabIndex = 10;
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.Location = new System.Drawing.Point(9, 215);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(75, 23);
            this.zoomInButton.TabIndex = 9;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearSingleAnnotationButton);
            this.groupBox1.Location = new System.Drawing.Point(215, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 51);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Control";
            // 
            // clearSingleAnnotationButton
            // 
            this.clearSingleAnnotationButton.Location = new System.Drawing.Point(6, 19);
            this.clearSingleAnnotationButton.Name = "clearSingleAnnotationButton";
            this.clearSingleAnnotationButton.Size = new System.Drawing.Size(109, 23);
            this.clearSingleAnnotationButton.TabIndex = 0;
            this.clearSingleAnnotationButton.Text = "Clear Single";
            this.clearSingleAnnotationButton.UseVisualStyleBackColor = true;
            this.clearSingleAnnotationButton.Click += new System.EventHandler(this.clearSingleAnnotationButton_Click);
            // 
            // zoomedPanel
            // 
            this.zoomedPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.zoomedPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zoomedPanel.Location = new System.Drawing.Point(9, 9);
            this.zoomedPanel.Name = "zoomedPanel";
            this.zoomedPanel.Size = new System.Drawing.Size(200, 200);
            this.zoomedPanel.TabIndex = 7;
            // 
            // IOGroupBox
            // 
            this.IOGroupBox.Controls.Add(this.autoAnnotateButton);
            this.IOGroupBox.Controls.Add(this.exportImagesButton);
            this.IOGroupBox.Controls.Add(this.loadButton);
            this.IOGroupBox.Controls.Add(this.saveButton);
            this.IOGroupBox.Location = new System.Drawing.Point(215, 99);
            this.IOGroupBox.Name = "IOGroupBox";
            this.IOGroupBox.Size = new System.Drawing.Size(249, 84);
            this.IOGroupBox.TabIndex = 6;
            this.IOGroupBox.TabStop = false;
            this.IOGroupBox.Text = "Annotation IO";
            // 
            // autoAnnotateButton
            // 
            this.autoAnnotateButton.Location = new System.Drawing.Point(6, 48);
            this.autoAnnotateButton.Name = "autoAnnotateButton";
            this.autoAnnotateButton.Size = new System.Drawing.Size(109, 23);
            this.autoAnnotateButton.TabIndex = 3;
            this.autoAnnotateButton.Text = "Auto Annotate";
            this.autoAnnotateButton.UseVisualStyleBackColor = true;
            this.autoAnnotateButton.Click += new System.EventHandler(this.autoAnnotateButton_Click);
            // 
            // exportImagesButton
            // 
            this.exportImagesButton.Location = new System.Drawing.Point(133, 48);
            this.exportImagesButton.Name = "exportImagesButton";
            this.exportImagesButton.Size = new System.Drawing.Size(109, 23);
            this.exportImagesButton.TabIndex = 2;
            this.exportImagesButton.Text = "Export Images";
            this.exportImagesButton.UseVisualStyleBackColor = true;
            this.exportImagesButton.Click += new System.EventHandler(this.exportImagesButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(133, 19);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(109, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load Capture";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(6, 19);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(109, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save Capture";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // mainNavigationControlPanel
            // 
            this.mainNavigationControlPanel.Controls.Add(this.previouseImageButton);
            this.mainNavigationControlPanel.Controls.Add(this.setDirectoryButton);
            this.mainNavigationControlPanel.Controls.Add(this.nextImageButton);
            this.mainNavigationControlPanel.Location = new System.Drawing.Point(215, 9);
            this.mainNavigationControlPanel.Name = "mainNavigationControlPanel";
            this.mainNavigationControlPanel.Size = new System.Drawing.Size(249, 84);
            this.mainNavigationControlPanel.TabIndex = 5;
            this.mainNavigationControlPanel.TabStop = false;
            this.mainNavigationControlPanel.Text = "Navigation";
            // 
            // previouseImageButton
            // 
            this.previouseImageButton.Location = new System.Drawing.Point(6, 19);
            this.previouseImageButton.Name = "previouseImageButton";
            this.previouseImageButton.Size = new System.Drawing.Size(109, 23);
            this.previouseImageButton.TabIndex = 0;
            this.previouseImageButton.Text = "Previouse Image";
            this.previouseImageButton.UseVisualStyleBackColor = true;
            this.previouseImageButton.Click += new System.EventHandler(this.previouseImageButton_Click);
            // 
            // setDirectoryButton
            // 
            this.setDirectoryButton.Location = new System.Drawing.Point(6, 48);
            this.setDirectoryButton.Name = "setDirectoryButton";
            this.setDirectoryButton.Size = new System.Drawing.Size(236, 23);
            this.setDirectoryButton.TabIndex = 2;
            this.setDirectoryButton.Text = "Set Directory";
            this.setDirectoryButton.UseVisualStyleBackColor = true;
            this.setDirectoryButton.Click += new System.EventHandler(this.setDirectoryButton_Click);
            // 
            // nextImageButton
            // 
            this.nextImageButton.Location = new System.Drawing.Point(133, 19);
            this.nextImageButton.Name = "nextImageButton";
            this.nextImageButton.Size = new System.Drawing.Size(109, 23);
            this.nextImageButton.TabIndex = 1;
            this.nextImageButton.Text = "Next Image";
            this.nextImageButton.UseVisualStyleBackColor = true;
            this.nextImageButton.Click += new System.EventHandler(this.nextImageButton_Click);
            // 
            // AnnotationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 538);
            this.Controls.Add(this.mainLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnnotationScreen";
            this.Text = "Ground Truthing Toolkit";
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainImageDisplayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainImageDisplay)).EndInit();
            this.frameDetailsPanle.ResumeLayout(false);
            this.mainFrameDisplayGroupBox.ResumeLayout(false);
            this.annotationPannel.ResumeLayout(false);
            this.annotationPannel.PerformLayout();
            this.navigationPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.IOGroupBox.ResumeLayout(false);
            this.mainNavigationControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Panel frameDetailsPanle;
        private System.Windows.Forms.Panel annotationPannel;
        private System.Windows.Forms.ListBox annotationObjectListBox;
        private System.Windows.Forms.Button addAnnotationButton;
        private System.Windows.Forms.Label annotationObjectsLable;
        private System.Windows.Forms.GroupBox mainFrameDisplayGroupBox;
        private System.Windows.Forms.TreeView frameInformationTreeView;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.GroupBox IOGroupBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox mainNavigationControlPanel;
        private System.Windows.Forms.Button previouseImageButton;
        private System.Windows.Forms.Button setDirectoryButton;
        private System.Windows.Forms.Button nextImageButton;
        private System.Windows.Forms.Panel zoomedPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button clearSingleAnnotationButton;
        private System.Windows.Forms.Button exportImagesButton;
        private System.Windows.Forms.Button zoomOutButton;
        private System.Windows.Forms.Button zoomInButton;
        private System.Windows.Forms.Panel mainImageDisplayPanel;
        private System.Windows.Forms.Button autoAnnotateButton;
        private Emgu.CV.UI.ImageBox mainImageDisplay;
    }
}

