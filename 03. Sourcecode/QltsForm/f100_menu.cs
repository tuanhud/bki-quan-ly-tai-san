using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;


using System.Collections;


using IP.Core.IPCommon;
using IP.Core.IPSystemAdmin;

namespace QltsForm {
    public partial class f100_menu : Form {
        public f100_menu() {
            InitializeComponent();
        }


        #region public Interface
        public void display(ref IPConstants.HowUserWantTo_Exit_MainForm o_exitMode) {
            this.ShowDialog();
            o_exitMode = m_exitMode;
        }

        #endregion
        #region Data Structures

        #endregion

        #region Members

        IPConstants.HowUserWantTo_Exit_MainForm m_exitMode = IPConstants.HowUserWantTo_Exit_MainForm.ExitFromSystem;
        #endregion
    }
}
