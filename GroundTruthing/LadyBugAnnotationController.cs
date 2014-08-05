using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GroundTruthing
{
    class LadyBugAnnotationController
    {
        private RawImageStore rawImageStore = null;

        public LadyBugAnnotationController()
        {
        }

        public void OpenFile()
        {
            OpenFileDialog pgrFileDialog = new OpenFileDialog();
            if (pgrFileDialog.ShowDialog() == DialogResult.OK)
            {
                rawImageStore = new RawImageStore(pgrFileDialog.FileName);
                if (rawImageStore.Open())
                {

                }

                else
                {
                }
            }
        }
    }
}
