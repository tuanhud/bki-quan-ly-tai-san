using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QltsForm
{
    public partial class f1001_About : Form
    {
        public f1001_About()
        {
            InitializeComponent();
        }

        #region Public Interface
        public void display()
        {
            this.ShowDialog();
        }
        #endregion

    }
}
