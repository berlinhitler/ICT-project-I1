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
    public partial class NewAnnotation : Form
    {
        public string annotationName = "";

        public NewAnnotation()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            annotationName = "";
            this.Close();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            annotationName = newAnnotationNameTextBox.Text;
            this.Close();
        }

        private void newAnnotationNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                annotationName = newAnnotationNameTextBox.Text;
                this.Close();
            }
        }
    }
}
