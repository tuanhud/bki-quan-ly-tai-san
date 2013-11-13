using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IP.Core.IPCommon;

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

        private void m_cmd_tro_ve_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(v_e);
            }
        }

    }
}
