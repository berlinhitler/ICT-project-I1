using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

namespace GroundTruthing
{
    public partial class AnnotationScreen : Form
    {
        private readonly AnnotationController _annotationController = new AnnotationController();

        public AnnotationScreen()
        {
            InitializeComponent();
        }

        private void setDirectoryButton_Click(object sender, EventArgs e)
        {
            _annotationController.SetWorkingDirectory();
            Image image = _annotationController.PreviouseImage();
            Bitmap bitImage = new Bitmap(image);
            mainImageDisplay.Image = new Image<Bgr, Byte>(bitImage);
            _annotationController.UpdateTreeView(frameInformationTreeView);
        }

        private void previouseImageButton_Click(object sender, EventArgs e)
        {
            Image image = _annotationController.PreviouseImage();
            Bitmap bitImage = new Bitmap(image);
            mainImageDisplay.Image = new Image<Bgr, Byte>(bitImage);
            _annotationController.UpdateTreeView(frameInformationTreeView);
        }

        private void nextImageButton_Click(object sender, EventArgs e)
        {
            Image image = _annotationController.NextImage();
            Bitmap bitImage = new Bitmap(image);
            mainImageDisplay.Image = new Image<Bgr, Byte>(bitImage);
            _annotationController.UpdateTreeView(frameInformationTreeView);
        }

        private void mainImageDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            _annotationController.HandleDisplayMessage(e.X, e.Y, (Control.ModifierKeys & Keys.Shift) != Keys.None,
                mainImageDisplay, zoomedPanel);
        }

        private void addAnnotationButton_Click(object sender, EventArgs e)
        {
            _annotationController.AddAnnotation(annotationObjectListBox);
        }

        private void annotationObjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _annotationController.UpdateSelectedAnnotation(annotationObjectListBox.SelectedItem.ToString());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _annotationController.SaveCurrentCapture();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Image image = _annotationController.LoadCapture(annotationObjectListBox);
            Bitmap bitImage = new Bitmap(image);
            mainImageDisplay.Image = new Image<Bgr, Byte>(bitImage);
        }

        private void clearSingleAnnotationButton_Click(object sender, EventArgs e)
        {
            _annotationController.ClearSelectedAnnotationFromFrame();
        }

        private void exportImagesButton_Click(object sender, EventArgs e)
        {
            _annotationController.ExportImages();
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {

        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {

        }

        private void autoAnnotateButton_Click(object sender, EventArgs e)
        {
            Image image = _annotationController.AutoAnnotate(mainImageDisplay.Image.Bitmap);
            Bitmap bitImage = new Bitmap(image);
            mainImageDisplay.Image = new Image<Bgr, Byte>(bitImage);
        }
    }
}
