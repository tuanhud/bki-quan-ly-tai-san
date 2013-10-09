using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;

public partial class BaoCao_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        load_data();
    }

    private void load_data()
    {
        US_V_DM_NHA us = new US_V_DM_NHA();
        DS_V_DM_NHA ds = new DS_V_DM_NHA();
        us.FillDataset(ds);
    }
}