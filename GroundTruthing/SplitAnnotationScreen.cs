using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GroundTruthing
{
    public partial class SplitAnnotationScreen : Form
    {
        private LadyBugAnnotationController lbaControler = new LadyBugAnnotationController();

        public SplitAnnotationScreen()
        {
            InitializeComponent();
        }

        private void importPGRResouceButton_Click(object sender, EventArgs e)
        {
            lbaControler.OpenFile();
        }
    }
}
