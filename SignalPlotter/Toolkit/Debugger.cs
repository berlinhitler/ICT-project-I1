using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SignalPlotter.Toolkit
{
    class Debugger
    {
        private TextBoxBase baseLoggingObject = null;

        public Debugger(TextBoxBase baseLoggingObject)
        {
            this.baseLoggingObject = baseLoggingObject;
        }

        public void WriteLine(string message)
        {
            this.baseLoggingObject.Text += DateTime.Now + ": " + message + "\n";
        }
    }
}
