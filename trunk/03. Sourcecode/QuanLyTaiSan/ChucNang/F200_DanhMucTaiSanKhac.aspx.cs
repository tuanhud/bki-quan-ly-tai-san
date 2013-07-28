using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using WebDS;
using IP.Core.IPCommon;
using WebUS;

public partial class Default2 : System.Web.UI.Page
{
    #region Member
    US_DM_TAI_SAN_KHAC m_us_tai_san_khac = new US_DM_TAI_SAN_KHAC();
    DS_DM_TAI_SAN_KHAC m_ds_tai_san_khac = new DS_DM_TAI_SAN_KHAC();
    #endregion
    #region Data Structures
    #endregion
    #region Private Methods
    private void load_data_2_grid()
    {
        try
        {
            m_us_tai_san_khac.FillDataset(m_ds_tai_san_khac);
            m_grv_tai_san_khac.DataSource = m_ds_tai_san_khac.DM_TAI_SAN_KHAC;
            m_grv_tai_san_khac.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!this.IsPostBack)
            {
                load_data_2_grid();
            }

        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }
}