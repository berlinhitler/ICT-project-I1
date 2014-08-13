using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GroundTruthing
{
    public partial class AnnotationScreen : Form
    {
        private AnnotationController annotationController = new AnnotationController();

        public AnnotationScreen()
        {
            InitializeComponent();
        }

        private void setDirectoryButton_Click(object sender, EventArgs e)
        {
            annotationController.SetWorkingDirectory();
            mainImageDisplay.Image = annotationController.PreviouseImage();
            annotationController.UpdateTreeView(frameInformationTreeView);
        }

        private void previouseImageButton_Click(object sender, EventArgs e)
        {
            mainImageDisplay.Image = annotationController.PreviouseImage();
            annotationController.UpdateTreeView(frameInformationTreeView);
        }

        private void nextImageButton_Click(object sender, EventArgs e)
        {
            mainImageDisplay.Image = annotationController.NextImage();
            annotationController.UpdateTreeView(frameInformationTreeView);
        }

        private void mainImageDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) != Keys.None)
            {
                annotationController.HandleDisplayMessage(e.X, e.Y, true, mainImageDisplay, zoomedPanel);
            }

            else
            {
                annotationController.HandleDisplayMessage(e.X, e.Y, false, mainImageDisplay, zoomedPanel);
            }
        }

        private void addAnnotationButton_Click(object sender, EventArgs e)
        {
            annotationController.AddAnnotation(annotationObjectListBox);
        }

        private void annotationObjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            annotationController.UpdateSelectedAnnotation(annotationObjectListBox.SelectedItem.ToString());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            annotationController.SaveCurrentCapture();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            mainImageDisplay.Image = annotationController.LoadCapture(annotationObjectListBox);
        }

        private void clearSingleAnnotationButton_Click(object sender, EventArgs e)
        {
            annotationController.ClearSelectedAnnotationFromFrame();
        }
    }
}
