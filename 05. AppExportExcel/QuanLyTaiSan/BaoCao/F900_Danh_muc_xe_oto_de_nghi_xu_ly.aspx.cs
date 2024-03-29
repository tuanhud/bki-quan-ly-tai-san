﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using IP.Core.IPCommon;

public partial class BaoCao_F900_Danh_muc_xe_oto_de_nghi_xu_ly : System.Web.UI.Page
{
    #region Members
    US_DM_OTO m_us_dm_oto = new US_DM_OTO();
    DS_DM_OTO m_ds_dm_oto = new DS_DM_OTO();
    #endregion

    #region Data Structures
    #endregion

    #region Private Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                load_cbo_user_group();
            }
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }
    
    private void load_cbo_user_group()
    {
        try
        {
            US_CM_DM_TU_DIEN us_cm_tu_dien = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
            us_cm_tu_dien.FillDataset(ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN =7");
            m_cbo_trang_thai.DataSource = ds_cm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_trang_thai.DataValueField = CM_DM_LOAI_TD.ID;
            m_cbo_trang_thai.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    
    private void load_data_2_grid() 
    {
        try
        {
            m_us_dm_oto.FillDataset(m_ds_dm_oto, " WHERE ID_TRANG_THAI ="+CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue));
            m_grv_bao_cao_oto.DataSource = m_ds_dm_oto.DM_OTO;
            m_grv_bao_cao_oto.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }

    #endregion

    #region Events
    #endregion
}